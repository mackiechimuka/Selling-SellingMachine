-- Create the database
CREATE DATABASE SSposb;
GO

-- Use the newly created database
USE SSposb;
GO

-- Create Customers table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    CustomerName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    createdAt DATETIME NOT NULL,
    updatedAt DATETIME NOT NULL
);
GO

-- Create Products table
CREATE TABLE Products (
    ProductsId INT PRIMARY KEY,
    ProductName NVARCHAR(80) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Quantity INT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedAt DATETIME NOT NULL
);
GO

-- Create Transactions table
CREATE TABLE Transactions (
    TransactionId INT PRIMARY KEY,
    CustomerId INT NOT NULL,
    UserId INT NOT NULL,
    TransactionDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    PaymentMethod NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME NOT NULL
);
GO

-- Create TransactionItems table
CREATE TABLE TransactionItems (
    TransactionItemId INT PRIMARY KEY,
    TransactionId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    createdAt DATETIME NOT NULL
);
GO

-- Create Users table
CREATE TABLE Users (
    UserId INT PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NOT NULL
);
GO

-- Create UserManagement table
CREATE TABLE UserManagement (
    UserId INT PRIMARY KEY,
    Role NVARCHAR(70) NOT NULL
);
GO

-- Add foreign key constraints

-- Customers table
-- Customers table
ALTER TABLE Customers
ADD CONSTRAINT FK_Customers_Transactions
FOREIGN KEY (TransactionId)
REFERENCES Transactions (TransactionId);
GO

-- Transactions table
ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Customers
FOREIGN KEY (CustomerId)
REFERENCES Customers (CustomerId);

ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Users
FOREIGN KEY (UserId)
REFERENCES Users (UserId);
GO

-- TransactionItems table
ALTER TABLE TransactionItems
ADD CONSTRAINT FK_TransactionItems_Transactions
FOREIGN KEY (TransactionId)
REFERENCES Transactions (TransactionId);

ALTER TABLE TransactionItems
ADD CONSTRAINT FK_TransactionItems_Products
FOREIGN KEY (ProductId)
REFERENCES Products (ProductsId);
GO

-- UserManagement table
ALTER TABLE UserManagement
ADD CONSTRAINT FK_UserManagement_Users
FOREIGN KEY (UserId)
REFERENCES Users (UserId);
GO