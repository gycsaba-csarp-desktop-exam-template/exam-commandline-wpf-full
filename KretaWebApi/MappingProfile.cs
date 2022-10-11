using AutoMapper;
using Kreata.Models.DataModel;
using Kreta.Models.DataModel;
using Kreta.Models.DataTranferObjects;
using Kreta.Models.EFClass;

namespace KretaWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EFSubject, Subject>();
            CreateMap<EFSchoolClass, SchoolClass>();
            CreateMap<SubjectForCreationDto, EFSubject>();
            CreateMap<SubjectForUpdateDto, EFSubject>();
        }
    }
}
