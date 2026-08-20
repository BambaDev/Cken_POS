/*******************************************************************************
 * CYPOS - Phase 1 Validation Script
 *
 * Purpose: Validate that Phase 1 migration was successful
 * Run this AFTER migration and password hashing
 *
 * Expected results are documented for each check
 ******************************************************************************/

USE CYPOS;
GO

PRINT '';
PRINT '========================================';
PRINT 'CYPOS Phase 1 Validation';
PRINT 'Date: ' + CONVERT(VARCHAR, GETDATE(), 120);
PRINT '========================================';
PRINT '';

/*******************************************************************************
 * CHECK 1: Backup Table Exists
 ******************************************************************************/

PRINT 'CHECK 1: Backup Table';
PRINT '----------------------';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_User_Backup_PrePhase1')
BEGIN
    PRINT '✓ PASS: Backup table tbl_User_Backup_PrePhase1 exists';

    DECLARE @BackupCount INT;
    SELECT @BackupCount = COUNT(*) FROM tbl_User_Backup_PrePhase1;
    PRINT '  Backup contains ' + CAST(@BackupCount AS VARCHAR) + ' user(s)';
END
ELSE
BEGIN
    PRINT '✗ FAIL: Backup table tbl_User_Backup_PrePhase1 does NOT exist';
    PRINT '  WARNING: No rollback available if issues occur';
END

PRINT '';

/*******************************************************************************
 * CHECK 2: Password Column Structure
 ******************************************************************************/

PRINT 'CHECK 2: Password Column Structure';
PRINT '-----------------------------------';

DECLARE @DataType NVARCHAR(128);
DECLARE @MaxLength INT;

SELECT
    @DataType = TYPE_NAME(system_type_id),
    @MaxLength = max_length
FROM sys.columns
WHERE object_id = OBJECT_ID('tbl_User') AND name = 'password';

IF @DataType = 'varchar' AND @MaxLength = 256
BEGIN
    PRINT '✓ PASS: Password column is VARCHAR(256)';
END
ELSE
BEGIN
    PRINT '✗ FAIL: Password column is ' + @DataType + '(' + CAST(@MaxLength AS VARCHAR) + ')';
    PRINT '  EXPECTED: varchar(256)';
END

PRINT '';

/*******************************************************************************
 * CHECK 3: Password Hashing Status
 ******************************************************************************/

PRINT 'CHECK 3: Password Hashing Status';
PRINT '---------------------------------';

DECLARE @TotalUsers INT;
DECLARE @HashedUsers INT;
DECLARE @PlainTextUsers INT;

SELECT
    @TotalUsers = COUNT(*),
    @HashedUsers = COUNT(CASE WHEN LEN(password) = 64 THEN 1 END),
    @PlainTextUsers = COUNT(CASE WHEN LEN(password) < 64 THEN 1 END)
FROM tbl_User;

PRINT 'Total users: ' + CAST(@TotalUsers AS VARCHAR);
PRINT 'Hashed passwords (64 chars): ' + CAST(@HashedUsers AS VARCHAR);
PRINT 'Plain text passwords (< 64 chars): ' + CAST(@PlainTextUsers AS VARCHAR);

IF @PlainTextUsers = 0 AND @HashedUsers = @TotalUsers
BEGIN
    PRINT '✓ PASS: All passwords are hashed';
END
ELSE
BEGIN
    PRINT '✗ FAIL: ' + CAST(@PlainTextUsers AS VARCHAR) + ' password(s) still in plain text';
    PRINT '';
    PRINT 'Users with plain text passwords:';
    SELECT
        id,
        user_name,
        LEN(password) AS password_length
    FROM tbl_User
    WHERE LEN(password) < 64;
END

PRINT '';

/*******************************************************************************
 * CHECK 4: Test Password Verification
 ******************************************************************************/

PRINT 'CHECK 4: Test Password Verification';
PRINT '------------------------------------';

-- Test that admin password is correctly hashed
-- SHA256('admin') = '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'

DECLARE @AdminPassword VARCHAR(256);
SELECT @AdminPassword = password FROM tbl_User WHERE user_name = 'admin';

IF @AdminPassword = '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'
BEGIN
    PRINT '✓ PASS: Admin password hash is correct (SHA256)';
    PRINT '  Login with admin/admin should work';
END
ELSE IF LEN(@AdminPassword) = 64
BEGIN
    PRINT '⚠ WARNING: Admin password is hashed but not the default "admin"';
    PRINT '  This is OK if password was changed before migration';
    PRINT '  Current hash: ' + LEFT(@AdminPassword, 20) + '...';
END
ELSE
BEGIN
    PRINT '✗ FAIL: Admin password is not properly hashed';
    PRINT '  Length: ' + CAST(LEN(@AdminPassword) AS VARCHAR);
END

PRINT '';

/*******************************************************************************
 * CHECK 5: User Table Integrity
 ******************************************************************************/

PRINT 'CHECK 5: User Table Integrity';
PRINT '------------------------------';

-- Check for NULL passwords
DECLARE @NullPasswords INT;
SELECT @NullPasswords = COUNT(*) FROM tbl_User WHERE password IS NULL;

IF @NullPasswords = 0
BEGIN
    PRINT '✓ PASS: No NULL passwords found';
END
ELSE
BEGIN
    PRINT '✗ FAIL: ' + CAST(@NullPasswords AS VARCHAR) + ' user(s) with NULL password';
    SELECT id, user_name FROM tbl_User WHERE password IS NULL;
END

