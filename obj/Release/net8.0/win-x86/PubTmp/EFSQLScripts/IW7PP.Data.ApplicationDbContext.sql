IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525205738_IdentityMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240525205738_IdentityMigration', N'9.0.0-preview.4.24267.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525215715_AddNewColumns'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(13) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525215715_AddNewColumns'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525215715_AddNewColumns'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240525215715_AddNewColumns'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240525215715_AddNewColumns', N'9.0.0-preview.4.24267.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240527001226_PruebaDeMigracion'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240527001226_PruebaDeMigracion', N'9.0.0-preview.4.24267.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [Feet] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [Durability] float NOT NULL,
        CONSTRAINT [PK_Feet] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [KneeArticulates] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [Durability] float NOT NULL,
        CONSTRAINT [PK_KneeArticulates] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [LifeStyles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [promedioDesgaste] float NOT NULL,
        CONSTRAINT [PK_LifeStyles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [Liners] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [Durability] float NOT NULL,
        CONSTRAINT [PK_Liners] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [LowerLimbAmputations] (
        [Id] uniqueidentifier NOT NULL,
        [AmputationName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_LowerLimbAmputations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [Sockets] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(100) NOT NULL,
        [Durability] float NOT NULL,
        CONSTRAINT [PK_Sockets] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [Tubes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [Durability] float NOT NULL,
        CONSTRAINT [PK_Tubes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [UnionSockets] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [Durability] float NOT NULL,
        CONSTRAINT [PK_UnionSockets] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [UpperLimbAmputations] (
        [Id] uniqueidentifier NOT NULL,
        [AmputationName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UpperLimbAmputations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [Prostheses] (
        [Id] int NOT NULL IDENTITY,
        [SocketId] int NULL,
        [LinerId] int NULL,
        [TubeId] int NULL,
        [FootId] int NULL,
        [UnionSocketId] int NULL,
        [KneeArticulateId] int NULL,
        [UpperLimbAmputationsiD] uniqueidentifier NULL,
        [LowerLimbAmputationsiD] uniqueidentifier NULL,
        [Durability] float NOT NULL,
        [AverageDurability] float NOT NULL,
        CONSTRAINT [PK_Prostheses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Prostheses_Feet_FootId] FOREIGN KEY ([FootId]) REFERENCES [Feet] ([Id]),
        CONSTRAINT [FK_Prostheses_KneeArticulates_KneeArticulateId] FOREIGN KEY ([KneeArticulateId]) REFERENCES [KneeArticulates] ([Id]),
        CONSTRAINT [FK_Prostheses_Liners_LinerId] FOREIGN KEY ([LinerId]) REFERENCES [Liners] ([Id]),
        CONSTRAINT [FK_Prostheses_LowerLimbAmputations_LowerLimbAmputationsiD] FOREIGN KEY ([LowerLimbAmputationsiD]) REFERENCES [LowerLimbAmputations] ([Id]),
        CONSTRAINT [FK_Prostheses_Sockets_SocketId] FOREIGN KEY ([SocketId]) REFERENCES [Sockets] ([Id]),
        CONSTRAINT [FK_Prostheses_Tubes_TubeId] FOREIGN KEY ([TubeId]) REFERENCES [Tubes] ([Id]),
        CONSTRAINT [FK_Prostheses_UnionSockets_UnionSocketId] FOREIGN KEY ([UnionSocketId]) REFERENCES [UnionSockets] ([Id]),
        CONSTRAINT [FK_Prostheses_UpperLimbAmputations_UpperLimbAmputationsiD] FOREIGN KEY ([UpperLimbAmputationsiD]) REFERENCES [UpperLimbAmputations] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE TABLE [Clientes] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [ProtesisId] int NOT NULL,
        [ProsthesisId] int NOT NULL,
        [LifeStyleId] int NOT NULL,
        CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Clientes_LifeStyles_LifeStyleId] FOREIGN KEY ([LifeStyleId]) REFERENCES [LifeStyles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Clientes_Prostheses_ProsthesisId] FOREIGN KEY ([ProsthesisId]) REFERENCES [Prostheses] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[Feet]'))
        SET IDENTITY_INSERT [Feet] ON;
    EXEC(N'INSERT INTO [Feet] ([Id], [Description], [Durability], [Name])
    VALUES (1, N''Foot 1 Description'', 6.0E0, N''Foot 1''),
    (2, N''Foot 2 Description'', 12.0E0, N''Foot 2''),
    (3, N''Foot 3 Description'', 18.0E0, N''Foot 3''),
    (4, N''Foot 4 Description'', 24.0E0, N''Foot 4''),
    (5, N''Foot 5 Description'', 30.0E0, N''Foot 5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[Feet]'))
        SET IDENTITY_INSERT [Feet] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[KneeArticulates]'))
        SET IDENTITY_INSERT [KneeArticulates] ON;
    EXEC(N'INSERT INTO [KneeArticulates] ([Id], [Description], [Durability], [Name])
    VALUES (1, N''KneeArticulate 1 Description'', 6.0E0, N''KneeArticulate 1''),
    (2, N''KneeArticulate 2 Description'', 12.0E0, N''KneeArticulate 2''),
    (3, N''KneeArticulate 3 Description'', 18.0E0, N''KneeArticulate 3''),
    (4, N''KneeArticulate 4 Description'', 24.0E0, N''KneeArticulate 4''),
    (5, N''KneeArticulate 5 Description'', 30.0E0, N''KneeArticulate 5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[KneeArticulates]'))
        SET IDENTITY_INSERT [KneeArticulates] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'promedioDesgaste') AND [object_id] = OBJECT_ID(N'[LifeStyles]'))
        SET IDENTITY_INSERT [LifeStyles] ON;
    EXEC(N'INSERT INTO [LifeStyles] ([Id], [Description], [Name], [promedioDesgaste])
    VALUES (1, N''El estilo de vida sedentario implica baja actividad física y largos periodos sentados, a menudo por trabajo o uso de dispositivos'', N''Sedentary'', 0.5E0),
    (2, N''Un estilo de vida activo incluye actividad física moderada y regular, con ejercicios de intensidad moderada'', N''Activo'', 1.0E0),
    (3, N''El estilo de vida de un deportista se enfoca en alta actividad física y rendimiento, dedicando mucho tiempo al entrenamiento'', N''Deportista'', 1.5E0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'promedioDesgaste') AND [object_id] = OBJECT_ID(N'[LifeStyles]'))
        SET IDENTITY_INSERT [LifeStyles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[Liners]'))
        SET IDENTITY_INSERT [Liners] ON;
    EXEC(N'INSERT INTO [Liners] ([Id], [Description], [Durability], [Name])
    VALUES (1, N''Liner 1 Description'', 6.0E0, N''Liner 1''),
    (2, N''Liner 2 Description'', 12.0E0, N''Liner 2''),
    (3, N''Liner 3 Description'', 18.0E0, N''Liner 3''),
    (4, N''Liner 4 Description'', 24.0E0, N''Liner 4''),
    (5, N''Liner 5 Description'', 30.0E0, N''Liner 5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[Liners]'))
        SET IDENTITY_INSERT [Liners] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[LowerLimbAmputations]'))
        SET IDENTITY_INSERT [LowerLimbAmputations] ON;
    EXEC(N'INSERT INTO [LowerLimbAmputations] ([Id], [AmputationName])
    VALUES (''03f6120a-5fe8-434f-83e5-82e50a4ce438'', N''ToePartial''),
    (''1a506915-7368-4947-a28d-97228f344662'', N''FootPartial''),
    (''37fe1f4e-058b-449a-a321-0112ad782c3d'', N''Hemipelvectomy''),
    (''5975536c-9837-44b5-bdaf-24edee8fd7fa'', N''ToeComplete''),
    (''5c237fc7-25e6-4f4e-8881-dd80131c6169'', N''Below Knee''),
    (''704d785e-d24c-4832-9697-ade07716289a'', N''AnkleDisarticulation''),
    (''96b8e4c0-c19f-45d6-9040-26bc4ad5b545'', N''KneeDisarticulation''),
    (''96d2bf06-e884-4df4-9a53-a8eddee5694f'', N''Transfemoral''),
    (''9d18904a-3cd0-4701-8555-08c015874463'', N''Chopart''),
    (''e056bf8b-b140-419e-b921-e6d5c0b7ebf2'', N''Lisfranc''),
    (''e396ded0-1035-4b56-9782-d943a0341fd5'', N''HipDisarticulation''),
    (''e4f15b72-d015-48e9-ac59-3ba806c92993'', N''Transtibial''),
    (''eb2fdb82-7434-4e4d-bdca-c53c66ff18d9'', N''Above Knee'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[LowerLimbAmputations]'))
        SET IDENTITY_INSERT [LowerLimbAmputations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability') AND [object_id] = OBJECT_ID(N'[Sockets]'))
        SET IDENTITY_INSERT [Sockets] ON;
    EXEC(N'INSERT INTO [Sockets] ([Id], [Description], [Durability])
    VALUES (1, N''Socket 1'', 6.0E0),
    (2, N''Socket 2'', 12.0E0),
    (3, N''Socket 3'', 18.0E0),
    (4, N''Socket 4'', 24.0E0),
    (5, N''Socket 5'', 30.0E0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability') AND [object_id] = OBJECT_ID(N'[Sockets]'))
        SET IDENTITY_INSERT [Sockets] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[Tubes]'))
        SET IDENTITY_INSERT [Tubes] ON;
    EXEC(N'INSERT INTO [Tubes] ([Id], [Description], [Durability], [Name])
    VALUES (1, N''Tube 1 Description'', 6.0E0, N''Tube 1''),
    (2, N''Tube 2 Description'', 12.0E0, N''Tube 2''),
    (3, N''Tube 3 Description'', 18.0E0, N''Tube 3''),
    (4, N''Tube 4 Description'', 24.0E0, N''Tube 4''),
    (5, N''Tube 5 Description'', 30.0E0, N''Tube 5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[Tubes]'))
        SET IDENTITY_INSERT [Tubes] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[UnionSockets]'))
        SET IDENTITY_INSERT [UnionSockets] ON;
    EXEC(N'INSERT INTO [UnionSockets] ([Id], [Description], [Durability], [Name])
    VALUES (1, N''UnionSocket 1 Description'', 6.0E0, N''UnionSocket 1''),
    (2, N''UnionSocket 2 Description'', 12.0E0, N''UnionSocket 2''),
    (3, N''UnionSocket 3 Description'', 18.0E0, N''UnionSocket 3''),
    (4, N''UnionSocket 4 Description'', 24.0E0, N''UnionSocket 4''),
    (5, N''UnionSocket 5 Description'', 30.0E0, N''UnionSocket 5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Durability', N'Name') AND [object_id] = OBJECT_ID(N'[UnionSockets]'))
        SET IDENTITY_INSERT [UnionSockets] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[UpperLimbAmputations]'))
        SET IDENTITY_INSERT [UpperLimbAmputations] ON;
    EXEC(N'INSERT INTO [UpperLimbAmputations] ([Id], [AmputationName])
    VALUES (''0d371bc7-cfdc-4a25-8a3f-831b521236ac'', N''Hand Partial''),
    (''191af8c8-378f-48c7-a2b0-d4eab05fc649'', N''Wrist Disarticulation''),
    (''6674355c-74c7-431a-b255-41a6e15d3f1f'', N''Finger Complete''),
    (''8fe2e47b-68c0-48cd-a5e5-36e54e4864c2'', N''Transradial''),
    (''cf4275bf-76fb-4183-a55e-ffbedca1398b'', N''Finger Partial''),
    (''ec7c2d2b-849e-4f30-a11a-166f38d1d757'', N''Elbow Disarticulation'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[UpperLimbAmputations]'))
        SET IDENTITY_INSERT [UpperLimbAmputations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Clientes_LifeStyleId] ON [Clientes] ([LifeStyleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Clientes_ProsthesisId] ON [Clientes] ([ProsthesisId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_FootId] ON [Prostheses] ([FootId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_KneeArticulateId] ON [Prostheses] ([KneeArticulateId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_LinerId] ON [Prostheses] ([LinerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_LowerLimbAmputationsiD] ON [Prostheses] ([LowerLimbAmputationsiD]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_SocketId] ON [Prostheses] ([SocketId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_TubeId] ON [Prostheses] ([TubeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_UnionSocketId] ON [Prostheses] ([UnionSocketId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    CREATE INDEX [IX_Prostheses_UpperLimbAmputationsiD] ON [Prostheses] ([UpperLimbAmputationsiD]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240603235010_AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel', N'9.0.0-preview.4.24267.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    DROP TABLE [Clientes];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''03f6120a-5fe8-434f-83e5-82e50a4ce438'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''1a506915-7368-4947-a28d-97228f344662'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''37fe1f4e-058b-449a-a321-0112ad782c3d'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''5975536c-9837-44b5-bdaf-24edee8fd7fa'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''5c237fc7-25e6-4f4e-8881-dd80131c6169'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''704d785e-d24c-4832-9697-ade07716289a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''96b8e4c0-c19f-45d6-9040-26bc4ad5b545'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''96d2bf06-e884-4df4-9a53-a8eddee5694f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''9d18904a-3cd0-4701-8555-08c015874463'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''e056bf8b-b140-419e-b921-e6d5c0b7ebf2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''e396ded0-1035-4b56-9782-d943a0341fd5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''e4f15b72-d015-48e9-ac59-3ba806c92993'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''eb2fdb82-7434-4e4d-bdca-c53c66ff18d9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''0d371bc7-cfdc-4a25-8a3f-831b521236ac'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''191af8c8-378f-48c7-a2b0-d4eab05fc649'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''6674355c-74c7-431a-b255-41a6e15d3f1f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''8fe2e47b-68c0-48cd-a5e5-36e54e4864c2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''cf4275bf-76fb-4183-a55e-ffbedca1398b'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''ec7c2d2b-849e-4f30-a11a-166f38d1d757'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    CREATE TABLE [ClientesProtesicos] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [LastName] nvarchar(100) NOT NULL,
        [PhoneNumber] nvarchar(10) NOT NULL,
        [ProtesisId] int NOT NULL,
        [LifeStyleId] int NOT NULL,
        [ProsthesisId] int NOT NULL,
        CONSTRAINT [PK_ClientesProtesicos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ClientesProtesicos_LifeStyles_LifeStyleId] FOREIGN KEY ([LifeStyleId]) REFERENCES [LifeStyles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ClientesProtesicos_Prostheses_ProsthesisId] FOREIGN KEY ([ProsthesisId]) REFERENCES [Prostheses] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[LowerLimbAmputations]'))
        SET IDENTITY_INSERT [LowerLimbAmputations] ON;
    EXEC(N'INSERT INTO [LowerLimbAmputations] ([Id], [AmputationName])
    VALUES (''280952f0-7597-4e21-8f0b-7e3e91d037dc'', N''KneeDisarticulation''),
    (''2a9ac8a8-f9f4-4c54-99a4-598fb599647e'', N''FootPartial''),
    (''30f57670-f2e9-44da-8740-bfcc204e2f34'', N''AnkleDisarticulation''),
    (''39c5177f-915b-4b85-adf7-e6024ead7380'', N''HipDisarticulation''),
    (''3e9df86a-fc49-4b3e-be04-691f37f82d41'', N''Transfemoral''),
    (''4d8bc7bf-6f70-4ec1-aee7-d9eb12758ed9'', N''Hemipelvectomy''),
    (''6c6fe8da-437d-47b7-b1db-3e7fbcf785f4'', N''Above Knee''),
    (''a80b771f-3180-4b02-ad52-d9f534192050'', N''ToeComplete''),
    (''c554d246-03a1-4450-9932-5aae776e0d90'', N''Chopart''),
    (''cada66a1-816a-4327-8e1f-42be8f60aaed'', N''Lisfranc''),
    (''d85fc3c6-6ece-4e34-8133-41b7c96e41f8'', N''Below Knee''),
    (''dc198b8b-b03b-489d-bf29-8233b653a5a1'', N''ToePartial''),
    (''f33f5e0d-0d1f-40bb-a4d9-1acd43ca71f1'', N''Transtibial'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[LowerLimbAmputations]'))
        SET IDENTITY_INSERT [LowerLimbAmputations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[UpperLimbAmputations]'))
        SET IDENTITY_INSERT [UpperLimbAmputations] ON;
    EXEC(N'INSERT INTO [UpperLimbAmputations] ([Id], [AmputationName])
    VALUES (''0458f6af-d3f7-4b46-9322-cccb850f6a58'', N''Wrist Disarticulation''),
    (''244b1eec-9d43-4fd2-9b64-5dfd0d7c955b'', N''Hand Partial''),
    (''279863d0-972c-4e73-a9da-db9893d92fcb'', N''Finger Complete''),
    (''afa73303-0747-4886-bc20-7bd78d1450f4'', N''Finger Partial''),
    (''c3285bb6-b165-4691-8dc9-2191fb6aacf2'', N''Elbow Disarticulation''),
    (''f02adbc5-13b2-4bcc-8eb5-3ce0201fcd27'', N''Transradial'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[UpperLimbAmputations]'))
        SET IDENTITY_INSERT [UpperLimbAmputations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    CREATE INDEX [IX_ClientesProtesicos_LifeStyleId] ON [ClientesProtesicos] ([LifeStyleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    CREATE INDEX [IX_ClientesProtesicos_ProsthesisId] ON [ClientesProtesicos] ([ProsthesisId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240608195554_DeleteClienteTableandAddClientesProtesicosTable', N'9.0.0-preview.4.24267.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    ALTER TABLE [ClientesProtesicos] DROP CONSTRAINT [FK_ClientesProtesicos_Prostheses_ProsthesisId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    DROP INDEX [IX_ClientesProtesicos_ProsthesisId] ON [ClientesProtesicos];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''280952f0-7597-4e21-8f0b-7e3e91d037dc'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''2a9ac8a8-f9f4-4c54-99a4-598fb599647e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''30f57670-f2e9-44da-8740-bfcc204e2f34'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''39c5177f-915b-4b85-adf7-e6024ead7380'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''3e9df86a-fc49-4b3e-be04-691f37f82d41'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''4d8bc7bf-6f70-4ec1-aee7-d9eb12758ed9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''6c6fe8da-437d-47b7-b1db-3e7fbcf785f4'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''a80b771f-3180-4b02-ad52-d9f534192050'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''c554d246-03a1-4450-9932-5aae776e0d90'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''cada66a1-816a-4327-8e1f-42be8f60aaed'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''d85fc3c6-6ece-4e34-8133-41b7c96e41f8'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''dc198b8b-b03b-489d-bf29-8233b653a5a1'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [LowerLimbAmputations]
    WHERE [Id] = ''f33f5e0d-0d1f-40bb-a4d9-1acd43ca71f1'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''0458f6af-d3f7-4b46-9322-cccb850f6a58'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''244b1eec-9d43-4fd2-9b64-5dfd0d7c955b'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''279863d0-972c-4e73-a9da-db9893d92fcb'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''afa73303-0747-4886-bc20-7bd78d1450f4'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''c3285bb6-b165-4691-8dc9-2191fb6aacf2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    EXEC(N'DELETE FROM [UpperLimbAmputations]
    WHERE [Id] = ''f02adbc5-13b2-4bcc-8eb5-3ce0201fcd27'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClientesProtesicos]') AND [c].[name] = N'ProsthesisId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ClientesProtesicos] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ClientesProtesicos] DROP COLUMN [ProsthesisId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[LowerLimbAmputations]'))
        SET IDENTITY_INSERT [LowerLimbAmputations] ON;
    EXEC(N'INSERT INTO [LowerLimbAmputations] ([Id], [AmputationName])
    VALUES (''39fbcf8b-345b-424b-bc58-b964d57688f0'', N''Transtibial''),
    (''3c294313-7d66-45d7-92db-5b2698647549'', N''FootPartial''),
    (''4f3ccd91-4b59-421d-942d-38c774154c5a'', N''Above Knee''),
    (''4fd51f44-cca3-47c2-b7a2-562caa13f621'', N''Transfemoral''),
    (''61c38a75-2a85-4794-adbc-64905f7a5097'', N''KneeDisarticulation''),
    (''6b8e74a5-0f23-4747-8606-3932f6460aa3'', N''Below Knee''),
    (''765c2165-54b3-4383-8773-1c2aeda1e71a'', N''AnkleDisarticulation''),
    (''8336c87b-1fba-44ef-8cbe-b1bb56fb083b'', N''Lisfranc''),
    (''8df8a5d8-faa3-443f-968a-4b355e8cc002'', N''ToePartial''),
    (''b97a5175-4379-4a42-8347-0cfeb9bb649b'', N''Hemipelvectomy''),
    (''d323f068-7725-46b2-a9c9-c1bfab541159'', N''ToeComplete''),
    (''e97134ee-b571-43cb-b071-e6c1fb1ff823'', N''HipDisarticulation''),
    (''f6d40f1d-8147-4c52-a4b2-750f6e518afd'', N''Chopart'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[LowerLimbAmputations]'))
        SET IDENTITY_INSERT [LowerLimbAmputations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[UpperLimbAmputations]'))
        SET IDENTITY_INSERT [UpperLimbAmputations] ON;
    EXEC(N'INSERT INTO [UpperLimbAmputations] ([Id], [AmputationName])
    VALUES (''1b8e7f90-c686-47ec-b2ca-5256302d7214'', N''Transradial''),
    (''85b2714c-b346-4f24-9a05-e0ca0749b825'', N''Finger Complete''),
    (''c6e65429-24a1-424a-baa9-acecd37169df'', N''Wrist Disarticulation''),
    (''d315167b-8462-40c7-b62e-6c0db10ad656'', N''Finger Partial''),
    (''d58a37aa-9aed-478b-9efd-959f82110f05'', N''Hand Partial''),
    (''dfb07944-12fb-45ed-b693-57bf8d1301fa'', N''Elbow Disarticulation'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AmputationName') AND [object_id] = OBJECT_ID(N'[UpperLimbAmputations]'))
        SET IDENTITY_INSERT [UpperLimbAmputations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    CREATE INDEX [IX_ClientesProtesicos_ProtesisId] ON [ClientesProtesicos] ([ProtesisId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    ALTER TABLE [ClientesProtesicos] ADD CONSTRAINT [FK_ClientesProtesicos_Prostheses_ProtesisId] FOREIGN KEY ([ProtesisId]) REFERENCES [Prostheses] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240608195945_ModificateClientesProtesicos'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240608195945_ModificateClientesProtesicos', N'9.0.0-preview.4.24267.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240610014426_ModificateColumnProstesisIdToAllowNulls'
)
BEGIN
    ALTER TABLE [ClientesProtesicos] DROP CONSTRAINT [FK_ClientesProtesicos_Prostheses_ProtesisId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240610014426_ModificateColumnProstesisIdToAllowNulls'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClientesProtesicos]') AND [c].[name] = N'ProtesisId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ClientesProtesicos] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ClientesProtesicos] ALTER COLUMN [ProtesisId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240610014426_ModificateColumnProstesisIdToAllowNulls'
)
BEGIN
    ALTER TABLE [ClientesProtesicos] ADD CONSTRAINT [FK_ClientesProtesicos_Prostheses_ProtesisId] FOREIGN KEY ([ProtesisId]) REFERENCES [Prostheses] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240610014426_ModificateColumnProstesisIdToAllowNulls'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240610014426_ModificateColumnProstesisIdToAllowNulls', N'9.0.0-preview.4.24267.1');
END;
GO

COMMIT;
GO

