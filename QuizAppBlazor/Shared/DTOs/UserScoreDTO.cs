using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBlazor.Shared.DTOs
{
    public class UserScoreDTO
    {
        public Guid QuizId { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
