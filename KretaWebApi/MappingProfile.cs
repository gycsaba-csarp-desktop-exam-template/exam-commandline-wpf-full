﻿using AutoMapper;
using Kreta.Models;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;

namespace KretaWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subject, SubjectDto>();
        }
    }
}
