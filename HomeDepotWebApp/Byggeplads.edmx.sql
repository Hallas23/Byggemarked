
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/03/2020 12:10:30
-- Generated from EDMX file: C:\Users\Simon\source\repos\Byggemarked\HomeDepotWebApp\Byggeplads.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Byggeplads];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KundeBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingSets] DROP CONSTRAINT [FK_KundeBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_VærktøjBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingSets] DROP CONSTRAINT [FK_VærktøjBooking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BookingSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingSets];
GO
IF OBJECT_ID(N'[dbo].[KundeSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KundeSets];
GO
IF OBJECT_ID(N'[dbo].[VærktøjSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VærktøjSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookingSets'
CREATE TABLE [dbo].[BookingSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Afhentningstid] datetime  NOT NULL,
    [Antaldage] int  NOT NULL,
    [KundeId] int  NOT NULL,
    [VærktøjId] int  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KundeSets'
CREATE TABLE [dbo].[KundeSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adresse] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Brugernavn] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VærktøjSet'
CREATE TABLE [dbo].[VærktøjSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Navn] nvarchar(max)  NOT NULL,
    [Beskrivelse] nvarchar(max)  NOT NULL,
    [Depositum] float  NOT NULL,
    [Døgnpris] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BookingSets'
ALTER TABLE [dbo].[BookingSets]
ADD CONSTRAINT [PK_BookingSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KundeSets'
ALTER TABLE [dbo].[KundeSets]
ADD CONSTRAINT [PK_KundeSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VærktøjSet'
ALTER TABLE [dbo].[VærktøjSet]
ADD CONSTRAINT [PK_VærktøjSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KundeId] in table 'BookingSets'
ALTER TABLE [dbo].[BookingSets]
ADD CONSTRAINT [FK_KundeBooking]
    FOREIGN KEY ([KundeId])
    REFERENCES [dbo].[KundeSets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KundeBooking'
CREATE INDEX [IX_FK_KundeBooking]
ON [dbo].[BookingSets]
    ([KundeId]);
GO

-- Creating foreign key on [VærktøjId] in table 'BookingSets'
ALTER TABLE [dbo].[BookingSets]
ADD CONSTRAINT [FK_VærktøjBooking]
    FOREIGN KEY ([VærktøjId])
    REFERENCES [dbo].[VærktøjSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VærktøjBooking'
CREATE INDEX [IX_FK_VærktøjBooking]
ON [dbo].[BookingSets]
    ([VærktøjId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------