# 📋 PLAN DE TESTS MANUELS - CYPOS RESTAURANT POS

**Date**: 2026-05-25  
**Version**: 1.0  
**Application**: CYPOS Restaurant.exe (Release)  
**Objectif**: Valider la migration SecureDataAccess et élimination des vulnérabilités SQL Injection

---

## 🎯 OBJECTIFS DES TESTS

✅ Vérifier que toutes les transactions ACID fonctionnent correctement  
✅ Valider les opérations CRUD sur tous les formulaires  
✅ S'assurer que les recherches avec SqlParameter fonctionnent  
✅ Tester la sécurité (login, passwords BCrypt, injection SQL)  
✅ Vérifier les rapports et impressions  

---

## ⚙️ PRÉPARATION

### Avant de commencer:

1. **Lancer l'application**:
   ```
   C:\Users\Bamba\Documents\Visual Studio 2022\Projets\Claude\CYPOS\Sourcecode\CYPOS\bin\Release\CYPOS Restaurant.exe
   ```

2. **Créer backup de la base de données** (recommandé):
   - Ouvrir SQL Server Management Studio
   - Clic droit sur votre base CYPOS → Tasks → Backup
   - Sauvegarder dans: `C:\Backup\CYPOS_BeforeTests_20260525.bak`

3. **Préparer un bloc-notes** pour noter les résultats

---

## 📝 TEST 1 - TRANSACTIONS CRITIQUES (30 min)

### 🎯 Objectif: Vérifier l'intégrité des transactions ACID

### Test 1.1 - Création de facture complète (SaveInvoice)

**Étapes:**
1. Lancer l'application et se connecter
2. Dans l'écran principal (frmMain):
   - Sélectionner une table (si demandé)
   - Ajouter 3 articles différents au panier
   - Vérifier que le total s'affiche correctement
3. Cliquer sur "DONE ORDER" ou équivalent
4. Dans l'écran de paiement (frmPayment):
   - Sélectionner "Cash" comme type de paiement
   - Entrer le montant payé
   - Cliquer sur "PAY"

**Vérifications:**
- [ ] La facture est créée sans erreur
- [ ] Le numéro de facture s'affiche
- [ ] L'écran principal se vide correctement

**Test Stock (important - vérifier la transaction ACID):**
1. Ouvrir le formulaire Items (Ctrl+I ou menu)
2. Chercher les 3 articles vendus
3. Noter les quantités en stock

**Résultat attendu:**
- [ ] Le stock a diminué exactement de la quantité vendue
- [ ] Aucun stock négatif
- [ ] Les 3 articles ont tous été mis à jour (atomicité de la transaction)

**Note SQL à vérifier:**
```sql
-- Vérifier la facture dans la base
SELECT * FROM tbl_InvoiceHeader WHERE invoice_no = 'VOTRE_NUMERO_FACTURE'
SELECT * FROM tbl_InvoiceDetail WHERE header_id = VOTRE_INVOICE_ID
SELECT * FROM tbl_Item WHERE item_code IN ('CODE1', 'CODE2', 'CODE3')
```

---

### Test 1.2 - Hold Invoice (HoldInvoice transaction)

**Étapes:**
1. Ajouter 2-3 articles au panier
2. Cliquer sur "HOLD" (bouton Hold Invoice)
3. Confirmer le Hold

**Vérifications:**
- [ ] Le hold est créé sans erreur
- [ ] Un numéro de hold est généré
- [ ] Le panier est vidé
- [ ] Aucun message d'erreur

**Test Recall:**
1. Cliquer sur "RECALL" (Recall Invoice)
2. Sélectionner le hold que vous venez de créer
3. Vérifier que les articles réapparaissent dans le panier

**Résultat attendu:**
- [ ] Les articles sont rechargés correctement
- [ ] Les quantités sont exactes
- [ ] Les prix sont corrects
- [ ] Les modifiers (si ajoutés) sont présents

---

### Test 1.3 - Purchase avec mise à jour stock (frmPurchase)

**Étapes:**
1. Ouvrir le formulaire Purchase (menu → Purchase)
2. Créer un nouvel achat:
   - Sélectionner un article
   - Entrer quantité: 10
   - Entrer prix d'achat: 5.00
   - Cliquer "Save"

