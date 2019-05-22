namespace book.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Account_Role> Account_Role { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponDetail> CouponDetails { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceStatu> InvoiceStatus { get; set; }
        public virtual DbSet<ListImage> ListImages { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.ID_Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.ID_Account);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.ID_Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Book>()
                .Property(e => e.MainImage)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.CartDetails)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.ID_Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.ID_Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.CouponDetails)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.ID_Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.ID_Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.ListImages)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.ID_Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
                .HasMany(e => e.CartDetails)
                .WithRequired(e => e.Cart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.ID_Category);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.Value)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.CouponDetails)
                .WithRequired(e => e.Coupon)
                .HasForeignKey(e => e.ID_Coupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.DiscountCode)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Invoice)
                .HasForeignKey(e => e.ID_Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceStatu>()
                .Property(e => e.TheOrder)
                .IsFixedLength();

            modelBuilder.Entity<InvoiceStatu>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.InvoiceStatu)
                .HasForeignKey(e => e.ID_InvoiceStatus);

            modelBuilder.Entity<ListImage>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Publisher)
                .HasForeignKey(e => e.ID_Publisher);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();
        }
    }
}
