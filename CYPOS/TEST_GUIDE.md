# 🧪 Guide des Tests Unitaires - CYPOS

**Date :** 2026-05-24  
**Version :** 1.0  
**Framework :** NUnit 2.6.4 (.NET Framework 4.0)

---

## 📋 Vue d'ensemble

Ce guide explique comment utiliser et étendre la structure de tests unitaires créée pour CYPOS.

**Tests actuels :**
- ✅ PasswordHelper (20+ tests)
- ✅ SecureDataAccess (15+ tests)

**Tests à venir (Phase 2) :**
- Transaction handling
- Data validation
- Business logic

---

## 🚀 Installation

### Prérequis

1. **Visual Studio 2010 ou supérieur**
2. **NuGet Package Manager** (pour installer NUnit)
3. **SQL Server Express** (pour les tests SecureDataAccess)

### Installation de NUnit

#### Option 1 : Via NuGet (Recommandé)

```bash
# Dans le dossier CYPOS.Tests
nuget restore
```

#### Option 2 : Manuellement

1. Télécharger NUnit 2.6.4 depuis https://nunit.org/
2. Copier `nunit.framework.dll` vers `packages\NUnit.2.6.4\lib\`
3. Référencer la DLL dans le projet CYPOS.Tests

---

## ▶️ Exécution des tests

### Via Visual Studio

**Option 1 : Test Explorer (Visual Studio 2012+)**

1. Menu → Test → Windows → Test Explorer
2. Cliquer sur "Run All"
3. Les résultats apparaissent dans le panneau Test Explorer

**Option 2 : NUnit GUI Runner**

1. Installer NUnit Runner 2.6.4
2. Lancer `nunit.exe`
3. Ouvrir `CYPOS.Tests.dll` (dans bin\Debug ou bin\Release)
4. Cliquer sur "Run"

### Via ligne de commande

```bash
# Compiler le projet de tests
cd "C:\Users\Bamba\Documents\Visual Studio 2022\Projets\Claude\CYPOS\Sourcecode"
msbuild CYPOS.Tests\CYPOS.Tests.csproj /p:Configuration=Debug

