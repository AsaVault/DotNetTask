namespace AssessmentTask.Models
{
    using Microsoft.Azure.CosmosRepository;
    using Microsoft.Azure.CosmosRepository.Attributes;
    using Newtonsoft.Json;

    namespace DotNetTasks.Models
    {
        public class CustomQuestion : Item
        {
            public string Name { get; set; }
        }

        public class Input : CustomQuestion
        {
            public string Label { get; set; }
        }

        public class SingleInput : Input
        {
            public string Option { get; set; }
        }

        public class MultipleInput : Input
        {
            public List<string> Options { get; set; } = new List<string>();
        }

        public class DropDown : CustomQuestion
        {

            public List<string> Options { get; set; } = new List<string>();
            public string Label { get; set; }

        }

        public class SingleDropDown : DropDown
        {
            public string SelectedOption { get; set; }
        }


        public class MultipleDropDown : DropDown
        {
            public List<string> SelectedOptions { get; set; } = new List<string>();
        }

    }
}
