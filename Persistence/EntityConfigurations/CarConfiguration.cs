using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(f => f.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(f => f.CarState).HasColumnName("State").IsRequired();
        builder.Property(f => f.ModelYear).HasColumnName("ModelYear").IsRequired();
        builder.Property(f => f.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(f => f.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(f => f.DeletedAt).HasColumnName("DeletedAt");

        builder.HasOne(f => f.Model);

        builder.HasQueryFilter(f => !f.DeletedAt.HasValue);
    }
}
