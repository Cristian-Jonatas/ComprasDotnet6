using ComprasDotnet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComprasDotnet6.Infra.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("idpessoa").UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnName("nome");
            builder.Property(p => p.Document).HasColumnName("documento");
            builder.Property(p => p.Phone).HasColumnName("celular");

            builder.HasMany(p => p.Purchases).WithOne(p => p.Person).HasForeignKey(p => p.PersonId);
        }
    }
}
