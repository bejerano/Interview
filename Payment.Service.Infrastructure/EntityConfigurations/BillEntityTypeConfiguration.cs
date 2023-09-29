using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.Infrastructure;

public class BillEntityTypeConfiguration: PlootoEntityTypeConfiguration<Bill>
{
    public override void Configure(EntityTypeBuilder<Bill> billConfiguration)
    {
        
        base.Configure(billConfiguration);

        billConfiguration.ToTable("Bills", PaymentContext.DEFAULT_SCHEMA);

        billConfiguration.HasKey(o => o.Id);

        billConfiguration
            .Property<int>("_identifier")
            .ValueGeneratedOnAdd()
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Identifier")
            .IsRequired(true);

        billConfiguration
            .Property<decimal>("_totalDue")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("TotalDue")
            .IsRequired(true);

        billConfiguration
            .Property<DateTimeOffset>("_dueDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("DueDate")
            .IsRequired(true);      


        billConfiguration
            .Property<decimal>("_previousBalance")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("PreviousBalance")
            .IsRequired(true);  

          billConfiguration
            .Property<string>("_vendor")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Vendor")
            .IsRequired(true);          
      
    }
}