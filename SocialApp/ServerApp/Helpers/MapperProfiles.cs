using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Helpers
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<User,UserForListDTO>()
            .ForMember(dest => dest.Image, opt=>
            opt.MapFrom(src => src.Images.FirstOrDefault(i=>i.IsProfile))
            ).ForMember(dest =>dest.Age,opt=> opt.MapFrom(src=>src.DateofBirth.CalcuateAge()));
            CreateMap<User,UserForDetailsDTO>();
            CreateMap<Image, ImagesForDetails>();
        }
 
    }
}