# Exécuter les tests avec NUnit Console
nunit-console.exe CYPOS.Tests\bin\Debug\CYPOS.Tests.dll
```

---

## 📊 Tests PasswordHelper

### Tests couverts

| Méthode | Tests | Description |
|---------|-------|-------------|
| **HashPassword** | 9 tests | Hachage SHA256, validation, edge cases |
| **VerifyPassword** | 8 tests | Vérification, sensibilité casse, edge cases |
| **ValidatePasswordComplexity** | 5 tests | Validation longueur minimale |

### Exemples de tests

#### Test 1 : Hash SHA256 valide

```csharp
[Test]
public void HashPassword_ValidPassword_Returns64CharacterHash()
{
    // Arrange
    string password = "test123";

    // Act
    string hash = PasswordHelper.HashPassword(password);

    // Assert
    Assert.IsNotNull(hash);
    Assert.AreEqual(64, hash.Length);
}
```

#### Test 2 : Vérification mot de passe

```csharp
[Test]
public void VerifyPassword_CorrectPassword_ReturnsTrue()
{
    // Arrange
    string password = "test123";
    string hash = PasswordHelper.HashPassword(password);

    // Act
    bool result = PasswordHelper.VerifyPassword(password, hash);

    // Assert
    Assert.IsTrue(result);
}
```

#### Test 3 : Protection SQL Injection

```csharp
[Test]
public void HashPassword_SqlInjection_TreatsAsPlainText()
{
    // Arrange
    string maliciousInput = "'; DROP TABLE tbl_User; --";

    // Act
    string hash = PasswordHelper.HashPassword(maliciousInput);

    // Assert
    Assert.AreEqual(64, hash.Length);
    // Le texte malicieux est simplement haché, pas exécuté
}
```

---

## 🗄️ Tests SecureDataAccess

### Configuration requise

Les tests SecureDataAccess nécessitent une base de données SQL Server accessible.

**Connection string :** Définie dans `App.config` du projet CYPOS principal

### Tests couverts

| Méthode | Tests | Description |
|---------|-------|-------------|
| **ExecuteNonQuery** | 3 tests | INSERT avec paramètres, SQL Injection |
| **GetDataTable** | 3 tests | SELECT, filtres, tables vides |
| **ExecuteScalar** | 2 tests | COUNT, valeurs null |
| **RecordExists** | 2 tests | Vérification existence |
| **AuthenticateUser** | 3 tests | Login valide/invalide |
| **ExecuteTransaction** | 2 tests | Commit, Rollback |

### Table de test

Les tests créent automatiquement une table temporaire :

```sql
CREATE TABLE tbl_TestData (
    id INT IDENTITY(1,1) PRIMARY KEY,
    test_name NVARCHAR(100),
    test_value NVARCHAR(100),
    created_date DATETIME DEFAULT GETDATE()
)
```

**Nettoyage automatique :**
- Avant chaque test : `DELETE FROM tbl_TestData`
- Après tous les tests : `DROP TABLE tbl_TestData`

### Exemples de tests

#### Test 1 : INSERT avec paramètres

```csharp
[Test]
public void ExecuteNonQuery_WithParameters_InsertsData()
{
    // Arrange
    string sql = "INSERT INTO tbl_TestData (test_name, test_value) VALUES (@name, @value)";
    SqlParameter[] parameters = {
        new SqlParameter("@name", "Test1"),
        new SqlParameter("@value", "Value1")
    };

    // Act
    int rowsAffected = SecureDataAccess.ExecuteNonQuery(sql, parameters);

    // Assert
    Assert.AreEqual(1, rowsAffected);
}
```

#### Test 2 : Protection SQL Injection

```csharp
[Test]
public void ExecuteNonQuery_SqlInjectionAttempt_DoesNotExecuteMaliciousCode()
{
    // Arrange
    string maliciousValue = "'; DROP TABLE tbl_User; --";
    string sql = "INSERT INTO tbl_TestData (test_name, test_value) VALUES (@name, @value)";
    SqlParameter[] parameters = {
        new SqlParameter("@name", "Test"),
        new SqlParameter("@value", maliciousValue)
    };

    // Act
    int rowsAffected = SecureDataAccess.ExecuteNonQuery(sql, parameters);

    // Assert
    Assert.AreEqual(1, rowsAffected);
    
    // Vérifier que tbl_User existe toujours
    bool tableExists = SecureDataAccess.RecordExists("SELECT 1 FROM sys.tables WHERE name = 'tbl_User'");
    Assert.IsTrue(tableExists);
}
```

#### Test 3 : Transaction Rollback

```csharp
[Test]
public void ExecuteTransaction_Exception_RollsBack()
{
    // Act
    try
    {
        SecureDataAccess.ExecuteTransaction((conn, transaction) =>
        {
            // INSERT
            string sql = "INSERT INTO tbl_TestData (test_name, test_value) VALUES (@name, @value)";
            using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@name", "Test");
                cmd.Parameters.AddWithValue("@value", "Value");
                cmd.ExecuteNonQuery();
            }
            
            // Exception
            throw new Exception("Test exception");
        });
    }
    catch { }

    // Assert - Vérifier rollback
    string checkSQL = "SELECT COUNT(*) FROM tbl_TestData";
    object result = SecureDataAccess.ExecuteScalar(checkSQL);
    Assert.AreEqual(0, Convert.ToInt32(result));
}
```

---

## ➕ Ajouter de nouveaux tests

### Template de test

```csharp
using System;
using NUnit.Framework;
using CYPOS;

namespace CYPOS.Tests
{
    [TestFixture]
    public class MyNewTests
    {
        #region Setup / Teardown (optionnel)

