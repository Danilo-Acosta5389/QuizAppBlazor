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


        // GET: api/score
        [HttpGet]
        public ActionResult<IEnumerable<GetScoreByAuthorDTO>> GetScoreByUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            //Scoremodel only gives us QuizId, UserId, LinkId, Score and AuthorId(Creator of quiz)
            //We want the Title of the quiz where quizid == QuizId, and we want the name of the user where userId == UserId
            //Select the Title, Username and Score.

            IEnumerable<GetScoreByAuthorDTO> result;

            try
            {
                result = (from s in _context.Score
                              join q in _context.Quizzes on s.LinkId equals q.LinkId
                              join u in _context.Users on s.UserId equals u.Id
                              where s.AuthorId == userId
                              select new GetScoreByAuthorDTO
                              {
                                  Title = q.Title,
                                  Nickname = u.Nickname,
                                  Points = s.CorrectAnswers
                              });
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e}");
            }
            
            return Ok(result);
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

            var authorId = _context.Quizzes.Where(x => x.LinkId == userScore.LinkId).Select(x => x.UserId).FirstOrDefault();

            var result = new ScoreModel() { LinkId = userScore.LinkId, UserId = userId, CorrectAnswers = userScore.CorrectAnswers, AuthorId = authorId };
            var jsonPayLoad = JsonSerializer.Serialize(result);
            Console.WriteLine(jsonPayLoad);


            // have try catch here
            try
            {
                _context.Add(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest("ERROR: " + e.Message);
            }
            return Ok();
        }
    }
}
