# CYPOS Phase 1 - Checklist de Déploiement

**Date de déploiement prévue :** _______________  
**Responsable :** _______________  
**Durée estimée :** 1-2 heures

---

## Pré-déploiement (À faire 24h avant)

### Préparation

- [ ] Lire complètement `MIGRATION_PHASE1.md`
- [ ] Lire `PLAN_PHASE1.md`
- [ ] Informer tous les utilisateurs de la maintenance planifiée
- [ ] Planifier une fenêtre de maintenance (suggéré : après fermeture)
- [ ] Identifier 2-3 utilisateurs clés pour tests post-déploiement

### Sauvegardes

- [ ] Créer sauvegarde complète de la base CYPOS
  - Fichier : `C:\Backup\CYPOS_PrePhase1_YYYYMMDD.bak`
  - Vérifier l'intégrité de la sauvegarde
- [ ] Créer archive du code source actuel
  - Fichier : `CYPOS_Source_PrePhase1_YYYYMMDD.zip`
- [ ] Copier les sauvegardes sur un serveur externe/USB
- [ ] Tester la restauration sur une base de test

### Compilation

- [ ] Compiler CYPOS en mode Release
  - Aucune erreur de compilation
  - Tester sur base de test
- [ ] Compiler PasswordMigrationUtility.exe
  - Tester sur base de test avec quelques comptes
- [ ] Créer un dossier "Deployment_Package" avec:
  ```
  Deployment_Package/
  ├── Application/
  │   ├── CYPOS Restaurant.exe
  │   ├── *.dll
  │   └── ...
  ├── Scripts/
  │   ├── migration_phase1.sql
  │   ├── rollback_phase1.sql
  │   ├── validation_phase1.sql
  │   └── PasswordMigrationUtility.exe
  └── Documentation/
      ├── MIGRATION_PHASE1.md
      └── DEPLOYMENT_CHECKLIST.md (ce fichier)
  ```

---

## Jour du déploiement

### Phase 1 : Arrêt du système (T-0)

**Heure de début :** _______________

- [ ] Envoyer notification finale aux utilisateurs (15 min avant)
- [ ] Fermer CYPOS sur tous les postes clients
  - Poste 1: _______________
  - Poste 2: _______________
  - Poste 3: _______________
  - Autres: _______________
- [ ] Vérifier qu'aucun utilisateur n'est connecté
- [ ] Vérifier les connexions SQL actives
  ```sql
  SELECT session_id, login_name, host_name, program_name
  FROM sys.dm_exec_sessions
  WHERE database_id = DB_ID('CYPOS');
  ```
- [ ] Tuer les connexions actives si nécessaire

**Notes :** _______________________________________________

---

### Phase 2 : Migration SQL (T+10 min)

**Heure de début :** _______________

- [ ] Ouvrir `migration_phase1.sql` dans SQL Server Management Studio
- [ ] Lire le script entièrement
- [ ] Exécuter le script
- [ ] Vérifier qu'aucune erreur n'est apparue
- [ ] Vérifier la création de `tbl_User_Backup_PrePhase1`
  ```sql
  SELECT COUNT(*) FROM tbl_User_Backup_PrePhase1;
  ```
  Résultat : _______________

- [ ] Vérifier la nouvelle structure de colonne
  ```sql
  SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
  FROM INFORMATION_SCHEMA.COLUMNS
  WHERE TABLE_NAME = 'tbl_User' AND COLUMN_NAME = 'password';
  ```
  Attendu : `password`, `varchar`, `256`

**Notes :** _______________________________________________

---

### Phase 3 : Migration des mots de passe (T+20 min)

**Heure de début :** _______________

- [ ] Naviguer vers le dossier contenant `PasswordMigrationUtility.exe`
- [ ] Exécuter `PasswordMigrationUtility.exe`
- [ ] Lire le rapport affiché
- [ ] Confirmer la migration (taper `yes`)
- [ ] Attendre la fin de l'exécution
- [ ] Vérifier le résultat :
  - Total users processed : _______________
  - Successfully migrated : _______________
  - Failed : _______________ (doit être 0)

