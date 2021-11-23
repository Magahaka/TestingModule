using Microsoft.EntityFrameworkCore;
using Moq;
using SportTracker.Controllers;
using SportTracker.Data;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Controllers
{
    public class QuestionCreateTest
    {
        private readonly Mock<DbSet<Question>> dbSet;
        private readonly Mock<AppDbContext> context;
        private readonly CreateQuestion.Handler handler;

        public QuestionCreateTest()
        {
            dbSet = new Mock<DbSet<Question>>();
            var options = new DbContextOptionsBuilder<AppDbContext>().Options;
            context = new Mock<AppDbContext>(options);
            handler = new CreateQuestion.Handler(context.Object);
        }

        [Fact]
        public async Task CanCreateQuestion()
        {
            var command = new CreateQuestion.Command
            {
                Question = new Question
                {
                    Id = 1,
                    Name = "test",
                    Answers = new List<Answer>(),
                    QuestionnaireQuestions = new List<QuestionnaireQuestion>(),
                    Depth = 1
                }
            };

            context.Setup(e => e.Questions).Returns(dbSet.Object);

            await handler.Handle(command, new CancellationToken());

            dbSet.Verify(m => m.Add(It.IsAny<Question>()), Times.Once());
            context.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task CantCreateQuestionWithoutName()
        {
            var command = new CreateQuestion.Command
            {
                Question = new Question
                {
                    Id = 1,
                    Name = string.Empty,
                    Answers = new List<Answer>(),
                    QuestionnaireQuestions = new List<QuestionnaireQuestion>(),
                    Depth = 1
                }
            };

            context.Setup(e => e.Questions).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Question must have a name", exception.Message);
        }

        [Fact]
        public async Task CantCreateQuestionWithZeroId()
        {
            var command = new CreateQuestion.Command
            {
                Question = new Question
                {
                    Id = 0,
                    Name = "test1",
                    Answers = new List<Answer>(),
                    QuestionnaireQuestions = new List<QuestionnaireQuestion>(),
                    Depth = 1
                }
            };

            context.Setup(e => e.Questions).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Question must have id", exception.Message);
        }

        [Fact]
        public async Task DepthCannotBeNegative()
        {
            var command = new CreateQuestion.Command
            {
                Question = new Question
                {
                    Id = 1,
                    Name = "test1",
                    Answers = new List<Answer>(),
                    QuestionnaireQuestions = new List<QuestionnaireQuestion>(),
                    Depth = -1
                }
            };

            context.Setup(m => m.Questions).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Question must have a positive depth level", exception.Message);
        }

        [Fact]
        public async Task AnswerListCannotBeNull()
        {
            var command = new CreateQuestion.Command
            {
                Question = new Question
                {
                    Id = 1,
                    Name = "test1",
                    Answers = null,
                    QuestionnaireQuestions = new List<QuestionnaireQuestion>(),
                    Depth = 1
                }
            };

            context.Setup(e => e.Questions).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Question must have answers list", exception.Message);
        }

        [Fact]
        public async Task QuestionnaireQuestionsCannotBeNull()
        {
            var command = new CreateQuestion.Command
            {
                Question = new Question
                {
                    Id = 1,
                    Name = "test1",
                    Answers = new List<Answer>(),
                    QuestionnaireQuestions = null,
                    Depth = 1
                }
            };

            context.Setup(e => e.Questions).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Questionnaire questions must have answers list", exception.Message);
        }
    }
}
