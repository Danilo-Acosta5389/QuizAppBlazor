

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppBlazor.Server.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

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

        // Navigation property
        public QuizModel Quiz { get; set; }

    }
}
