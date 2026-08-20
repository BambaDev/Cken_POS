# Test Rollback Transaction - Instructions

**Date :** 2026-05-25  
**Fichier modifié :** frmMain.cs (ligne ~1128)

---

## ✅ Modification Effectuée

J'ai ajouté une ligne qui **force une erreur** après la création du header de facture :

```csharp
// Ligne 1126 : Header créé avec succès
HeaderId = (int)cmdHeader.ExecuteScalar();

// Ligne 1128 : ERREUR FORCÉE POUR TEST
throw new Exception("TEST ROLLBACK TRANSACTION - Facture ne devrait PAS être créée");

// Le reste du code n'est jamais exécuté → Details & Stock non modifiés
```

---

## 🧪 Procédure de Test

### Étape 1 : Compiler l'application

```bash
# Dans Visual Studio
Build > Rebuild Solution
```

### Étape 2 : Noter le stock AVANT test

Ouvrir SQL Server Management Studio :

```sql
-- Choisir 1 article et noter son stock actuel
SELECT item_code, item_name, stock_quantity 
FROM [CYPOS].[dbo].[[CYPOS].[dbo].[tbl_Item]]
WHERE item_code = 'PEP-1.5'
-- Exemple résultat : stock_quantity = -17.00
```

### Étape 3 : Exécuter le test

1. Lancer `CYPOS Restaurant.exe`
2. Se connecter
3. Ajouter l'article `PEP-1.5` (quantité : 1)
4. Cliquer **"Save Invoice"**

**Résultat attendu :**
- ❌ Message d'erreur s'affiche : "TEST ROLLBACK TRANSACTION..."
- ❌ Facture PAS créée

### Étape 4 : Vérifier le ROLLBACK

```sql
-- 1. Vérifier que le header N'A PAS été créé
SELECT TOP 1 * FROM [CYPOS].[dbo].[tbl_InvoiceHeader] 
ORDER BY id DESC
-- Regarder le dernier invoice_no → doit être ANCIEN (pas celui du test)

-- 2. Vérifier que le stock N'A PAS changé
SELECT item_code, item_name, stock_quantity 
FROM [CYPOS].[dbo].[tbl_Item] 
WHERE item_code = 'PEP-1.5'
-- Résultat : stock_quantity = -17.00 (IDENTIQUE à Étape 2)
```

---

## ✅ Critères de Succès

| Vérification | Résultat Attendu | Statut |
|--------------|------------------|--------|
| Message erreur affiché | "TEST ROLLBACK TRANSACTION..." | ⏳ |
| Header PAS créé | Dernier invoice_no = ancien | ⏳ |
| Stock INTACT | stock_quantity = valeur avant test | ⏳ |
| Données cohérentes | Base identique à avant test | ⏳ |

**Si TOUS les critères sont ✅ → Transaction atomique fonctionne !**

---

## ❌ Si le Test Échoue

### Scénario 1 : Header créé malgré erreur
```sql
-- Si vous trouvez un nouveau header
SELECT * FROM [CYPOS].[dbo].[tbl_InvoiceHeader] WHERE id = [DERNIER_ID]
```
**Problème :** Transaction ne rollback pas  
**Action :** Vérifier code SecureDataAccess.ExecuteTransaction

### Scénario 2 : Stock modifié malgré erreur
**Problème :** UPDATE stock exécuté avant l'erreur  
**Action :** Impossible car throw est AVANT la boucle Details

---

## 🔄 Après le Test

### SUPPRIMER la ligne de test

Une fois le rollback validé, **supprimer immédiatement** :

```csharp
// SUPPRIMER CES 3 LIGNES :
// *** TEST ROLLBACK - SUPPRIMER APRÈS TEST ***
throw new Exception("TEST ROLLBACK TRANSACTION - Facture ne devrait PAS être créée");
// *** FIN TEST ***
```

**Puis recompiler :**
```bash
Build > Rebuild Solution
```

---

## 📊 Documenter le Résultat

Dans `FRMMAIN_TESTS_PHASE1.md`, section Test 9 :

**Si succès :**
```
✅ Message erreur affiché
✅ Header PAS créé (ID max = [ANCIEN_ID])
✅ Stock intact (PEP-1.5 = -17.00)
✅ ROLLBACK FONCTIONNEL
```

**Si échec :**
```
❌ Header créé (ID = [NOUVEAU_ID])
❌ Transaction n'a PAS rollback
❌ PROBLÈME CRITIQUE
```

---

## 🎯 Pourquoi ce Test est CRUCIAL

**Sans transaction (code ancien) :**
```
1. INSERT Header → ✅ RÉUSSI (données écrites)
2. INSERT Detail → ✅ RÉUSSI (données écrites)
3. UPDATE Stock → ❌ ÉCHEC (erreur réseau)
Résultat : Facture + Details créés, Stock PAS mis à jour
= DONNÉES INCOHÉRENTES !
```

**Avec transaction (code migré) :**
```
1. INSERT Header → ✅ RÉUSSI (mémoire temporaire)
2. INSERT Detail → ✅ RÉUSSI (mémoire temporaire)
3. UPDATE Stock → ❌ ÉCHEC (erreur réseau)
→ ROLLBACK AUTOMATIQUE
Résultat : RIEN n'est créé, base intacte
= DONNÉES COHÉRENTES !
```

---

**Version :** 1.0  
**Durée estimée :** 10 minutes  
**Criticité :** ⭐⭐⭐⭐⭐
