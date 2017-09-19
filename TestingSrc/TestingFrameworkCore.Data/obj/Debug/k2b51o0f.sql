IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [ProductAccountCodeIdentity] (
    [PmtProductCode] nvarchar(450) NOT NULL,
    [Account] int NOT NULL,
    [Description] nvarchar(max),
    CONSTRAINT [PK_ProductAccountCodeIdentity] PRIMARY KEY ([PmtProductCode])
);

GO

CREATE UNIQUE INDEX [IX_AuthIdentity_UmtUserCode] ON [AuthIdentity] ([UmtUserCode]) WHERE [UmtUserCode] IS NOT NULL;

GO

CREATE INDEX [IX_HistoryTable_PmtProductCode] ON [HistoryTable] ([PmtProductCode]);

GO

CREATE INDEX [IX_T_TransactionDetailMaster_Tdmt_ProductCode] ON [T_TransactionDetailMaster] ([Tdmt_ProductCode]);

GO

CREATE INDEX [IX_T_TransactionMaster_Tmt_UserCode] ON [T_TransactionMaster] ([Tmt_UserCode]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919034226_NewTableForAccountProduct', N'1.1.2');

GO