- [ ] Valider en SQL
  ```sql
  SELECT 
      COUNT(*) AS Total,
      COUNT(CASE WHEN LEN(password) = 64 THEN 1 END) AS Hashed,
      COUNT(CASE WHEN LEN(password) < 64 THEN 1 END) AS PlainText
  FROM tbl_User;
  ```
  - Total : _______________
  - Hashed : _______________ (doit égaler Total)
  - PlainText : _______________ (doit être 0)

**Notes :** _______________________________________________

---

### Phase 4 : Validation SQL (T+30 min)

**Heure de début :** _______________

- [ ] Ouvrir `validation_phase1.sql` dans SQL Server Management Studio
- [ ] Exécuter le script
- [ ] Lire le rapport complet
- [ ] Vérifier le résumé :
  - Checks passed : _____ / 7
  - Pass rate : _____%

- [ ] Si < 100% : Investiguer les échecs
  - Échec #1 : _______________
  - Action corrective : _______________
  - Échec #2 : _______________
  - Action corrective : _______________

**Notes :** _______________________________________________

---

### Phase 5 : Déploiement du code (T+40 min)

**Heure de début :** _______________

- [ ] Naviguer vers `Deployment_Package/Application/`
- [ ] Copier tous les fichiers vers le répertoire de production
  - Chemin : _______________
- [ ] Remplacer les anciens fichiers
- [ ] Vérifier que `CYPOS Restaurant.exe` est bien la nouvelle version
  - Date de fichier : _______________
  - Taille : _______________

- [ ] Répéter pour chaque poste client:
  - [ ] Poste 1 : _______________
  - [ ] Poste 2 : _______________
  - [ ] Poste 3 : _______________
  - [ ] Autres : _______________

**Notes :** _______________________________________________

---

### Phase 6 : Tests de validation (T+50 min)

**Heure de début :** _______________

#### Test 1 : Authentification

- [ ] Lancer CYPOS
- [ ] Login avec `admin` / `admin`
- [ ] ✅ Résultat : _______________ (Attendu : Succès)

- [ ] Logout
- [ ] Login avec `admin` / `wrongpass`
- [ ] ✅ Résultat : _______________ (Attendu : Échec)

- [ ] Login avec `admin' OR '1'='1' --` / `anything`
- [ ] ✅ Résultat : _______________ (Attendu : Échec - SQL Injection bloqué)

#### Test 2 : Création d'utilisateur

- [ ] Naviguer vers Back Office → Users
- [ ] Créer un utilisateur de test :
  - Username : `test_phase1`
  - Password : `test123`
  - Type : Cashier
- [ ] ✅ Sauvegarder : _______________ (Attendu : Succès)
- [ ] Logout et login avec `test_phase1` / `test123`
- [ ] ✅ Résultat : _______________ (Attendu : Succès)

#### Test 3 : Modification d'utilisateur

- [ ] Modifier l'utilisateur `test_phase1`
- [ ] Changer le mot de passe pour `newpass456`
- [ ] ✅ Sauvegarder : _______________ (Attendu : Succès)
- [ ] Logout et login avec nouveau mot de passe
- [ ] ✅ Résultat : _______________ (Attendu : Succès)

#### Test 4 : Client avec caractères spéciaux

- [ ] Naviguer vers Back Office → Customers
- [ ] Créer un client :
  - Name : `Jean-François O'Brien`
  - Address : `123 Rue de l'Église`
  - City : `Montréal`
  - Phone : `514-555-1234`
- [ ] ✅ Sauvegarder : _______________ (Attendu : Succès sans erreur)
- [ ] Rechercher le client
- [ ] ✅ Affichage correct : _______________ (Attendu : Apostrophes et accents OK)

#### Test 5 : Fournisseur

- [ ] Créer un fournisseur de test
- [ ] ✅ Résultat : _______________ (Attendu : Succès)

#### Test 6 : Retour de vente

- [ ] Naviguer vers Sales Return
- [ ] Entrer un numéro de facture valide : _______________
- [ ] Ajouter des articles à retourner
- [ ] ✅ Sauvegarder : _______________ (Attendu : Succès sans erreur)

#### Test 7 : Logs d'erreur

- [ ] Ouvrir `bin\Debug\Errors\errlog_YYYYMMDD.txt`
- [ ] ✅ Vérifier : _______________ (Attendu : Aucune nouvelle erreur)

**Notes :** _______________________________________________

---

### Phase 7 : Validation utilisateur (T+1h10)

