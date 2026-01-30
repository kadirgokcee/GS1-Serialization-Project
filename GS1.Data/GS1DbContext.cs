using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS1.Core.Entities;
using Microsoft.EntityFrameworkCore;



namespace GS1.Data
{
    public class GS1DbContext : DbContext
    {
       
        public GS1DbContext(DbContextOptions<GS1DbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }

        //  (Unique Constraint vb.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // GLN (Firma No) 
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.GLN)
                .IsUnique();

            // GTIN (Barkod) 
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.GTIN)
                .IsUnique();

            // SSCC (Koli/Palet kodu) 
            modelBuilder.Entity<SerialNumber>()
                .HasIndex(s => s.SSCC)
                .IsUnique()
                .HasFilter("[SSCC] IS NOT NULL"); 

            // İlişkiler (Cascade Delete önleme)
            // Bir müşteri silinirse ürünleri hemen silinmesin, hata versin.
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}