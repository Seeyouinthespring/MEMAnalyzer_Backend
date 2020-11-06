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

            CreateMap<Mem, MemViewModel>()
                .ForMember(dest => dest.Picture, src => src.MapFrom(x => x.Code));

            CreateMap<ResultToHandleModel, Answer>();

            CreateMap<Result, ResultViewModel>()
                .ForMember(dest => dest.Domestic, src => src.MapFrom(x => x.CategoryOnePercentage))
                .ForMember(dest => dest.Popular, src => src.MapFrom(x => x.CategorytwoPercentage))
                .ForMember(dest => dest.Pointless, src => src.MapFrom(x => x.CategoryThreePercentage))
                .ForMember(dest => dest.Intellectual, src => src.MapFrom(x => x.CategoryFourPercentage))
                .ForMember(dest => dest.Conservative, src => src.MapFrom(x => x.CategoryFivePercentage));
        }
    }
}
