# CYPOS - Contexte du Domaine

## Vue d'ensemble

CYPOS (Cyber Point of Sale) est un système de point de vente conçu pour les restaurants avec service à table. Le système gère l'ensemble du cycle de vie d'une commande restaurant, de la prise de commande à l'encaissement, en passant par la communication avec la cuisine.

## Glossaire du domaine

### Concepts de base

**Invoice (Facture)**
Une facture client générée lors de la finalisation d'une commande. Contient les articles commandés, les prix, les taxes, les remises et le montant total.

**Order Type (Type de commande)**
Le mode de service de la commande :
- **Dine-in** : Service à table dans le restaurant
- **Take-away** : Commande à emporter
- **Delivery** : Livraison à domicile
- **Pickup** : Retrait par le client

**Table**
Table physique du restaurant. Associée à une **Table Location** (zone/emplacement). Une table peut avoir un statut ouvert (commande en cours) ou fermé (disponible).

**Item (Article)**
Produit vendable du menu. Peut avoir :
- Un code-barres (barcode)
- Une catégorie
- Un prix de vente
- Des taxes (Tax1, Tax2)
- Une image
- Un niveau de stock

**Modifier (Modificateur)**
Option de personnalisation d'un article (ex: sans mayo, extra fromage, cuisson à point). Peut avoir un coût additionnel.

**Category (Catégorie)**
Classification des articles du menu (Entrées, Plats, Desserts, Boissons, etc.).

### Opérations

**Hold (Mise en attente)**
Sauvegarde temporaire d'une commande en cours pour la reprendre plus tard. La commande reste associée à la table mais n'est pas encore envoyée en cuisine.

**Recall (Rappel)**
Récupération d'une commande mise en attente (hold) ou d'une facture précédente pour modification ou réimpression.

**KOT (Kitchen Order Ticket)**
Ticket de commande envoyé à la cuisine. Contient les articles à préparer pour une table donnée. Le système inclut un **Kitchen Display** pour afficher les KOT en temps réel.

**Sales Return (Retour de vente)**
Opération de remboursement partiel ou total d'une facture. Implique la mise à jour du stock et le remboursement client.

**Payment (Paiement)**
Encaissement d'une facture. Peut être :
- Paiement complet (montant payé ≥ montant dû → calcul de la monnaie rendue)
- Paiement partiel (montant payé < montant dû → montant restant dû)

**Payment Type (Type de paiement)**
Méthode de paiement acceptée : Espèces, Carte bancaire, Chèque, etc.

### Gestion du back-office

**Customer (Client)**
Client enregistré dans le système. Peut avoir des factures en attente de paiement (due invoices) et un historique d'achats.

**Supplier (Fournisseur)**
Fournisseur de produits. Lié aux opérations d'achat et à la gestion du stock.

**Purchase (Achat)**
Achat de marchandises auprès d'un fournisseur pour réapprovisionner le stock.

**Expense (Dépense)**
Dépense opérationnelle du restaurant, catégorisée par **Expense Group**.

**User (Utilisateur)**
Compte utilisateur du système avec un niveau d'accès :
- **Admin** : Accès complet au système
- **Cashier** : Prise de commande et encaissement
- **Waiter** : Prise de commande uniquement

### Concepts financiers

**Discount (Remise)**
Réduction appliquée sur une facture. Deux types :
- **Item Discount** : Remise sur un article spécifique
- **Counter Discount** : Remise globale sur la facture

**Tax1 / Tax2**
Taxes appliquées sur les articles. Peuvent être configurées par article.

**Payable (Montant à payer)**
Montant total de la facture après application des remises et taxes.

**Change Amount (Monnaie rendue)**
Différence entre le montant payé et le montant dû (si paiement > montant dû).

**Due Amount (Montant restant dû)**
Montant restant à payer si le paiement est partiel.

## Règles métier

### Gestion des commandes

1. Une table ne peut avoir qu'une seule commande ouverte à la fois
2. Une commande peut être mise en attente (hold) et rappelée (recall) ultérieurement
3. Les modificateurs doivent être associés à un article spécifique
4. Le KOT n'est envoyé en cuisine qu'après validation de la commande

### Calcul des montants

