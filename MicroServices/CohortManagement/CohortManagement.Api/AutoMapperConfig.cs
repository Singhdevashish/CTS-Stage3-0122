using AutoMapper;
using CohortManagement.Api.DTOs;
using CohortManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortManagement.Api
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cohort, CohortDTO>().ForMember(obj => obj.TraineeCount, options => options.MapFrom(m => m.Trainees.Count())).ReverseMap();
            CreateMap<Trainee, TraineeDTO>().ReverseMap();
        }
    }
}
