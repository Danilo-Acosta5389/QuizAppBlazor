using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppBlazor.Server.Data;
using QuizAppBlazor.Server.Models;

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
    }
}
