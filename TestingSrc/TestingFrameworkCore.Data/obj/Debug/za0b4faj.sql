DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'T_ProductMaster') AND [c].[name] = N'ludatetime');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [T_ProductMaster] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [T_ProductMaster] ALTER COLUMN [ludatetime] datetime NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170916013912_revertChangesProductModel', N'1.1.2');

GO

