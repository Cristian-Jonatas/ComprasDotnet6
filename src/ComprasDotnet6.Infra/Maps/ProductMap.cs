using ComprasDotnet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComprasDotnet6.Infra.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("idproduto").UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnName("nome");
            builder.Property(p => p.CodErp).HasColumnName("coderp");
            builder.Property(p => p.Price).HasColumnName("preco");

            builder.HasMany(p => p.Purchases).WithOne(p => p.Product).HasForeignKey(p => p.ProductId); 
        }
    }
}
