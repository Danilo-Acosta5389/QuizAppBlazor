
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppBlazor.Server.Models
{
    public class QuizModel
    {
        [Key]
        public Guid Id { get; set; }

        //Link mainly for URL but works as publicId aswell, is a combination of Title and the first 13 characters of Id
        public string LinkId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        // Navigation property
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual IEnumerable<QuestionModel> Question { get; set; }
    }
}
