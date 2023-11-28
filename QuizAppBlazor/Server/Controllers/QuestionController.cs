using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppBlazor.Server.Data;
using QuizAppBlazor.Shared.DTOs;
using System.Security.Claims;
using QuizAppBlazor.Server.Models;
using System.Text.Json;

namespace QuizAppBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/question/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IEnumerable<QuestionModel> GetQuestionById(Guid id)
        {
            Console.WriteLine(id);
            var result = _context.Questions.Where(x => x.QuizId == id);
            return result;
        }

        // POST: api/question/create
        [HttpPost]
        [Route("create")]
        public IActionResult CreateQuestion([FromBody]CreateQuestionDTO newQuestion)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            var result = new QuestionModel()
            {
                QuizId = newQuestion.QuizId,
                Question = newQuestion.Question,
                CorrectAnswer = newQuestion.CorrectAnswer,
                Alternativ2 = newQuestion.Alternativ2,
                Alternativ3 = newQuestion.Alternativ3,
                Alternativ4 = newQuestion.Alternativ4,
                UserTextInput = newQuestion.UserTextInput,
                ImageVideo = newQuestion.ImageVideo,
                HasTimeLimit = newQuestion.HasTimeLimit,
                TimeLimit = newQuestion.TimeLimit
            };
            var resultJson = JsonSerializer.Serialize(result);
            Console.WriteLine(resultJson);

            _context.Add(result);
            _context.SaveChanges();
            return Ok();
        }
    }
}
