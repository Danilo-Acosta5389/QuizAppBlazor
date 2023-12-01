using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBlazor.Shared.DTOs
{
    public class CreateQuizDTO
    {

        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        // ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Title is required!")]
        [StringLength(20, ErrorMessage = "Title cannot be longer than 20 characters or less than 1.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [StringLength(200, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Description { get; set; }
    }
}
