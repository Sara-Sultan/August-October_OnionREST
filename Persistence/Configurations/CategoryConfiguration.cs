using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
   internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.HasKey(Category => Category.Id);

            builder.Property(Category => Category.Id).ValueGeneratedOnAdd();

            builder.Property(Product => Product.Name).IsRequired();
            builder.Property(Category => Category.Name).HasMaxLength(60);


            //builder.HasMany(Category => Category.Products)
            //    .WithOne()
            //    .HasForeignKey(Product => Product.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
