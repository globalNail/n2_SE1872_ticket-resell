using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Business__Packag__3E52440B",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK__Business__UserID__3D5E1FD2",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK__Feedback__BuyerI__68487DD7",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK__Feedback__Seller__693CA210",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK__Feedback__Ticket__6A30C649",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__52593CB8",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Ticke__534D60F1",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__BuyerID__4D94879B",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Staff__UserID__2C3393D0",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK__Ticket__Approved__47DBAE45",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK__Ticket__Category__46E78A0C",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK__Ticket__SellerID__45F365D3",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK__Transacti__Order__5CD6CB2B",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK__Transacti__Ticke__6383C8BA",
                table: "TransactionProcess");

            migrationBuilder.DropForeignKey(
                name: "FK__Transacti__Trans__628FA481",
                table: "TransactionProcess");

            migrationBuilder.DropForeignKey(
                name: "FK__User__RoleID__286302EC",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK__Wallet__UserID__30F848ED",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Wallet__84D4F92E08646F75",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK__UserRole__8AFACE3ABC264688",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK__User__1788CCAC7DE10734",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Transact__8CFAA0F729B62E03",
                table: "TransactionProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Transact__55433A4BEBB1E686",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Ticket__712CC6273CCFFA02",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Staff__96D4AAF71F2EB0DE",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ServiceP__322035EC3ABFBA10",
                table: "ServicePackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Orders__C3905BAFD5621A8F",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__57ED06A1AC8E3CF3",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Feedback__6A4BEDF60ED2DEDE",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Category__19093A2BCAE91B82",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Business__F1EAA34E147B665F",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "User");

            migrationBuilder.RenameIndex(
                name: "UQ__Wallet__1788CCAD0D9A0A8D",
                table: "Wallet",
                newName: "UQ__Wallet__1788CCAD8424177D");

            migrationBuilder.RenameIndex(
                name: "UQ__Transact__C3905BAE1F083B42",
                table: "Transaction",
                newName: "UQ__Transact__C3905BAEE7DD8BC1");

            migrationBuilder.RenameIndex(
                name: "UQ__Ticket__177800D3FBA71E5B",
                table: "Ticket",
                newName: "UQ__Ticket__177800D32B38CA6D");

            migrationBuilder.RenameIndex(
                name: "UQ__Staff__1788CCAD930F7DD2",
                table: "Staff",
                newName: "UQ__Staff__1788CCAD6422145F");

            migrationBuilder.RenameIndex(
                name: "UQ__Business__1788CCADB0760EDC",
                table: "Business",
                newName: "UQ__Business__1788CCAD33896293");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Wallet",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "User",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TransactionProcess",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Transaction",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "PdfFile",
                table: "Ticket",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Ticket",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Staff",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ServicePackage",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "OrderItem",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Feedback",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Category",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Business",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Wallet__84D4F92E52AB3BFF",
                table: "Wallet",
                column: "WalletID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__UserRole__8AFACE3A5486F317",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__User__1788CCACDD6F0454",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Transact__8CFAA0F798B5CEB7",
                table: "TransactionProcess",
                column: "TransactionProcessID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Transact__55433A4BBAEE492C",
                table: "Transaction",
                column: "TransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Ticket__712CC627FD251DF8",
                table: "Ticket",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Staff__96D4AAF720D68D04",
                table: "Staff",
                column: "StaffID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ServiceP__322035EC3DAEF18D",
                table: "ServicePackage",
                column: "PackageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Orders__C3905BAF1F1FF602",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__57ED06A199236322",
                table: "OrderItem",
                column: "OrderItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Feedback__6A4BEDF687E550EE",
                table: "Feedback",
                column: "FeedbackID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Category__19093A2B774655C6",
                table: "Category",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Business__F1EAA34E4683EB24",
                table: "Business",
                column: "BusinessID");

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    AverageRating = table.Column<decimal>(type: "decimal(3,2)", nullable: true, defaultValue: 0.00m),
                    RatingCount = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    MembershipDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MembershipStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Active"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Member__0CF04B385992FCDF", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK__Member__UserID__30F848ED",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Member__1788CCAD322EDE36",
                table: "Member",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK__Business__Packag__4BAC3F29",
                table: "Business",
                column: "PackageID",
                principalTable: "ServicePackage",
                principalColumn: "PackageID");

            migrationBuilder.AddForeignKey(
                name: "FK__Business__UserID__4AB81AF0",
                table: "Business",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Feedback__BuyerI__7B5B524B",
                table: "Feedback",
                column: "BuyerID",
                principalTable: "Member",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK__Feedback__Seller__7C4F7684",
                table: "Feedback",
                column: "SellerID",
                principalTable: "Member",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK__Feedback__Ticket__7D439ABD",
                table: "Feedback",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__628FA481",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Ticke__6383C8BA",
                table: "OrderItem",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__BuyerID__5CD6CB2B",
                table: "Orders",
                column: "BuyerID",
                principalTable: "Member",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK__Staff__UserID__35BCFE0A",
                table: "Staff",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Ticket__Approved__5629CD9C",
                table: "Ticket",
                column: "ApprovedBy",
                principalTable: "Staff",
                principalColumn: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK__Ticket__Category__5535A963",
                table: "Ticket",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK__Ticket__SellerID__5441852A",
                table: "Ticket",
                column: "SellerID",
                principalTable: "Member",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK__Transacti__Order__6E01572D",
                table: "Transaction",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK__Transacti__Ticke__75A278F5",
                table: "TransactionProcess",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK__Transacti__Trans__74AE54BC",
                table: "TransactionProcess",
                column: "TransactionID",
                principalTable: "Transaction",
                principalColumn: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK__User__RoleID__276EDEB3",
                table: "User",
                column: "RoleID",
                principalTable: "UserRole",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK__Wallet__UserID__3B75D760",
                table: "Wallet",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Business__Packag__4BAC3F29",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK__Business__UserID__4AB81AF0",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK__Feedback__BuyerI__7B5B524B",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK__Feedback__Seller__7C4F7684",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK__Feedback__Ticket__7D439ABD",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__628FA481",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Ticke__6383C8BA",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__BuyerID__5CD6CB2B",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Staff__UserID__35BCFE0A",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK__Ticket__Approved__5629CD9C",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK__Ticket__Category__5535A963",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK__Ticket__SellerID__5441852A",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK__Transacti__Order__6E01572D",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK__Transacti__Ticke__75A278F5",
                table: "TransactionProcess");

            migrationBuilder.DropForeignKey(
                name: "FK__Transacti__Trans__74AE54BC",
                table: "TransactionProcess");

            migrationBuilder.DropForeignKey(
                name: "FK__User__RoleID__276EDEB3",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK__Wallet__UserID__3B75D760",
                table: "Wallet");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Wallet__84D4F92E52AB3BFF",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK__UserRole__8AFACE3A5486F317",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK__User__1788CCACDD6F0454",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Transact__8CFAA0F798B5CEB7",
                table: "TransactionProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Transact__55433A4BBAEE492C",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Ticket__712CC627FD251DF8",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Staff__96D4AAF720D68D04",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ServiceP__322035EC3DAEF18D",
                table: "ServicePackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Orders__C3905BAF1F1FF602",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__57ED06A199236322",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Feedback__6A4BEDF687E550EE",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Category__19093A2B774655C6",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Business__F1EAA34E4683EB24",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TransactionProcess");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ServicePackage");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Business");

            migrationBuilder.RenameIndex(
                name: "UQ__Wallet__1788CCAD8424177D",
                table: "Wallet",
                newName: "UQ__Wallet__1788CCAD0D9A0A8D");

            migrationBuilder.RenameIndex(
                name: "UQ__Transact__C3905BAEE7DD8BC1",
                table: "Transaction",
                newName: "UQ__Transact__C3905BAE1F083B42");

            migrationBuilder.RenameIndex(
                name: "UQ__Ticket__177800D32B38CA6D",
                table: "Ticket",
                newName: "UQ__Ticket__177800D3FBA71E5B");

            migrationBuilder.RenameIndex(
                name: "UQ__Staff__1788CCAD6422145F",
                table: "Staff",
                newName: "UQ__Staff__1788CCAD930F7DD2");

            migrationBuilder.RenameIndex(
                name: "UQ__Business__1788CCAD33896293",
                table: "Business",
                newName: "UQ__Business__1788CCADB0760EDC");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "User",
                type: "decimal(3,2)",
                nullable: true,
                defaultValue: 0.00m);

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "User",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PdfFile",
                table: "Ticket",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Wallet__84D4F92E08646F75",
                table: "Wallet",
                column: "WalletID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__UserRole__8AFACE3ABC264688",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__User__1788CCAC7DE10734",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Transact__8CFAA0F729B62E03",
                table: "TransactionProcess",
                column: "TransactionProcessID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Transact__55433A4BEBB1E686",
                table: "Transaction",
                column: "TransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Ticket__712CC6273CCFFA02",
                table: "Ticket",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Staff__96D4AAF71F2EB0DE",
                table: "Staff",
                column: "StaffID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ServiceP__322035EC3ABFBA10",
                table: "ServicePackage",
                column: "PackageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Orders__C3905BAFD5621A8F",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__57ED06A1AC8E3CF3",
                table: "OrderItem",
                column: "OrderItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Feedback__6A4BEDF60ED2DEDE",
                table: "Feedback",
                column: "FeedbackID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Category__19093A2BCAE91B82",
                table: "Category",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Business__F1EAA34E147B665F",
                table: "Business",
                column: "BusinessID");

            migrationBuilder.AddForeignKey(
                name: "FK__Business__Packag__3E52440B",
                table: "Business",
                column: "PackageID",
                principalTable: "ServicePackage",
                principalColumn: "PackageID");

            migrationBuilder.AddForeignKey(
                name: "FK__Business__UserID__3D5E1FD2",
                table: "Business",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Feedback__BuyerI__68487DD7",
                table: "Feedback",
                column: "BuyerID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Feedback__Seller__693CA210",
                table: "Feedback",
                column: "SellerID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Feedback__Ticket__6A30C649",
                table: "Feedback",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__52593CB8",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Ticke__534D60F1",
                table: "OrderItem",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__BuyerID__4D94879B",
                table: "Orders",
                column: "BuyerID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Staff__UserID__2C3393D0",
                table: "Staff",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Ticket__Approved__47DBAE45",
                table: "Ticket",
                column: "ApprovedBy",
                principalTable: "Staff",
                principalColumn: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK__Ticket__Category__46E78A0C",
                table: "Ticket",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK__Ticket__SellerID__45F365D3",
                table: "Ticket",
                column: "SellerID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Transacti__Order__5CD6CB2B",
                table: "Transaction",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK__Transacti__Ticke__6383C8BA",
                table: "TransactionProcess",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK__Transacti__Trans__628FA481",
                table: "TransactionProcess",
                column: "TransactionID",
                principalTable: "Transaction",
                principalColumn: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK__User__RoleID__286302EC",
                table: "User",
                column: "RoleID",
                principalTable: "UserRole",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK__Wallet__UserID__30F848ED",
                table: "Wallet",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");
        }
    }
}
