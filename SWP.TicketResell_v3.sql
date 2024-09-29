USE [master]
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name='SWP391TicketResellPlatformV3')
    DROP DATABASE SWP391TicketResellPlatformV3
GO

CREATE DATABASE [SWP391TicketResellPlatformV3]
GO
USE [SWP391TicketResellPlatformV3]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- UserRole Table remains the same
CREATE TABLE UserRole (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);

-- User Table remains; we'll discuss splitting Buyer and Seller roles
CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(255),
    ImageUrl NVARCHAR(150),
    AverageRating DECIMAL(3,2) DEFAULT 0.00,  -- Độ uy tín trung bình
    RatingCount INT DEFAULT 0,
    RoleID INT,
    WalletID INT,
    FOREIGN KEY (RoleID) REFERENCES UserRole(RoleID)
);

-- Wallet Table linked to User
CREATE TABLE Wallet (
    WalletID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT UNIQUE,
    Balance DECIMAL(10,2) DEFAULT 0.00,
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

-- Removed Event, Invoice, and Payment tables as per feedback

-- Category Table remains the same
CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);

-- Staff Table to manage ticket approvals
CREATE TABLE Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(255),
    ImageUrl NVARCHAR(150),
    Role NVARCHAR(50) NOT NULL  -- Ví dụ: 'administrator', 'staff'
);

-- Ticket Table with Quantity added
CREATE TABLE Ticket (
    TicketID INT IDENTITY(1,1) PRIMARY KEY,
    Barcode NVARCHAR(100) NOT NULL UNIQUE,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT DEFAULT 1,  -- Added Quantity field
    SeatNumber NVARCHAR(10),
    SellerID INT,
    CategoryID INT,
    PdfFile VARBINARY(MAX),
    Status NVARCHAR(50) DEFAULT 'pending' CHECK (Status IN ('pending', 'verified', 'rejected', 'sold')),
    PostedAt DATETIME DEFAULT GETDATE(),
    ApprovedBy INT NULL,
    ApprovalDate DATETIME NULL,
    ProcessingNotes NVARCHAR(MAX),
    FOREIGN KEY (SellerID) REFERENCES [User](UserID),
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    FOREIGN KEY (ApprovedBy) REFERENCES Staff(StaffID)
);

-- Orders Table (Renamed from Cart)
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,  -- Reference to the User who placed the order
    CreatedAt DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'open' CHECK (Status IN ('open', 'completed', 'cancelled')),
    TotalAmount DECIMAL(10,2),  -- Added TotalPrice field to Orders
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

-- OrderItem Table (formerly CartItem) with TotalPrice
CREATE TABLE OrderItem (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,  -- Reference to the Orders
    TicketID INT,  -- Reference to the Ticket being purchased
    Quantity INT DEFAULT 1,  -- Number of tickets purchased
    UnitPrice DECIMAL(10,2),
    TotalPrice AS (Quantity * UnitPrice) PERSISTED,  -- Calculated total price
    AddedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID)
);

-- Transaction Table connected to Orders
CREATE TABLE [Transaction] (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT UNIQUE,
    TransactionDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    Status NVARCHAR(50) DEFAULT 'processing' CHECK (Status IN ('processing', 'completed', 'refunded')),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- New TransactionProcess Table to update ticket status during purchase
CREATE TABLE TransactionProcess (
    TransactionProcessID INT IDENTITY(1,1) PRIMARY KEY,
    TransactionID INT,
    TicketID INT,
    Status NVARCHAR(50) DEFAULT 'initiated' CHECK (Status IN ('initiated', 'in_process', 'completed', 'cancelled')),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (TransactionID) REFERENCES [Transaction](TransactionID),
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID)
);

-- Feedback Table remains the same
CREATE TABLE Feedback (
    FeedbackID INT IDENTITY(1,1) PRIMARY KEY,
    BuyerID INT,
    TicketID INT,
    SellerID INT,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(MAX),
    FOREIGN KEY (BuyerID) REFERENCES [User](UserID),
    FOREIGN KEY (SellerID) REFERENCES [User](UserID),
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID)
);

-- Insert roles for the users
INSERT INTO UserRole (RoleName) VALUES
('administrator'),
('staff'),
('buyer'),
('seller');

-- Sample Users
INSERT INTO [User] (Username, Password, Email, PhoneNumber, Address, RoleID) VALUES
('john_seller', 'password123', 'john@example.com', '123456789', '123 Main St', 4),
('maria_buyer', 'password123', 'maria@example.com', '987654321', '456 Another St', 3),
('admin', '1', 'admin@admin.com', '', '', 1),
('admin_staff', 'password123', 'admin@example.com', '111222333', '789 Staff St', 2);


-- Create Wallets for Users
INSERT INTO Wallet (UserID) VALUES
((SELECT UserID FROM [User] WHERE Username = 'john_seller')),
((SELECT UserID FROM [User] WHERE Username = 'maria_buyer'));
