Build started...
Build succeeded.
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Books" (
    "BookId" INTEGER NOT NULL CONSTRAINT "PK_Books" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Author" TEXT NOT NULL,
    "Synopsis" TEXT NOT NULL,
    "Gender" TEXT NOT NULL
);

CREATE TABLE "Readers" (
    "ReaderId" INTEGER NOT NULL CONSTRAINT "PK_Readers" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Password" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240927163150_Initial', '8.0.8');

COMMIT;


Build started...
Build failed. Use dotnet build to see the errors.
