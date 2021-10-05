using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportTracker.Areas.Identity.Data;
using SportTracker.Models;

namespace SportTracker.Data
{
    public class AppDbContext : IdentityDbContext<AspNetUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        public DbSet<SportPlan> SportPlans { get; set; }
        public DbSet<PlanWorkout> PlanWorkouts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AnswerQuestion>()
                .HasOne(e => e.Question)
                .WithMany(e => e.AnswerQuestions)
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AnswerQuestion>()
                .HasOne(e => e.Answer)
                .WithMany(e => e.AnswerQuestions)
                .HasForeignKey(e => e.AnswerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithOne(e => e.Question)
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
