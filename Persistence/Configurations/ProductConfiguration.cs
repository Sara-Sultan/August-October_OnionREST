using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
   internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(Product => Product.Id);

            builder.Property(Product => Product.Id).ValueGeneratedOnAdd();

            builder.Property(Product => Product.Name).IsRequired();
            builder.Property(Product => Product.Name).HasMaxLength(60);

            builder.Property(Product => Product.Price).IsRequired();
            builder.Property(Product => Product.Quantity).IsRequired();
            builder.Property(Product => Product.ImgURL).IsRequired();
        }
    }
}
