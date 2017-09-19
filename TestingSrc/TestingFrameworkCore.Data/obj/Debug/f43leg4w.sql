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

CREATE TABLE [ProductAccountCodeIdentity] (
    [Pacmt_ProductCode] nvarchar(450) NOT NULL,
    [Pacmt_Account] int NOT NULL,
    [Pacmt_Description] nvarchar(max),
    CONSTRAINT [PK_ProductAccountCodeIdentity] PRIMARY KEY ([Pacmt_ProductCode]),
    CONSTRAINT [FK_ProductAccountCodeIdentity_ProductMaster_Pacmt_ProductCode] FOREIGN KEY ([Pacmt_ProductCode]) REFERENCES [ProductMaster] ([Pmt_ProductCode]) ON DELETE CASCADE
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
    CONSTRAINT [FK_TransactionDetailMaster_ProductMaster_ProductMasterPmt_ProductCode] FOREIGN KEY ([ProductMasterPmt_ProductCode]) REFERENCES [ProductMaster] ([Pmt_ProductCode]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AuthIdentity] (
    [Amt_AuthCode] nvarchar(450) NOT NULL,
    [Amt_AuthName] nvarchar(max),
    [Amt_UmtUserCode] nvarchar(450),
    CONSTRAINT [PK_AuthIdentity] PRIMARY KEY ([Amt_AuthCode]),
    CONSTRAINT [FK_AuthIdentity_UserMaster_Amt_UmtUserCode] FOREIGN KEY ([Amt_UmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE NO ACTION
);

GO

CREATE TABLE [HistoryTable] (
    [Hmt_PmtProductCode] nvarchar(450) NOT NULL,
    [Hmt_UmtUserCode] nvarchar(450) NOT NULL,
    [Hmt_Description] nvarchar(max),
    [ProductMasterPmt_ProductCode] nvarchar(450),
    [UserMasterUmtUserCode] nvarchar(450),
    CONSTRAINT [PK_HistoryTable] PRIMARY KEY ([Hmt_PmtProductCode], [Hmt_UmtUserCode]),
    CONSTRAINT [FK_HistoryTable_ProductMaster_ProductMasterPmt_ProductCode] FOREIGN KEY ([ProductMasterPmt_ProductCode]) REFERENCES [ProductMaster] ([Pmt_ProductCode]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoryTable_UserMaster_UserMasterUmtUserCode] FOREIGN KEY ([UserMasterUmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TransactionMaster] (
    [Tmt_TransactionCode] nvarchar(450) NOT NULL,
    [Tmt_TransactionDate] datetime2,
    [Tmt_TransactionStatus] nvarchar(max),
    [Tmt_UserCode] nvarchar(max),
    [UserMasterUmtUserCode] nvarchar(450),
    CONSTRAINT [PK_TransactionMaster] PRIMARY KEY ([Tmt_TransactionCode]),
    CONSTRAINT [FK_TransactionMaster_UserMaster_UserMasterUmtUserCode] FOREIGN KEY ([UserMasterUmtUserCode]) REFERENCES [UserMaster] ([UmtUserCode]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_AuthIdentity_Amt_UmtUserCode] ON [AuthIdentity] ([Amt_UmtUserCode]) WHERE [Amt_UmtUserCode] IS NOT NULL;

GO

CREATE INDEX [IX_HistoryTable_ProductMasterPmt_ProductCode] ON [HistoryTable] ([ProductMasterPmt_ProductCode]);

GO

CREATE INDEX [IX_HistoryTable_UserMasterUmtUserCode] ON [HistoryTable] ([UserMasterUmtUserCode]);

GO

CREATE INDEX [IX_TransactionDetailMaster_ProductMasterPmt_ProductCode] ON [TransactionDetailMaster] ([ProductMasterPmt_ProductCode]);

GO

CREATE INDEX [IX_TransactionMaster_UserMasterUmtUserCode] ON [TransactionMaster] ([UserMasterUmtUserCode]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170919042523_RevisedClass', N'1.1.2');

GO

