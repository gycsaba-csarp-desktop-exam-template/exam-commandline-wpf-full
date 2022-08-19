using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using KretaParancssoriAlkalmazas.Models.EFClass;

namespace KretaRazorPages
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EFSubject, Subject>();
            CreateMap<Subject, EFSubject>();
            CreateMap<Subject, EFSubject>();
            CreateMap<EFSchoolClass, SchoolClass>();
            CreateMap<SubjectForCreationDto, EFSubject>();
            CreateMap<SubjectForUpdateDto, EFSubject>();
        }
    }
}