**Heure de début :** _______________

- [ ] Appeler utilisateur clé #1 : _______________
  - Test de prise de commande : _______________
  - Test de paiement : _______________
  - Feedback : _______________

- [ ] Appeler utilisateur clé #2 : _______________
  - Test de gestion client : _______________
  - Feedback : _______________

- [ ] Appeler utilisateur clé #3 : _______________
  - Test de retour de vente : _______________
  - Feedback : _______________

**Notes :** _______________________________________________

---

### Phase 8 : Remise en production (T+1h30)

**Heure de fin :** _______________

- [ ] Tous les tests passés avec succès
- [ ] Aucune erreur critique dans les logs
- [ ] Validation utilisateur positive

- [ ] Envoyer notification de fin de maintenance
- [ ] Informer tous les utilisateurs que le système est disponible
- [ ] Configurer monitoring pour les prochaines 24h

**Communication aux utilisateurs :**

```
Mise à jour CYPOS Phase 1 déployée avec succès !

Changements :
- Sécurité renforcée
- Bugs corrigés dans le module de retours
- Aucun changement visible pour vous

Vos mots de passe existants fonctionnent toujours.

En cas de problème, contactez : _______________
```

**Notes finales :** _______________________________________________

---

## Post-déploiement (24-48h)

### Monitoring Jour 1

**Heure :** 9h00
- [ ] Vérifier logs d'erreur
- [ ] Vérifier avec 2 utilisateurs
- [ ] Problèmes détectés : _______________

**Heure :** 13h00
- [ ] Vérifier logs d'erreur
- [ ] Collecter feedback utilisateurs
- [ ] Problèmes détectés : _______________

**Heure :** 17h00
- [ ] Vérifier logs d'erreur
- [ ] Résumer la journée
- [ ] Actions correctives si nécessaire : _______________

### Monitoring Jour 2

**Heure :** 9h00
- [ ] Vérifier logs d'erreur
- [ ] Problèmes détectés : _______________

**Heure :** 17h00
- [ ] Vérifier logs d'erreur
- [ ] Fermer le suivi si tout est stable

### Validation finale

- [ ] Aucune erreur critique dans les logs (2 jours)
- [ ] Aucun feedback négatif des utilisateurs
- [ ] Performances normales
- [ ] Déploiement considéré comme réussi

**Date de clôture :** _______________  
**Signature :** _______________

---

## Rollback d'urgence

### Critères de rollback

Exécuter le rollback SI :
- [ ] Impossible de se connecter au système
- [ ] Erreurs critiques répétées affectant les opérations
- [ ] Perte de données détectée
- [ ] Régression fonctionnelle majeure

### Procédure de rollback

1. **Arrêter CYPOS sur tous les postes**
   - [ ] Tous les postes fermés

2. **Restaurer la base de données**
   ```sql
   -- Option A : Restauration complète
   USE master;
   ALTER DATABASE CYPOS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
   RESTORE DATABASE CYPOS
   FROM DISK = 'C:\Backup\CYPOS_PrePhase1_YYYYMMDD.bak'
   WITH REPLACE;
   ALTER DATABASE CYPOS SET MULTI_USER;
   ```
   - [ ] Base restaurée

3. **Restaurer l'ancien code**
   - [ ] Dézipper `CYPOS_Source_PrePhase1_YYYYMMDD.zip`
   - [ ] Copier les anciens fichiers
   - [ ] Déployé sur tous les postes

4. **Tester le rollback**
   - [ ] Login admin/admin fonctionne
   - [ ] Opération de base fonctionne

5. **Informer les utilisateurs**
   - [ ] Notification envoyée

6. **Investiguer**
   - Cause du rollback : _______________
   - Actions correctives : _______________

**Heure de rollback :** _______________  
**Responsable :** _______________

---

## Contact et support

**Support technique :** _______________  
**Téléphone :** _______________  
**Email :** _______________

**Escalade (si problème critique) :** _______________

---

## Signatures

**Préparé par :** _______________ Date : _______________

**Approuvé par :** _______________ Date : _______________

**Exécuté par :** _______________ Date : _______________

**Validé par :** _______________ Date : _______________

---

**Version :** 1.0  
**Date de création :** 2026-05-24  
**Statut :** ✅ Prêt pour utilisation
