﻿using AutoMapper;
using uCarOk.Data.Entities;
using uCarOk.Domain.DTOs;

namespace uCarOk.Domain.Mappings
{
    public class BaseMapper: Profile
    {
        public BaseMapper()
        {
            CreateMap<Mechanic, MechanicDTO>();
            CreateMap<MechanicDTO, Mechanic>();
        }
    }
}
