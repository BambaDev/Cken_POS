/*******************************************************************************
 * CYPOS - Phase 1 Database Rollback Script
 *
 * Purpose: Rollback database changes from Phase 1 migration
 * Date: 2026-05-24
 * Version: 1.0
 *
 * IMPORTANT:
 * - Only run this script if Phase 1 migration caused critical issues
 * - This will restore passwords to plain text (original state)
 * - You must revert to the old application code after running this
 * - This script depends on tbl_User_Backup_PrePhase1 existing
 *
 * WARNING:
 * - All password changes made after migration will be lost
 * - All new users created after migration will be lost
 * - Consider selective rollback if only some users are affected
 ******************************************************************************/

USE CYPOS;
GO

PRINT '========================================';
PRINT 'CYPOS Phase 1 Rollback - START';
PRINT 'Date: ' + CONVERT(VARCHAR, GETDATE(), 120);
PRINT '========================================';
PRINT '';

/*******************************************************************************
 * STEP 1: Pre-Rollback Validation
 ******************************************************************************/

PRINT 'STEP 1: Pre-Rollback Validation';
PRINT '---------------------------------';

-- Check if database exists
IF DB_ID('CYPOS') IS NULL
BEGIN
    RAISERROR('Database CYPOS does not exist. Cannot proceed with rollback.', 16, 1);
    RETURN;
END

-- Check if backup table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_User_Backup_PrePhase1')
BEGIN
    RAISERROR('Backup table tbl_User_Backup_PrePhase1 does not exist. Cannot rollback without backup.', 16, 1);
    PRINT '';
    PRINT 'CRITICAL: No backup available. Manual recovery required.';
    PRINT 'Consider restoring from database backup if available.';
    RETURN;
END

PRINT 'Backup table found.';
PRINT '';

/*******************************************************************************
 * STEP 2: Display Current State
 ******************************************************************************/

PRINT 'STEP 2: Current State Before Rollback';
PRINT '---------------------------------------';

DECLARE @CurrentUserCount INT, @BackupUserCount INT;
SELECT @CurrentUserCount = COUNT(*) FROM tbl_User;
SELECT @BackupUserCount = COUNT(*) FROM tbl_User_Backup_PrePhase1;

PRINT 'Current users in tbl_User: ' + CAST(@CurrentUserCount AS VARCHAR);
PRINT 'Users in backup table: ' + CAST(@BackupUserCount AS VARCHAR);

IF @CurrentUserCount > @BackupUserCount
BEGIN
    PRINT '';
    PRINT 'WARNING: Current user count is greater than backup.';
    PRINT 'This means new users were created after migration.';
    PRINT 'These users will be LOST if rollback proceeds.';
    PRINT '';
    PRINT 'New users created after migration:';
    SELECT
        u.user_id,
        u.user_name,
        u.full_name,
        u.user_type
    FROM tbl_User u
    LEFT JOIN tbl_User_Backup_PrePhase1 b ON u.user_id = b.user_id
    WHERE b.user_id IS NULL;
    PRINT '';
END

/*******************************************************************************
 * STEP 3: User Confirmation Checkpoint
 ******************************************************************************/

PRINT '========================================';
PRINT 'CONFIRMATION REQUIRED';
PRINT '========================================';
PRINT '';
PRINT 'You are about to rollback Phase 1 migration.';
PRINT 'This will:';
PRINT '  - Restore all user data from backup';
PRINT '  - Revert passwords to plain text';
PRINT '  - LOSE any users created after migration';
PRINT '  - LOSE any password changes made after migration';
PRINT '';
PRINT 'To proceed, comment out the RETURN statement below.';
PRINT '';

-- SAFETY: Prevent accidental execution
RETURN;

-- If you are ABSOLUTELY SURE you want to rollback, comment out the RETURN above
-- and uncomment the PRINT below, then run the script.

-- PRINT 'Proceeding with rollback...';
-- PRINT '';

/*******************************************************************************
 * STEP 4: Create Current State Backup (Safety Net)
 ******************************************************************************/

