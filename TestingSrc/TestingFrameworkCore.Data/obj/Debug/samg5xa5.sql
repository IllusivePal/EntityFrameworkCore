IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [T_ProductMaster] (
    [Pmt_ProductCode] char(8) NOT NULL,
    [Pmt_ProductName] char(20),
    [Pmt_ProductPrice] decimal,
    [Pmt_ProductQuantity] int,
    [Pmt_Status] char(1),
    [ludatetime] datetime2 NOT NULL,
    CONSTRAINT [PK_T_ProductMaster] PRIMARY KEY ([Pmt_ProductCode])
);

GO

CREATE TABLE [T_UserMaster] (
    [Umt_UserCode] char(8) NOT NULL,
    [Umt_Email] char(20),
    [Umt_FirstName] char(20),
    [Umt_LastName] char(20),
    [Umt_MiddleName] char(20),
    [Umt_Password] char(20),
    [Umt_Status] char(1),
    CONSTRAINT [PK_T_UserMaster] PRIMARY KEY ([Umt_UserCode])
);

GO

CREATE TABLE [T_TransactionDetailMaster] (
    [Tdmt_TransactionDetailCode] char(8) NOT NULL,
    [Tdmt_Date] datetime,
    [Tdmt_Price] decimal,
    [Tdmt_ProductCode] char(8),
    [Tdmt_Quantity] decimal,
    [Tdmt_Status] char(1),
    [Tdmt_TotalPayment] decimal,
    [Tdmt_TransactionCode] char(8),
    CONSTRAINT [PK_T_TransactionDetailMaster] PRIMARY KEY ([Tdmt_TransactionDetailCode]),
    CONSTRAINT [FK_T_TransactionDetailMaster_T_TransactionMaster] FOREIGN KEY ([Tdmt_ProductCode]) REFERENCES [T_ProductMaster] ([Pmt_ProductCode]) ON DELETE CASCADE
);

GO

