using Microsoft.Azure.CosmosRepository;

namespace AssessmentTask.DTO
{
    public class PersonalInfoDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public bool IsMandated { get; set; }
        public bool IsInternal { get; set; }
        public bool IsHidden { get; set; }
        public string Type { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string SelectedOption { get; set; }
    }
}
