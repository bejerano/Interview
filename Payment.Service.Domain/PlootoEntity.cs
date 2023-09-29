namespace Plooto.Assessment.Payment.Domain;

public abstract class PlootoEntity
{
    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public string ModifiedBy { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
}
