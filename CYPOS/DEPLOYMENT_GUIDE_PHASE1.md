# 📦 Guide de Déploiement Phase 1 - CYPOS

**Date :** 2026-05-24  
**Version :** 1.0  
**Durée estimée :** 1-2 heures  

---

## 🎯 Vue d'ensemble

Ce guide vous accompagne étape par étape pour déployer CYPOS Phase 1 en production.

**Ce qui sera déployé :**
- ✅ Nouveau code sécurisé (5 formulaires migrés)
- ✅ 16 utilisateurs avec mots de passe hachés
- ✅ Protection SQL Injection sur formulaires migrés
- ✅ Correction des bugs frmSalesReturn

---

## ✅ Pré-requis

### Avant de commencer

- [ ] Phase 1 testée sur base de test avec succès
- [ ] validation_phase1.sql exécuté avec 6/7 checks PASS
- [ ] Backup de la base de production créé
- [ ] Fenêtre de maintenance planifiée (2-3h)
- [ ] Utilisateurs informés de la maintenance
- [ ] Droits administrateur sur le serveur
- [ ] Accès au serveur SQL

---

## 📋 Option 1 : Déploiement automatique (Recommandé)

### Utilisation du script PowerShell

**Le script `DEPLOY_PHASE1.ps1` fait tout automatiquement :**
1. Vérifie les pré-requis
2. Crée les backups
3. Ferme l'application
4. Copie les fichiers
5. Crée les dossiers nécessaires
6. Crée les raccourcis
7. Valide l'installation

### Étapes

#### 1. Mode TEST (optionnel mais recommandé)

Testez d'abord sans rien modifier :

```powershell
# Ouvrir PowerShell en tant qu'administrateur
# Clic droit sur PowerShell → Exécuter en tant qu'administrateur

cd "C:\Users\Bamba\Documents\Visual Studio 2022\Projets\Claude\CYPOS"

# Mode test (aucune modification)
.\DEPLOY_PHASE1.ps1 -TestMode
```

**Résultat attendu :** Le script s'exécute et affiche "MODE TEST - Aucune modification réelle"

---

#### 2. Déploiement réel

Une fois le test OK :

```powershell
# Déploiement par défaut
# Source : bin\Release
# Destination : C:\CYPOS\Production
.\DEPLOY_PHASE1.ps1

# OU avec chemins personnalisés
.\DEPLOY_PHASE1.ps1 -SourcePath "C:\chemin\vers\Release" -DestinationPath "D:\CYPOS" -BackupPath "D:\Backups"
```

**Le script va :**
- ✅ Créer les dossiers nécessaires
- ✅ Faire un backup de l'installation actuelle
- ✅ Fermer l'application CYPOS
- ✅ Copier les nouveaux fichiers
- ✅ Créer les raccourcis
- ✅ Valider l'installation

**Durée : 2-5 minutes**

---

#### 3. Vérification post-déploiement

Le script affiche à la fin :

```
✓ DÉPLOIEMENT PHASE 1 TERMINÉ AVEC SUCCÈS

PROCHAINES ÉTAPES :
1. Tester le login avec admin/admin
2. Créer un nouvel utilisateur
3. Tester un client avec apostrophe (ex: O'Brien)
4. Vérifier les logs dans Errors\
5. Monitoring pendant 24-48h
```

---

## 📋 Option 2 : Déploiement manuel

Si vous préférez faire étape par étape manuellement.

### Étape 1 : Préparation (5 min)

#### 1.1 Créer les dossiers

```
C:\CYPOS\Production\              (dossier principal)
C:\CYPOS\Production\Errors\       (logs d'erreur)
C:\CYPOS\Production\Images\       (images entreprise)
C:\CYPOS\Production\ItemImages\   (images articles)
C:\CYPOS\Backups\                 (backups)
```

#### 1.2 Backup de l'installation actuelle

Si CYPOS existe déjà :

```
Copier C:\CYPOS\Production → C:\CYPOS\Backups\Backup_20260524
```

---

### Étape 2 : Arrêt de l'application (2 min)

#### 2.1 Fermer CYPOS sur tous les postes

- Informer tous les utilisateurs
- Demander de fermer l'application
- Vérifier qu'aucune instance n'est ouverte

#### 2.2 Vérifier les processus

**Gestionnaire des tâches** → Rechercher "CYPOS Restaurant" → Terminer si nécessaire

---

### Étape 3 : Migration base de données (20-30 min)

#### 3.1 Backup de la base de données

```sql
-- Dans SQL Server Management Studio
BACKUP DATABASE CYPOS
TO DISK = 'C:\CYPOS\Backups\CYPOS_PrePhase1_20260524.bak'
WITH FORMAT, INIT, COMPRESSION;
```

