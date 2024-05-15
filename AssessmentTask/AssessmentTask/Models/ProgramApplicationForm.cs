using Microsoft.Azure.CosmosRepository;

namespace AssessmentTask.Models
{
    public class ProgramApplicationForm : Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProgramApplicationPersonalInfo> PersonalInfos { get; set; } = new List<ProgramApplicationPersonalInfo>();
        public List<ProgramApplicationQuestion> Questions { get; set; } = new List<ProgramApplicationQuestion>();
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }

    public class ProgramApplicationPersonalInfo
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
    }

    public class ProgramApplicationQuestion
    {
        public List<string> selectedOptions { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
    }
}
