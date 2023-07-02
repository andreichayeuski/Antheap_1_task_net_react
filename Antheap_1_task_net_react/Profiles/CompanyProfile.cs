using Antheap_1_task_net_react.Data.Entities;
using Antheap_1_task_net_react.ViewModels;
using AutoMapper;

namespace Antheap_1_task_net_react.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyEntity, CompanyViewModel>()
               .ForMember(dest => dest.StatusVat, opt => opt.MapFrom(c => c.StatusVat))
               .ForMember(dest => dest.Representatives, opt => opt.Ignore());
        }
    }
}
