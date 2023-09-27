using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                 .ToTable("Product");

            builder
                .HasKey(x => x.Id);
                    
            builder
                .Property(x => x.Title)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

          
            builder
                .Property(x => x.Price)
                .HasColumnType("money");
           
        }
    }
}
