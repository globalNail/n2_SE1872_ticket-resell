USE [master]

GO

IF EXISTS (SELECT * FROM sys.databases WHERE name='SWP391TicketResellPlatform')
    DROP DATABASE SWP391TicketResellPlatform
GO

CREATE DATABASE [SWP391TicketResellPlatform]
GO
USE [SWP391TicketResellPlatform]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE UserRole (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);

CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(255),
    ImageUrl NVARCHAR(MAX),
    RoleID INT,
    WalletID INT,
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (RoleID) REFERENCES UserRole(RoleID)
);
CREATE TABLE Member (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT UNIQUE,
    AverageRating DECIMAL(3,2) DEFAULT 0.00,
    RatingCount INT DEFAULT 0,
    MembershipDate DATETIME DEFAULT GETDATE(),
    MembershipStatus NVARCHAR(50) DEFAULT 'Active'CHECK (MembershipStatus IN ('Active', 'Inactive')),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT UNIQUE,
    Role NVARCHAR(50) NOT NULL,
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Wallet (
    WalletID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT UNIQUE,
    Balance DECIMAL(10,2) DEFAULT 0.00,
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
);
CREATE TABLE ServicePackage (
    PackageID INT IDENTITY(1,1) PRIMARY KEY,
    PackageName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Fee DECIMAL(10,2) NOT NULL,
    DiscountPercentage DECIMAL(5,2) DEFAULT 0.00,
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
);

CREATE TABLE Business(
    BusinessID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT UNIQUE,
    PackageID INT NULL,
    BusinessName NVARCHAR(100) NOT NULL,
    RegistrationDate DATETIME DEFAULT GETDATE(),
    ExpiryDate DATETIME,
    Status NVARCHAR(50) DEFAULT 'Pending', CHECK (Status IN ('Pending', 'Valid', 'Expired', 'Sold')),
    CanSkipVerification BIT DEFAULT 0,
    IsAgent BIT DEFAULT 0,
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES [User](UserID),
    FOREIGN KEY (PackageID) REFERENCES ServicePackage(PackageID)
);
CREATE TABLE Ticket (
    TicketID INT IDENTITY(1,1) PRIMARY KEY,
    Barcode NVARCHAR(MAX) NOT NULL ,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT DEFAULT 1,
    SeatNumber NVARCHAR(10),
    StartDate DATETIME NULL,
    SellerID INT,
    CategoryID INT,
    PdfFile NVARCHAR(MAX),
    Status NVARCHAR(50) DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Verified', 'Rejected', 'Sold')),
    PostedAt DATETIME DEFAULT GETDATE(),
    ApprovedBy INT NULL,
    ApprovalDate DATETIME NULL,
    Description NVARCHAR(MAX),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (SellerID) REFERENCES Member(MemberID),
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    FOREIGN KEY (ApprovedBy) REFERENCES Staff(StaffID),
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    BuyerID INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Open' CHECK (Status IN ('open', 'Completed', 'Cancelled')),
    TotalAmount DECIMAL(10,2),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (BuyerID) REFERENCES Member(MemberID)
);

CREATE TABLE OrderItem (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    TicketID INT,
    Quantity INT DEFAULT 1,
    UnitPrice DECIMAL(10,2),
    TotalPrice AS (Quantity * UnitPrice) PERSISTED,
    AddedAt DATETIME DEFAULT GETDATE(),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID)
);

CREATE TABLE [Transaction] (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT UNIQUE,
    TransactionDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    PlatformFee DECIMAL(10,2) DEFAULT 0.00,
    Discount DECIMAL(10,2) DEFAULT 0.00,
    NetAmount DECIMAL(10,2) DEFAULT 0.00,
    Status NVARCHAR(50) DEFAULT 'Processing' CHECK (Status IN ('Processing', 'Completed', 'Refunded')),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

CREATE TABLE TransactionProcess (
    TransactionProcessID INT IDENTITY(1,1) PRIMARY KEY,
    TransactionID INT,
    TicketID INT,
    Status NVARCHAR(50) DEFAULT 'Initiated' CHECK (Status IN ('Initiated', 'In_process', 'Completed', 'Cancelled')),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(MAX),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (TransactionID) REFERENCES [Transaction](TransactionID),
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID)
);

