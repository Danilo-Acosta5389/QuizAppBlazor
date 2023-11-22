namespace QuizAppBlazor.Server.Models
{
    public class UserQuizModel
    {

        public string UserId { get; set; }

        public Guid QuizId { get; set; }

        public int CorrectAnswers { get; set; }

        // Navigation property
        public ApplicationUser User { get; set; }
        public QuizModel Quiz { get; set; }
    }
}
