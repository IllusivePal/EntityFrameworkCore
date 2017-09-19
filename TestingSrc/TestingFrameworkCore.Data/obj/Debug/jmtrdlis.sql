IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [ProductMaster] (
    [Pmt_ProductCode] nvarchar(450) NOT NULL,
    [Pmt_ProductName] nvarchar(max),
    [Pmt_ProductPrice] decimal(18, 2),
    [Pmt_ProductQuantity] int,
    [Status] nvarchar(max),
    [ludatetime] datetime2 NOT NULL,
    CONSTRAINT [PK_ProductMaster] PRIMARY KEY ([Pmt_ProductCode])
);

GO

CREATE TABLE [UserMaster] (
    [UmtUserCode] nvarchar(450) NOT NULL,
    [UmtEmail] nvarchar(max),
    [UmtFirstName] nvarchar(max),
    [UmtLastName] nvarchar(max),
    [UmtMiddleName] nvarchar(max),
    [UmtPassword] nvarchar(max),
    [UmtStatus] nvarchar(max),
    CONSTRAINT [PK_UserMaster] PRIMARY KEY ([UmtUserCode])
);

GO

CREATE TABLE [ProductAccountCodeIdentityMaster] (
    [Pacmt_ProductCode] nvarchar(450) NOT NULL,
    [Pacmt_Account] int NOT NULL,
    [Pacmt_Description] nvarchar(max),
    CONSTRAINT [PK_ProductAccountCodeIdentityMaster] PRIMARY KEY ([Pacmt_ProductCode]),
    CONSTRAINT [FK_ProductAccountCodeIdentityMaster_ProductMaster_Pacmt_ProductCode] FOREIGN KEY ([Pacmt_ProductCode]) REFERENCES [ProductMaster] ([Pmt_ProductCode]) ON DELETE CASCADE
);

GO

CREATE TABLE [TransactionDetailMaster] (
    [Tdmt_TransactionDetailCode] nvarchar(450) NOT NULL,
    [ProductMasterPmt_ProductCode] nvarchar(450),
    [Tdmt_Date] datetime2,
    [Tdmt_Price] decimal(18, 2),
    [Tdmt_ProductCode] nvarchar(max),
    [Tdmt_Quantity] decimal(18, 2),
    [Tdmt_Status] nvarchar(max),
    [Tdmt_TotalPayment] decimal(18, 2),
    [Tdmt_TransactionCode] nvarchar(max),
    CONSTRAINT [PK_TransactionDetailMaster] PRIMARY KEY ([Tdmt_TransactionDetailCode]),
    CONSTRAINT [FK_TransactionDetailMaster_ProductMaster_ProductMasterPmt_ProductCode] FOREIGN KEY ([ProductMasterPmt_ProductCode]) REFERENCES [ProductMaster] ([Pmt_ProductCode]) ON DELETE CASCADE
);

GO

