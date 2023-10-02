namespace Plooto.Assessment.Payment.Domain;

public abstract class PlootoEntity
{
    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user who created the entity.
    /// </summary>
    public string CreatedBy { get; set; }
  
    /// <summary>
    /// The date and time the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// The user who last modified the entity.
    /// </summary>
    public string ModifiedBy { get; set; }

    /// <summary>
    /// The date and time the entity was last modified.
    /// </summary>
    public DateTimeOffset ModifiedOn { get; set; }
}
