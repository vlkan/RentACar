using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
    public void Configure(EntityTypeBuilder<Transmission> builder)
    {
        builder.ToTable("Transmissions").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.Name).HasColumnName("Name").IsRequired();
        builder.Property(f => f.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(f => f.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(f => f.DeletedAt).HasColumnName("DeletedAt");

        builder.HasIndex(indexExpression: f => f.Name, name: "UK_Transmissions_Name").IsUnique();

        builder.HasMany(f => f.Models);

        builder.HasQueryFilter(f => !f.DeletedAt.HasValue);
    }
}
