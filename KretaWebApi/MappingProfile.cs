using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using KretaParancssoriAlkalmazas.Models.EFClass;

namespace KretaWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EFSubject, Subject>();
            CreateMap<SchoolClass, SchoolClassDto>();
            CreateMap<SubjectForCreationDto, EFSubject>();
            CreateMap<SubjectForUpdateDto, EFSubject>();
        }
    }
}
