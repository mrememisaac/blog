USE master
GO
DROP DATABASE IF EXISTS EmemIsaac.Blog
GO

CREATE DATABASE EmemIsaac.Blog
GO 
USE EmemIsaac.Blog
GO 

USE master;
GO
CREATE LOGIN [dbuser] WITH PASSWORD=N'Sql1nContainersR0cks!', CHECK_EXPIRATION=OFF, CHECK_POLICY=ON;
GO
USE EmemIsaac.Blog;
GO
CREATE USER [dbuser] FOR LOGIN [dbuser];
GO
EXEC sp_addrolemember N'db_owner', [dbuser];
GO

----------------------------------------------------------------------------
--- TABLE CREATION
----------------------------------------------------------------------------
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

CREATE TABLE [Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Url] nvarchar(50) NOT NULL,
    [CreateDate] datetimeoffset NOT NULL,
    [CreatorId] nvarchar(50) NOT NULL,
    [LastModifiedDate] datetimeoffset NOT NULL,
    [ModifierId] nvarchar(50) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Articles] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(100) NOT NULL,
    [ImageUrl] nvarchar(250) NOT NULL,
    [Url] nvarchar(100) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [Content] nvarchar(4000) NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [PublishDate] datetimeoffset NOT NULL,
    [Stage] int NOT NULL,
    [CreateDate] datetimeoffset NOT NULL,
    [CreatorId] nvarchar(50) NOT NULL,
    [LastModifiedDate] datetimeoffset NOT NULL,
    [ModifierId] nvarchar(50) NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Articles_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comment] (
    [Id] uniqueidentifier NOT NULL,
    [ParentId] uniqueidentifier NOT NULL,
    [Content] nvarchar(250) NOT NULL,
    [ArticleId] uniqueidentifier NOT NULL,
    [AuthorName] nvarchar(50) NOT NULL,
    [CreateDate] datetimeoffset NOT NULL,
    [CreatorId] nvarchar(50) NOT NULL,
    [LastModifiedDate] datetimeoffset NOT NULL,
    [ModifierId] nvarchar(50) NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comment_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [Articles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tag] (
    [Id] uniqueidentifier NOT NULL,
    [ArticleId] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tag_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [Articles] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Articles_CategoryId] ON [Articles] ([CategoryId]);
GO

CREATE INDEX [IX_Comment_ArticleId] ON [Comment] ([ArticleId]);
GO

CREATE INDEX [IX_Tag_ArticleId] ON [Tag] ([ArticleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230707190429_InitialCreate', N'7.0.13');
GO

COMMIT;
GO

