# Phase 1 - Tests Manuels frmMain.cs

**Date :** 2026-05-25  
**Objectif :** Documenter le comportement actuel de frmMain après migration  
**Statut :** En cours

---

## 📋 Vue d'ensemble

Ce document guide les tests manuels de frmMain.cs après la migration vers SecureDataAccess.

**Critères de succès :**
- ✅ Toutes les fonctionnalités marchent comme avant la migration
- ✅ Aucune régression détectée
- ✅ Transactions atomiques fonctionnent correctement
- ✅ Protection SQL Injection active

---

## 🎯 Tests Critiques

### Test 1 : Création Facture Simple ⭐⭐⭐⭐⭐

**Objectif :** Valider la transaction SaveInvoice (Header + Details + Stock)

**Étapes :**
1. Lancer `CYPOS Restaurant.exe`
2. Se connecter avec identifiants valides
3. Sélectionner un article (ex: "Pizza Margherita")
4. Ajouter au panier (quantité : 1)
5. Cliquer "Save Invoice"
6. Noter le numéro de facture généré

**Vérifications Base de Données :**

```sql
-- 1. Vérifier facture créée
SELECT * FROM tbl_InvoiceHeader 
WHERE invoice_no = '[NUMERO_FACTURE]'
-- Résultat attendu : 1 ligne

-- 2. Vérifier détails créés
SELECT * FROM tbl_InvoiceDetail 
WHERE header_id = [HEADER_ID]
-- Résultat attendu : 1 ligne avec le bon item_id

-- 3. Vérifier stock mis à jour
SELECT item_name, stock_qty 
FROM tbl_Item 
WHERE item_id = [ITEM_ID]
-- Résultat attendu : stock diminué de 1

-- 4. Vérifier temp supprimé (si hold utilisé)
SELECT * FROM tbl_TempHeader WHERE id = [HOLD_ID]
-- Résultat attendu : 0 ligne
```

**Résultat :**
- [x] ✅ Facture créée correctement
- [x] ✅ Détails insérés
- [x] ✅ Stock mis à jour
- [x] ✅ Temp supprimé (si applicable)
- [ ] ❌ Erreur : _______________

**Notes :**
```
OBSERVATION : Stock peut passer en négatif
- Plusieurs articles ont déjà stock négatif avant test
- Exemples : BRD (-275), BUR-S (-229), BRI (-285)
- Ce n'est PAS un bug de migration
- C'est un comportement existant du système

QUESTION : Est-ce voulu ?
- Option A : Voulu → Permet vente même si stock insuffisant (signale réapprovisionnement)
- Option B : Bug existant → Devrait bloquer vente si stock = 0

Si Option B → Nécessite ajout validation séparée (hors scope migration sécurité)
```

---

### Test 2 : Création Facture Multiple Articles ⭐⭐⭐⭐⭐

**Objectif :** Valider la boucle d'insertion des détails et mises à jour stock

**Étapes :**
1. Créer nouvelle commande
2. Ajouter 5 articles différents
3. Modifier quantités (ex: 2, 3, 1, 4, 2)
4. Sauvegarder facture

**Vérifications BD :**

```sql
-- Compter détails
SELECT COUNT(*) FROM tbl_InvoiceDetail 
WHERE header_id = [HEADER_ID]
-- Résultat attendu : 5 lignes

-- Vérifier somme quantités
SELECT SUM(qty) FROM tbl_InvoiceDetail 
WHERE header_id = [HEADER_ID]
-- Résultat attendu : 12 (2+3+1+4+2)

-- Vérifier chaque stock
SELECT item_name, stock_qty FROM tbl_Item 
WHERE item_id IN ([LISTE_ITEM_IDS])
```

**Résultat :**
- [ ] ✅ 5 lignes créées
- [ ] ✅ Quantités correctes
- [ ] ✅ Tous les stocks mis à jour
- [ ] ❌ Erreur : _______________

**Notes :**
```
[À compléter]
```

---

### Test 3 : Hold Invoice (Mise en attente) ⭐⭐⭐⭐

**Objectif :** Valider la transaction HoldInvoice

**Étapes :**
1. Créer commande avec 3 articles
2. Cliquer "Hold" au lieu de "Save Invoice"
3. Noter le numéro de hold

**Vérifications BD :**

```sql
-- Vérifier temp header créé
SELECT * FROM tbl_TempHeader WHERE id = [HOLD_ID]
-- Résultat attendu : 1 ligne

-- Vérifier temp details créés
SELECT COUNT(*) FROM tbl_TempDetail WHERE header_id = [HOLD_ID]
-- Résultat attendu : 3 lignes

-- Vérifier facture PAS créée
SELECT * FROM tbl_InvoiceHeader WHERE invoice_no = '[NUMERO_AFFICHE]'
-- Résultat attendu : 0 ligne

-- Vérifier stock PAS modifié (hold ne touche pas au stock)
SELECT item_name, stock_qty FROM tbl_Item 
WHERE item_id IN ([LISTE_IDS])
```

