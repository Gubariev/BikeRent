using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BikeRent.Dto;
using BikeRent.Models;

namespace BikeRent.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<BikeDto, Bike>();
            Mapper.CreateMap<Bike, BikeDto>();

            Mapper.CreateMap<BikeType, BikeTypeDto>();
            Mapper.CreateMap<BikeTypeDto, BikeType>();

        }
    }
}