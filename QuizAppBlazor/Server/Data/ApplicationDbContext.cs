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

        public DbSet<UserQuizModel> UserQuiz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserQuizModel>()
                .HasKey(k => new { k.UserId, k.QuizId });

            modelBuilder.Entity<QuestionModel>()
                .HasKey(k => new { k.Id });

            //modelBuilder.Entity<QuizModel>()
            //    .HasKey(k => new { k.Id });

            //Database seeding
            //modelBuilder.Entity<QuizModel>().HasData(
            //    new QuizModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Title = "Politics",
            //        Description = "Test your knowledge about world politics.",
            //        UserId = "05307715-cae7-45ca-b5d8-d30ec1705e2a"
            //    },
            //    new QuizModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Title = "Geography",
            //        Description = "Test your knowledge about countrys and citys.",
            //        UserId = "05307715-cae7-45ca-b5d8-d30ec1705e2a"
            //    },
            //    new QuizModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Title = "History",
            //        Description = "Test your knowledge about world history.",
            //        UserId = "05307715-cae7-45ca-b5d8-d30ec1705e2a"
            //    });
        }
    }
}