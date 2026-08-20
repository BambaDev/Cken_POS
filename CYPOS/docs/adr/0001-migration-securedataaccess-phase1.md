# ADR 0001 : Migration vers SecureDataAccess pour corriger les vulnérabilités SQL Injection

**Date :** 2026-05-24  
**Statut :** ✅ Accepté  
**Décideurs :** Équipe projet CYPOS  
**Tags :** sécurité, sql-injection, phase1

---

## Contexte

Le système CYPOS actuel utilise une classe `DataAccess.cs` qui construit des requêtes SQL par concaténation de chaînes. Cette approche présente des vulnérabilités critiques :

1. **SQL Injection** : 325 appels vulnérables, 98 concaténations directes de contrôles UI
   - Exemple : `frmLogin.cs:114` permet de bypasser l'authentification avec `' OR '1'='1`
2. **Mots de passe en clair** : Stockage sans hachage dans la base de données
3. **Gestion des ressources** : Connexion SQL statique jamais fermée, pas de libération de ressources
4. **Pas de transactions** : Opérations multi-étapes sans garantie d'intégrité

### Logs d'erreur identifiés

- `frmSalesReturn` : "Error converting varchar to bigint" (3 fois)
- `frmSalesReturn` : "There is no row at position 0" (4 fois)

---

## Décision

Nous créons une nouvelle classe `SecureDataAccess.cs` avec une approche hybride :

### 1. Méthodes génériques avec SqlParameter

```csharp
public static class SecureDataAccess
{
    public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
    public static DataTable GetDataTable(string sql, SqlParameter[] parameters = null)
    public static DataSet GetDataSet(string sql, SqlParameter[] parameters = null)
    public static object ExecuteScalar(string sql, SqlParameter[] parameters = null)
    public static void ExecuteTransaction(Action<SqlConnection, SqlTransaction> operations)
}
```

### 2. Méthodes spécialisées pour opérations critiques

```csharp
public static bool AuthenticateUser(string username, string password, out UserInfo userInfo)
public static void CreateUser(string username, string password, string userType, ...)
public static void UpdateUser(int userId, string username, string password, ...)
```

### 3. Classe PasswordHelper pour hachage

```csharp
public static class PasswordHelper
{
    public static string HashPassword(string password)  // SHA256
    public static bool VerifyPassword(string password, string hash)
}
```

### 4. Migration progressive (Phase 1)

**Formulaires critiques à migrer immédiatement :**
1. `frmLogin` - Authentification (CRITIQUE)
2. `frmUser` - Gestion des utilisateurs (CRITIQUE)
3. `frmPayment` - Paiements avec transactions (CRITIQUE)
4. `frmCustomer` - CRUD clients (IMPORTANT)
5. `frmSupplier` - CRUD fournisseurs (IMPORTANT)
6. `frmSalesReturn` - Retours + correction bugs (IMPORTANT)

**Les 32 autres formulaires** seront migrés en Phase 2.

### 5. Coexistence temporaire

- `DataAccess.cs` reste en place (non modifié, non supprimé)
- `SecureDataAccess.cs` coexiste avec l'ancien système
- Migration formulaire par formulaire
- Suppression de `DataAccess.cs` uniquement en fin de Phase 2

---

## Alternatives considérées

### Alternative A : Corriger DataAccess.cs existante

**Avantages :**
- Pas de nouvelle classe
- Changements localisés

**Inconvénients :**
- Risque de casser tous les formulaires existants
- Difficile de tester progressivement
- Mélange ancien et nouveau code

**Rejeté** : Trop risqué, pas de migration progressive possible

### Alternative B : ORM (Entity Framework, Dapper)

**Avantages :**
- Solution moderne et éprouvée
- Protection automatique contre SQL Injection
- Mapping objet-relationnel

**Inconvénients :**
- Courbe d'apprentissage importante
- Refactoring massif de tout le code
- Hors scope de Phase 1 (sécurité + bugs)
- Migration .NET Framework 4.0 → moderne nécessaire

