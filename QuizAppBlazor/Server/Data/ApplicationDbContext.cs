using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuizAppBlazor.Server.Models;

namespace QuizAppBlazor.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<QuestionModel> Questions { get; set; }

        public DbSet<QuizModel> Quizzes { get; set; }

        public DbSet<ScoreModel> Score { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Database seeding   //You may replace userId in the futer or whatever
            //modelBuilder.Entity<QuizModel>().HasData(
            //    new QuizModel
            //    {
            //        Id = Guid.Parse("F770E323-5463-49A9-97F1-0F88F6857D21"),
            //        LinkId = "masters-of-the-game-f770e323",
            //        Title = "\"Masters of the Game\"",
            //        Description = "Politics Quiz: Discover the intricate dance of power and governance in 'Masters of the Game.' Explore political systems, international relations, and economic ideologies that shape the world of politics.",
            //        UserId = "b429a22a-7746-416d-81ec-7837b1e28379"
            //    });

            //modelBuilder.Entity<QuestionModel>().HasData(
            //    new QuestionModel
            //    {
            //        Id = 1,
            //        Question = "What is the term for a political system in which power is vested in the hands of a few individuals or a single entity?",
            //        CorrectAnswer = "Oligarchy",
            //        Alternativ2 = "Democracy",
            //        Alternativ3 = "Anarchy",
            //        Alternativ4 = "Communism",
            //        IsTextInput = false,
            //        ImageVideo = "https://s3.amazonaws.com/blog.oxfamamerica.org/politicsofpoverty/2015/04/Inequality-014-1220x763.jpg",
            //        IsImage = true,
            //        HasTimeLimit = true,
            //        TimeLimit = 20,
            //        QuizId = Guid.Parse("F770E323-5463-49A9-97F1-0F88F6857D21"),
            //        LinkId = "masters-of-the-game-f770e323"
            //    },
            //    new QuestionModel
            //    {
            //        Id = 2,
            //        Question = "Which branch of the United States government is responsible for interpreting laws and ensuring they align with the Constitution?",
            //        CorrectAnswer = "Judicial",
            //        Alternativ2 = "Legislative",
            //        Alternativ3 = "Executive",
            //        Alternativ4 = "Administrative",
            //        IsTextInput = false,
            //        ImageVideo = "https://cdn.britannica.com/34/203634-049-D35DACFA.jpg",
            //        IsImage = true,
            //        HasTimeLimit = true,
            //        TimeLimit = 20,
            //        QuizId = Guid.Parse("F770E323-5463-49A9-97F1-0F88F6857D21"),
            //        LinkId = "masters-of-the-game-f770e323"
            //    },
            //    new QuestionModel
            //    {
            //        Id = 3,
            //        Question = "In international relations, what is the concept that suggests countries should avoid interference in the internal affairs of other sovereign nations?",
            //        CorrectAnswer = "Isolationism",
            //        Alternativ2 = "Imperialism",
            //        Alternativ3 = "Globalism",
            //        Alternativ4 = "Interventionism",
            //        IsTextInput = false,
            //        ImageVideo = "y32cFdicW1U",
            //        IsYoutubeVideo = true,
            //        HasTimeLimit = true,
            //        TimeLimit = 20,
            //        QuizId = Guid.Parse("F770E323-5463-49A9-97F1-0F88F6857D21"),
            //        LinkId = "masters-of-the-game-f770e323"
            //    },
            //    new QuestionModel
            //    {
            //        Id = 4,
            //        Question = "What is the primary function of the United Nations Security Council?",
            //        CorrectAnswer = "Conflict resolution",
            //        Alternativ2 = "Humanitarian aid",
            //        Alternativ3 = "Economic development",
            //        Alternativ4 = "Cultural exchange",
            //        IsTextInput = false,
            //        ImageVideo = "https://vod-progressive.akamaized.net/exp=1701334814~acl=%2Fvimeo-prod-skyfire-std-us%2F01%2F2836%2F12%2F314181352%2F1212112677.mp4~hmac=f85c8a3f2832b0957da2af728fd1605894cd96de2b35504fdea2b43ae2b94e23/vimeo-prod-skyfire-std-us/01/2836/12/314181352/1212112677.mp4",
            //        IsVideo = true,
            //        HasTimeLimit = true,
            //        TimeLimit = 30,
            //        QuizId = Guid.Parse("F770E323-5463-49A9-97F1-0F88F6857D21"),
            //        LinkId = "masters-of-the-game-f770e323"
            //    },
            //    new QuestionModel
            //    {
            //        Id = 5,
            //        Question = "Which economic system is characterized by private ownership of the means of production and individual entrepreneurship?",
            //        CorrectAnswer = "Capitalism",
            //        IsTextInput = true,
            //        ImageVideo = "https://bestdiplomats.org/wp-content/uploads/2023/10/Types-of-Political-Economy-copy-1.jpg",
            //        IsImage = true,
            //        HasTimeLimit = true,
            //        TimeLimit = 60,
            //        QuizId = Guid.Parse("F770E323-5463-49A9-97F1-0F88F6857D21"),
            //        LinkId = "masters-of-the-game-f770e323"
            //    });
        }
    }
}