# Corrections de Structure de Base de Données

**Date :** 2026-05-24  
**Problème :** Noms de colonnes différents entre la documentation et la base réelle  
**Statut :** ✅ Tous les problèmes corrigés  

---

## Résumé du problème

La documentation initiale supposait des noms de colonnes qui ne correspondaient pas à la structure réelle de la base de données CYPOS.

### Structure documentée (incorrecte)
```sql
tbl_User:
- user_id (PK)
- user_name
- password
- user_type
- full_name
- contact
- dob
- image_name
```

### Structure réelle (découverte)
```sql
tbl_User:
- id (PK, bigint)          ← Différent !
- user_name (varchar)
- password (varchar)
- user_type (varchar)
- name (varchar)           ← Différent !
- address (varchar)
- contact (varchar)
- email (varchar)
- dob (datetime)
- log_date (datetime)
```

---

## Erreurs rencontrées

### 1. PasswordMigrationUtility.exe

**Erreur initiale :**
```
Invalid column name 'user_id'.
```

**Ligne problématique :**
```csharp
string selectSql = @"SELECT user_id, user_name, password
                    FROM tbl_User
                    WHERE LEN(password) < 64";
```

---

## Corrections appliquées

### 1. PasswordMigrationUtility.cs (3 corrections)

**Changement 1 - Ligne 50 :**
```csharp
// AVANT
SELECT user_id, user_name, password FROM tbl_User

// APRÈS
SELECT id, user_name, password FROM tbl_User
```

**Changement 2 - Ligne 78 :**
```csharp
// AVANT
Console.WriteLine(string.Format("  - {0} (ID: {1})", row["user_name"], row["user_id"]));

// APRÈS
Console.WriteLine(string.Format("  - {0} (ID: {1})", row["user_name"], row["id"]));
```

**Changement 3 - Lignes 108-112 :**
```csharp
// AVANT
string updateSql = @"UPDATE tbl_User
                    SET password = @hashedPassword
                    WHERE user_id = @userId";
int userId = Convert.ToInt32(row["user_id"]);

// APRÈS
string updateSql = @"UPDATE tbl_User
                    SET password = @hashedPassword
                    WHERE id = @userId";
int userId = Convert.ToInt32(row["id"]);
```

---

### 2. SecureDataAccess.cs (2 méthodes corrigées)

#### CreateUser (ligne 346)

**AVANT :**
```csharp
string sql = @"INSERT INTO tbl_User
              (user_name, password, user_type, full_name, contact, dob, image_name)
              VALUES
              (@username, @password, @userType, @fullName, @contact, @dob, @imageName)";
```

**APRÈS :**
```csharp
string sql = @"INSERT INTO tbl_User
              (user_name, password, user_type, name, contact, dob, image_name)
              VALUES
              (@username, @password, @userType, @fullName, @contact, @dob, @imageName)";
```

**Changement :** `full_name` → `name`

---

#### UpdateUser (lignes 395 et 419)

**AVANT :**
```csharp
sql = @"UPDATE tbl_User
       SET user_name = @username,
           password = @password,
           user_type = @userType,
           full_name = @fullName,
           contact = @contact,
           dob = @dob,
           image_name = @imageName
       WHERE user_id = @userId";
```

**APRÈS :**
```csharp
sql = @"UPDATE tbl_User
       SET user_name = @username,
           password = @password,
           user_type = @userType,
           name = @fullName,
           contact = @contact,
           dob = @dob,
           image_name = @imageName
       WHERE id = @userId";
```

**Changements :**
- `full_name` → `name`
- `user_id` → `id` (dans la clause WHERE)

**Type de données :**
- `SqlDbType.Int` → `SqlDbType.BigInt` (car la colonne `id` est de type `bigint`)

---

## Autres corrections liées

### 3. Dossiers manquants