CREATE TABLE Feedback (
    FeedbackID INT IDENTITY(1,1) PRIMARY KEY,
    BuyerID INT,
    TicketID INT,
    SellerID INT,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(MAX),
    CreateDate DATETIME DEFAULT GETDATE(),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (BuyerID) REFERENCES Member(MemberID),
    FOREIGN KEY (SellerID) REFERENCES Member(MemberID),
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID)
);


-- Insert roles for the users
INSERT INTO UserRole (RoleName) VALUES
('administrator'),
('staff'),
('buyer'),
('seller'),
('agent'); 

INSERT INTO [User] (Username, PasswordHash, Email, PhoneNumber, Address, RoleID) VALUES
('john_seller', 'password123', 'john@example.com', '123456789', '123 Main St', 4),
('maria_buyer', 'password123', 'maria@example.com', '987654321', '456 Another St', 3),
('admin', '1', 'admin@admin.com', '', '', 1),
('admin_staff', 'password123', 'admin@example.com', '111222333', '789 Staff St', 2);

INSERT INTO Member (UserID) VALUES
((SELECT UserID FROM [User] WHERE Username = 'john_seller')),
((SELECT UserID FROM [User] WHERE Username = 'maria_buyer'));

INSERT INTO Wallet (UserID) VALUES
((SELECT UserID FROM [User] WHERE Username = 'john_seller')),
((SELECT UserID FROM [User] WHERE Username = 'maria_buyer'));

INSERT INTO Category (CategoryName) VALUES
('Concert'),
('Sport'),
('Theater'),
('Comedy');

INSERT INTO Ticket (Barcode, Price, Quantity, SeatNumber, SellerID, CategoryID, PdfFile, Status) VALUES
('1234567890', 50.00, 2, 'A1', (SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'john_seller')), 1, NULL, 'pending'),
('0987654321', 30.00, 5, 'B2', (SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'john_seller')), 2, NULL, 'pending'),
('5432167890', 20.00, 1, 'C3', (SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'john_seller')), 3, NULL, 'pending');

INSERT INTO Orders (BuyerID, TotalAmount) VALUES
((SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'maria_buyer')), 100.00),
((SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'maria_buyer')), 150.00);

INSERT INTO OrderItem (OrderID, TicketID, Quantity, UnitPrice) VALUES
((SELECT OrderID FROM Orders WHERE BuyerID = (SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'maria_buyer')) AND Status = 'open' ORDER BY CreatedAt ASC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY),
 (SELECT TicketID FROM Ticket WHERE Barcode = '1234567890'), 1, 50.00),
((SELECT OrderID FROM Orders WHERE BuyerID = (SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'maria_buyer')) AND Status = 'open' ORDER BY CreatedAt ASC OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY),
 (SELECT TicketID FROM Ticket WHERE Barcode = '0987654321'), 2, 30.00);

INSERT INTO ServicePackage (PackageName, Description, Fee, DiscountPercentage) VALUES
('Basic', 'Gói cơ bản cho doanh nghiệp mới', 100.00, 0.00),
('Standard', 'Gói tiêu chuẩn với nhiều tính năng hơn', 200.00, 5.00),
('Premium', 'Gói cao cấp với tất cả các tính năng', 300.00, 10.00);

INSERT INTO Feedback (BuyerID, TicketID, SellerID, Rating, Comment) VALUES
((SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'maria_buyer')),
 (SELECT TicketID FROM Ticket WHERE Barcode = '1234567890'),
 (SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'john_seller')),
 5, 'Great experience!'),
((SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'maria_buyer')),
 (SELECT TicketID FROM Ticket WHERE Barcode = '0987654321'),
 (SELECT MemberID FROM Member WHERE UserID = (SELECT UserID FROM [User] WHERE Username = 'john_seller')),
 4, 'Good service, will buy again.');

