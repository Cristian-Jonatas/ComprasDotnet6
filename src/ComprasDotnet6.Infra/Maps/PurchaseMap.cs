using ComprasDotnet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprasDotnet6.Infra.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("compra");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).HasColumnName("idcompra").UseIdentityColumn();
            builder.Property(c => c.PersonId).HasColumnName("idpessoa");
            builder.Property(c => c.ProductId).HasColumnName("idproduto");
            builder.Property(c => c.Date).HasColumnType("date").HasColumnName("datacompra");

            builder.HasOne(c => c.Person).WithMany(c => c.Purchases);
            builder.HasOne(c => c.Product).WithMany(c => c.Purchases);
        }
    }
}
