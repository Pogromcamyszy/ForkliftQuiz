using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkliftQuiz.Core.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } // Relacja z użytkownikiem
        public ICollection<Question> Questions { get; set; } // Relacja z pytaniami
    }
}
