# CYPOS - Feuille de Route

## Vue d'ensemble

Roadmap de modernisation et sécurisation du système CYPOS en 3 phases.

```
┌─────────────────────────────────────────────────────────────────────────┐
│                        ÉTAT ACTUEL (Legacy)                              │
├─────────────────────────────────────────────────────────────────────────┤
│ • .NET Framework 4.0 / WinForms                                         │
│ • SQL Server Express avec SQL Injection                                 │
│ • Mots de passe en clair                                                │
│ • 38 formulaires, 325 requêtes vulnérables                              │
│ • Bugs critiques dans frmSalesReturn                                    │
│ • Connexions SQL statiques non fermées                                  │
└─────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│            PHASE 1 : Sécurité et Corrections de Bugs                    │
│                    Durée : 1-2 semaines                                  │
├─────────────────────────────────────────────────────────────────────────┤
│ ✅ Créer SecureDataAccess avec SqlParameter                             │
│ ✅ Implémenter PasswordHelper (SHA256)                                  │
│ ✅ Migrer 6 formulaires critiques :                                     │
│    • frmLogin (authentification sécurisée)                              │
│    • frmUser (gestion utilisateurs)                                     │
│    • frmPayment (paiements avec transactions)                           │
│    • frmCustomer (CRUD clients)                                         │
│    • frmSupplier (CRUD fournisseurs)                                    │
│    • frmSalesReturn (correction bugs + sécurité)                        │
│ ✅ Scripts de migration SQL + rollback                                  │
│ ✅ Documentation (CONTEXT.md, PLAN_PHASE1.md, ADR 0001)                 │
│                                                                          │
│ 📊 Résultat attendu :                                                   │
│    • 0 SQL Injection dans les 6 formulaires critiques                   │
│    • 100% mots de passe hachés                                          │
│    • Bugs frmSalesReturn résolus                                        │
│    • Base solide pour Phase 2                                           │
└─────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│         PHASE 2 : Refactoring et Maintenabilité                         │
│                    Durée : 3-4 semaines                                  │
├─────────────────────────────────────────────────────────────────────────┤
│ 🔄 Migration complète vers SecureDataAccess                             │
│    • Migrer les 32 formulaires restants                                 │
│    • Supprimer DataAccess.cs (legacy)                                   │
│                                                                          │
│ 🏗️ Refactoring de la logique métier                                     │
│    • Extraire règles de calcul (montants, taxes, remises)              │
│    • Créer classes métier (Invoice, Order, Payment)                    │
│    • Pattern Repository                                                 │
│    • Services pour logique complexe                                     │
│                                                                          │
│ 🧪 Tests unitaires                                                       │
│    • Framework de test (NUnit ou xUnit)                                 │
│    • Tests SecureDataAccess                                             │
│    • Tests règles métier                                                │
│    • Code coverage > 70%                                                │
│                                                                          │
│ 🔐 Amélioration sécurité                                                │
│    • Migrer vers BCrypt ou Argon2 (ADR 0002)                           │
│    • Ajouter salt aux mots de passe                                     │
│    • Politique de complexité                                            │
│    • Audit logs (tentatives login échouées)                             │
│                                                                          │
│ 🐛 Gestion des erreurs                                                  │
│    • Exceptions personnalisées                                          │
│    • Gestion centralisée                                                │
│    • Logs structurés (Serilog)                                          │
│                                                                          │
│ 📊 Résultat attendu :                                                   │
│    • 100% des formulaires sécurisés                                     │
│    • Code maintenable et testable                                       │
│    • Couverture de tests > 70%                                          │
│    • Performance optimisée                                              │
│    • Base prête pour modernisation                                      │
└─────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                PHASE 3 : Modernisation                                   │
│                    Durée : 2-3 mois                                      │
├─────────────────────────────────────────────────────────────────────────┤
│ 🚀 Migration technologique                                              │
│    • .NET 6/8 (au lieu de .NET 4.0)                                     │
│    • WPF + MVVM (au lieu de WinForms)                                   │
│    • Entity Framework Core (ORM moderne)                                │
│    • Dependency Injection                                               │
│                                                                          │
│ 🎨 Interface utilisateur moderne                                        │
│    • Material Design ou Fluent Design                                   │
│    • Responsive (support tablettes)                                     │
│    • Thèmes clairs/sombres                                              │
│    • Animations et transitions                                          │
│    • Accessibilité (WCAG 2.1)                                           │
│                                                                          │
│ 🌐 Architecture moderne                                                 │
│    • API REST (ASP.NET Core)                                            │
│    • Client lourd (WPF) + Client web (Blazor/React)                    │
│    • Application mobile (MAUI ou React Native)                          │
│    • Architecture microservices (optionnel)                             │
│                                                                          │
│ ⚡ Nouvelles fonctionnalités                                            │
│    • Mode multi-postes avec synchronisation temps réel                  │
│    • Intégration paiements électroniques (Stripe, PayPal)              │
│    • Commande en ligne (app mobile client)                              │
│    • Dashboard analytics en temps réel                                  │
│    • Notifications push                                                 │
│    • Mode hors-ligne avec sync                                          │
│    • Export vers comptabilité (Sage, QuickBooks)                        │
│                                                                          │
│ ☁️ Cloud et DevOps                                                      │
│    • Déploiement Azure/AWS                                              │
│    • CI/CD (GitHub Actions, Azure DevOps)                               │
│    • Containers (Docker)                                                │
│    • Monitoring (Application Insights)                                  │
│    • Backup automatique                                                 │
│                                                                          │
│ 📊 Résultat attendu :                                                   │
│    • Application moderne et performante                                 │
│    • Multi-plateforme (Windows, Web, Mobile)                            │
│    • Scalable et cloud-ready                                            │
│    • Compétitif sur le marché                                           │
└─────────────────────────────────────────────────────────────────────────┘

```

