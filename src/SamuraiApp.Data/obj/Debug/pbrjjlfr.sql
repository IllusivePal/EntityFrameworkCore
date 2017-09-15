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