CREATE TABLE [T_TransactionMaster] (
    [Tmt_TransactionCode] char(8) NOT NULL,
    [Tmt_TransactionDate] datetime,
    [Tmt_TransactionStatus] char(1),
    [Tmt_UserCode] char(8),
    CONSTRAINT [PK_T_TransactionMaster] PRIMARY KEY ([Tmt_TransactionCode]),
    CONSTRAINT [FK_T_TransactionMaster_T_UserMaster_Tmt_UserCode] FOREIGN KEY ([Tmt_UserCode]) REFERENCES [T_UserMaster] ([Umt_UserCode]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_T_TransactionDetailMaster_Tdmt_ProductCode] ON [T_TransactionDetailMaster] ([Tdmt_ProductCode]);

GO

CREATE INDEX [IX_T_TransactionMaster_Tmt_UserCode] ON [T_TransactionMaster] ([Tmt_UserCode]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916012021_ChangeProductModel', N'1.1.2');

GO

EXEC sp_rename N'T_ProductMaster.Pmt_Status', N'Status', N'COLUMN';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916014403_ChangeStatusName', N'1.1.2');

GO

ALTER TABLE [T_ProductMaster] ADD [ludatetime] datetime NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916014912_AddModelInProductsTable', N'1.1.2');

GO

EXEC sp_rename N'T_ProductMaster.ludatetime', N'ludatetimes', N'COLUMN';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916020248_revertChangeColoumnnamr', N'1.1.2');

GO

CREATE TABLE [History] (
    [UserCode] nvarchar(450) NOT NULL,
    [ProductCode] nvarchar(450) NOT NULL,
    [Description] nvarchar(max),
    [ProductPmtProductCode] char(8),
    [UserUmtUserCode] char(8),
    CONSTRAINT [PK_History] PRIMARY KEY ([UserCode], [ProductCode]),
    CONSTRAINT [FK_History_T_ProductMaster_ProductPmtProductCode] FOREIGN KEY ([ProductPmtProductCode]) REFERENCES [T_ProductMaster] ([Pmt_ProductCode]) ON DELETE CASCADE,
    CONSTRAINT [FK_History_T_UserMaster_UserUmtUserCode] FOREIGN KEY ([UserUmtUserCode]) REFERENCES [T_UserMaster] ([Umt_UserCode]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_History_ProductPmtProductCode] ON [History] ([ProductPmtProductCode]);

GO

CREATE INDEX [IX_History_UserUmtUserCode] ON [History] ([UserUmtUserCode]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916025521_AddSchema', N'1.1.2');

GO

CREATE TABLE [HistoryTable] (
    [UmtUserCode] char(8) NOT NULL,
    [PmtProductCode] char(8) NOT NULL,
    [Description] nvarchar(max),
    CONSTRAINT [PK_HistoryTable] PRIMARY KEY ([UmtUserCode], [PmtProductCode]),
    CONSTRAINT [FK_HistoryTable_T_ProductMaster_PmtProductCode] FOREIGN KEY ([PmtProductCode]) REFERENCES [T_ProductMaster] ([Pmt_ProductCode]) ON DELETE CASCADE,
    CONSTRAINT [FK_HistoryTable_T_UserMaster_UmtUserCode] FOREIGN KEY ([UmtUserCode]) REFERENCES [T_UserMaster] ([Umt_UserCode]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_HistoryTable_PmtProductCode] ON [HistoryTable] ([PmtProductCode]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916032806_AddHistoryTable', N'1.1.2');

GO

CREATE TABLE [AuthIdentity] (
    [AuthCode] nvarchar(450) NOT NULL,
    [AuthName] nvarchar(max),
    [PmtProductCode] char(8),
    CONSTRAINT [PK_AuthIdentity] PRIMARY KEY ([AuthCode]),
    CONSTRAINT [FK_AuthIdentity_T_ProductMaster_PmtProductCode] FOREIGN KEY ([PmtProductCode]) REFERENCES [T_ProductMaster] ([Pmt_ProductCode]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_AuthIdentity_PmtProductCode] ON [AuthIdentity] ([PmtProductCode]) WHERE [PmtProductCode] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916035831_addAuthIdentityClass', N'1.1.2');

GO

ALTER TABLE [AuthIdentity] DROP CONSTRAINT [FK_AuthIdentity_T_ProductMaster_PmtProductCode];

GO

EXEC sp_rename N'AuthIdentity.PmtProductCode', N'UmtUserCode', N'COLUMN';

GO

EXEC sp_rename N'AuthIdentity.IX_AuthIdentity_PmtProductCode', N'IX_AuthIdentity_UmtUserCode', N'INDEX';

GO

ALTER TABLE [AuthIdentity] ADD CONSTRAINT [FK_T_TransactionMaster_T_UserMaster] FOREIGN KEY ([UmtUserCode]) REFERENCES [T_UserMaster] ([Umt_UserCode]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170918235008_ChangedRelationship', N'1.1.2');

GO

ALTER TABLE [AuthIdentity] DROP CONSTRAINT [FK_T_TransactionMaster_T_UserMaster];

GO

CREATE TABLE [ProductAccountCodeIdentity] (
    [PmtProductCode] nvarchar(450) NOT NULL,
    [Account] int NOT NULL,
    [Description] nvarchar(max),
    CONSTRAINT [PK_ProductAccountCodeIdentity] PRIMARY KEY ([PmtProductCode])
);

GO

ALTER TABLE [AuthIdentity] ADD CONSTRAINT [FK_AuthIdentity_T_UserMaster_UmtUserCode] FOREIGN KEY ([UmtUserCode]) REFERENCES [T_UserMaster] ([Umt_UserCode]) ON DELETE CASCADE;

GO

ALTER TABLE [T_ProductMaster] ADD CONSTRAINT [FK_T_ProductMaster_ProductAccountCodeIdentity_Pmt_ProductCode] FOREIGN KEY ([Pmt_ProductCode]) REFERENCES [ProductAccountCodeIdentity] ([PmtProductCode]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919024214_NewTableForAccountProduct', N'1.1.2');

GO

