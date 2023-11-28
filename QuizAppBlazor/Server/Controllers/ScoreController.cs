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
    public class ScoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ScoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/score/post
        [HttpPost]
        [Route("post")]
        public ActionResult PostScore([FromBody] UserScoreDTO userScore)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            var result = new UserQuizModel() { QuizId = userScore.QuizId, UserId = userId, CorrectAnswers = userScore.CorrectAnswers };
            var jsonPayLoad = JsonSerializer.Serialize(result);
            Console.WriteLine(jsonPayLoad);

            _context.Add(result);
            _context.SaveChanges();
            return Ok();
        }
    }
}