CREATE TABLE [AuthIdentityMaster] (
    [Amt_AuthCode] nvarchar(450) NOT NULL,
    [Amt_AuthName] nvarchar(max),
    [Amt_UmtUserCode] nvarchar(450),
    CONSTRAINT [PK_AuthIdentityMaster] PRIMARY KEY ([Amt_AuthCode]),
    CONSTRAINT [FK_AuthIdentityMaster_UserMaster_Amt_UmtUserCode] FOREIGN KEY ([Amt_UmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE CASCADE
);

GO

CREATE TABLE [HistoryTableMaster] (
    [Hmt_PmtProductCode] nvarchar(450) NOT NULL,
    [Hmt_UmtUserCode] nvarchar(450) NOT NULL,
    [Hmt_Description] nvarchar(max),
    [ProductMasterPmt_ProductCode] nvarchar(450),
    [UserMasterUmtUserCode] nvarchar(450),
    CONSTRAINT [PK_HistoryTableMaster] PRIMARY KEY ([Hmt_PmtProductCode], [Hmt_UmtUserCode]),
    CONSTRAINT [FK_HistoryTableMaster_ProductMaster_ProductMasterPmt_ProductCode] FOREIGN KEY ([ProductMasterPmt_ProductCode]) REFERENCES [ProductMaster] ([Pmt_ProductCode]) ON DELETE CASCADE,
    CONSTRAINT [FK_HistoryTableMaster_UserMaster_UserMasterUmtUserCode] FOREIGN KEY ([UserMasterUmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE CASCADE
);

GO

CREATE TABLE [TransactionMaster] (
    [Tmt_TransactionCode] nvarchar(450) NOT NULL,
    [Tmt_TransactionDate] datetime2,
    [Tmt_TransactionStatus] nvarchar(max),
    [Tmt_UserCode] nvarchar(max),
    [UserMasterUmtUserCode] nvarchar(450),
    CONSTRAINT [PK_TransactionMaster] PRIMARY KEY ([Tmt_TransactionCode]),
    CONSTRAINT [FK_TransactionMaster_UserMaster_UserMasterUmtUserCode] FOREIGN KEY ([UserMasterUmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_AuthIdentityMaster_Amt_UmtUserCode] ON [AuthIdentityMaster] ([Amt_UmtUserCode]) WHERE [Amt_UmtUserCode] IS NOT NULL;

GO

CREATE INDEX [IX_HistoryTableMaster_ProductMasterPmt_ProductCode] ON [HistoryTableMaster] ([ProductMasterPmt_ProductCode]);

GO

CREATE INDEX [IX_HistoryTableMaster_UserMasterUmtUserCode] ON [HistoryTableMaster] ([UserMasterUmtUserCode]);

GO

CREATE INDEX [IX_TransactionDetailMaster_ProductMasterPmt_ProductCode] ON [TransactionDetailMaster] ([ProductMasterPmt_ProductCode]);

GO

CREATE INDEX [IX_TransactionMaster_UserMasterUmtUserCode] ON [TransactionMaster] ([UserMasterUmtUserCode]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919065952_Initial', N'1.1.2');

GO

ALTER TABLE [UserMaster] ADD [Umt_Gender] nvarchar(max);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919070402_addNewColumnGender', N'1.1.2');

GO

EXEC sp_rename N'UserMaster.UmtLastName', N'Umt_UserLastName', N'COLUMN';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919070548_renameLastNameColumn', N'1.1.2');

GO

ALTER TABLE [AuthIdentityMaster] DROP CONSTRAINT [FK_AuthIdentityMaster_UserMaster_Amt_UmtUserCode];

GO

ALTER TABLE [AuthIdentityMaster] DROP CONSTRAINT [PK_AuthIdentityMaster];

GO

EXEC sp_rename N'AuthIdentityMaster', N'AuthIdentityUserMasters';

GO

EXEC sp_rename N'AuthIdentityUserMasters.IX_AuthIdentityMaster_Amt_UmtUserCode', N'IX_AuthIdentityUserMasters_Amt_UmtUserCode', N'INDEX';

GO

ALTER TABLE [AuthIdentityUserMasters] ADD CONSTRAINT [PK_AuthIdentityUserMasters] PRIMARY KEY ([Amt_AuthCode]);

GO

ALTER TABLE [AuthIdentityUserMasters] ADD CONSTRAINT [FK_AuthIdentityUserMasters_UserMaster_Amt_UmtUserCode] FOREIGN KEY ([Amt_UmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919071835_RenamedIdentityUserTable', N'1.1.2');

GO

ALTER TABLE [AuthIdentityUserMasters] DROP CONSTRAINT [FK_AuthIdentityUserMasters_UserMaster_Amt_UmtUserCode];

GO

ALTER TABLE [AuthIdentityUserMasters] ADD CONSTRAINT [FK_AuthIdentityUserMasters_UserMaster_Amt_UmtUserCode] FOREIGN KEY ([Amt_UmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919073416_ChangedDeleteBehaviorinAutIdentity', N'1.1.2');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919073619_RevertToCasCade', N'1.1.2');

GO

