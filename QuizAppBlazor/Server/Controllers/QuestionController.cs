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

        // GET: api/question/{LinkId}
        [HttpGet]
        [Route("{LinkId}")]
        public ActionResult<IEnumerable<GetQuestionsDTO>> GetQuestionById(string LinkId)
        {
            Console.WriteLine("LinkId is: " + LinkId);

            try
            {
                var result = _context.Questions
                .Where(x => x.LinkId == LinkId)
                .Select(x => new GetQuestionsDTO
                {
                    LinkId = x.LinkId,
                    Question = x.Question,
                    CorrectAnswer = x.CorrectAnswer,
                    Alternativ2 = x.Alternativ2,
                    Alternativ3 = x.Alternativ3,
                    Alternativ4 = x.Alternativ4,
                    IsTextInput = x.IsTextInput,
                    ImageVideo = x.ImageVideo,
                    IsImage = x.IsImage,
                    IsVideo = x.IsVideo,
                    IsYoutubeVideo = x.IsYoutubeVideo,
                    HasTimeLimit = x.HasTimeLimit,
                    TimeLimit = x.TimeLimit
                });

                return Ok(result);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR: " + e.Message);
                return BadRequest("ERROR:" + e);
            }
            
        }

        // POST: api/question/create
        [HttpPost]
        [Route("create")]
        public IActionResult CreateQuestion([FromBody]CreateQuestionDTO newQuestion)
        {
            //Console.WriteLine("HEEELLLOOO");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }
            Console.WriteLine(userId);

            QuizModel quizId = new QuizModel();

            try
            {
                quizId = _context.Quizzes.Where(x => x.LinkId == newQuestion.LinkId).First();
                Console.WriteLine("Here is quizId: " + quizId.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine("DID NOT WORK: " + e.Message);
            }
            

            var result = new QuestionModel()
            {
                QuizId = quizId.Id, 
                LinkId = newQuestion.LinkId,
                Question = newQuestion.Question,
                CorrectAnswer = newQuestion.CorrectAnswer,
                Alternativ2 = newQuestion.Alternativ2,
                Alternativ3 = newQuestion.Alternativ3,
                Alternativ4 = newQuestion.Alternativ4,
                IsTextInput = newQuestion.IsTextInput,
                ImageVideo = newQuestion.ImageVideo,
                IsImage = newQuestion.IsImage,
                IsVideo = newQuestion.IsVideo,
                IsYoutubeVideo = newQuestion.IsYoutubeVideo,
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