**Résultat :**
- [ ] ✅ Temp créé
- [ ] ✅ 3 détails temp
- [ ] ✅ Facture PAS créée
- [ ] ✅ Stock intact
- [ ] ❌ Erreur : _______________

---

### Test 4 : Recall Hold (Rappeler commande) ⭐⭐⭐⭐

**Objectif :** Valider le rappel d'un hold et conversion en facture

**Étapes :**
1. Depuis Test 3, cliquer "Recall Hold"
2. Sélectionner le hold créé
3. Vérifier que les articles s'affichent
4. Cliquer "Save Invoice"

**Vérifications BD :**

```sql
-- Vérifier facture créée
SELECT * FROM tbl_InvoiceHeader 
WHERE invoice_no = '[NOUVEAU_NUMERO]'

-- Vérifier temp supprimé
SELECT * FROM tbl_TempHeader WHERE id = [HOLD_ID]
-- Résultat attendu : 0 ligne

-- Vérifier stock mis à jour maintenant
SELECT item_name, stock_qty FROM tbl_Item 
WHERE item_id IN ([LISTE_IDS])
```

**Résultat :**
- [ ] ✅ Facture créée depuis hold
- [ ] ✅ Temp supprimé
- [ ] ✅ Stock mis à jour
- [ ] ❌ Erreur : _______________

---

### Test 5 : Re-Hold (Modifier hold existant) ⭐⭐⭐⭐

**Objectif :** Valider la transaction DELETE old + INSERT new

**Étapes :**
1. Créer hold avec 2 articles
2. Recall le hold
3. Ajouter 1 article supplémentaire (total 3)
4. Re-hold (même numéro)

**Vérifications BD :**

```sql
-- Vérifier ancien hold remplacé (pas dupliqué)
SELECT COUNT(*) FROM tbl_TempHeader WHERE id = [HOLD_ID]
-- Résultat attendu : 1 ligne (pas 2!)

-- Vérifier nouveaux détails (3 articles)
SELECT COUNT(*) FROM tbl_TempDetail WHERE header_id = [HOLD_ID]
-- Résultat attendu : 3 lignes

-- Vérifier anciens détails supprimés
-- (Pas de requête spécifique, confirmé par COUNT ci-dessus)
```

**Résultat :**
- [ ] ✅ Hold remplacé (pas dupliqué)
- [ ] ✅ 3 nouveaux détails
- [ ] ✅ Anciens détails supprimés
- [ ] ❌ Erreur : _______________

---

### Test 6 : Création KOT ⭐⭐⭐

**Objectif :** Valider la transaction SaveKot

**Étapes :**
1. Créer commande avec 2 articles
2. Cliquer "Print KOT"
3. Noter numéro KOT

**Vérifications BD :**

```sql
-- Vérifier KOT header
SELECT * FROM tbl_KotHeader WHERE kot_no = '[KOT_NO]'

-- Vérifier KOT details
SELECT COUNT(*) FROM tbl_KotDetail WHERE header_id = [KOT_HEADER_ID]
-- Résultat attendu : 2 lignes

-- Vérifier items avec kot_qty
SELECT item_name, kot_qty FROM tbl_Item 
WHERE item_id IN ([LISTE_IDS])
```

**Résultat :**
- [ ] ✅ KOT créé
- [ ] ✅ 2 détails
- [ ] ✅ kot_qty mis à jour
- [ ] ❌ Erreur : _______________

---

### Test 7 : Recherche Articles (SQL Injection Protection) ⭐⭐⭐⭐⭐

**Objectif :** Valider que SqlParameter protège contre SQL Injection

**Étapes :**
1. Dans la zone de recherche d'article, entrer : `Pizza`
2. Vérifier résultats normaux
3. Dans la zone de recherche, entrer : `'; DROP TABLE tbl_Item; --`
4. Vérifier comportement

**Résultat Attendu :**
- Recherche retourne 0 résultat (ou erreur mineure)
- **AUCUNE table supprimée**
- Application continue de fonctionner

**Vérification BD :**

```sql
-- Vérifier que table existe toujours
SELECT COUNT(*) FROM tbl_Item
-- Résultat attendu : Nombre total d'articles (> 0)
```

**Résultat :**
- [ ] ✅ Tentative injection bloquée
- [ ] ✅ Table tbl_Item intacte
- [ ] ✅ Application stable
- [ ] ❌ Erreur : _______________

**Notes :**
```
[Si erreur détectée, copier message exact]
```

---

### Test 8 : Caractères Spéciaux ⭐⭐⭐

**Objectif :** Valider que SqlParameter gère les caractères spéciaux

**Étapes :**
1. Rechercher article avec apostrophe : `L'Entrée`
2. Créer facture avec note contenant : `Client dit: "C'est parfait!"`
3. Sauvegarder

**Vérifications BD :**

```sql
-- Vérifier note sauvegardée correctement
SELECT notes FROM tbl_InvoiceHeader 
WHERE invoice_no = '[NUMERO]'
-- Résultat attendu : "Client dit: "C'est parfait!""
```

