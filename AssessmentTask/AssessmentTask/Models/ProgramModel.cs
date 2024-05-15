using AssessmentTask.Models.DotNetTasks.Models;
using Microsoft.Azure.CosmosRepository;

namespace AssessmentTask.Models
{
    public class ProgramModel : Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PersonalInfo> PersonalInfos { get; set; } = new List<PersonalInfo>();
        public List<CustomQuestion> CustomQuestions { get; set; } = new List<CustomQuestion>();
    }
}
