namespace ForkliftQuiz.Application.DTOs
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string[] Errors { get; set; }
    }
}
