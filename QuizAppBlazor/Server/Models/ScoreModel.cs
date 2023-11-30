using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizAppBlazor.Server.Models
{
    public class ScoreModel
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string LinkId { get; set; }

        public int CorrectAnswers { get; set; }

        public string AuthorId { get; set; }

        //Datetime would be nice but not necessary

    }
}
