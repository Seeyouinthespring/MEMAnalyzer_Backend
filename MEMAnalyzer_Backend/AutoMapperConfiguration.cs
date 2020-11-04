using AutoMapper;
using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.DBModels;

namespace MEMAnalyzer_Backend
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.DateOfBirth, src => src.MapFrom(x => x.BirthDate));

            CreateMap<Mem, MemViewModel>();
        }
    }
}
