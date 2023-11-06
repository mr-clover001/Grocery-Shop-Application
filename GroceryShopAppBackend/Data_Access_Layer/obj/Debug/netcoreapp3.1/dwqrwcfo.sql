CREATE TABLE [MyOrders] (
    [Id] int NOT NULL IDENTITY,
    [ProductName] varchar(100) NULL,
    [Description] varchar(250) NULL,
    [Quantity] int NULL,
    [ImageFileName] varchar(250) NULL,
    [Price] float NULL,
    [Discount] int NULL,
    [Specification] varchar(250) NULL,
    CONSTRAINT [PK_MyOrders] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [ProductName] varchar(100) NULL,
    [Description] varchar(250) NULL,
    [Quantity] int NULL,
    [ImageFileName] varchar(250) NULL,
    [Price] float NULL,
    [Discount] int NULL,
    [Specification] varchar(250) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [UserLogin] (
    [Email] varchar(100) NULL,
    [Password] varchar(100) NULL
);
GO


CREATE TABLE [UsersRegister] (
    [UserId] int NOT NULL IDENTITY,
    [FirstName] varchar(100) NULL,
    [LastName] varchar(100) NULL,
    [Email] varchar(100) NULL,
    [Mobile] varchar(100) NULL,
    [Password] varchar(100) NULL,
    [MemberSin] datetime2 NOT NULL,
    CONSTRAINT [PK_UsersRegister] PRIMARY KEY ([UserId])
);
GO


CREATE TABLE [ViewCart] (
    [Id] int NOT NULL IDENTITY,
    [ProductName] varchar(100) NULL,
    [Description] varchar(250) NULL,
    [Quantity] int NULL,
    [ImageFileName] varchar(250) NULL,
    [Price] float NULL,
    [Discount] int NULL,
    [Specification] varchar(250) NULL,
    CONSTRAINT [PK_ViewCart] PRIMARY KEY ([Id])
);
GO


