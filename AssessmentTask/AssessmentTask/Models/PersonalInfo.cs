using Microsoft.Azure.CosmosRepository;

namespace AssessmentTask.Models
{
    public class PersonalInfo : Item
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public bool IsMandated { get; set; }
        public bool IsInternal { get; set; }
        public bool IsHidden { get; set; }
    }

    public class PersonalInfoInput : PersonalInfo
    {
        public string Type { get; set; }
    }

    public class PersonalInfoDropDown : PersonalInfo
    {
        public List<string> Options { get; set; } = new List<string>();
        public string SelectedOption { get; set; }
    }
}
