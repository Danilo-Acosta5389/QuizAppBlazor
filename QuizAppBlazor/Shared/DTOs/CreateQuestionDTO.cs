using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBlazor.Shared.DTOs
{
    public class CreateQuestionDTO
    {
        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public string UserAnswer { get; set; } = string.Empty;

        public string ImageVideo { get; set; } = "https://static.vecteezy.com/system/resources/thumbnails/007/653/541/small/seamless-pattern-background-with-bright-sign-question-marks-on-blue-backdrop-feedback-brainstorm-opinion-reaction-questionnaire-learning-concept-business-office-wallpaper-vector.jpg";

        public int Duration { get; set; } = 60;
    }
}
