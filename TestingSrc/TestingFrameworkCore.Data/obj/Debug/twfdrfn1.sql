IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170916012021_ChangeProductModel')
BEGIN
    CREATE TABLE [T_ProductMaster] (
        [Pmt_ProductCode] char(8) NOT NULL,
        [Pmt_ProductName] char(20),
        [Pmt_ProductPrice] decimal,
        [Pmt_ProductQuantity] int,
        [Pmt_Status] char(1),
        [ludatetime] datetime2 NOT NULL,
        CONSTRAINT [PK_T_ProductMaster] PRIMARY KEY ([Pmt_ProductCode])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170916012021_ChangeProductModel')
BEGIN
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
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170916012021_ChangeProductModel')
BEGIN
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
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170916012021_ChangeProductModel')
BEGIN
    CREATE TABLE [T_TransactionMaster] (
        [Tmt_TransactionCode] char(8) NOT NULL,
        [Tmt_TransactionDate] datetime,
        [Tmt_TransactionStatus] char(1),
        [Tmt_UserCode] char(8),
        CONSTRAINT [PK_T_TransactionMaster] PRIMARY KEY ([Tmt_TransactionCode]),
        CONSTRAINT [FK_T_TransactionMaster_T_UserMaster_Tmt_UserCode] FOREIGN KEY ([Tmt_UserCode]) REFERENCES [T_UserMaster] ([Umt_UserCode]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170916012021_ChangeProductModel')
BEGIN
    CREATE INDEX [IX_T_TransactionDetailMaster_Tdmt_ProductCode] ON [T_TransactionDetailMaster] ([Tdmt_ProductCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170916012021_ChangeProductModel')
BEGIN
    CREATE INDEX [IX_T_TransactionMaster_Tmt_UserCode] ON [T_TransactionMaster] ([Tmt_UserCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170916012021_ChangeProductModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20170916012021_ChangeProductModel', N'1.1.2');
END;

GO

