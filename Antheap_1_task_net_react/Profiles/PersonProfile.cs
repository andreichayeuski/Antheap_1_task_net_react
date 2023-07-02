using Antheap_1_task_net_react.Data.Entities;
using Antheap_1_task_net_react.ViewModels;
using AutoMapper;

namespace Antheap_1_task_net_react.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonEntity, PersonViewModel>()
                .ForMember(dest => dest.Representatives, opt => opt.Ignore());
        }
    }
}