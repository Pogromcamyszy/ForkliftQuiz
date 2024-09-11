namespace ForkliftQuiz.Application.DTOs
{
    public class CreateQuizDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CreateQuestionDto> Questions { get; set; }
    }

    public class CreateQuestionDto
    {
        public string Text { get; set; }
        public List<CreateAnswerDto> Answers { get; set; }
    }

    public class CreateAnswerDto
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