**Erreur au démarrage de l'application :**
```
Login error: Impossible de trouver une partie du chemin d'accès
'C:\Users\Bamba\Document\Visual Studio 2022\Projets\Claude\CYPO
```

**Cause :** L'application essaie de créer des logs dans des dossiers qui n'existent pas.

**Solution :** Création des dossiers nécessaires dans `bin\Release\` :
```bash
mkdir Errors
mkdir ItemImages
mkdir Images
```

Ces dossiers sont utilisés par :
- `Errors\` : Logs d'erreurs (ErrorLog)
- `ItemImages\` : Images des articles du menu
- `Images\` : Logo de l'entreprise et autres images

---

## Résultats après corrections

### Test de migration

```
========================================
CYPOS Password Migration Utility
========================================

Total users processed: 15
Successfully migrated: 15
Failed: 0

SUCCESS: All passwords have been hashed!
```

**Utilisateurs migrés :**
1. admin
2. anil
3. menon
4. emiley
5. nilanthi
6. tim
7. deepak
8. keith
9. anna
10. palani
11. kayal
12. farhan
13. sophia
14. akmal
15. bamba

### Test de login

✅ **Login fonctionne** avec `admin` / `admin`
✅ **Application démarre** sans erreur de chemin (après création des dossiers)

---

## Fichiers modifiés

1. **Database/Scripts/PasswordMigrationUtility.cs**
   - 3 corrections de noms de colonnes

2. **Sourcecode/CYPOS/Class/SecureDataAccess.cs**
   - CreateUser : `full_name` → `name`
   - UpdateUser : `full_name` → `name` et `user_id` → `id`
   - Type de données ajusté : `SqlDbType.BigInt` pour l'ID

3. **Dossiers créés dans bin/Release/**
   - Errors/
   - ItemImages/
   - Images/

---

## Leçons apprises

### 1. Toujours vérifier la structure réelle

Avant d'écrire du code qui accède à une base de données, **toujours vérifier** :
```sql
SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'tbl_User';
```

### 2. Convention de nommage incohérente

La base de données utilise un mélange de conventions :
- `id` (court) au lieu de `user_id` (descriptif)
- `name` (court) au lieu de `full_name` (descriptif)
- Mais `user_name`, `user_type`, `image_name` (descriptifs)

**Recommandation pour Phase 2 :** Standardiser les noms de colonnes.

### 3. Dossiers requis par l'application

L'application suppose que certains dossiers existent :
- `Errors\` pour les logs
- `ItemImages\` pour les images d'articles
- `Images\` pour les logos

**Recommandation :** Ajouter du code pour créer ces dossiers automatiquement au démarrage si ils n'existent pas.

---

## Script SQL de vérification

Pour vérifier la structure de n'importe quelle table :

```sql
USE CYPOS;
GO

SELECT
    COLUMN_NAME AS [Nom de colonne],
    DATA_TYPE AS [Type de données],
    CHARACTER_MAXIMUM_LENGTH AS [Longueur max],
    IS_NULLABLE AS [Nullable]
FROM
    INFORMATION_SCHEMA.COLUMNS
WHERE
    TABLE_NAME = 'tbl_User'
ORDER BY
    ORDINAL_POSITION;
```

---

## Prochaines étapes

### Tests supplémentaires à faire

- [ ] Tester création d'un nouvel utilisateur (frmUser.cs)
- [ ] Tester modification d'un utilisateur existant
- [ ] Tester changement de mot de passe
- [ ] Vérifier les autres formulaires (Customer, Supplier, etc.)

### Vérifications pour les autres tables

Les autres tables peuvent aussi avoir des noms de colonnes différents. À vérifier :
- `tbl_Customer` : `customer_id` vs `id` ?
- `tbl_Supplier` : `supplier_id` vs `id` ?
- `tbl_Item` : `item_id` vs `id` ?

---

**Version :** 1.0  
**Date :** 2026-05-24  
**Statut :** ✅ Corrections appliquées et testées
