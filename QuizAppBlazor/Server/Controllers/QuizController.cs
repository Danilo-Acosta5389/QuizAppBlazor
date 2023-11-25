using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppBlazor.Server.Data;
using QuizAppBlazor.Server.Models;
using QuizAppBlazor.Shared.DTOs;

namespace QuizAppBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/quiz
        [HttpGet]
        public List<QuizModel> GetAllQuizzes()
        {
            var result = _context.Quizzes.ToList<QuizModel>();
            return result;
        }

        // POST: api/quiz/CreateQuizDTO
        [HttpPost]
        public IActionResult CreateQuiz(CreateQuizDTO newQuiz)
        {
            if (newQuiz.Title == null)
            {
                Console.WriteLine(newQuiz);

                return Ok();
            }

            return BadRequest();
        }
    }
}
