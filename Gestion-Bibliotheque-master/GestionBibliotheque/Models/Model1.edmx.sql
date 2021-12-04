
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2018 13:02:37
-- Generated from EDMX file: C:\Users\Dev INFO\Desktop\ESISA_4_eme_annee\S2\MVC\TpProjet\GestionBibliotheque\GestionBibliotheque\Models\Model1.edmx
-- --------------------------------------------------

create database dbBib;
SET QUOTED_IDENTIFIER OFF;
GO
USE [dbBib];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_fk3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[etudiant] DROP CONSTRAINT [FK_fk3];
GO
IF OBJECT_ID(N'[dbo].[FK_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[auteur] DROP CONSTRAINT [FK_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_fk1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[emprunt] DROP CONSTRAINT [FK_fk1];
GO
IF OBJECT_ID(N'[dbo].[FK_fk2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[emprunt] DROP CONSTRAINT [FK_fk2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Compte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Compte];
GO
IF OBJECT_ID(N'[dbo].[auteur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[auteur];
GO
IF OBJECT_ID(N'[dbo].[emprunt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[emprunt];
GO
IF OBJECT_ID(N'[dbo].[etudiant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[etudiant];
GO
IF OBJECT_ID(N'[dbo].[ouvrage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ouvrage];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Compte'
CREATE TABLE [dbo].[Compte] (
    [login] varchar(50)  NOT NULL,
    [pwd] varchar(50)  NOT NULL,
    [role] int  NOT NULL
);
GO

-- Creating table 'auteur'
CREATE TABLE [dbo].[auteur] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nom] varchar(50)  NOT NULL,
    [prenom] varchar(50)  NOT NULL,
    [idouvrage] int  NOT NULL
);
GO

-- Creating table 'emprunt'
CREATE TABLE [dbo].[emprunt] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [idouvrage] int  NOT NULL,
    [idetudiant] int  NOT NULL,
    [dateemprunt] datetime  NOT NULL,
    [dateretour] datetime  NULL
);
GO

-- Creating table 'etudiant'
CREATE TABLE [dbo].[etudiant] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nom] varchar(50)  NOT NULL,
    [prenom] varchar(50)  NOT NULL,
    [niveau] int  NOT NULL,
    [login] varchar(50)  NULL
);
GO

-- Creating table 'ouvrage'
CREATE TABLE [dbo].[ouvrage] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [titre] varchar(50)  NOT NULL,
    [edition] datetime  NOT NULL,
    [nbExemplaires] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [login] in table 'Compte'
ALTER TABLE [dbo].[Compte]
ADD CONSTRAINT [PK_Compte]
    PRIMARY KEY CLUSTERED ([login] ASC);
GO

-- Creating primary key on [Id] in table 'auteur'
ALTER TABLE [dbo].[auteur]
ADD CONSTRAINT [PK_auteur]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'emprunt'
ALTER TABLE [dbo].[emprunt]
ADD CONSTRAINT [PK_emprunt]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'etudiant'
ALTER TABLE [dbo].[etudiant]
ADD CONSTRAINT [PK_etudiant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ouvrage'
ALTER TABLE [dbo].[ouvrage]
ADD CONSTRAINT [PK_ouvrage]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [login] in table 'etudiant'
ALTER TABLE [dbo].[etudiant]
ADD CONSTRAINT [FK_fk3]
    FOREIGN KEY ([login])
    REFERENCES [dbo].[Compte]
        ([login])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fk3'
CREATE INDEX [IX_FK_fk3]
ON [dbo].[etudiant]
    ([login]);
GO

-- Creating foreign key on [idouvrage] in table 'auteur'
ALTER TABLE [dbo].[auteur]
ADD CONSTRAINT [FK_fk]
    FOREIGN KEY ([idouvrage])
    REFERENCES [dbo].[ouvrage]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fk'
CREATE INDEX [IX_FK_fk]
ON [dbo].[auteur]
    ([idouvrage]);
GO

-- Creating foreign key on [idouvrage] in table 'emprunt'
ALTER TABLE [dbo].[emprunt]
ADD CONSTRAINT [FK_fk1]
    FOREIGN KEY ([idouvrage])
    REFERENCES [dbo].[ouvrage]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fk1'
CREATE INDEX [IX_FK_fk1]
ON [dbo].[emprunt]
    ([idouvrage]);
GO

-- Creating foreign key on [idetudiant] in table 'emprunt'
ALTER TABLE [dbo].[emprunt]
ADD CONSTRAINT [FK_fk2]
    FOREIGN KEY ([idetudiant])
    REFERENCES [dbo].[etudiant]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fk2'
CREATE INDEX [IX_FK_fk2]
ON [dbo].[emprunt]
    ([idetudiant]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------