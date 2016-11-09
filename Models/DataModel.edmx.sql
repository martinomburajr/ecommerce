
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2016 14:24:40
-- Generated from EDMX file: C:\Users\Martin Ombura\Desktop\dev\poppel\Poppel\Poppel\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PoppelDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK_CustomerId];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerId2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK_CustomerId2];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK_CustomerTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK_OrderItem];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentId2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK_PaymentId2];
GO
IF OBJECT_ID(N'[dbo].[FK_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PoppelStore] DROP CONSTRAINT [FK_ProductId];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionId2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK_TransactionId2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Delivery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Delivery];
GO
IF OBJECT_ID(N'[dbo].[OrderItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItem];
GO
IF OBJECT_ID(N'[dbo].[Payment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payment];
GO
IF OBJECT_ID(N'[dbo].[PoppelStore]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PoppelStore];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Transaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transaction];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [Account] decimal(19,4)  NULL
);
GO

-- Creating table 'Deliveries'
CREATE TABLE [dbo].[Deliveries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Company] nvarchar(20)  NOT NULL,
    [CustomerId] int  NOT NULL,
    [TransactionId] int  NOT NULL,
    [PaymentId] int  NOT NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [Cost] decimal(19,4)  NOT NULL,
    [image] varchar(max)  NULL,
    [image2] varbinary(max)  NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [OrderItemId] int  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'PoppelStores'
CREATE TABLE [dbo].[PoppelStores] (
    [Id] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [Stock] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Deliveries'
ALTER TABLE [dbo].[Deliveries]
ADD CONSTRAINT [PK_Deliveries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PoppelStores'
ALTER TABLE [dbo].[PoppelStores]
ADD CONSTRAINT [PK_PoppelStores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Customer'
CREATE INDEX [IX_FK_Customer]
ON [dbo].[OrderItems]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_CustomerId]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerId'
CREATE INDEX [IX_FK_CustomerId]
ON [dbo].[Payments]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'Deliveries'
ALTER TABLE [dbo].[Deliveries]
ADD CONSTRAINT [FK_CustomerId2]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerId2'
CREATE INDEX [IX_FK_CustomerId2]
ON [dbo].[Deliveries]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_CustomerTransaction]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerTransaction'
CREATE INDEX [IX_FK_CustomerTransaction]
ON [dbo].[Transactions]
    ([CustomerId]);
GO

-- Creating foreign key on [PaymentId] in table 'Deliveries'
ALTER TABLE [dbo].[Deliveries]
ADD CONSTRAINT [FK_PaymentId2]
    FOREIGN KEY ([PaymentId])
    REFERENCES [dbo].[Payments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentId2'
CREATE INDEX [IX_FK_PaymentId2]
ON [dbo].[Deliveries]
    ([PaymentId]);
GO

-- Creating foreign key on [TransactionId] in table 'Deliveries'
ALTER TABLE [dbo].[Deliveries]
ADD CONSTRAINT [FK_TransactionId2]
    FOREIGN KEY ([TransactionId])
    REFERENCES [dbo].[Transactions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionId2'
CREATE INDEX [IX_FK_TransactionId2]
ON [dbo].[Deliveries]
    ([TransactionId]);
GO

-- Creating foreign key on [OrderItemId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_OrderItem]
    FOREIGN KEY ([OrderItemId])
    REFERENCES [dbo].[OrderItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItem'
CREATE INDEX [IX_FK_OrderItem]
ON [dbo].[Transactions]
    ([OrderItemId]);
GO

-- Creating foreign key on [ProductId] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product'
CREATE INDEX [IX_FK_Product]
ON [dbo].[OrderItems]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'PoppelStores'
ALTER TABLE [dbo].[PoppelStores]
ADD CONSTRAINT [FK_ProductId]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductId'
CREATE INDEX [IX_FK_ProductId]
ON [dbo].[PoppelStores]
    ([ProductId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------