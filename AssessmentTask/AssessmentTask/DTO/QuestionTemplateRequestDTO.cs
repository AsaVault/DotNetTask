namespace AssessmentTask.DTO
{
    public class QuestionTemplateRequestDTO
    {
        public string Id { get; set; } // Dropdown Yes/No
        public string Type { get; set; } // 
        public string Name { get; set; } // Dropdown Yes/No
        public bool Question { get; set; }
        public bool Choice { get; set; }
        public bool Other { get; set; }
        public bool MaxChoiceAllowed { get; set; }
    }
}
