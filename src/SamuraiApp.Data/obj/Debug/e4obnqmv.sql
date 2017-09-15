﻿IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Battles] (
    [Id] int NOT NULL IDENTITY,
    [EndDate] datetime2 NOT NULL,
    [Name] nvarchar(max),
    [StartDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Battles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Samurais] (
    [Id] int NOT NULL IDENTITY,
    [BattleId] int NOT NULL,
    [Name] nvarchar(max),
    CONSTRAINT [PK_Samurais] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Samurais_Battles_BattleId] FOREIGN KEY ([BattleId]) REFERENCES [Battles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Quotes] (
    [Id] int NOT NULL IDENTITY,
    [SamuraiId] int NOT NULL,
    [Text] nvarchar(max),
    CONSTRAINT [PK_Quotes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Quotes_Samurais_SamuraiId] FOREIGN KEY ([SamuraiId]) REFERENCES [Samurais] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Quotes_SamuraiId] ON [Quotes] ([SamuraiId]);

GO

CREATE INDEX [IX_Samurais_BattleId] ON [Samurais] ([BattleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170902054618_init', N'1.1.2');

GO

ALTER TABLE [Samurais] DROP CONSTRAINT [FK_Samurais_Battles_BattleId];

GO

DROP INDEX [IX_Samurais_BattleId] ON [Samurais];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Samurais') AND [c].[name] = N'BattleId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Samurais] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Samurais] DROP COLUMN [BattleId];

GO

CREATE TABLE [SamuraiBattle] (
    [BattleId] int NOT NULL,
    [SamuraiId] int NOT NULL,
    CONSTRAINT [PK_SamuraiBattle] PRIMARY KEY ([BattleId], [SamuraiId]),
    CONSTRAINT [FK_SamuraiBattle_Battles_BattleId] FOREIGN KEY ([BattleId]) REFERENCES [Battles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SamuraiBattle_Samurais_SamuraiId] FOREIGN KEY ([SamuraiId]) REFERENCES [Samurais] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_SamuraiBattle_SamuraiId] ON [SamuraiBattle] ([SamuraiId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170915063701_JoinTable', N'1.1.2');

GO

CREATE TABLE [SecretIdentity] (
    [Id] int NOT NULL IDENTITY,
    [RealName] nvarchar(max),
    [SamuraiId] int NOT NULL,
    CONSTRAINT [PK_SecretIdentity] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SecretIdentity_Samurais_SamuraiId] FOREIGN KEY ([SamuraiId]) REFERENCES [Samurais] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_SecretIdentity_SamuraiId] ON [SecretIdentity] ([SamuraiId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170915065109_SecretIdentity', N'1.1.2');

GO
