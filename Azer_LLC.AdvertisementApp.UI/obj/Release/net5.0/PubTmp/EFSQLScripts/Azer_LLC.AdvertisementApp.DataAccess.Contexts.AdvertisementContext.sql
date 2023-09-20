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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [AdvertisementAppUserStatuses] (
        [Id] int NOT NULL IDENTITY,
        [Definition] nvarchar(300) NOT NULL,
        CONSTRAINT [PK_AdvertisementAppUserStatuses] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [Advertisements] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(200) NOT NULL,
        [Status] bit NOT NULL,
        [Description] ntext NOT NULL,
        [CreatedDate] datetime2 NOT NULL DEFAULT (getdate()),
        CONSTRAINT [PK_Advertisements] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [AppRoles] (
        [Id] int NOT NULL IDENTITY,
        [Definition] nvarchar(300) NOT NULL,
        CONSTRAINT [PK_AppRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [Genders] (
        [Id] int NOT NULL IDENTITY,
        [Definition] nvarchar(300) NOT NULL,
        CONSTRAINT [PK_Genders] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [MilitaryStatuses] (
        [Id] int NOT NULL IDENTITY,
        [Definition] nvarchar(300) NOT NULL,
        CONSTRAINT [PK_MilitaryStatuses] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [ProvidedServices] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(300) NOT NULL,
        [ImagePath] nvarchar(500) NOT NULL,
        [Description] ntext NOT NULL,
        [CreatedDate] datetime2 NOT NULL DEFAULT (getdate()),
        CONSTRAINT [PK_ProvidedServices] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [AppUsers] (
        [Id] int NOT NULL IDENTITY,
        [Firstname] nvarchar(300) NOT NULL,
        [Surname] nvarchar(300) NOT NULL,
        [Username] nvarchar(300) NOT NULL,
        [Password] nvarchar(50) NOT NULL,
        [PhoneNumber] nvarchar(20) NOT NULL,
        [Email] nvarchar(max) NULL,
        [GenderId] int NOT NULL,
        CONSTRAINT [PK_AppUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AppUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [AdvertisementAppUsers] (
        [Id] int NOT NULL IDENTITY,
        [AdvertisementId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [AdvertisementAppUserStatusId] int NOT NULL,
        [MilitaryStatusId] int NOT NULL,
        [EndDate] datetime2 NULL,
        [WorkExperience] int NOT NULL,
        [CvPath] nvarchar(500) NOT NULL,
        CONSTRAINT [PK_AdvertisementAppUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AdvertisementAppUsers_AdvertisementAppUserStatuses_AdvertisementAppUserStatusId] FOREIGN KEY ([AdvertisementAppUserStatusId]) REFERENCES [AdvertisementAppUserStatuses] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AdvertisementAppUsers_Advertisements_AdvertisementId] FOREIGN KEY ([AdvertisementId]) REFERENCES [Advertisements] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AdvertisementAppUsers_AppUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AdvertisementAppUsers_MilitaryStatuses_MilitaryStatusId] FOREIGN KEY ([MilitaryStatusId]) REFERENCES [MilitaryStatuses] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE TABLE [AppUserRoles] (
        [Id] int NOT NULL IDENTITY,
        [AppUserId] int NOT NULL,
        [AppRoleId] int NOT NULL,
        CONSTRAINT [PK_AppUserRoles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AppUserRoles_AppRoles_AppRoleId] FOREIGN KEY ([AppRoleId]) REFERENCES [AppRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AppUserRoles_AppUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Definition') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
        SET IDENTITY_INSERT [AppRoles] ON;
    EXEC(N'INSERT INTO [AppRoles] ([Id], [Definition])
    VALUES (1, N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Definition') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
        SET IDENTITY_INSERT [AppRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Definition') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
        SET IDENTITY_INSERT [AppRoles] ON;
    EXEC(N'INSERT INTO [AppRoles] ([Id], [Definition])
    VALUES (2, N''Member'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Definition') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
        SET IDENTITY_INSERT [AppRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE INDEX [IX_AdvertisementAppUsers_AdvertisementAppUserStatusId] ON [AdvertisementAppUsers] ([AdvertisementAppUserStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE UNIQUE INDEX [IX_AdvertisementAppUsers_AdvertisementId_AppUserId] ON [AdvertisementAppUsers] ([AdvertisementId], [AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE INDEX [IX_AdvertisementAppUsers_AppUserId] ON [AdvertisementAppUsers] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE INDEX [IX_AdvertisementAppUsers_MilitaryStatusId] ON [AdvertisementAppUsers] ([MilitaryStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE INDEX [IX_AppUserRoles_AppRoleId] ON [AppUserRoles] ([AppRoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE UNIQUE INDEX [IX_AppUserRoles_AppUserId_AppRoleId] ON [AppUserRoles] ([AppUserId], [AppRoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    CREATE INDEX [IX_AppUsers_GenderId] ON [AppUsers] ([GenderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914133359_DataAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230914133359_DataAdded', N'5.0.1');
END;
GO

COMMIT;
GO

