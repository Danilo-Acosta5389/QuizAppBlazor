﻿using Duende.IdentityServer.EntityFramework.Options;
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

            //Database seeding
            modelBuilder.Entity<QuizModel>().HasData(
                new QuizModel { 
                    Id = Guid.NewGuid(), 
                    Title = "Politics", 
                    Description = "Test your knowledge about world politics.", 
                    UserId = "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad"
                },
                new QuizModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Geography",
                    Description = "Test your knowledge about countrys and citys.",
                    UserId = "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad"
                },
                new QuizModel
                {
                    Id = Guid.NewGuid(),
                    Title = "History",
                    Description = "Test your knowledge about world history.",
                    UserId = "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad"
                });
        }
    }
}