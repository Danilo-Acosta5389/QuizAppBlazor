using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBlazor.Shared.DTOs
{
    public class GetScoreByAuthorDTO
    {
        public string Title { get; set; }
        public string Nickname { get; set; }
        public int Points { get; set; }
    }
}
