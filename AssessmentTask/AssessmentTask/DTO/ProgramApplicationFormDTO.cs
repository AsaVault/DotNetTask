using AssessmentTask.Models;

namespace AssessmentTask.DTO
{
    public class ProgramApplicationFormDTO
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProgramApplicationPersonalInfo> PersonalInfos { get; set; } = new List<ProgramApplicationPersonalInfo>();
        public List<ProgramApplicationQuestion> Questions { get; set; } = new List<ProgramApplicationQuestion>();
    }
}
