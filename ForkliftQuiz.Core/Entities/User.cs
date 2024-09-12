using System;
using System.Collections.Generic;

namespace ForkliftQuiz.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Default Role is set to 'User' if none is provided
        private string _role;
        public string Role
        {
            get => _role ?? "User";
            set => _role = value;
        }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
