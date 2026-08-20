/*******************************************************************************
 * CYPOS - Vérification de la structure de tbl_User
 *
 * Ce script affiche la structure réelle de la table tbl_User
 * pour identifier les noms corrects des colonnes.
 ******************************************************************************/

USE CYPOS;
GO

PRINT '========================================';
PRINT 'Structure de la table tbl_User';
PRINT '========================================';
PRINT '';

-- Afficher toutes les colonnes de tbl_User
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

PRINT '';
PRINT '========================================';
PRINT 'Exemple de données (3 premiers users)';
PRINT '========================================';
PRINT '';

-- Afficher les 3 premiers utilisateurs
SELECT TOP 3 * FROM tbl_User;

PRINT '';
PRINT 'Vérification terminée.';
