using Plooto.Assessment.Payment.Domain.Common;


namespace Plooto.Assessment.Payment.Domain;

public class BillStatus : Enumeration
{
    public static BillStatus Paid = new BillStatus(1, nameof(Paid).ToLowerInvariant());
    public static BillStatus Overdue = new BillStatus(2, nameof(Overdue).ToLowerInvariant());
    public static BillStatus Partially_Paid = new BillStatus(3, nameof(Partially_Paid).ToLowerInvariant());
    public static BillStatus Unpaid = new BillStatus(4, nameof(Unpaid).ToLowerInvariant());


    public BillStatus(int id, string name)
    : base(id, name)
    {

    }

    public static IEnumerable<BillStatus> List() =>
        new[] { Paid, Overdue, Partially_Paid, Unpaid };
    public static BillStatus FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new Exception($"Possible values for BillStatus: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static BillStatus From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new Exception($"Possible values for BillStatus: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}


