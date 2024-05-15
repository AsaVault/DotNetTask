namespace AssessmentTask.DTO
{
    public class QuestionTemplateResponseDTO
    {
        public string Name { get; set; }
        public string Question { get; set; }
        public List<string> Choices { get; set; } = new List<string>();
        public bool Other { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }
}
