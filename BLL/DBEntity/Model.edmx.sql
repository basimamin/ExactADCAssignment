
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2018 19:01:34
-- Generated from EDMX file: D:\Backup Projects\Basim_Code\ExactAssignment\BLL\DBEntity\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FilesDocuments];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DropBoxExactOnline]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DropBoxExactOnline];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DropBoxExactOnlines'
CREATE TABLE [dbo].[DropBoxExactOnlines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DropBoxPath] nvarchar(500)  NOT NULL,
    [ExactOnlineGUID] nvarchar(50)  NOT NULL,
    [isFile] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DropBoxExactOnlines'
ALTER TABLE [dbo].[DropBoxExactOnlines]
ADD CONSTRAINT [PK_DropBoxExactOnlines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------