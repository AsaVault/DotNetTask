using AssessmentTask.Models;

namespace AssessmentTask.DTO
{
    public class ProgramModelDTO
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PersonalInfo> PersonalInfos { get; set; } = new List<PersonalInfo>();
        public List<CustomQuestion> CustomQuestions { get; set; } = new List<CustomQuestion>();
    }
}
