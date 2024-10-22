Build started...
Build failed. Use dotnet build to see the errors.
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

BEGIN TRANSACTION;
GO

CREATE TABLE [BooksReaders] (
    [BookReaderId] int NOT NULL IDENTITY,
    [BookId] int NOT NULL,
    [ReaderId] int NOT NULL,
    [Score] int NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_BooksReaders] PRIMARY KEY ([BookReaderId]),
    CONSTRAINT [FK_BooksReaders_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]) ON DELETE CASCADE,
    CONSTRAINT [FK_BooksReaders_Readers_ReaderId] FOREIGN KEY ([ReaderId]) REFERENCES [Readers] ([ReaderId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BooksReaders_BookId] ON [BooksReaders] ([BookId]);
GO

CREATE INDEX [IX_BooksReaders_ReaderId] ON [BooksReaders] ([ReaderId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241022203137_newtable', N'8.0.8');
GO

COMMIT;
GO


