using AutoMapper;
using SofCaptionThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofCaptionThis
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cat, CatViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Url, opt => opt.MapFrom(s => s.Url))
                .ReverseMap();
        }
    }
}
