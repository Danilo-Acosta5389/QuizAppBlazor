using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBlazor.Shared.DTOs
{
    public class GetQuizDTO
    {
        public string LinkId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
