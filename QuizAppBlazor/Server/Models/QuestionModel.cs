

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuizAppBlazor.Server.Models
{   
    //This model could be devided into at least two models, Question and Media
    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        [AllowNull]
        public string? Alternativ2 { get; set; }

        [AllowNull]
        public string? Alternativ3 { get; set; }

        [AllowNull]
        public string? Alternativ4 { get; set; }

        // If this is false then it is options
        [AllowNull]
        public bool? IsTextInput { get; set; }

        [AllowNull]
        public string? ImageVideo { get; set; }

        [AllowNull]
        public bool? IsImage { get; set; }

        [AllowNull]
        public bool? IsVideo { get; set; }  //Probably will be most compatible with MP4 format

        [AllowNull]
        public bool? IsYoutubeVideo { get; set; }

        [AllowNull]
        public bool? HasTimeLimit { get; set; }

        [AllowNull]
        public int? TimeLimit { get; set; }

        [AllowNull]
        public string? LinkId { get; set; }

        // Navigation property
        public Guid? QuizId { get; set; }
        public QuizModel? Quiz { get; set; }

    }
}
