using Microsoft.Azure.CosmosRepository;

namespace AssessmentTask.Models
{
    public class QuestionTemplateRequest : Item
    {
        public string Name { get; set; } // Dropdown Yes/No
        public bool Question { get; set; }
        public bool Choice { get; set; }
        public bool Other { get; set; }
        public bool MaxChoiceAllowed { get; set; }
    }
}
