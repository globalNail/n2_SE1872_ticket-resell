using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__19093A2BCAE91B82", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ServicePackage",
                columns: table => new
                {
                    PackageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true, defaultValue: 0.00m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceP__322035EC3ABFBA10", x => x.PackageID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRole__8AFACE3ABC264688", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AverageRating = table.Column<decimal>(type: "decimal(3,2)", nullable: true, defaultValue: 0.00m),
                    RatingCount = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    WalletID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__1788CCAC7DE10734", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__User__RoleID__286302EC",
                        column: x => x.RoleID,
                        principalTable: "UserRole",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PackageID = table.Column<int>(type: "int", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Pending"),
                    CanSkipVerification = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsAgent = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Business__F1EAA34E147B665F", x => x.BusinessID);
                    table.ForeignKey(
                        name: "FK__Business__Packag__3E52440B",
                        column: x => x.PackageID,
                        principalTable: "ServicePackage",
                        principalColumn: "PackageID");
                    table.ForeignKey(
                        name: "FK__Business__UserID__3D5E1FD2",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "open"),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BAFD5621A8F", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__BuyerID__4D94879B",
                        column: x => x.BuyerID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__96D4AAF71F2EB0DE", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK__Staff__UserID__2C3393D0",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    WalletID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0.00m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Wallet__84D4F92E08646F75", x => x.WalletID);
                    table.ForeignKey(
                        name: "FK__Wallet__UserID__30F848ED",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlatformFee = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0.00m),
                    Discount = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0.00m),
                    NetAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0.00m),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "processing")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__55433A4BEBB1E686", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK__Transacti__Order__5CD6CB2B",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    SeatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    PdfFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "pending"),
                    PostedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProcessingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ticket__712CC6273CCFFA02", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK__Ticket__Approved__47DBAE45",
                        column: x => x.ApprovedBy,
                        principalTable: "Staff",
                        principalColumn: "StaffID");
                    table.ForeignKey(
                        name: "FK__Ticket__Category__46E78A0C",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK__Ticket__SellerID__45F365D3",
                        column: x => x.SellerID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerID = table.Column<int>(type: "int", nullable: true),
                    TicketID = table.Column<int>(type: "int", nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__6A4BEDF60ED2DEDE", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__Feedback__BuyerI__68487DD7",
                        column: x => x.BuyerID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Feedback__Seller__693CA210",
                        column: x => x.SellerID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Feedback__Ticket__6A30C649",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    TicketID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(21,2)", nullable: true, computedColumnSql: "([Quantity]*[UnitPrice])", stored: true),
                    AddedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__57ED06A1AC8E3CF3", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK__OrderItem__Order__52593CB8",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__OrderItem__Ticke__534D60F1",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID");
                });

            migrationBuilder.CreateTable(
                name: "TransactionProcess",
                columns: table => new
                {
                    TransactionProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionID = table.Column<int>(type: "int", nullable: true),
                    TicketID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "initiated"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__8CFAA0F729B62E03", x => x.TransactionProcessID);
                    table.ForeignKey(
                        name: "FK__Transacti__Ticke__6383C8BA",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID");
                    table.ForeignKey(
                        name: "FK__Transacti__Trans__628FA481",
                        column: x => x.TransactionID,
                        principalTable: "Transaction",
                        principalColumn: "TransactionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_PackageID",
                table: "Business",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "UQ__Business__1788CCADB0760EDC",
                table: "Business",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_BuyerID",
                table: "Feedback",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_SellerID",
                table: "Feedback",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TicketID",
                table: "Feedback",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_TicketID",
                table: "OrderItem",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerID",
                table: "Orders",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Staff__1788CCAD930F7DD2",
                table: "Staff",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ApprovedBy",
                table: "Ticket",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CategoryID",
                table: "Ticket",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SellerID",
                table: "Ticket",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Ticket__177800D3FBA71E5B",
                table: "Ticket",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Transact__C3905BAE1F083B42",
                table: "Transaction",
                column: "OrderID",
                unique: true,
                filter: "[OrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionProcess_TicketID",
                table: "TransactionProcess",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionProcess_TransactionID",
                table: "TransactionProcess",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "UQ__Wallet__1788CCAD0D9A0A8D",
                table: "Wallet",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "TransactionProcess");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "ServicePackage");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
