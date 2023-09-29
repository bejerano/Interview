

using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.Infrastructure;


public class PaymentEntityTypeConfiguration : PlootoEntityTypeConfiguration<PaymentDetail>
{
    public override void Configure(EntityTypeBuilder<PaymentDetail> paymentConfiguration)
    {        
        base.Configure(paymentConfiguration);

        paymentConfiguration.ToTable("Payments", PaymentContext.DEFAULT_SCHEMA);        
        paymentConfiguration.HasKey(o => o.Id);          

        paymentConfiguration
            .Property<decimal>("_amount")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Amount")
            .IsRequired(true);

        paymentConfiguration
            .Property<DateTimeOffset>("_debitDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("DebitDate")
            .IsRequired(true);

        paymentConfiguration
            .Property<string>("_status")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Status")
            .IsRequired(false);

        paymentConfiguration
            .Property<PaymentMethod>("_method")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Method")
            .IsRequired(true);

        paymentConfiguration
            .Property<Guid>("BillId")            
            .HasColumnName("BillId")
            .IsRequired(true);

        paymentConfiguration
            .HasOne<Bill>()
            .WithMany()
            .HasForeignKey("BillId")
            .IsRequired(true);    
      
    }
}
