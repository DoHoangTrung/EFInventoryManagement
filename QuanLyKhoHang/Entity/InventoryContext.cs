using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyKhoHang.Entity
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
            : base("name=InventoryContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryVoucher> DeliveryVouchers { get; set; }
        public virtual DbSet<DeliveryVoucherInfo> DeliveryVoucherInfoes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ReceiveVoucher> ReceiveVouchers { get; set; }
        public virtual DbSet<ReceiveVoucherInfo> ReceiveVoucherInfoes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<DeliveryVoucherInfoView> DeliveryVoucherInfoViews { get; set; }
        public virtual DbSet<DeliveryVoucherView> DeliveryVoucherViews { get; set; }
        public virtual DbSet<ProductCanSellView> ProductCanSellViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.IDType)
                .IsUnicode(false);

            modelBuilder.Entity<AccountType>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<AccountType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AccountType>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.AccountType)
                .HasForeignKey(e => e.IDType);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.DeliveryVouchers)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.IDCustomer);

            modelBuilder.Entity<DeliveryVoucher>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucher>()
                .Property(e => e.IDCustomer)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucher>()
                .HasMany(e => e.DeliveryVoucherInfoes)
                .WithRequired(e => e.DeliveryVoucher)
                .HasForeignKey(e => e.IDDeliveryVoucher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryVoucherInfo>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherInfo>()
                .Property(e => e.IDDeliveryVoucher)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherInfo>()
                .Property(e => e.IDReceiveVoucher)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.IdType)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DeliveryVoucherInfoes)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.IDProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ReceiveVoucherInfoes)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.IDProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.IdType);

            modelBuilder.Entity<ReceiveVoucher>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiveVoucher>()
                .Property(e => e.IDSupplier)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiveVoucher>()
                .HasMany(e => e.DeliveryVoucherInfoes)
                .WithRequired(e => e.ReceiveVoucher)
                .HasForeignKey(e => e.IDReceiveVoucher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiveVoucher>()
                .HasMany(e => e.ReceiveVoucherInfoes)
                .WithRequired(e => e.ReceiveVoucher)
                .HasForeignKey(e => e.IDReceiveVoucher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiveVoucherInfo>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiveVoucherInfo>()
                .Property(e => e.IDReceiveVoucher)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.ReceiveVouchers)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.IDSupplier);

            modelBuilder.Entity<DeliveryVoucherInfoView>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherInfoView>()
                .Property(e => e.DeliveryVoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherView>()
                .Property(e => e.VoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherView>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherView>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherView>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryVoucherView>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCanSellView>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCanSellView>()
                .Property(e => e.IDType)
                .IsUnicode(false);
        }
    }
}
