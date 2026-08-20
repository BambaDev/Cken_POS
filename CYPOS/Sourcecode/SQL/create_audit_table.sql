-- Phase 2: Create Audit Log table
-- Run this script on your CYPOS database before deploying Phase 2 code

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tbl_AuditLog') AND type in (N'U'))
BEGIN
    CREATE TABLE tbl_AuditLog (
        id INT IDENTITY(1,1) PRIMARY KEY,
        user_name NVARCHAR(50) NOT NULL,
        action NVARCHAR(50) NOT NULL,
        detail NVARCHAR(500) NULL,
        log_date DATE NOT NULL,
        log_time TIME NOT NULL
    );

    CREATE INDEX IX_AuditLog_Date ON tbl_AuditLog(log_date DESC);
    CREATE INDEX IX_AuditLog_User ON tbl_AuditLog(user_name);
    CREATE INDEX IX_AuditLog_Action ON tbl_AuditLog(action);
END
GO

-- Expand password column to support PBKDF2 hashes (longer than SHA256)
IF COL_LENGTH('tbl_User', 'password') < 256
BEGIN
    ALTER TABLE tbl_User ALTER COLUMN password NVARCHAR(256) NOT NULL;
END
GO
