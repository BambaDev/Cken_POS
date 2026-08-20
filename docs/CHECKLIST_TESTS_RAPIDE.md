# ✅ CHECKLIST TESTS RAPIDE - CYPOS

**Date**: ____________  
**Testeur**: ____________  
**Version**: CYPOS Restaurant.exe (Release)

---

## 🚀 DÉMARRAGE

- [ ] Backup base de données créé
- [ ] Application lancée: `CYPOS\bin\Release\CYPOS Restaurant.exe`
- [ ] Login réussi

---

## 1️⃣ TRANSACTIONS (30 min)

### Facture + Stock
- [ ] Créer facture avec 3 articles
- [ ] Paiement Cash effectué
- [ ] Stock diminué correctement
- [ ] Aucun stock négatif

### Hold/Recall
- [ ] Hold créé avec 2 articles
- [ ] Recall réussit
- [ ] Articles rechargés correctement

### Purchase
- [ ] Achat créé (qté: 10)
- [ ] Stock augmenté de 10
- [ ] Transaction atomique OK

### Paiement Client
- [ ] Facture avec client créée
- [ ] Paiement partiel effectué
- [ ] Historique visible

---

## 2️⃣ CRUD (30 min)

### Client
- [ ] CREATE: "Test Client 001"
- [ ] READ: Recherche fonctionne
- [ ] UPDATE: Phone modifié
- [ ] DELETE: Client supprimé

### Article
- [ ] CREATE: "TEST001" - Prix 10.50
- [ ] UPDATE: Prix → 12.75 (pas d'erreur decimal)
- [ ] DELETE: Article supprimé

### Autres (rapide)
- [ ] Category: CREATE/UPDATE/DELETE
- [ ] Supplier: CREATE/UPDATE/DELETE
- [ ] Table: CREATE/UPDATE/DELETE
- [ ] User: CREATE/UPDATE/DELETE
- [ ] ExpenseGroup: CREATE/UPDATE/DELETE
- [ ] Modifier: CREATE/UPDATE/DELETE

---

## 3️⃣ CONFIGURATION (15 min)

- [ ] Company: Tax rates modifiés (5.50, 3.25)
- [ ] Settings: Discount/SC modifiés
- [ ] Printers: Imprimantes configurées
- [ ] Database: Truncate test OK

---

## 4️⃣ RAPPORTS (15 min)

- [ ] Kitchen Display: Commande affichée
- [ ] Print Preview: Facture affichée
- [ ] Reports: Rapport ventes généré

---

## 5️⃣ SÉCURITÉ (10 min)

### BCrypt Password
- [ ] Login avec password BCrypt OK
- [ ] Changement password fonctionne
- [ ] Nouveau login réussit

### SQL Injection
- [ ] Test injection Client: `' OR '1'='1`
  - Résultat: ⬜ Bloqué (OK) / ⬜ Passé (DANGER!)
- [ ] Test injection Item: `'; DROP TABLE tbl_Item; --`
  - Résultat: ⬜ Bloqué (OK) / ⬜ Passé (DANGER!)
- [ ] Table tbl_Item toujours présente: ⬜ OUI

### ACID Stress
- [ ] Arrêt brutal pendant facture
- [ ] Redémarrage: Données cohérentes
- [ ] Pas de facture partielle

---

## 📊 RÉSULTAT GLOBAL

**Tests réussis**: ____ / 37

**Erreurs rencontrées**:
```
1. ________________________________________________
2. ________________________________________________
3. ________________________________________________
```

**Statut final**:
- [ ] ✅ TOUS LES TESTS PASSÉS → **PROD READY**
- [ ] ⚠️ QUELQUES ERREURS → Corriger avant prod
- [ ] ❌ ERREURS CRITIQUES → Ne pas déployer

---

## 📝 NOTES

```
___________________________________________________________
___________________________________________________________
___________________________________________________________
___________________________________________________________
___________________________________________________________
```

---

**Signature testeur**: ________________  
**Date**: ________________
