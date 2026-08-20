-- ================================================================
-- REQUÊTES SQL POUR VALIDATION DES TESTS - CYPOS
-- ================================================================
-- Ces requêtes permettent de vérifier manuellement la cohérence
-- des données après les tests de l'application
-- ================================================================

-- ----------------------------------------------------------------
-- 1. VÉRIFICATION DES TRANSACTIONS FACTURES
-- ----------------------------------------------------------------

-- Dernières factures créées
SELECT TOP 10
    invoice_no,
    invoice_date,
    invoice_time,
    payment_amount,
    due_amount,
    customer_id,
    user_name
FROM tbl_InvoiceHeader
ORDER BY invoice_id DESC;

-- Détails de la dernière facture (remplacer INVOICE_NO)
SELECT
    item_code,
    item_name,
    qty,
    selling_price,
    total,
    discount
FROM tbl_InvoiceDetail
WHERE header_id = (SELECT TOP 1 invoice_id FROM tbl_InvoiceHeader ORDER BY invoice_id DESC);

-- Vérifier cohérence stock après facture
SELECT
    i.item_code,
    i.item_name,
    i.current_stock,
    ISNULL(SUM(id.qty), 0) AS total_vendu,
    i.current_stock + ISNULL(SUM(id.qty), 0) AS stock_avant_vente
FROM tbl_Item i
LEFT JOIN tbl_InvoiceDetail id ON i.item_code = id.item_code
WHERE i.item_code IN ('VOTRE_CODE1', 'VOTRE_CODE2', 'VOTRE_CODE3')
GROUP BY i.item_code, i.item_name, i.current_stock;

-- ----------------------------------------------------------------
-- 2. VÉRIFICATION DES HOLD INVOICES
-- ----------------------------------------------------------------

-- Tous les holds actifs
SELECT
    id,
    hold_no,
    invoice_date,
    table_id,
    no_of_guests,
    user_name
FROM tbl_TempHeader
ORDER BY id DESC;

-- Détails d'un hold spécifique (remplacer HOLD_ID)
SELECT
    item_code,
    item_name,
    qty,
    selling_price,
    total
FROM tbl_TempDetail
WHERE header_id = 1; -- Remplacer par l'ID du hold

-- ----------------------------------------------------------------
-- 3. VÉRIFICATION DES PURCHASES
-- ----------------------------------------------------------------

-- Derniers achats
SELECT TOP 10
    purchase_date,
    product_id,
    quantity,
    price,
    amount,
    purchase_type
FROM tbl_Purchase
ORDER BY id DESC;

-- Vérifier stock après purchase
SELECT
    i.item_code,
    i.item_name,
    i.current_stock,
    ISNULL(SUM(p.quantity), 0) AS total_achete
FROM tbl_Item i
LEFT JOIN tbl_Purchase p ON i.id = p.product_id
WHERE i.item_code = 'VOTRE_CODE'
GROUP BY i.item_code, i.item_name, i.current_stock;

-- ----------------------------------------------------------------
-- 4. VÉRIFICATION DES CLIENTS
-- ----------------------------------------------------------------

-- Tous les clients (vérifier SqlParameter sur recherche)
SELECT
    id,
    name,
    address,
    city,
    phone,
    email
FROM tbl_Customer
ORDER BY name;

-- Chercher client par nom (simuler recherche avec SqlParameter)
SELECT * FROM tbl_Customer
WHERE name LIKE '%Test%';

-- Historique paiements d'un client
SELECT
    invoice_id,
    invoice_date,
    payment_amount,
    due_amount,
    payment_type
FROM tbl_InvoiceHeader
WHERE customer_id = 1 -- Remplacer par l'ID client
ORDER BY invoice_date DESC;

-- ----------------------------------------------------------------
-- 5. VÉRIFICATION DES ARTICLES
-- ----------------------------------------------------------------

-- Tous les articles avec stock
SELECT
    item_code,
    item_name,
    category_name,
    selling_price,
    cost_price,
    current_stock,
    stock_item
FROM tbl_Item
LEFT JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id
ORDER BY item_name;

-- Articles avec stock négatif (NE DEVRAIT PAS EXISTER!)
SELECT
    item_code,
    item_name,
    current_stock
FROM tbl_Item
WHERE current_stock < 0;
-- Résultat attendu: 0 lignes (si des lignes, la transaction ACID a échoué!)

-- Articles les plus vendus
SELECT TOP 10
    item_code,
    item_name,
    SUM(qty) AS total_vendu,
    SUM(total) AS chiffre_affaires
FROM tbl_InvoiceDetail
GROUP BY item_code, item_name
ORDER BY total_vendu DESC;

-- ----------------------------------------------------------------
-- 6. VÉRIFICATION DES UTILISATEURS (BCRYPT)
-- ----------------------------------------------------------------

-- Tous les utilisateurs
SELECT
    id,
    name,
    user_name,
    user_type,
    contact,
    email,
    LEN(password) AS password_length,
    LEFT(password, 7) AS password_prefix
FROM tbl_User;

-- Vérification BCrypt
-- Les passwords BCrypt commencent toujours par "$2a$" ou "$2b$"
-- et ont une longueur de 60 caractères
SELECT
    user_name,
    CASE
        WHEN LEN(password) = 60 AND LEFT(password, 3) = '$2a' THEN 'BCrypt OK'
        WHEN LEN(password) = 60 AND LEFT(password, 3) = '$2b' THEN 'BCrypt OK'
        ELSE 'PLAIN TEXT - DANGER!'
    END AS password_status
FROM tbl_User;
-- Résultat attendu: Tous "BCrypt OK"

-- ----------------------------------------------------------------
-- 7. VÉRIFICATION SETTINGS ET CONFIGURATION
-- ----------------------------------------------------------------