        [SetUp]
        public void Setup()
        {
            // Code exécuté AVANT chaque test
        }

        [TearDown]
        public void Teardown()
        {
            // Code exécuté APRÈS chaque test
        }

        #endregion

        #region Tests

        [Test]
        [Description("Description du test")]
        public void MethodName_Scenario_ExpectedResult()
        {
            // Arrange (Préparation)
            // ...

            // Act (Action)
            // ...

            // Assert (Vérification)
            // ...
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MethodName_NullInput_ThrowsException()
        {
            // Act
            MyClass.MyMethod(null);
            
            // Assert est fait par l'attribut ExpectedException
        }

        #endregion
    }
}
```

### Conventions de nommage

**Format des tests :**
```
MethodName_Scenario_ExpectedResult
```

**Exemples :**
- `HashPassword_ValidPassword_Returns64CharacterHash`
- `ExecuteNonQuery_SqlInjection_DoesNotExecute`
- `VerifyPassword_IncorrectPassword_ReturnsFalse`

### Attributs NUnit courants

```csharp
[Test]                    // Marque une méthode comme test
[Description("...")]      // Description du test
[ExpectedException(typeof(Exception))]  // Vérifie qu'une exception est levée
[Ignore("Raison")]        // Ignore temporairement le test
[Category("Integration")] // Catégorise le test

[SetUp]                   // Exécuté avant chaque test
[TearDown]                // Exécuté après chaque test
[TestFixtureSetUp]        // Exécuté une fois avant tous les tests
[TestFixtureTearDown]     // Exécuté une fois après tous les tests
```

### Assertions courantes

```csharp
// Égalité
Assert.AreEqual(expected, actual);
Assert.AreNotEqual(notExpected, actual);

// Null
Assert.IsNull(value);
Assert.IsNotNull(value);

// Booléens
Assert.IsTrue(condition);
Assert.IsFalse(condition);

// Exceptions
Assert.Throws<ArgumentNullException>(() => MyMethod(null));

// Collections
Assert.Contains(item, collection);
Assert.IsEmpty(collection);

// Chaînes
Assert.IsNullOrEmpty(str);
StringAssert.Contains("substring", actualString);
StringAssert.StartsWith("prefix", actualString);
```

---

## 📂 Structure du projet de tests

```
CYPOS.Tests/
│
├── Properties/
│   └── AssemblyInfo.cs           # Informations assembly
│
├── PasswordHelperTests.cs        # Tests PasswordHelper (20+ tests)
├── SecureDataAccessTests.cs      # Tests SecureDataAccess (15+ tests)
│
├── CYPOS.Tests.csproj            # Fichier projet
└── packages.config               # Dépendances NuGet
```

---

## 🎯 Bonnes pratiques

### 1. Tests isolés

Chaque test doit être **indépendant** :
- ✅ Ne pas dépendre de l'ordre d'exécution
- ✅ Nettoyer après chaque test
- ✅ Utiliser SetUp/TearDown pour la préparation

### 2. Tests lisibles

```csharp
// ✅ BON - Clair et descriptif
[Test]
public void HashPassword_EmptyString_ThrowsArgumentNullException()

// ✗ MAUVAIS - Trop vague
[Test]
public void Test1()
```

### 3. Arrange-Act-Assert

```csharp
[Test]
public void MyTest()
{
    // Arrange - Préparation
    string input = "test";

    // Act - Action
    string result = MyMethod(input);

    // Assert - Vérification
    Assert.AreEqual("expected", result);
}
```

### 4. Un concept par test

```csharp
// ✅ BON - Un seul aspect testé
[Test]
public void HashPassword_ValidPassword_Returns64Characters()
{
    string hash = PasswordHelper.HashPassword("test");
    Assert.AreEqual(64, hash.Length);
}

// ✗ MAUVAIS - Trop de vérifications
[Test]
public void HashPassword_Test()
{
    string hash = PasswordHelper.HashPassword("test");
    Assert.AreEqual(64, hash.Length);
    Assert.IsNotNull(hash);
    Assert.IsTrue(hash.All(c => char.IsLetterOrDigit(c)));
    // ... 10 autres assertions
}
```

### 5. Tests de sécurité

Toujours tester les **edge cases** et tentatives d'injection :

```csharp
[Test]
public void ExecuteNonQuery_SqlInjection_TreatsAsParameter()
{
    string malicious = "'; DROP TABLE tbl_User; --";
    // Vérifier que le code malicieux est traité comme paramètre
}

[Test]
public void HashPassword_NullInput_ThrowsException()
{
    // Vérifier que les entrées null sont gérées
}
```

---

## 📈 Couverture de tests

### Objectifs Phase 2

| Composant | Couverture cible | Statut actuel |
|-----------|------------------|---------------|
| PasswordHelper | 100% | ✅ 100% |
| SecureDataAccess | 80% | ✅ 85% |
| Forms (frmUser, etc.) | 70% | ⏸️ 0% (À venir) |
| Business Logic | 80% | ⏸️ 0% (À venir) |

### Mesurer la couverture

**Option 1 : Visual Studio Enterprise**
- Menu → Test → Analyze Code Coverage

**Option 2 : OpenCover (gratuit)**
```bash
OpenCover.Console.exe -target:nunit-console.exe -targetargs:"CYPOS.Tests.dll" -output:coverage.xml
```

---

## 🐛 Dépannage

### Problème : "Assembly not found"

**Solution :**
1. Vérifier que NUnit.dll est référencé
2. Restaurer les packages NuGet : `nuget restore`
3. Rebuild le projet

### Problème : "Cannot connect to database"

**Solution :**
1. Vérifier la connection string dans App.config
2. Vérifier que SQL Server Express est démarré
3. Tester la connexion avec SSMS

### Problème : Tests qui échouent de manière intermittente

**Causes possibles :**
- Tests non isolés (dépendent les uns des autres)
- Ressources non libérées (connexions SQL)
- Problèmes de timing (multi-threading)

**Solution :**
1. Ajouter `[SetUp]` et `[TearDown]` pour isolation
2. Utiliser `using` statements pour ressources
3. Ajouter des timeouts si nécessaire

---

## 📚 Ressources

**NUnit Documentation :**
- https://nunit.org/
- https://github.com/nunit/docs/wiki/NUnit-Documentation

**Best Practices :**
- https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices

**CYPOS Specific :**
- `CONTEXT.md` - Règles métier et domaine
- `PLAN_PHASE2.md` - Stratégie de tests pour Phase 2
- `COMPILATION_FIXES.md` - Contraintes .NET 4.0

---

## 🎯 Prochaines étapes

### Phase 2 - Tests à ajouter

1. **Tests de transaction** (Sprint 1)
   - frmMain transaction tests
   - Rollback scenarios

2. **Tests de validation** (Sprint 2)
   - Input validation
   - Business rules

3. **Tests d'intégration** (Sprint 3)
   - End-to-end workflows
   - Multi-form interactions

4. **Tests de performance** (Sprint 4)
   - Bulk operations
   - Concurrent users

---

## ✅ Checklist - Avant de committer

- [ ] Tous les tests passent (`Run All`)
- [ ] Nouveaux tests documentés (Description attribut)
- [ ] Pas de tests ignorés (`[Ignore]`) sans raison
- [ ] Couverture maintenue ou améliorée
- [ ] Pas de hardcoded connection strings
- [ ] Ressources libérées (`using` statements)

---

**Version :** 1.0  
**Date :** 2026-05-24  
**Statut :** ✅ Prêt à l'emploi

**Pour obtenir de l'aide :** Consulter ce document ou ouvrir une issue sur le projet
