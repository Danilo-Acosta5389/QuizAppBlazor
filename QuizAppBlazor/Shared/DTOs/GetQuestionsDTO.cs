using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBlazor.Shared.DTOs
{
    public class GetQuestionsDTO
    {
        public string? LinkId { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public string? Alternativ2 { get; set; }

        public string? Alternativ3 { get; set; }

        public string? Alternativ4 { get; set; }

        public string? UserTextInput { get; set; }  //THIS FIELD IS NOT NEEDED

        public bool? IsTextInput { get; set; }

        public string? ImageVideo { get; set; }

        public bool? IsImage { get; set; }

        public bool? IsVideo { get; set; }

        public bool? IsYoutubeVideo { get; set; }

        public bool? HasTimeLimit { get; set; }

        public int? TimeLimit { get; set; }
    }
}
