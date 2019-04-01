
Insert into Mantenimiento_Departamento values(001, 'Direccion')

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/22/2019 22:51:18
-- Generated from EDMX file: C:\Users\Enrique R\source\repos\juan991103\GestionRHP3\GestionRH\Models\MaitenanceModule.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GestionRH];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Mantenimiento_Empleado'
CREATE TABLE [dbo].[Mantenimiento_Empleado] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo_empleado]int NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Apellido] nvarchar(50)  NOT NULL,
    [Telefono] nvarchar(50) NOT NULL,
    [Departamento] nvarchar(50) NOT NULL,
    [Fecha_Ingreso] datetime  NOT NULL,
    [Salario] float  NOT NULL,
    [Estatus] bit NOT NULL,
    [Cargo] nvarchar(50) NOT NULL
);
GO

-- Creating table 'Mantenimiento_Departamento'
CREATE TABLE [dbo].[Mantenimiento_Departamento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo_Departamento] int NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Mantenimiento_Cargo'
CREATE TABLE [dbo].[Mantenimiento_Cargo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo_Cargo] int  NOT NULL,
    [Nombre_Cargo] nvarchar(50)  NOT NULL
);
GO

insert into Mantenimiento_Cargo values(001, 'Director')



-- Creating table 'Process_nominas'
CREATE TABLE [dbo].[Process_nominas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Age] datetime  NOT NULL,
    [mes] datetime  NOT NULL,
    [monto_total] float  NOT NULL
);
GO

-- Creating table 'Process_salida_empleado'
CREATE TABLE [dbo].[Process_salida_empleado] (
    [Empleado] nvarchar(50)  NOT NULL,
    [Tipo_de_salida] nvarchar(50)  NOT NULL,
    [Motivo] nvarchar(50)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Process_Vacaciones'
CREATE TABLE [dbo].[Process_Vacaciones] (
    [Empleado] nvarchar(50)  NOT NULL,
    [desde] datetime  NOT NULL,
    [hasta] datetime  NOT NULL,
    [correspondiente] datetime  NOT NULL,
    [comentario] nvarchar(max)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Process_licencias'
CREATE TABLE [dbo].[Process_licencias] (
    [Empleado] nvarchar(50)  NOT NULL,
    [desde] datetime  NOT NULL,
    [hasta] datetime  NOT NULL,
    [comentario] nvarchar(50)  NOT NULL,
    [motivo] nvarchar(50)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Process_Permisos'
CREATE TABLE [dbo].[Process_Permisos] (
    [Empleado] nvarchar(50)  NOT NULL,
    [desde] datetime  NOT NULL,
    [hasta] datetime  NOT NULL,
    [comentario] nvarchar(50)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Mantenimiento_Empleado'
ALTER TABLE [dbo].[Mantenimiento_Empleado]
ADD CONSTRAINT [PK_Mantenimiento_Empleado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mantenimiento_Departamento'
ALTER TABLE [dbo].[Mantenimiento_Departamento]
ADD CONSTRAINT [PK_Mantenimiento_Departamento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mantenimiento_Cargo'
ALTER TABLE [dbo].[Mantenimiento_Cargo]
ADD CONSTRAINT [PK_Mantenimiento_Cargo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Process_nominas'
ALTER TABLE [dbo].[Process_nominas]
ADD CONSTRAINT [PK_Process_nominas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Process_salida_empleado'
ALTER TABLE [dbo].[Process_salida_empleado]
ADD CONSTRAINT [PK_Process_salida_empleado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Process_Vacaciones'
ALTER TABLE [dbo].[Process_Vacaciones]
ADD CONSTRAINT [PK_Process_Vacaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Process_licencias'
ALTER TABLE [dbo].[Process_licencias]
ADD CONSTRAINT [PK_Process_licencias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Process_Permisos'
ALTER TABLE [dbo].[Process_Permisos]
ADD CONSTRAINT [PK_Process_Permisos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

INSERT INTO Mantenimiento_Empleado VALUES(001, 'Juan', 'Rosario', '8095554197', 'Software', '2019-01-01', 20000, 1, 'Contador')
INSERT INTO Mantenimiento_Departamento VALUES(001, 'Software')
INSERT INTO Mantenimiento_Cargo VALUES(001, 'Contador')
