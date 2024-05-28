using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.Name).HasColumnName("Name").IsRequired();
        builder.Property(f => f.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(f => f.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(f => f.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(f => f.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        builder.Property(f => f.ImageURL).HasColumnName("ImageURL").IsRequired();

        builder.Property(f => f.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(f => f.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(f => f.DeletedAt).HasColumnName("DeletedAt");

        builder.HasIndex(indexExpression: f => f.Name, name: "UK_Models_Name").IsUnique();

        builder.HasOne(f => f.Brand);
        builder.HasOne(f => f.Fuel);
        builder.HasOne(f => f.Transmission);

        builder.HasMany(f => f.Cars);

        builder.HasQueryFilter(f => !f.DeletedAt.HasValue);
    }
}
