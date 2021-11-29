using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEFCore.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // db ile alakalı tüm işlemleri burada yapıyoruz.
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique(); // unique index aynı kategori ismi verilmesin
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            // CategoryId ürünün 1 adet kategorisi olmak zorundadır.
            // kategori altında ürün olmadan ürünün bir anlamaı olmamasından dolayı burada relation verdik.
            // hangi tablo ana main tablo ise relation oradan verilir.
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            
        }
    }
}
