using AutoMapper;
using Kreata.Models.DataModel;
using Kreta.Models.DataModel;
using Kreta.Models.DataTranferObjects;
using Kreta.Models.EFClass;

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
