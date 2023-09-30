using AutoMapper;
using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.API;

public class BillProfile: Profile
{
    public BillProfile()
    {
        CreateMap<Bill, ViewModels.BillVM>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                    .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.GetIdentifier()))
                                    .ForMember(dest => dest.TotalDue, opt => opt.MapFrom(src => src.GetTotalDue()))
                                    .ForMember(dest => dest.Vendor, opt => opt.MapFrom(src => src.GetVendor()))
                                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>GetBillStatus(src)));

    }
                               
    private static string GetBillStatus(Bill src)
    {
        return src.BillStatus.Name;        
    }
}