**Vérifications:**
- [ ] L'achat est enregistré sans erreur
- [ ] Retourner dans Items et vérifier que le stock a AUGMENTÉ de 10
- [ ] La transaction est atomique (achat + stock en une seule opération)

---

### Test 1.4 - Paiement client avec historique (frmCustomerPayment)

**Étapes:**
1. Créer une facture avec un client (pas "Cash")
2. Ne pas payer la totalité (créer un "due amount")
3. Aller dans "Customer Payment" ou "Due Invoices"
4. Effectuer un paiement partiel

**Vérifications:**
- [ ] Le paiement est enregistré
- [ ] Le montant dû diminue correctement
- [ ] L'historique s'affiche dans frmCustomer

---

## 📝 TEST 2 - CRUD OPÉRATIONS (30 min)

### 🎯 Objectif: Valider Create/Read/Update/Delete sur tous les formulaires

### Test 2.1 - Gestion des Clients (frmCustomer)

**CREATE:**
1. Ouvrir Customers (menu)
2. Cliquer "New" ou équivalent
3. Remplir:
   - Name: "Test Client 001"
   - Address: "123 Test Street"
   - City: "Test City"
   - Phone: "1234567890"
   - Email: "test@test.com"
4. Cliquer "Save"

**Vérifications:**
- [ ] Client créé sans erreur
- [ ] Apparaît dans la liste des clients

**READ:**
1. Utiliser la barre de recherche
2. Chercher "Test Client"

**Vérifications:**
- [ ] Le client s'affiche correctement
- [ ] La recherche fonctionne (SqlParameter)

**UPDATE:**
1. Sélectionner "Test Client 001"
2. Modifier Phone: "9999999999"
3. Cliquer "Save"

**Vérifications:**
- [ ] Modification sauvegardée
- [ ] Nouvelle valeur affichée

**DELETE:**
1. Sélectionner "Test Client 001"
2. Cliquer "Delete"
3. Confirmer

**Vérifications:**
- [ ] Client supprimé
- [ ] Ne s'affiche plus dans la liste

---

### Test 2.2 - Gestion des Articles (frmItem)

**CREATE:**
1. Ouvrir Items
2. Créer nouvel article:
   - Item Code: "TEST001"
   - Item Name: "Test Article"
   - Category: (sélectionner une catégorie)
   - Selling Price: 10.50
   - Cost Price: 5.25
   - Stock: 100
3. Cliquer "Save"