-- Check for duplicate usernames
DECLARE @Duplicates INT;
SELECT @Duplicates = COUNT(*)
FROM (
    SELECT user_name, COUNT(*) AS cnt
    FROM tbl_User
    GROUP BY user_name
    HAVING COUNT(*) > 1
) AS Dupes;

IF @Duplicates = 0
BEGIN
    PRINT '✓ PASS: No duplicate usernames';
END
ELSE
BEGIN
    PRINT '✗ FAIL: Duplicate usernames found';
    SELECT user_name, COUNT(*) AS count
    FROM tbl_User
    GROUP BY user_name
    HAVING COUNT(*) > 1;
END

PRINT '';

/*******************************************************************************
 * CHECK 6: Recent Login Logs
 ******************************************************************************/

PRINT 'CHECK 6: Recent Login Logs';
PRINT '--------------------------';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_UserLogs')
BEGIN
    DECLARE @RecentLogins INT;
    SELECT @RecentLogins = COUNT(*)
    FROM tbl_UserLogs
    WHERE log_date >= CAST(GETDATE() AS DATE)
    AND log_type = 'IN';

    PRINT '✓ PASS: Login logs table exists';
    PRINT '  Logins today: ' + CAST(@RecentLogins AS VARCHAR);

    IF @RecentLogins > 0
    BEGIN
        PRINT '';
        PRINT '  Recent logins:';
        SELECT TOP 5
            user_name,
            log_date,
            log_time
        FROM tbl_UserLogs
        WHERE log_type = 'IN'
        ORDER BY log_date DESC, log_time DESC;
    END
END
ELSE
BEGIN
    PRINT '⚠ WARNING: Login logs table does not exist';
    PRINT '  This is not critical but may indicate a schema issue';
END

PRINT '';

/*******************************************************************************
 * CHECK 7: Data Integrity (Sample Records)
 ******************************************************************************/

PRINT 'CHECK 7: Data Integrity';
PRINT '-----------------------';

-- Check that critical tables exist and have data
DECLARE @CustomerCount INT, @SupplierCount INT, @ItemCount INT;

SELECT @CustomerCount = COUNT(*) FROM tbl_Customer;
SELECT @SupplierCount = COUNT(*) FROM tbl_Supplier;
SELECT @ItemCount = COUNT(*) FROM tbl_Item;

PRINT 'Customers: ' + CAST(@CustomerCount AS VARCHAR);
PRINT 'Suppliers: ' + CAST(@SupplierCount AS VARCHAR);
PRINT 'Items: ' + CAST(@ItemCount AS VARCHAR);

IF @CustomerCount > 0 AND @SupplierCount > 0 AND @ItemCount > 0
BEGIN
    PRINT '✓ PASS: Core business data exists';
END
ELSE
BEGIN
    PRINT '⚠ WARNING: Some core tables are empty';
    PRINT '  This may be normal for a new installation';
END

PRINT '';

/*******************************************************************************
 * SUMMARY
 ******************************************************************************/

PRINT '========================================';
PRINT 'Validation Summary';
PRINT '========================================';
PRINT '';

-- Calculate overall pass rate
DECLARE @PassCount INT = 0;
DECLARE @TotalChecks INT = 7;

-- Increment for each check that passed
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_User_Backup_PrePhase1')
    SET @PassCount = @PassCount + 1;

IF @DataType = 'varchar' AND @MaxLength = 256
    SET @PassCount = @PassCount + 1;

IF @PlainTextUsers = 0
    SET @PassCount = @PassCount + 1;

IF @AdminPassword = '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918' OR LEN(@AdminPassword) = 64
    SET @PassCount = @PassCount + 1;

IF @NullPasswords = 0
    SET @PassCount = @PassCount + 1;

IF @Duplicates = 0
    SET @PassCount = @PassCount + 1;

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_UserLogs')
    SET @PassCount = @PassCount + 1;

PRINT 'Checks passed: ' + CAST(@PassCount AS VARCHAR) + ' / ' + CAST(@TotalChecks AS VARCHAR);
PRINT 'Pass rate: ' + CAST((@PassCount * 100 / @TotalChecks) AS VARCHAR) + '%';
PRINT '';

IF @PassCount = @TotalChecks
BEGIN
    PRINT '✓✓✓ ALL CHECKS PASSED ✓✓✓';
    PRINT '';
    PRINT 'Migration appears successful!';
    PRINT 'Next steps:';
    PRINT '1. Deploy new application code';
    PRINT '2. Test login with admin/admin';
    PRINT '3. Test user creation';
    PRINT '4. Test customer/supplier CRUD';
    PRINT '5. Monitor error logs';
END
ELSE IF @PassCount >= 5
BEGIN
    PRINT '⚠ PARTIAL PASS ⚠';
    PRINT '';
    PRINT 'Most checks passed, but some issues detected.';
    PRINT 'Review the failed checks above and correct if needed.';
    PRINT 'Consider proceeding with caution.';
END
ELSE
BEGIN
    PRINT '✗✗✗ MULTIPLE FAILURES ✗✗✗';
    PRINT '';
    PRINT 'CRITICAL: Multiple validation checks failed.';
    PRINT 'DO NOT proceed to production deployment.';
    PRINT '';
    PRINT 'Recommended actions:';
    PRINT '1. Review failed checks above';
    PRINT '2. Fix identified issues';
    PRINT '3. Re-run this validation script';
    PRINT '4. Consider rollback if issues cannot be resolved';
END

PRINT '';
PRINT '========================================';

GO
