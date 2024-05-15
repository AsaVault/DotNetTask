using AssessmentTask.DTO;
using AssessmentTask.Models;
using AutoMapper;
namespace AssessmentTask.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonalInfo, PersonalInfoDTO>().ReverseMap();
            CreateMap<ProgramApplicationForm, ProgramApplicationFormDTO>().ReverseMap();
            CreateMap<ProgramModel, ProgramModelDTO>().ReverseMap();
            CreateMap<QuestionTemplateRequest, QuestionTemplateRequestDTO>().ReverseMap();
            CreateMap<QuestionTemplateResponse, QuestionTemplateResponseDTO>().ReverseMap();

        }
    }
}
