using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.API;

public class PaymentProfile: Profile
{
    public PaymentProfile()
    {
        CreateMap<PaymentDetail, ViewModels.PaymentVM>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                                        .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.GetIdentifier()))
                                                        .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.GetAmount()))
                                                        .ForMember(dest => dest.DebitDate, opt => opt.MapFrom(src => src.GetDebitDate()));
                                    

    }
}
