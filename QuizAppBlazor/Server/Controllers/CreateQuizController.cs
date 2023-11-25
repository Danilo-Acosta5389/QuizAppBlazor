using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuizAppBlazor.Server.Data;
using QuizAppBlazor.Server.Models;
using QuizAppBlazor.Shared;
using QuizAppBlazor.Shared.DTOs;
using System.Security.Claims;

namespace QuizAppBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateQuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CreateQuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/CreateQuiz/quizId/title/desc/userId
        [HttpPost]
        public ActionResult<QuizModel> Create(Guid quizId, string title, string desc, string userId)
        {
            if (title != null && desc != null)
            {
                //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //Guid id = Guid.NewGuid();
                //Console.WriteLine(id);

                _context.Add(new QuizModel { Id = quizId, Title = title, Description = desc, UserId = userId});
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }

    }
}
