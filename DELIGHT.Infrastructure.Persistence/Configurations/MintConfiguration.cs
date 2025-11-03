using DELIGHT.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DELIGHT.Infraestructure.Persistence.Configurations
{
    public class MintConfiguration : IEntityTypeConfiguration<Mint>
    {
        public void Configure(EntityTypeBuilder<Mint> builder)
        {
            builder.ToTable("Mints", "DELIGHT");

            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder
                .Property(m => m.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.SugarContent)
                .HasPrecision(12, 2)
                .IsRequired();

            builder
                .Property(m => m.Flavor)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.WeightInGrams)
                .HasPrecision(12, 2)
                .IsRequired();

            builder
                .Property(m => m.Price)
                .HasPrecision(12, 2)
                .IsRequired();

            builder
                .Property(m => m.PricePerUnit)
                .HasPrecision(12, 2)
                .IsRequired();

            builder
                .Property(m => m.CreatedDate)
                .IsRequired();

            builder
                .Property(m => m.ModifiedDate)
                .IsRequired(false);

            builder
                .Property(m => m.IsDeleted)
                .IsRequired();

            builder
                .Property(m => m.DeletedDate)
                .IsRequired(false);

        }
    }
}