#### 3.2 Créer la table de backup

```sql
-- Créer une copie de tbl_User
SELECT * INTO tbl_User_Backup_PrePhase1 FROM tbl_User;

-- Vérifier
SELECT COUNT(*) FROM tbl_User_Backup_PrePhase1;
```

#### 3.3 Exécuter PasswordMigrationUtility.exe

1. Copier `PasswordMigrationUtility.exe` vers `C:\CYPOS\Tools\`
2. Double-cliquer sur l'exécutable
3. Vérifier que tous les utilisateurs sont listés
4. Taper **"yes"** pour confirmer
5. Attendre la fin (15/15 ou 16/16 utilisateurs migrés)

**Résultat attendu :**
```
✓ admin - Password hashed successfully
✓ bamba - Password hashed successfully
...
SUCCESS: All passwords have been hashed!
```

---

### Étape 4 : Déploiement du code (5-10 min)

#### 4.1 Copier les fichiers compilés

**Depuis :**
```
CYPOS\Sourcecode\CYPOS\bin\Release\
```

**Vers :**
```
C:\CYPOS\Production\
```

**Fichiers à copier :**
- ✅ `CYPOS Restaurant.exe`
- ✅ `CYPOS Restaurant.exe.config`
- ✅ Toutes les DLL (*.dll)
- ✅ Fichiers PDB (*.pdb) - optionnel mais recommandé pour debug

**Méthode :**
```powershell
Copy-Item "C:\Users\Bamba\Documents\Visual Studio 2022\Projets\Claude\CYPOS\Sourcecode\CYPOS\bin\Release\*" "C:\CYPOS\Production\" -Recurse -Force
```

---

### Étape 5 : Tests de validation (15-20 min)

#### 5.1 Test login

1. Lancer `C:\CYPOS\Production\CYPOS Restaurant.exe`
2. Login : **admin**
3. Password : **admin**
4. **Résultat attendu :** Login réussit

❌ **Si ça échoue :** Les mots de passe n'ont pas été migrés correctement

---

#### 5.2 Test création utilisateur

1. Aller dans gestion utilisateurs
2. Créer un nouvel utilisateur :
   - Nom : Test Phase1
   - Username : test
   - Password : test123
   - Type : Cashier
3. **Sauvegarder**
4. **Résultat attendu :** Utilisateur créé, visible dans la liste

❌ **Si ça échoue :** Problème avec SecureDataAccess

---

#### 5.3 Test client avec caractères spéciaux

1. Aller dans gestion clients
2. Créer un client :
   - Nom : **O'Brien Restaurant**
   - Contact : 0612345678
3. **Sauvegarder**
4. **Résultat attendu :** Client créé sans erreur

❌ **Si ça échoue :** SQL Injection non corrigée

---

#### 5.4 Vérification SQL

Exécuter `validation_phase1.sql` sur la base de production

**Résultat attendu :** 6/7 checks PASS (85%)

---

### Étape 6 : Déploiement multi-postes (variable)

Si vous avez plusieurs postes :

#### Option A : Réseau partagé

1. Installer sur 1 serveur : `\\SERVEUR\CYPOS\`
2. Créer raccourci sur chaque poste pointant vers `\\SERVEUR\CYPOS\CYPOS Restaurant.exe`

#### Option B : Installation locale sur chaque poste

1. Copier les fichiers sur chaque poste
2. Répéter Étape 4 sur chaque machine
3. Tester sur chaque poste

---

## 📊 Checklist de déploiement

### Pré-déploiement

- [ ] Backup base de données créé
- [ ] Backup code source créé
- [ ] Utilisateurs informés
- [ ] Fenêtre de maintenance planifiée
- [ ] Mode test du script exécuté avec succès

### Déploiement

- [ ] Application fermée sur tous les postes
- [ ] Table tbl_User_Backup_PrePhase1 créée
- [ ] PasswordMigrationUtility.exe exécuté
- [ ] Tous les mots de passe hachés (16/16)
- [ ] Nouveaux fichiers copiés
- [ ] Dossiers Errors/, Images/, ItemImages/ créés
- [ ] Raccourcis créés

### Post-déploiement

- [ ] Login admin/admin fonctionne
- [ ] Création utilisateur fonctionne
- [ ] Client avec apostrophe fonctionne
- [ ] validation_phase1.sql = 6/7 checks
- [ ] Logs d'erreur vides
- [ ] Tous les postes déployés et testés

---

## 🚨 Procédure de rollback

### Si problème critique détecté

#### Rollback code (5 min)

```powershell
# Restaurer l'ancien code
Copy-Item "C:\CYPOS\Backups\Backup_20260524\*" "C:\CYPOS\Production\" -Recurse -Force
```

#### Rollback base de données (15-20 min)

```sql
-- Option 1 : Restaurer le backup complet
RESTORE DATABASE CYPOS
FROM DISK = 'C:\CYPOS\Backups\CYPOS_PrePhase1_20260524.bak'
WITH REPLACE;

