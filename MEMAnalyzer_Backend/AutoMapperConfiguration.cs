using AutoMapper;
using MEMAnalyzer_Backend.Business.BusinessModels;
using MEMAnalyzer_Backend.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.DateOfBirth, src => src.MapFrom(x => x.BirthDate));
        }
    }
}
