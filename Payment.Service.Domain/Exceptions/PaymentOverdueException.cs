

namespace Plooto.Assessment.Payment.Domain.Exceptions;

public class PaymentOverdueException : Exception
{
    public PaymentOverdueException()    
    {
      
    }

    public PaymentOverdueException(string message)
        : base(message)
    {
    }

    public PaymentOverdueException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
