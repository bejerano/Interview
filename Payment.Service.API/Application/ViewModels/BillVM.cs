namespace Plooto.Assessment.Payment.API.ViewModels;

public class BillVM
{
    public Guid Id { get; set; }
    public int  Identifier { get; set; }
    public decimal TotalDue { get; set; }
    public string Vendor { get; set; }  
     public string Status { get; set; }  
}