---

## Chronologie

### 2026 - Trimestre 2

**Mai 2026 :** Phase 1 - Semaines 1-2
- Semaine 1 : Développement SecureDataAccess + PasswordHelper
- Semaine 2 : Migration formulaires + tests + déploiement

### 2026 - Trimestre 3

**Juin-Juillet 2026 :** Phase 2 - Semaines 3-6
- Semaine 3-4 : Migration des 32 formulaires restants
- Semaine 5 : Refactoring logique métier + tests unitaires
- Semaine 6 : Amélioration sécurité + gestion erreurs

### 2026 - Trimestre 4

**Août-Octobre 2026 :** Phase 3 - Semaines 7-18
- Semaine 7-8 : Planification détaillée Phase 3
- Semaine 9-12 : Migration .NET 6/8 + WPF
- Semaine 13-15 : API REST + intégrations
- Semaine 16-18 : Application mobile + tests + déploiement

---

## Dépendances entre phases

```
Phase 1 ──────► Phase 2 ──────► Phase 3
   │               │               │
   │               │               │
   ▼               ▼               ▼
Sécurité      Refactoring   Modernisation
  base          complet       complète
   │               │               │
   │               │               │
Bloquant     Fortement      Nécessite
pour Phase 2  recommandé    Phase 2
              avant Phase 3
```

**Règles :**
- ✅ Phase 2 peut commencer dès Phase 1 terminée
- ⚠️ Phase 3 doit attendre la fin de Phase 2 (refactoring nécessaire)
- 🔄 Chaque phase peut être itérative si nécessaire

---

## Métriques de succès global

### Sécurité

| Métrique                        | État actuel | Phase 1  | Phase 2  | Phase 3  |
|---------------------------------|-------------|----------|----------|----------|
| Vulnérabilités SQL Injection    | 325         | 6→0      | 0        | 0        |
| Mots de passe hachés            | 0%          | 100%     | 100%     | 100%     |
| Audit de sécurité               | ❌          | ⚠️       | ✅       | ✅       |
| Conformité OWASP Top 10         | ❌          | ⚠️       | ✅       | ✅       |

### Qualité du code

| Métrique                        | État actuel | Phase 1  | Phase 2  | Phase 3  |
|---------------------------------|-------------|----------|----------|----------|
| Code coverage (tests)           | 0%          | 0%       | >70%     | >80%     |
| Dette technique (jours)         | 60          | 50       | 20       | 5        |
| Complexité cyclomatique         | Élevée      | Élevée   | Moyenne  | Faible   |
| Duplication de code             | 25%         | 25%      | <10%     | <5%      |

### Performance

| Métrique                        | État actuel | Phase 1  | Phase 2  | Phase 3  |
|---------------------------------|-------------|----------|----------|----------|
| Temps de login                  | 2s          | 2s       | 1.5s     | 0.5s     |
| Temps de recherche              | 3s          | 3s       | 2s       | 0.8s     |
| Mémoire utilisée                | 150 MB      | 140 MB   | 100 MB   | 80 MB    |
| Temps de démarrage              | 5s          | 5s       | 4s       | 2s       |

### Maintenabilité

| Métrique                        | État actuel | Phase 1  | Phase 2  | Phase 3  |
|---------------------------------|-------------|----------|----------|----------|
| Documentation                   | ❌          | ✅       | ✅       | ✅       |
| Architecture claire             | ❌          | ⚠️       | ✅       | ✅       |
| Facilité d'ajout de features    | Difficile   | Difficile| Moyenne  | Facile   |
| Temps de formation nouveaux dev | 4 semaines  | 4 sem.   | 2 sem.   | 1 sem.   |

---

## Risques et mitigations

### Phase 1

