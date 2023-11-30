using Microsoft.AspNetCore.Identity;

namespace QuizAppBlazor.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }

        public virtual IEnumerable<QuizModel> Quiz { get; set; }
    }
}