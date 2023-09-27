using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                 .ToTable("Customer");

            builder
                .HasKey(x => x.Id);

            builder
            .OwnsOne(x => x.Name)
            .Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .IsRequired();

            builder
               .OwnsOne(x => x.Name)
               .Property(x => x.LastName)
               .HasColumnName("LastName")
               .IsRequired();

            builder
               .OwnsOne(x => x.User)
               .Property(x => x.PasswordHash)
               .HasColumnName("PasswordHash")
               .HasColumnType("VARCHAR")
               .HasMaxLength(255)
               .IsRequired();

            builder
               .OwnsOne(x => x.User)
               .Property(x => x.ConfirmPassword)
               .HasColumnType("VARCHAR")
               .HasMaxLength(255)
               .IsRequired();

            builder
              .OwnsOne(x => x.User)
              .Property(x => x.Username)
              .HasColumnType("VARCHAR")
              .HasMaxLength(80)
              .IsRequired();
                     

            builder
                .Property(x => x.Email)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(80);

            builder
                .HasIndex(x => x.Email, "IX_User_Email")
                .IsUnique();         


        }
    }
}