-- Company settings avec tax rates
SELECT
    company_name,
    tax1_name,
    tax1_rate,
    tax2_name,
    tax2_rate,
    tax_type,
    cal_method
FROM tbl_Company;

-- General settings
SELECT
    items_per_page,
    ask_table,
    ask_guest_count,
    ask_waiter,
    default_discount_rate,
    enable_sc,
    sc_rate,
    invoice_printer,
    kot_printer
FROM tbl_Settings;

-- ----------------------------------------------------------------
-- 8. VÉRIFICATION INTÉGRITÉ RÉFÉRENTIELLE
-- ----------------------------------------------------------------

-- Factures sans détails (ANORMAL!)
SELECT
    ih.invoice_no,
    ih.invoice_date,
    COUNT(id.detail_id) AS nb_lignes
FROM tbl_InvoiceHeader ih
LEFT JOIN tbl_InvoiceDetail id ON ih.invoice_id = id.header_id
GROUP BY ih.invoice_no, ih.invoice_date
HAVING COUNT(id.detail_id) = 0;
-- Résultat attendu: 0 lignes

-- Articles dans factures qui n'existent plus (ANORMAL!)
SELECT DISTINCT
    id.item_code,
    id.item_name
FROM tbl_InvoiceDetail id
LEFT JOIN tbl_Item i ON id.item_code = i.item_code
WHERE i.item_code IS NULL;
-- Résultat attendu: 0 lignes

-- ----------------------------------------------------------------
-- 9. STATISTIQUES GÉNÉRALES
-- ----------------------------------------------------------------

-- Nombre total d'enregistrements par table
SELECT 'Customers' AS TableName, COUNT(*) AS RecordCount FROM tbl_Customer
UNION ALL
SELECT 'Items', COUNT(*) FROM tbl_Item
UNION ALL
SELECT 'Categories', COUNT(*) FROM tbl_Category
UNION ALL
SELECT 'Suppliers', COUNT(*) FROM tbl_Supplier
UNION ALL
SELECT 'Invoices', COUNT(*) FROM tbl_InvoiceHeader
UNION ALL
SELECT 'Invoice Details', COUNT(*) FROM tbl_InvoiceDetail
UNION ALL
SELECT 'Purchases', COUNT(*) FROM tbl_Purchase
UNION ALL
SELECT 'Users', COUNT(*) FROM tbl_User
UNION ALL
SELECT 'Tables', COUNT(*) FROM tbl_Tables
UNION ALL
SELECT 'Holds', COUNT(*) FROM tbl_TempHeader;

-- Chiffre d'affaires total
SELECT
    COUNT(DISTINCT invoice_id) AS nb_factures,
    SUM(payment_amount) AS total_ventes,
    AVG(payment_amount) AS panier_moyen,
    SUM(due_amount) AS total_du
FROM tbl_InvoiceHeader;

-- ----------------------------------------------------------------
-- 10. TEST INJECTION SQL (À EXÉCUTER MANUELLEMENT)
-- ----------------------------------------------------------------

-- Si l'application est vulnérable, cette recherche retournerait TOUS les clients
-- Avec SqlParameter, elle ne devrait retourner AUCUN résultat
DECLARE @SearchTerm NVARCHAR(50) = ''' OR ''1''=''1';

SELECT * FROM tbl_Customer
WHERE name LIKE '%' + @SearchTerm + '%';
-- Résultat attendu avec SqlParameter: 0 lignes
-- Résultat DANGEREUX sans protection: TOUS les clients!

-- ----------------------------------------------------------------
-- 11. VÉRIFICATION TRANSACTIONS ACID
-- ----------------------------------------------------------------

-- Cette requête vérifie qu'il n'y a pas de factures "orphelines"
-- (facture créée mais stock pas mis à jour, ou inversement)

-- Comparer stock théorique vs réel
WITH StockTheory AS (
    SELECT
        i.item_code,
        i.item_name,
        i.current_stock AS stock_actuel,
        -- Stock initial + achats - ventes
        (
            ISNULL((SELECT SUM(quantity) FROM tbl_Purchase WHERE product_id = i.id), 0) -
            ISNULL((SELECT SUM(qty) FROM tbl_InvoiceDetail WHERE item_code = i.item_code), 0)
        ) AS stock_calcule
    FROM tbl_Item i
)
SELECT
    item_code,
    item_name,
    stock_actuel,
    stock_calcule,
    stock_actuel - stock_calcule AS difference
FROM StockTheory
WHERE stock_actuel != stock_calcule;
-- Résultat attendu: 0 lignes (stocks cohérents)
-- Si des différences existent: problème de transaction ACID!

-- ----------------------------------------------------------------
-- 12. NETTOYAGE (APRÈS TESTS UNIQUEMENT!)
-- ----------------------------------------------------------------

-- ATTENTION: N'exécuter QUE sur base de test!
-- Supprimer les données de test créées

/*
-- Supprimer client test
DELETE FROM tbl_Customer WHERE name LIKE 'Test Client%';

-- Supprimer article test
DELETE FROM tbl_Item WHERE item_code LIKE 'TEST%';

-- Supprimer catégorie test
DELETE FROM tbl_Category WHERE category_name LIKE 'Test%';

-- Supprimer utilisateur test
DELETE FROM tbl_User WHERE user_name LIKE 'Test%';
*/

-- ================================================================
-- FIN DES REQUÊTES DE VALIDATION
-- ================================================================

-- RAPPEL IMPORTANT:
-- Si vous trouvez des incohérences avec ces requêtes:
-- 1. Noter la requête exacte qui montre le problème
-- 2. Noter les résultats obtenus vs attendus
-- 3. Me fournir ces informations pour correction immédiate
-- ================================================================