-- Option 2 : Restaurer juste les mots de passe
TRUNCATE TABLE tbl_User;
INSERT INTO tbl_User SELECT * FROM tbl_User_Backup_PrePhase1;
```

**Durée totale rollback : 20-25 minutes**

---

## 📝 Communication aux utilisateurs

### Avant la maintenance

**Email/message type :**

```
Objet : Maintenance CYPOS - [DATE] à [HEURE]

Bonjour,

Une maintenance du système CYPOS aura lieu :
📅 Date : [DIMANCHE 26 MAI 2026]
🕐 Heure : [20h00 - 23h00]
⏱️ Durée : 2-3 heures

Améliorations incluses :
✅ Sécurité renforcée (protection des données)
✅ Corrections de bugs (retours de vente)
✅ Performances améliorées

⚠️ Pendant la maintenance :
- L'application sera indisponible
- Fermez CYPOS avant [HEURE]
- Ne tentez pas de vous connecter pendant la maintenance

✅ Après la maintenance :
- Login avec vos identifiants habituels
- Mot de passe inchangé
- Toutes vos données préservées

En cas de problème : [VOTRE CONTACT]

Merci de votre compréhension,
L'équipe technique
```

---

### Après la maintenance

**Email/message type :**

```
Objet : Maintenance CYPOS terminée

Bonjour,

La maintenance CYPOS est terminée avec succès !

✅ Vous pouvez à nouveau utiliser l'application
✅ Vos identifiants n'ont pas changé
✅ Toutes vos données sont intactes

Nouveautés :
- Sécurité renforcée
- Corrections de bugs
- Performances améliorées

Si vous rencontrez un problème :
1. Notez le message d'erreur exact
2. Notez ce que vous tentiez de faire
3. Contactez : [VOTRE CONTACT]

Merci et bon travail !
L'équipe technique
```

---

## 📞 Support post-déploiement

### Monitoring 24-48h

#### Jour 1 (24h après déploiement)

**Vérifier :**
- [ ] Logs d'erreur : `C:\CYPOS\Production\Errors\errlog_[DATE].txt`
- [ ] Feedback utilisateurs (appels, messages)
- [ ] Performances (ralentissements ?)
- [ ] Fonctionnalités critiques (paiements, commandes)

#### Jour 2 (48h après déploiement)

**Vérifier :**
- [ ] Logs d'erreur (nouveaux problèmes ?)
- [ ] Utilisation normale par tous les utilisateurs
- [ ] Pas de régression fonctionnelle

#### Semaine 1

**Vérifier :**
- [ ] Stabilité générale
- [ ] Aucun bug critique
- [ ] Feedback utilisateurs positif

**Si tout va bien → Planifier Sprint 1 (Groupe A)**

---

## 🎯 Indicateurs de succès

### Phase 1 réussie si :

✅ **Sécurité**
- Login fonctionne pour tous les utilisateurs
- Pas d'erreur d'authentification
- Pas de SQL Injection détectée

✅ **Fonctionnalité**
- Création/modification utilisateurs OK
- Création/modification clients OK
- Création/modification fournisseurs OK
- Caractères spéciaux (apostrophes) OK
- Retours de vente sans erreur

✅ **Stabilité**
- Pas de crash
- Logs d'erreur vides ou mineurs
- Performances normales

✅ **Utilisateurs**
- Feedback positif
- Pas de blocage dans le travail
- Formation minimale nécessaire

---

## 📚 Ressources

**Scripts :**
- `DEPLOY_PHASE1.ps1` - Script automatique
- `PasswordMigrationUtility.exe` - Migration mots de passe
- `validation_phase1.sql` - Validation complète

**Documentation :**
- `MIGRATION_PHASE1.md` - Guide détaillé migration
- `DEPLOYMENT_CHECKLIST.md` - Checklist complète
- `PHASE1_FINAL_REPORT.md` - Rapport complet

**Rollback :**
- `rollback_phase1.sql` - Rollback SQL
- Backups dans `C:\CYPOS\Backups\`

---

## ✅ Déploiement terminé !

**Après le déploiement réussi :**

1. ✅ Documenter la date/heure de déploiement
2. ✅ Archiver les logs de déploiement
3. ✅ Mettre à jour le statut du projet
4. ✅ Célébrer ! 🎉

**Prochaine étape :**
- Monitoring 1 semaine
- Puis démarrer Sprint 1 (Groupe A - 7 formulaires critiques)

---

**Version :** 1.0  
**Date :** 2026-05-24  
**Statut :** ✅ Prêt pour déploiement
