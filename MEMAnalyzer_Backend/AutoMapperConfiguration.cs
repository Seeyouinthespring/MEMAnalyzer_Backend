using AutoMapper;
using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.DBModels;
using System;
using System.Linq;

namespace MEMAnalyzer_Backend
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.DateOfBirth, src => src.MapFrom(x => DateTime.SpecifyKind(x.BirthDate,DateTimeKind.Local) ));

            CreateMap<ApplicationUserDtoModel, ApplicationUser>();

            CreateMap<ApplicationUser, ApplicationUserEnterViewModel>()
                .ForMember(dest => dest.DateOfBirth, src => src.MapFrom(x => DateTime.SpecifyKind(x.BirthDate, DateTimeKind.Local)))
                .ForMember(dest => dest.Result, src => src.MapFrom(x => x.Results.FirstOrDefault()))
                .ForMember(dest => dest.Role, src => src.MapFrom(x => (x.IdentityRole == null) ? null : x.IdentityRole.Name));

            CreateMap<Mem, MemViewModel>()
                .ForMember(dest => dest.Picture, src => src.MapFrom(x => x.Code));
            CreateMap<Mem, MemWithCategoryViewModel>()
                .ForMember(dest => dest.Picture, src => src.MapFrom(x => x.Code));
            CreateMap<MemDtoModel, Mem>();

            CreateMap<ResultToHandleModel, Answer>();

            CreateMap<Result, ResultViewModel>()
                .ForMember(dest => dest.Domestic, src => src.MapFrom(x => x.CategoryOnePercentage))
                .ForMember(dest => dest.Popular, src => src.MapFrom(x => x.CategorytwoPercentage))
                .ForMember(dest => dest.Pointless, src => src.MapFrom(x => x.CategoryThreePercentage))
                .ForMember(dest => dest.Intellectual, src => src.MapFrom(x => x.CategoryFourPercentage))
                .ForMember(dest => dest.Conservative, src => src.MapFrom(x => x.CategoryFivePercentage))
                .ForMember(dest => dest.Statement, src => src.MapFrom(x => x.Stetement.Text));

            CreateMap<ApplicationUser, ApplicationUserWithResultViewModel>()
                .ForMember(dest => dest.DateOfBirth, src => src.MapFrom(x => DateTime.SpecifyKind(x.BirthDate, DateTimeKind.Local)))
                .ForMember(dest => dest.Result, src => src.MapFrom(x => x.Results.FirstOrDefault()))
                .ForMember(dest => dest.Role, src => src.MapFrom(x => (x.IdentityRole == null) ? null : x.IdentityRole.Name));
        }
    }
}
