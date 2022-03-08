using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerManagement.Domain;

namespace TrainerManagement.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TrainerDTO, Trainer>().ReverseMap();
        }
    }
}
