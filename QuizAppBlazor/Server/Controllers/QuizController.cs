using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppBlazor.Server.Data;
using QuizAppBlazor.Server.Models;
using QuizAppBlazor.Shared.DTOs;
using System.Security.Claims;
using System.Text.Json;

namespace QuizAppBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/quiz
        [HttpGet]
        public IEnumerable<QuizModel> GetAllQuizzes()
        {
            var result = _context.Quizzes;
            return result;
        }


        // GET: api/quiz/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public QuizModel GetById(Guid id)
        {
            var result = _context.Quizzes.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        // POST: api/quiz/create
        [HttpPost]
        [Route("create")]
        public ActionResult CreateQuiz([FromBody]CreateQuizDTO newQuiz)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (string.IsNullOrEmpty(newQuiz.Title) || string.IsNullOrEmpty(newQuiz.Description))
            {
                Console.WriteLine("Title or description empty");
                return BadRequest();
            }
            
            var result = new QuizModel() { Id = Guid.NewGuid(), Title = newQuiz.Title, Description = newQuiz.Description, UserId = userId };
            var jsonPayLoad = JsonSerializer.Serialize(result);
            Console.WriteLine(jsonPayLoad);

            _context.Add(result);
            _context.SaveChanges();
            return new OkObjectResult(result.Id);
        }
    }
}
