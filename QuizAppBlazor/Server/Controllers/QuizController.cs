using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppBlazor.Server.Data;
using QuizAppBlazor.Server.Models;
using QuizAppBlazor.Shared.DTOs;
using System;
using System.Security.Claims;
using System.Text.Json;
using System.Text.RegularExpressions;

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
        public IEnumerable<GetQuizDTO> GetAllQuizzes()
        {
            //Should not return entire QuizModel, use DTO for this

            var result = _context.Quizzes.Select(x => new GetQuizDTO { LinkId = x.LinkId, Title = x.Title, Description = x.Description});


            return result;
        }


        // GET: api/quiz/user
        [HttpGet]
        [Route("user")]
        public IEnumerable<QuizModel> GetByUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            var result = _context.Quizzes.Where(x => x.UserId == userId);
            return result;
        }

        // GET: api/quiz/{id}
        [HttpGet]
        [Route("{LinkId}")]
        public GetQuizDTO GetByQuizId([FromRoute] string linkId)
        {
            var result = _context.Quizzes.Where(x => x.LinkId == linkId).Select(x => new GetQuizDTO { LinkId = x.LinkId, Title = x.Title, Description = x.Description}).FirstOrDefault();
            return result;
        }

        // POST: api/quiz/create
        [HttpPost]
        [Route("create")]
        public IActionResult CreateQuiz([FromBody]CreateQuizDTO newQuiz)
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

            // The quizId is a new Guid
            var quizId = Guid.NewGuid();

            //Below method generates the LinkId, A combination of the title and the 8 first characters of the QuizId guid
            //Incase special charaters have been introduced in the title, they will be removed here
            string CreateLinkId(Guid quizId, string title)
            {
                title = Regex.Replace(title, "[^a-zA-Z0-9]", " ", RegexOptions.Compiled);
                title = title.Trim();
                title = Regex.Replace(title, " ", "-", RegexOptions.Compiled);
                title = Regex.Replace(title, "(?<=\\-)[^a-zA-Z0-9](?=\\-)", " ", RegexOptions.Compiled);
                title = title.Replace(" ", "");
                title = Regex.Replace(title, "[^a-zA-Z0-9](?=\\-)", "", RegexOptions.Compiled);
                
                var trimmedGuid = quizId.ToString().Remove(8);
                var result = title + "-" + trimmedGuid;
                return result;
            }

            //The LinkId is used as a public id, it is also passed in the URL for linking to the quiz
            var newLinkId = CreateLinkId(quizId, newQuiz.Title).ToLower();

            var result = new QuizModel() 
            { 
                Id = quizId, 
                LinkId = newLinkId, 
                Title = newQuiz.Title, 
                Description = newQuiz.Description, 
                UserId = userId 
            };

            var jsonPayLoad = JsonSerializer.Serialize(result.LinkId);
            Console.WriteLine("LinkId: " + jsonPayLoad);

            _context.Add(result);
            _context.SaveChanges();
            return Ok(jsonPayLoad);
        }
    }
}
