using AutoMapper;
using Rasyotek.Business.DTOs;
using Rasyotek.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Business.Map
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Personel, CreatePersonelDto>().ReverseMap();
            CreateMap<Personel, UpdatePersonelDto>().ReverseMap();
            CreateMap<Personel, ResultPersonelDto>().ReverseMap();
            CreateMap<Personel, GetByIdPersonelDto>().ReverseMap();
        }
    }
}
