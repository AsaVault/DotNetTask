using Microsoft.Azure.CosmosRepository;

namespace AssessmentTask.Models
{
    public class QuestionTemplateResponse : Item
    {

        public string Name { get; set; }
        public string Question { get; set; }
        public List<string> Choices { get; set; } = new List<string>();
        public bool Other { get; set; }
        public int MaxChoiceAllowed { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}
