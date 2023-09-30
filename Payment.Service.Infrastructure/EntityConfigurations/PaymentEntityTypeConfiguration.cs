

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
            .Property<int>("_identifier")            
            .ValueGeneratedOnAdd()            
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Identifier")
            .HasColumnOrder(1)
            .IsRequired(true);      

        paymentConfiguration
            .Property<decimal>("_amount")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Amount")
            .HasColumnOrder(2)
            .IsRequired(true);

        paymentConfiguration
            .Property<DateTimeOffset>("_debitDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("DebitDate")
            .HasColumnOrder(3)
            .IsRequired(true);

        paymentConfiguration
            .Property<string>("_status")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Status")
            .HasColumnOrder(4)
            .IsRequired(false);

        paymentConfiguration
            .Property<PaymentMethod>("_method")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Method")
            .HasColumnOrder(5)
            .IsRequired(true);

        paymentConfiguration
            .Property<Guid>("BillId")            
            .HasColumnName("BillId")
            .HasColumnOrder(6)
            .IsRequired(true);

        paymentConfiguration
            .HasOne<Bill>()
            .WithMany()
            .HasForeignKey("BillId")
            .IsRequired(true);    
      
    }
}
