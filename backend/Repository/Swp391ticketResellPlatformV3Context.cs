using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository;

public partial class Swp391ticketResellPlatformV3Context : DbContext
{
    public Swp391ticketResellPlatformV3Context()
    {
    }

    public Swp391ticketResellPlatformV3Context(DbContextOptions<Swp391ticketResellPlatformV3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionProcess> TransactionProcesses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=SWP391TicketResellPlatformV3;UID=sa;PWD=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B33FA4EBB");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF63B4FE189");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.BuyerId).HasColumnName("BuyerID");
            entity.Property(e => e.SellerId).HasColumnName("SellerID");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");

            entity.HasOne(d => d.Buyer).WithMany(p => p.FeedbackBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__Feedback__BuyerI__59063A47");

            entity.HasOne(d => d.Seller).WithMany(p => p.FeedbackSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Feedback__Seller__59FA5E80");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Feedback__Ticket__5AEE82B9");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF5D7AF7DF");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("open");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__4222D4EF");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A16F303E61");

            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.TotalPrice)
                .HasComputedColumnSql("([Quantity]*[UnitPrice])", true)
                .HasColumnType("decimal(21, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderItem__Order__46E78A0C");

            entity.HasOne(d => d.Ticket).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__OrderItem__Ticke__47DBAE45");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF736032C8C");

            entity.HasIndex(e => e.Username, "UQ__Staff__536C85E4E2D97845").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC627D44B7C42");

            entity.ToTable("Ticket");

            entity.HasIndex(e => e.Barcode, "UQ__Ticket__177800D3D9D58A50").IsUnique();

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.Barcode).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.PostedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.SeatNumber).HasMaxLength(10);
            entity.Property(e => e.SellerId).HasColumnName("SellerID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("pending");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__Ticket__Approved__3C69FB99");

            entity.HasOne(d => d.Category).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Ticket__Category__3B75D760");

            entity.HasOne(d => d.Seller).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Ticket__SellerID__3A81B327");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4BB98F5CF8");

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.OrderId, "UQ__Transact__C3905BAE940A3CEC").IsUnique();

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("processing");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithOne(p => p.Transaction)
                .HasForeignKey<Transaction>(d => d.OrderId)
                .HasConstraintName("FK__Transacti__Order__4E88ABD4");
        });

        modelBuilder.Entity<TransactionProcess>(entity =>
        {
            entity.HasKey(e => e.TransactionProcessId).HasName("PK__Transact__8CFAA0F74094D822");

            entity.ToTable("TransactionProcess");

            entity.Property(e => e.TransactionProcessId).HasColumnName("TransactionProcessID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("initiated");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TransactionProcesses)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Transacti__Ticke__5535A963");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionProcesses)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK__Transacti__Trans__5441852A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACBDDFD3A1");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E4893B2DC5").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AverageRating)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RatingCount).HasDefaultValue(0);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.WalletId).HasColumnName("WalletID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleID__29572725");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__8AFACE3A5B7DA7D0");

            entity.ToTable("UserRole");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__Wallet__84D4F92E1986651D");

            entity.ToTable("Wallet");

            entity.HasIndex(e => e.UserId, "UQ__Wallet__1788CCAD2B250828").IsUnique();

            entity.Property(e => e.WalletId).HasColumnName("WalletID");
            entity.Property(e => e.Balance)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Wallet)
                .HasForeignKey<Wallet>(d => d.UserId)
                .HasConstraintName("FK__Wallet__UserID__2E1BDC42");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