**Rejeté pour Phase 1** : Trop de changements, réservé pour Phase 3 (Modernisation)

### Alternative C : Stored Procedures

**Avantages :**
- Logique SQL centralisée en base
- Protection contre SQL Injection
- Performance potentiellement meilleure

**Inconvénients :**
- Nécessite réécriture de toutes les requêtes
- Maintenance répartie entre C# et SQL
- Moins flexible pour modifications futures
- Courbe d'apprentissage pour l'équipe

**Rejeté** : Trop de travail pour Phase 1, moins maintenable à long terme

### Alternative D : Reporter la correction à Phase 2

**Avantages :**
- Focus sur refactoring en Phase 2
- Correction globale en une fois

**Inconvénients :**
- Vulnérabilités critiques restent présentes
- Risque de sécurité inacceptable
- Mots de passe en clair exposés

**Rejeté** : Inacceptable du point de vue sécurité

---

## Conséquences

### Positives

1. **Sécurité renforcée**
   - Élimination des SQL Injection dans les 6 formulaires critiques
   - Mots de passe hachés (SHA256)
   - Using statements pour libération des ressources

2. **Migration progressive sans risque**
   - Coexistence des deux systèmes
   - Tests formulaire par formulaire
   - Rollback facile si problème

3. **Base pour Phase 2**
   - Pattern établi pour les autres formulaires
   - Documentation et exemples disponibles
   - Équipe formée sur la nouvelle approche

4. **Intégrité des données**
   - Transactions SQL pour opérations critiques
   - Rollback automatique en cas d'erreur

5. **Correction des bugs existants**
   - frmSalesReturn : bugs résolus en même temps que migration
   - Validation robuste des données

### Négatives

1. **Duplication temporaire**
   - Deux classes d'accès aux données coexistent
   - Confusion possible pour les développeurs
   - **Mitigation** : Documentation claire, convention de nommage

2. **Maintenance de deux systèmes**
   - Bug fix doit considérer les deux approches
   - **Mitigation** : Phase 2 planifiée rapidement

3. **Temps de développement**
   - 6-8 heures de développement
   - **Mitigation** : Investissement nécessaire pour la sécurité

4. **Migration de la base de données**
   - Downtime de 1-2 heures
   - Risque de rollback si problème
   - **Mitigation** : Tests exhaustifs, scripts de rollback testés

5. **Formulaires non migrés restent vulnérables**
   - 32 formulaires à risque jusqu'à Phase 2
   - **Mitigation** : Focus sur les critiques d'abord, Phase 2 rapide

---

## Détails d'implémentation

### Structure de SecureDataAccess.cs

```csharp
using System;
using System.Data;
using System.Data.SqlClient;

namespace cypos
{
    public static class SecureDataAccess
    {
        private static string ConnectionString = 
            "Data Source=.\\SQLEXPRESS;Initial Catalog=CYPOS;Integrated Security=True;";
        
        private static ErrorLog errorLog = new ErrorLog();

        // Méthodes génériques avec SqlParameter
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.ExecuteNonQuery", 
                               AppDomain.CurrentDomain.BaseDirectory + "Errors\\");
                throw;
            }
        }

        // Support des transactions
        public static void ExecuteTransaction(Action<SqlConnection, SqlTransaction> operations)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        operations(conn, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        errorLog.Write(ex.Message, "SecureDataAccess.ExecuteTransaction", 
                                       AppDomain.CurrentDomain.BaseDirectory + "Errors\\");
                        throw;
                    }
                }
            }
        }

        // Méthodes spécialisées
        public static bool AuthenticateUser(string username, string password, 
                                           out string userType)
        {
            string sql = @"SELECT user_type, password 
                          FROM tbl_User 
                          WHERE user_name = @username";
            
            SqlParameter[] parameters = {
                new SqlParameter("@username", SqlDbType.NVarChar) { Value = username }
            };

            DataTable dt = GetDataTable(sql, parameters);
            
            if (dt.Rows.Count == 0)
            {
                userType = null;
                return false;
            }

            string storedHash = dt.Rows[0]["password"].ToString();
            userType = dt.Rows[0]["user_type"].ToString();
            
            return PasswordHelper.VerifyPassword(password, storedHash);
        }

        // ... autres méthodes
    }
}
```

