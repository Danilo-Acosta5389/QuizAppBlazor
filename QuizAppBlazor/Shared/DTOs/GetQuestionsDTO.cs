using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBlazor.Shared.DTOs
{
    public class GetQuestionsDTO
    {
        public Guid QuizId { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public string Alternativ2 { get; set; }

        public string Alternativ3 { get; set; }

        public string Alternativ4 { get; set; }

        public string? UserTextInput { get; set; }

        public bool? IsCorrect { get; set; }

        public string? ImageVideo { get; set; }

        public bool? HasTimeLimit { get; set; }

        public int? TimeLimit { get; set; }
    }
}
