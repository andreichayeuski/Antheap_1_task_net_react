using Antheap_1_task_net_react.Data.Entities;
using Antheap_1_task_net_react.ViewModels;
using AutoMapper;

namespace Antheap_1_task_net_react.Profiles
{
    public class RepresentativeProfile : Profile
    {
        public RepresentativeProfile()
        {
            CreateMap<RepresentativeEntity, RepresentativeViewModel>();
        }
    }
}
