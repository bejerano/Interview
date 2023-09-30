namespace Plooto.Assessment.Payment.Infrastructure;

public class BillStatusEntityTypeConfiguration : IEntityTypeConfiguration<BillStatus>
{
    public void Configure(EntityTypeBuilder<BillStatus> orderStatusConfiguration)
    {
        orderStatusConfiguration.ToTable("BillStatus", PaymentContext.DEFAULT_SCHEMA);

        orderStatusConfiguration.HasKey(o => o.Id);

        orderStatusConfiguration.Property(o => o.Id)
            .HasDefaultValue(1)
            .ValueGeneratedNever()
            .IsRequired();

        orderStatusConfiguration.Property(o => o.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}