**Vérifications:**
- [ ] Article créé avec tous les décimaux corrects (pas d'erreur "varchar to numeric")
- [ ] Prix affichés avec 2 décimales

**UPDATE:**
1. Modifier Selling Price: 12.75
2. Save

**Vérifications:**
- [ ] Prix modifié correctement (SqlParameter avec SqlDbType.Decimal)

**DELETE:**
1. Supprimer l'article test

**Vérifications:**
- [ ] Suppression réussie

---

### Test 2.3 - Autres formulaires CRUD rapides

Répéter le cycle CREATE → READ → UPDATE → DELETE pour:

**frmCategory:**
- [ ] Créer catégorie "Test Category"
- [ ] Rechercher
- [ ] Modifier
- [ ] Supprimer

**frmSupplier:**
- [ ] Créer fournisseur "Test Supplier"
- [ ] Rechercher
- [ ] Modifier
- [ ] Supprimer

**frmTable:**
- [ ] Créer table "Test Table"
- [ ] Sélectionner location
- [ ] Modifier nombre de chaises
- [ ] Supprimer

**frmUser:**
- [ ] Créer utilisateur "TestUser"
- [ ] Vérifier password (hashé avec BCrypt)
- [ ] Modifier
- [ ] Supprimer

**frmExpenseGroup:**
- [ ] Créer groupe "Test Expense"
- [ ] Modifier
- [ ] Supprimer

**frmModifier:**
- [ ] Créer modifier "Extra Cheese" (+2.00)
- [ ] Modifier prix
- [ ] Supprimer

---

## 📝 TEST 3 - CONFIGURATION SYSTÈME (15 min)

### Test 3.1 - Company Settings (frmCompany)

**Étapes:**
1. Ouvrir Company Settings
2. Modifier:
   - Tax1 Rate: 5.50 (décimal)
   - Tax2 Rate: 3.25 (décimal)
3. Save

**Vérifications:**
- [ ] Sauvegarde réussie (pas d'erreur "varchar to numeric")
- [ ] Valeurs décimales correctes avec SqlParameter

---

### Test 3.2 - General Settings (frmSettings)

**Étapes:**
1. Ouvrir Settings
2. Modifier:
   - Default Discount Rate: 10.5
   - Service Charge Rate: 12.0
3. Save

**Vérifications:**
- [ ] Tous les paramètres sauvegardés avec SqlParameter
- [ ] Pas d'erreur de conversion

---

### Test 3.3 - Printers (frmPrinters)

**Étapes:**
1. Ouvrir Printer Settings
2. Sélectionner une imprimante pour Invoice
3. Sélectionner une imprimante pour KOT
4. Save

**Vérifications:**
- [ ] Configuration sauvegardée avec SqlParameter

---

### Test 3.4 - Database Management (frmDatabase)

**⚠️ ATTENTION: Test destructif! Utiliser base de test uniquement**

**Étapes:**
1. Ouvrir Database Management
2. NE PAS COCHER "Invoices" ou "Purchases" (données importantes)
3. Cocher uniquement: "Tables" ou une table test
4. Cliquer "Truncate/Reset"
5. Confirmer

**Vérifications:**
- [ ] Truncate exécuté avec SecureDataAccess
- [ ] Pas d'erreur SQL
- [ ] DBCC CHECKIDENT exécuté correctement

---

## 📝 TEST 4 - RAPPORTS ET AFFICHAGES (15 min)

### Test 4.1 - Kitchen Display (frmKitchenDisplay)

**Étapes:**
1. Créer une commande avec items "show in kitchen"
2. Sauvegarder comme KOT (Kitchen Order Ticket)
3. Ouvrir Kitchen Display
4. Vérifier que la commande s'affiche

**Vérifications:**
- [ ] Commande affichée avec SecureDataAccess
- [ ] UpdateStatus fonctionne avec SqlParameter
- [ ] Pas d'erreur d'affichage

---

### Test 4.2 - Print Preview (frmPrintView)

**Étapes:**
1. Créer une facture complète
2. Dans l'aperçu avant impression:
   - Vérifier que toutes les données s'affichent
   - Logo, items, totaux, taxes

**Vérifications:**
- [ ] Rapport LoadInvoice fonctionne avec SqlParameter
- [ ] Toutes les données correctes
- [ ] Pas d'erreur SQL dans le rapport

---

### Test 4.3 - Reports (frmReports)

**Étapes:**
1. Ouvrir Reports
2. Sélectionner date range
3. Générer rapport de ventes

**Vérifications:**
- [ ] Rapport généré avec SecureDataAccess
- [ ] Données correctes
- [ ] Pas d'erreur SQL

---

## 📝 TEST 5 - SÉCURITÉ (10 min)

### 🎯 Objectif: Valider la sécurité contre SQL Injection et BCrypt

### Test 5.1 - Login sécurisé

**Étapes:**
1. Fermer l'application
2. Relancer CYPOS Restaurant.exe
3. À l'écran login:
   - Username: (votre username)
   - Password: (votre password)
4. Login

**Vérifications:**
- [ ] Login réussit avec password BCrypt
- [ ] PasswordHelper.VerifyPassword fonctionne

---

### Test 5.2 - Changement de mot de passe

**Étapes:**
1. Ouvrir User Profile ou User Management
2. Sélectionner un utilisateur test
3. Changer le mot de passe: "NewPass123"
4. Save
5. Logout
6. Réessayer login avec nouveau password

**Vérifications:**
- [ ] Password hashé avec BCrypt (PasswordHelper.HashPassword)
- [ ] Login fonctionne avec nouveau password
- [ ] Ancien password ne fonctionne plus

---

### Test 5.3 - Protection SQL Injection (Critique!)

**Test d'injection sur recherche Client:**

**Étapes:**
1. Ouvrir Customers
2. Dans la barre de recherche, entrer:
   ```
   ' OR '1'='1
   ```
3. Appuyer Enter

**Résultat attendu:**
- [ ] **Recherche échoue ou retourne 0 résultat** (bon signe - SqlParameter protège)
- [ ] **Pas de crash**
- [ ] **Pas tous les clients affichés** (mauvais signe si ça arrive)

**Test d'injection sur recherche Item:**

**Étapes:**
1. Ouvrir Items
2. Chercher:
   ```
   '; DROP TABLE tbl_Item; --
   ```

**Résultat attendu:**
- [ ] **Aucun effet** (SqlParameter empêche l'injection)
- [ ] **Table tbl_Item toujours présente**
- [ ] **Application toujours fonctionnelle**

**Vérification finale:**
```sql
-- Exécuter dans SQL Server Management Studio
SELECT COUNT(*) FROM tbl_Item;
-- Doit retourner le nombre d'items (pas 0 ou erreur)
```

---

### Test 5.4 - Vérification des transactions ACID sous stress

**Étapes:**
1. Créer une facture avec 5+ items
2. **Pendant** la sauvegarde, débrancher le réseau (si SQL Server distant)
   OU arrêter brutalement l'application (Task Manager → End Task)

**Vérifications après redémarrage:**
- [ ] Soit la facture est complète (tous les items + stock à jour)
- [ ] Soit rien n'est enregistré (rollback complet)
- [ ] **JAMAIS** de facture partielle ou stock incohérent
- [ ] C'est la preuve que les transactions ACID fonctionnent!

---

## 📊 RÉSULTATS DES TESTS

### Formulaire de rapport

Compléter après chaque test:

| Test | Statut | Erreurs | Commentaires |
|------|--------|---------|--------------|
| 1.1 - SaveInvoice + Stock | ⬜ OK / ⬜ FAIL | | |
| 1.2 - Hold/Recall Invoice | ⬜ OK / ⬜ FAIL | | |
| 1.3 - Purchase + Stock | ⬜ OK / ⬜ FAIL | | |
| 1.4 - Customer Payment | ⬜ OK / ⬜ FAIL | | |
| 2.1 - CRUD Clients | ⬜ OK / ⬜ FAIL | | |
| 2.2 - CRUD Items | ⬜ OK / ⬜ FAIL | | |
| 2.3 - CRUD Autres | ⬜ OK / ⬜ FAIL | | |
| 3.1 - Company Settings | ⬜ OK / ⬜ FAIL | | |
| 3.2 - General Settings | ⬜ OK / ⬜ FAIL | | |
| 3.3 - Printers | ⬜ OK / ⬜ FAIL | | |
| 3.4 - Database Truncate | ⬜ OK / ⬜ FAIL | | |
| 4.1 - Kitchen Display | ⬜ OK / ⬜ FAIL | | |
| 4.2 - Print Preview | ⬜ OK / ⬜ FAIL | | |
| 4.3 - Reports | ⬜ OK / ⬜ FAIL | | |
| 5.1 - Login BCrypt | ⬜ OK / ⬜ FAIL | | |
| 5.2 - Change Password | ⬜ OK / ⬜ FAIL | | |
| 5.3 - SQL Injection | ⬜ OK / ⬜ FAIL | | |
| 5.4 - ACID Stress Test | ⬜ OK / ⬜ FAIL | | |

---

## 🚨 EN CAS D'ERREUR

Si vous rencontrez une erreur pendant les tests:

1. **Noter l'erreur exacte**:
   - Message d'erreur complet
   - Écran où ça se produit
   - Étapes pour reproduire

2. **Vérifier les logs** (si disponibles):
   ```
   C:\Users\Bamba\Documents\Visual Studio 2022\Projets\Claude\CYPOS\Sourcecode\CYPOS\Errors\
   ```

3. **Prendre screenshot** de l'erreur

4. **Me fournir**:
   - L'erreur exacte
   - Le formulaire concerné
   - Les étapes de reproduction

Je corrigerai immédiatement! 🔧

---

## ✅ VALIDATION FINALE

Une fois tous les tests complétés et **tous OK**:

- [ ] **Toutes les transactions ACID fonctionnent**
- [ ] **Tous les CRUD fonctionnent**
- [ ] **Aucune erreur "varchar to numeric"**
- [ ] **Protection SQL Injection validée**
- [ ] **BCrypt password fonctionne**
- [ ] **Application stable**

**L'application est prête pour la production!** 🚀

---

## 📞 CONTACT

En cas de problème ou question pendant les tests, fournissez-moi:
1. Le numéro du test qui échoue
2. Le message d'erreur exact
3. Les étapes effectuées

Je vous aiderai à résoudre rapidement! 💪
