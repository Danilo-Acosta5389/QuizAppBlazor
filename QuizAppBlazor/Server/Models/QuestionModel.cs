namespace QuizAppBlazor.Server.Models
{
    public class QuestionModel
    {
        //[Key]
        public Guid Id { get; set; }

        //[ForeignKey("QuizModel")]
        public Guid QuizId { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public string UserAnswer { get; set; }

        public bool IsCorrect { get; set; }

        public string ImageVideo { get; set; }

        public int Duration { get; set; }

        // Navigation property
        public QuizModel Quiz { get; set; }

    }
}