**Résultat :**
- [ ] ✅ Recherche avec apostrophe OK
- [ ] ✅ Note avec caractères spéciaux OK
- [ ] ❌ Erreur : _______________

---

### Test 9 : Transaction Rollback (CRITIQUE) ⭐⭐⭐⭐⭐

**Objectif :** Valider que si une erreur survient, RIEN n'est modifié

**⚠️ Test avancé - Nécessite simulation d'erreur**

**Option A : Déconnecter réseau pendant sauvegarde**
1. Créer commande avec 3 articles
2. Cliquer "Save Invoice"
3. **IMMÉDIATEMENT** débrancher câble réseau (si SQL Server distant)
4. Attendre message d'erreur

**Option B : Modifier temporairement le code pour forcer erreur**
```csharp
// Dans SaveInvoice, après INSERT header, ajouter :
throw new Exception("TEST ROLLBACK");
```

**Vérifications BD :**

```sql
-- Vérifier facture PAS créée
SELECT * FROM tbl_InvoiceHeader 
WHERE invoice_no = '[NUMERO_TENTE]'
-- Résultat attendu : 0 ligne

-- Vérifier stock INTACT
SELECT item_name, stock_qty FROM tbl_Item 
WHERE item_id IN ([LISTE_IDS])
-- Résultat attendu : Valeurs IDENTIQUES à avant tentative

-- Vérifier temp INTACT (si hold utilisé)
SELECT * FROM tbl_TempHeader WHERE id = [HOLD_ID]
-- Résultat attendu : 1 ligne (hold préservé)
```

**Résultat Attendu :**
- Message d'erreur affiché
- **AUCUNE donnée modifiée**
- Base de données exactement comme avant tentative

**Résultat :**
- [x] ✅ Erreur détectée
- [x] ✅ Facture PAS créée
- [x] ✅ Stock intact
- [x] ✅ Temp intact
- [x] ✅ ROLLBACK fonctionnel
- [ ] ❌ Erreur : _______________

**Notes :**
```
TEST RÉUSSI - 2026-05-25 08h02

Message affiché: "TEST ROLLBACK TRANSACTION - Facture ne devrait PAS être créée"

Vérifications SQL:
1. Dernier header: 2026-05-25 09:17:18 (AUCUNE nouvelle facture)
2. Stock 7-1.5L: -157.00 (INTACT)

ROLLBACK FONCTIONNEL À 100%
Si erreur pendant SaveInvoice → RIEN n'est créé en base
Intégrité des données GARANTIE
```

---

## 📊 Résumé des Tests

| # | Test | Priorité | Statut | Notes |
|---|------|----------|--------|-------|
| 1 | Facture Simple | ⭐⭐⭐⭐⭐ | ✅ | Stock mis à jour (comportement négatif préexistant) |
| 2 | Facture Multiple | ⭐⭐⭐⭐⭐ | ⏳ |  |
| 3 | Hold Invoice | ⭐⭐⭐⭐ | ⏳ |  |
| 4 | Recall Hold | ⭐⭐⭐⭐ | ⏳ |  |
| 5 | Re-Hold | ⭐⭐⭐⭐ | ⏳ |  |
| 6 | Création KOT | ⭐⭐⭐ | ⏳ |  |
| 7 | SQL Injection | ⭐⭐⭐⭐⭐ | ⏳ | À tester |
| 8 | Caractères Spéciaux | ⭐⭐⭐ | ⏳ |  |
| 9 | Rollback | ⭐⭐⭐⭐⭐ | ✅ | PARFAIT - Rollback validé, Commit validé |

**Légende :**
- ⏳ En attente
- ✅ Réussi
- ⚠️ Réussi avec remarques
- ❌ Échec

---

## 🐛 Bugs Détectés

### Bug #1 : [Titre]
**Sévérité :** 🔴 Critique / 🟡 Moyenne / 🟢 Mineure  
**Reproduction :**
1. ...
2. ...

**Résultat attendu :**  
**Résultat observé :**  
**Impact :**  
**Fichier :** frmMain.cs:XXXX

---

## ✅ Validation Finale

**Tous les tests critiques (⭐⭐⭐⭐⭐) réussis ?**
- [ ] Test 1 : Facture Simple
- [ ] Test 2 : Facture Multiple
- [ ] Test 7 : SQL Injection
- [ ] Test 9 : Rollback

**Décision :**
- [ ] ✅ Migration frmMain validée - Prêt pour production
- [ ] ⚠️ Bugs mineurs détectés - Corrections nécessaires
- [ ] ❌ Bugs critiques - Rollback migration

---

## 📝 Notes du Testeur

```
[Observations générales, suggestions, questions]
```

---

## 🎯 Prochaines Étapes

**Si tests OK :**
1. Marquer frmMain comme validé
2. Continuer Sprint 1 avec frmPayment

**Si bugs détectés :**
1. Documenter dans section "Bugs Détectés"
2. Prioriser corrections
3. Re-tester après fix

---

**Version :** 1.0  
**Date création :** 2026-05-25  
**Testeur :** [Nom]  
**Durée estimée :** 30-45 minutes
