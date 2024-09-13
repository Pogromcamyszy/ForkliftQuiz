namespace ForkliftQuiz.Application.DTOs
{
    public class UpdateQuizDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UpdateQuestionDto> Questions { get; set; }
    }

    public class UpdateQuestionDto
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public List<UpdateAnswerDto> Answers { get; set; }
    }

    public class UpdateAnswerDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
