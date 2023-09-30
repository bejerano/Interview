using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.Infrastructure;

public abstract class PlootoEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity: PlootoEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> baseConfiguration)
    {
        baseConfiguration
            .Property(cr => cr.CreatedBy)
            .HasDefaultValue("Plooto Default")
            .IsRequired();
        baseConfiguration
            .Property(cr => cr.CreatedOn)
            .HasDefaultValue(DateTimeOffset.Now)
            .IsRequired();
        baseConfiguration.Property(cr => cr.ModifiedBy)
                         .ValueGeneratedOnAdd()
                         .IsRequired();
        baseConfiguration.Property(cr => cr.ModifiedOn)
                         .ValueGeneratedOnAdd()
                         .IsRequired();
    }
}
