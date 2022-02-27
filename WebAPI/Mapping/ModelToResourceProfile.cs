using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebAPI.Models;
using WebAPI.Resources;

namespace WebAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ForceType, ForceTypeResource>();
            CreateMap<Result, ResultResource>();
        }
    }
}
