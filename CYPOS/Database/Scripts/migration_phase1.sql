/*******************************************************************************
 * CYPOS - Phase 1 Database Migration Script
 *
 * Purpose: Migrate database to support secure password hashing
 * Date: 2026-05-24
 * Version: 1.0
 *
 * IMPORTANT:
 * - This script must be run BEFORE deploying the new application code
 * - Make a full backup before running this script
 * - Test on a copy of the database first
 *
 * Changes:
 * 1. Create backup table for user data
 * 2. Alter tbl_User.password column to support hash storage (VARCHAR(256))
 * 3. Validate schema changes
 *
 * Note: Password hashing is done by the C# application after this script runs.
 *       See migration utility: PasswordMigrationUtility.exe
 ******************************************************************************/

USE CYPOS;
GO

PRINT '========================================';
PRINT 'CYPOS Phase 1 Migration - START';
PRINT 'Date: ' + CONVERT(VARCHAR, GETDATE(), 120);
PRINT '========================================';
PRINT '';

/*******************************************************************************
 * STEP 1: Pre-Migration Validation
 ******************************************************************************/

PRINT 'STEP 1: Pre-Migration Validation';
PRINT '-----------------------------------';

-- Check if database exists
IF DB_ID('CYPOS') IS NULL
BEGIN
    RAISERROR('Database CYPOS does not exist. Cannot proceed with migration.', 16, 1);
    RETURN;
END

-- Check if tbl_User exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_User')
BEGIN
    RAISERROR('Table tbl_User does not exist. Cannot proceed with migration.', 16, 1);
    RETURN;
END

-- Check if password column exists
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_User') AND name = 'password')
BEGIN
    RAISERROR('Column password does not exist in tbl_User. Cannot proceed with migration.', 16, 1);
    RETURN;
END

PRINT 'Pre-migration validation passed.';
PRINT '';

/*******************************************************************************
 * STEP 2: Create Backup Table
 ******************************************************************************/

PRINT 'STEP 2: Creating Backup Table';
PRINT '-------------------------------';

-- Drop backup table if it already exists (from previous migration attempt)
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_User_Backup_PrePhase1')
BEGIN
    PRINT 'Dropping existing backup table...';
    DROP TABLE tbl_User_Backup_PrePhase1;
END

-- Create backup table with all data
SELECT *
INTO tbl_User_Backup_PrePhase1
FROM tbl_User;

-- Verify backup
DECLARE @OriginalCount INT, @BackupCount INT;
SELECT @OriginalCount = COUNT(*) FROM tbl_User;
SELECT @BackupCount = COUNT(*) FROM tbl_User_Backup_PrePhase1;

IF @OriginalCount != @BackupCount
BEGIN
    RAISERROR('Backup verification failed. Record counts do not match.', 16, 1);
    RETURN;
END

PRINT 'Backup table created successfully.';
PRINT 'Original records: ' + CAST(@OriginalCount AS VARCHAR);
PRINT 'Backup records: ' + CAST(@BackupCount AS VARCHAR);
PRINT '';

/*******************************************************************************
 * STEP 3: Alter Password Column
 ******************************************************************************/

PRINT 'STEP 3: Altering Password Column';
PRINT '-----------------------------------';

-- Check current column definition
DECLARE @CurrentType NVARCHAR(128);
DECLARE @CurrentLength INT;

SELECT
    @CurrentType = TYPE_NAME(system_type_id),
    @CurrentLength = max_length
FROM sys.columns
WHERE object_id = OBJECT_ID('tbl_User') AND name = 'password';

PRINT 'Current password column type: ' + @CurrentType + '(' + CAST(@CurrentLength AS VARCHAR) + ')';

-- Alter column to support hash storage (SHA256 = 64 characters in hex)
-- Using VARCHAR(256) to allow future migration to longer hashes (BCrypt, Argon2)
ALTER TABLE tbl_User
ALTER COLUMN password VARCHAR(256) NOT NULL;

PRINT 'Password column altered to VARCHAR(256).';
PRINT '';

/*******************************************************************************
 * STEP 4: Post-Migration Validation
 ******************************************************************************/

PRINT 'STEP 4: Post-Migration Validation';
PRINT '------------------------------------';

-- Verify column alteration
SELECT
    @CurrentType = TYPE_NAME(system_type_id),
    @CurrentLength = max_length
FROM sys.columns
WHERE object_id = OBJECT_ID('tbl_User') AND name = 'password';

IF @CurrentType != 'varchar' OR @CurrentLength != 256
BEGIN
    RAISERROR('Column alteration verification failed. Expected VARCHAR(256).', 16, 1);
    RETURN;
END

PRINT 'Column alteration verified: ' + @CurrentType + '(' + CAST(@CurrentLength AS VARCHAR) + ')';
PRINT '';

-- Display current user data (without passwords for security)
PRINT 'Current users in system:';
SELECT
    user_id,
    user_name,
    user_type,
    full_name,
    LEN(password) AS password_length,
    CASE
        WHEN LEN(password) = 64 THEN 'Hashed (SHA256)'
        WHEN LEN(password) < 64 THEN 'Plain text (needs hashing)'
        ELSE 'Unknown format'
    END AS password_status
FROM tbl_User
ORDER BY user_id;

PRINT '';

/*******************************************************************************
 * STEP 5: Summary and Next Steps
 ******************************************************************************/

PRINT '========================================';
PRINT 'CYPOS Phase 1 Migration - COMPLETED';
PRINT 'Date: ' + CONVERT(VARCHAR, GETDATE(), 120);
PRINT '========================================';
PRINT '';
PRINT 'NEXT STEPS:';
PRINT '1. Run PasswordMigrationUtility.exe to hash all plain text passwords';
PRINT '2. Verify all passwords are hashed (LENGTH = 64 characters)';
PRINT '3. Deploy new application code with SecureDataAccess';
PRINT '4. Test authentication with existing users';
PRINT '5. If issues occur, run rollback_phase1.sql';
PRINT '';
PRINT 'BACKUP TABLE: tbl_User_Backup_PrePhase1';
PRINT 'This table contains original data and can be used for rollback.';
PRINT '';

GO