### Structure de PasswordHelper.cs

```csharp
using System;
using System.Security.Cryptography;
using System.Text;

namespace cypos
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string password, string hash)
        {
            string hashOfInput = HashPassword(password);
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }
    }
}
```

### Migration de frmLogin (Exemple)

**Avant (Vulnérable) :**
```csharp
string strSQL = "SELECT user_name, password, user_type FROM tbl_User " + 
                "WHERE user_name = '" + txtUserName.Text + "' " +
                "and password = '" + txtPassword.Text + "'";
DataTable dt = DataAccess.GetDataTable(strSQL);
```

**Après (Sécurisé) :**
```csharp
string userType;
bool authenticated = SecureDataAccess.AuthenticateUser(
    txtUserName.Text, 
    txtPassword.Text, 
    out userType
);

if (authenticated)
{
    UserInfo.UserName = txtUserName.Text;
    UserInfo.UserType = userType;
    // ...
}
```

---

## Validation et tests

### Critères de succès

1. **Sécurité**
   - ✅ Injection SQL `' OR '1'='1` échoue sur login
   - ✅ Tous les mots de passe sont hachés (64 caractères)
   - ✅ Aucune connexion SQL non fermée

2. **Fonctionnalité**
   - ✅ Login admin/admin réussit
   - ✅ Création/modification utilisateur fonctionne
   - ✅ Paiements avec transactions réussissent
   - ✅ CRUD clients/fournisseurs fonctionne
   - ✅ frmSalesReturn : bugs résolus

3. **Régression**
   - ✅ Formulaires non migrés fonctionnent toujours
   - ✅ Aucune nouvelle erreur dans les logs

### Plan de test

Voir `PLAN_PHASE1.md` section "Checklist de validation post-déploiement"

---

## Migration de la base de données

### Script SQL

```sql
-- migration_phase1.sql

-- Étape 1 : Backup
SELECT * INTO tbl_User_Backup_PrePhase1 FROM tbl_User;

-- Étape 2 : Augmenter colonne password
ALTER TABLE tbl_User ALTER COLUMN password VARCHAR(256) NOT NULL;

-- Étape 3 : Le hachage est fait par le code C# (PasswordHelper)
-- Exécuter l'utilitaire de migration des mots de passe après ce script

-- Validation
SELECT 
    COUNT(*) AS TotalUsers,
    COUNT(CASE WHEN LEN(password) = 64 THEN 1 END) AS HashedUsers,
    COUNT(CASE WHEN LEN(password) < 64 THEN 1 END) AS UnhashedUsers
FROM tbl_User;
```

---

## Références

- **OWASP SQL Injection** : https://owasp.org/www-community/attacks/SQL_Injection
- **Microsoft SqlParameter Documentation** : https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparameter
- **NIST Password Guidelines** : https://pages.nist.gov/800-63-3/sp800-63b.html
- **CONTEXT.md** : Documentation du domaine CYPOS
- **PLAN_PHASE1.md** : Plan détaillé de la Phase 1

---

## Historique des modifications

| Date       | Version | Auteur          | Changements                    |
|------------|---------|-----------------|--------------------------------|
| 2026-05-24 | 1.0     | Équipe CYPOS    | Création initiale de l'ADR     |

---

## Décision suivante

**ADR 0002** : Choix de l'algorithme de hachage pour Phase 2 (BCrypt vs Argon2 vs SHA256 + Salt)

**À traiter en Phase 2** lorsque tous les formulaires seront migrés.
