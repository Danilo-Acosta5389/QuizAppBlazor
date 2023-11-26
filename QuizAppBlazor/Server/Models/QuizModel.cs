
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppBlazor.Server.Models
{
    public class QuizModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? UserId { get; set; }

        // Navigation property
        public ApplicationUser User { get; set; }
    }
}
