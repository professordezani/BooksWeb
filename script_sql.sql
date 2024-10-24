Build started...
Build succeeded.
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

CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [Synopsis] nvarchar(max) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId])
);
GO

CREATE TABLE [Readers] (
    [ReaderId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Readers] PRIMARY KEY ([ReaderId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240927165413_Initial', N'8.0.8');
GO

COMMIT;
GO


