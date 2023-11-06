using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GroceryShopApp.Repository.Entities;
using Data_Access_Layer.Repository.Entities;




// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GroceryShopApp.Repository
{
    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<UsersRegister> UsersRegister { get; set; }

        public virtual DbSet<ViewCart> ViewCart { get; set; }

        public virtual DbSet<MyOrders> MyOrders { get; set; }

        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=IN-G50D5S3;Initial Catalog=ProductDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImageFileName).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Specification).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);
            });

             modelBuilder.Entity<UsersRegister>(entity =>
              {
                  entity.Property(e => e.Email).IsUnicode(false);

                  entity.Property(e => e.FirstName).IsUnicode(false);

                  entity.Property(e => e.LastName).IsUnicode(false);

                  entity.Property(e => e.Mobile).IsUnicode(false);

                  entity.Property(e => e.Role).IsUnicode(false);

                  entity.Property(e => e.MemberSin).IsUnicode(false);

                  entity.Property(e => e.Password).IsUnicode(false);


              });

             modelBuilder.Entity<ViewCart>(entity =>
              {
                  entity.Property(e => e.Id).ValueGeneratedOnAdd();

                  entity.Property(e => e.Description).IsUnicode(false);

                  entity.Property(e => e.ImageFileName).IsUnicode(false);

                  entity.Property(e => e.ProductName).IsUnicode(false);

                  entity.Property(e => e.Specification).IsUnicode(false);

                  entity.Property(e => e.Category).IsUnicode(false);
              });

            modelBuilder.Entity<MyOrders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImageFileName).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Specification).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