PRINT 'STEP 4: Creating Safety Backup of Current State';
PRINT '-------------------------------------------------';

-- Drop safety backup if it exists
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_User_BeforeRollback')
BEGIN
    DROP TABLE tbl_User_BeforeRollback;
END

-- Create safety backup
SELECT *
INTO tbl_User_BeforeRollback
FROM tbl_User;

PRINT 'Current state backed up to tbl_User_BeforeRollback.';
PRINT '';

/*******************************************************************************
 * STEP 5: Restore Data from Backup
 ******************************************************************************/

PRINT 'STEP 5: Restoring Data from Backup';
PRINT '------------------------------------';

-- Disable constraints temporarily
PRINT 'Disabling foreign key constraints...';
ALTER TABLE tbl_User NOCHECK CONSTRAINT ALL;

-- Clear current data
PRINT 'Clearing current user data...';
TRUNCATE TABLE tbl_User;

-- Restore from backup
PRINT 'Restoring data from backup...';
SET IDENTITY_INSERT tbl_User ON;

INSERT INTO tbl_User (user_id, user_name, password, user_type, full_name, contact, dob, image_name)
SELECT user_id, user_name, password, user_type, full_name, contact, dob, image_name
FROM tbl_User_Backup_PrePhase1;

SET IDENTITY_INSERT tbl_User OFF;

-- Re-enable constraints
PRINT 'Re-enabling foreign key constraints...';
ALTER TABLE tbl_User CHECK CONSTRAINT ALL;

DECLARE @RestoredCount INT;
SELECT @RestoredCount = COUNT(*) FROM tbl_User;

PRINT 'Data restored successfully.';
PRINT 'Restored user count: ' + CAST(@RestoredCount AS VARCHAR);
PRINT '';

/*******************************************************************************
 * STEP 6: Validate Restoration
 ******************************************************************************/

PRINT 'STEP 6: Validating Restoration';
PRINT '--------------------------------';

-- Verify record count matches backup
IF @RestoredCount != @BackupUserCount
BEGIN
    RAISERROR('Restoration validation failed. Record counts do not match.', 16, 1);
    PRINT 'Expected: ' + CAST(@BackupUserCount AS VARCHAR);
    PRINT 'Actual: ' + CAST(@RestoredCount AS VARCHAR);
    RETURN;
END

PRINT 'Record count validation passed.';
PRINT '';

-- Display restored users
PRINT 'Restored users:';
SELECT
    user_id,
    user_name,
    user_type,
    full_name,
    LEN(password) AS password_length,
    CASE
        WHEN LEN(password) = 64 THEN 'Hashed (will not work with old code)'
        WHEN LEN(password) < 64 THEN 'Plain text (restored)'
        ELSE 'Unknown format'
    END AS password_status
FROM tbl_User
ORDER BY user_id;

PRINT '';

/*******************************************************************************
 * STEP 7: Summary and Next Steps
 ******************************************************************************/

PRINT '========================================';
PRINT 'CYPOS Phase 1 Rollback - COMPLETED';
PRINT 'Date: ' + CONVERT(VARCHAR, GETDATE(), 120);
PRINT '========================================';
PRINT '';
PRINT 'ROLLBACK SUCCESSFUL';
PRINT '';
PRINT 'NEXT STEPS:';
PRINT '1. Deploy OLD application code (pre-Phase 1)';
PRINT '2. Test authentication with existing users';
PRINT '3. Verify all functionality works as before';
PRINT '4. Investigate root cause of migration failure';
PRINT '5. Plan corrective actions before re-attempting migration';
PRINT '';
PRINT 'BACKUP TABLES AVAILABLE:';
PRINT '  - tbl_User_Backup_PrePhase1 (original backup from migration)';
PRINT '  - tbl_User_BeforeRollback (state before this rollback)';
PRINT '';
PRINT 'IMPORTANT: Do NOT delete backup tables until system is stable.';
PRINT '';

GO