```
Total Brut = Somme(Prix unitaire × Quantité) pour tous les articles
Total Remises Articles = Somme des remises individuelles
Sous-total après remises articles = Total Brut - Total Remises Articles
Remise globale = (Sous-total × Taux de remise global) / 100
Sous-total final = Sous-total après remises articles - Remise globale
Total Taxes = Somme(Tax1) + Somme(Tax2)
Montant à payer = Sous-total final + Total Taxes
```

### Gestion du stock

1. Le stock diminue lors de la vente d'un article
2. Le stock augmente lors d'un achat auprès d'un fournisseur
3. Le stock augmente lors d'un retour de vente
4. Un rapport de réapprovisionnement (Re-Order Report) signale les articles sous le niveau minimum

### Sécurité et accès

1. Tous les utilisateurs doivent s'authentifier via frmLogin
2. Les permissions sont basées sur le User Type (Admin/Cashier/Waiter)
3. Les opérations sensibles (gestion des utilisateurs, configuration) sont réservées aux Admin

## Architecture technique

### Structure de la base de données

**Principales tables :**
- `tbl_User` : Utilisateurs du système
- `tbl_Customer` : Clients
- `tbl_Supplier` : Fournisseurs
- `tbl_Item` : Articles du menu
- `tbl_Category` : Catégories d'articles
- `tbl_Modifier` : Modificateurs
- `tbl_Table` : Tables du restaurant
- `tbl_TableLocation` : Emplacements/zones de tables
- `tbl_Invoice` : Factures (en-tête)
- `tbl_InvoiceDetail` : Lignes de facture
- `tbl_Payment` : Paiements
- `tbl_PaymentType` : Types de paiement
- `tbl_Purchase` : Achats fournisseurs
- `tbl_Expense` : Dépenses
- `tbl_ExpenseGroup` : Catégories de dépenses

### Couche d'accès aux données

**DataAccess.cs (Legacy - À remplacer)**
- Connexion SQL statique
- Requêtes SQL par concaténation (vulnérable aux injections SQL)
- Pas de transactions
- Gestion minimale des erreurs

**SecureDataAccess.cs (Nouveau - Phase 1)**
- Utilisation de SqlParameter pour prévenir les injections SQL
- Support des transactions SQL
- Using statements pour libération des ressources
- Gestion robuste des erreurs avec ErrorLog

### Imprimantes et périphériques

- Support de plusieurs imprimantes configurables
- Impression de reçus (receipts)
- Impression de KOT pour la cuisine
- Support Cash Drawer (tiroir-caisse) via Microsoft Point of Service

## Phases de développement

### Phase 1 (En cours) : Sécurité et Corrections de bugs

**Objectifs :**
- Corriger les vulnérabilités SQL Injection
- Implémenter le hachage des mots de passe
- Corriger les bugs critiques (frmSalesReturn)
- Migration vers SecureDataAccess pour les formulaires critiques

**Formulaires migrés :**
- frmLogin
- frmUser
- frmPayment
- frmCustomer
- frmSupplier
- frmSalesReturn

### Phase 2 (Planifiée) : Refactoring et Maintenabilité

**Objectifs :**
- Migration complète vers SecureDataAccess
- Refactoring de la logique métier
- Amélioration de la gestion des erreurs
- Centralisation des règles métier
- Tests unitaires

### Phase 3 (Planifiée) : Modernisation

**Objectifs :**
- Migration vers .NET moderne (au lieu de .NET 4.0)
- Amélioration de l'interface utilisateur
- Architecture MVVM ou MVC
- Potentiellement version web ou mobile

## Notes importantes

### Limitations connues

1. Connexion à une seule base de données SQL Server en dur (pas de multi-tenant)
2. Interface en anglais uniquement
3. Pas de synchronisation multi-postes
4. Pas de mode hors-ligne
5. Pas d'intégration avec des systèmes de paiement électronique

### Dépendances externes

- SQL Server Express (base de données)
- Microsoft Report Viewer (génération de rapports)
- iTextSharp (génération de PDF)
- Spire.Barcode (gestion des codes-barres)
- Microsoft Point of Service (périphériques POS)

## Contacts et support

**Version actuelle :** 10.0.0.x (d'après CYPOS.csproj)
**Framework :** .NET Framework 4.0
**Dernière mise à jour des logs d'erreur :** 20-05-2021
