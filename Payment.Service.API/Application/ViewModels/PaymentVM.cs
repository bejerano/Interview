namespace Plooto.Assessment.Payment.API.ViewModels;

public class PaymentVM
{
    public Guid Id { get; set; }
    public int Identifier { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset DebitDate { get; set; }
    
}