| Risque                              | Probabilité | Impact   | Mitigation                          |
|-------------------------------------|-------------|----------|-------------------------------------|
| Mots de passe hachés incompatibles  | Faible      | Critique | Tests exhaustifs + script rollback  |
| Régression formulaires non migrés   | Très faible | Moyen    | Tests de régression                 |
| Performance dégradée                | Très faible | Faible   | SQL Connection Pooling automatique  |

### Phase 2

| Risque                              | Probabilité | Impact   | Mitigation                          |
|-------------------------------------|-------------|----------|-------------------------------------|
| Bugs introduits lors du refactoring | Moyenne     | Moyen    | Tests unitaires + code review       |
| Dépassement de budget temps         | Moyenne     | Faible   | Planification itérative             |
| Résistance au changement            | Faible      | Faible   | Formation équipe                    |

### Phase 3

| Risque                              | Probabilité | Impact   | Mitigation                          |
|-------------------------------------|-------------|----------|-------------------------------------|
| Migration .NET 4.0→8 complexe       | Moyenne     | Élevé    | POC préalable + analyse dépendances |
| Coût de licence cloud élevé         | Faible      | Moyen    | Analyse coûts + optimisation        |
| Perte de fonctionnalités périph.    | Moyenne     | Moyen    | Audit matériel + alternatives       |

---

## Budget estimé

### Phase 1 : Sécurité et Corrections

| Poste                      | Heures | Coût estimé |
|----------------------------|--------|-------------|
| Développement              | 8h     | -           |
| Tests                      | 3h     | -           |
| Déploiement                | 2h     | -           |
| Documentation              | 2h     | -           |
| **Total Phase 1**          | **15h**| -           |

### Phase 2 : Refactoring

| Poste                      | Heures | Coût estimé |
|----------------------------|--------|-------------|
| Migration formulaires      | 40h    | -           |
| Refactoring métier         | 30h    | -           |
| Tests unitaires            | 20h    | -           |
| Amélioration sécurité      | 10h    | -           |
| Documentation              | 10h    | -           |
| **Total Phase 2**          | **110h**| -          |

### Phase 3 : Modernisation

| Poste                      | Heures | Coût estimé |
|----------------------------|--------|-------------|
| Migration .NET + WPF       | 80h    | -           |
| API REST                   | 40h    | -           |
| Application mobile         | 60h    | -           |
| Intégrations               | 30h    | -           |
| UI/UX moderne              | 40h    | -           |
| Tests                      | 30h    | -           |
| DevOps + Cloud             | 20h    | -           |
| Documentation              | 20h    | -           |
| **Total Phase 3**          | **320h**| -          |

### Total Programme

**Total général : ~445 heures** (soit ~11 semaines à temps plein)

---

## Prochaines actions immédiates

### ✅ Terminé

1. Planification complète de Phase 1
2. Analyse du code existant
3. Identification des vulnérabilités
4. Création de la documentation :
   - CONTEXT.md
   - PLAN_PHASE1.md
   - docs/adr/0001-migration-securedataaccess-phase1.md
   - ROADMAP.md (ce document)
5. Création des 13 tâches de Phase 1

### 🔜 À faire (Phase 1)

1. **Semaine 1 - Développement**
   - Tâche #1 : Créer SecureDataAccess.cs
   - Tâche #2 : Créer PasswordHelper.cs
   - Tâche #3-4 : Scripts SQL migration + rollback
   - Tâche #5-10 : Migrer les 6 formulaires critiques

2. **Semaine 2 - Tests et Déploiement**
   - Tâche #11 : Documentation de migration
   - Tâche #12 : Tests de validation complets
   - Tâche #13 : Package de déploiement

### 📋 Backlog (Phase 2+)

- Planification détaillée de Phase 2
- Migration des 32 formulaires restants
- Refactoring de la logique métier
- Tests unitaires
- Amélioration sécurité (BCrypt, salt)

---

## Ressources et références

### Documentation projet

- **CONTEXT.md** : Glossaire et règles métier CYPOS
- **PLAN_PHASE1.md** : Plan détaillé Phase 1
- **docs/adr/** : Architecture Decision Records
- **CLAUDE.md** : Configuration des compétences d'agents

### Ressources externes

- [OWASP SQL Injection](https://owasp.org/www-community/attacks/SQL_Injection)
- [Microsoft SqlParameter](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparameter)
- [NIST Password Guidelines](https://pages.nist.gov/800-63-3/sp800-63b.html)
- [.NET Migration Guide](https://learn.microsoft.com/en-us/dotnet/core/porting/)

### Contacts

Pour questions ou support :
- Consulter la documentation projet
- Consulter les logs d'erreur : `bin/Debug/Errors/errlog_[DATE].txt`
- Ouvrir une issue GitHub (si configuré)

---

**Dernière mise à jour :** 2026-05-24  
**Version :** 1.0  
**Statut global :** 📋 Phase 1 planifiée - Prêt à démarrer
