using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCEFCore.Data.Mappings;
using MVCEFCore.Data.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEFCore.Data
{
    public class ApplicationDbContext: DbContext
    {
        //private IConfiguration _configuration;

        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TestConnection"));
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TestConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductFile> Files { get; set; }

        public DbSet<ProductCategoryView> ProductCategoryViews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        // model ayağa kalkarken uygulanacak tüm konfig tanımları için kullanırız.
        // migration uygulanırken bu kurallar database yansır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Viewler için hasnoKey olarak işaretliyoruz.
            // ProductCategory view databasede oluşur
            // ProductCategoryView dbSet tanımı yaparken HasNoKey ile Table olmadığını söylüyoruz.
            modelBuilder.Entity<ProductCategoryView>().HasNoKey().ToView("ProductCategory");

            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.Property(x => x.Name).HasMaxLength(20);
            //});

            // Reflection ile yükeleyebiliriz.
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());


            base.OnModelCreating(modelBuilder);
        }
    }
}
