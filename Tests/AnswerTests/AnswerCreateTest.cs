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

namespace Tests.AnswerTests
{
    public class AnswerCreateTest
    {
        private readonly Mock<AppDbContext> mockContext;
        private readonly Mock<DbSet<Answer>> mockDbSet;

        public AnswerCreateTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().Options;
            mockContext = new(options);
            mockDbSet = new();
        }

        public static IEnumerable<object[]> createTestData => new List<object[]>
        {
            new object[] { "FirstAnswer", (int?)null },
            new object[] { "SecondAnswer", 1 },
            new object[] { "ThirdAnswer", 1 },
        };

        [Theory]
        [MemberData(nameof(createTestData))]
        public async Task TestAnswerCreation(string name, int? id)
        {
            var mockCreateHandler = new Create.Handler(mockContext.Object);

            var mockCommand = new Create.Command
            {
                Answer = new Answer
                {
                    QuestionId = id,
                    Name = name
                }
            };

            mockContext.Setup(e => e.Answers).Returns(mockDbSet.Object);

            await mockCreateHandler.Handle(mockCommand, CancellationToken.None);

            mockDbSet.Verify(e => e.Add(It.IsAny<Answer>()), Times.Once());
            mockContext.Verify(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Theory]
        [InlineData("FirstAnswer")]
        [InlineData("SecondAnswer")]
        [InlineData("ThirdAnswer")]
        public async Task TestCreatedAnswerFieldCorrect(string name)
        {
            var mockCreateHandler = new Create.Handler(mockContext.Object);
            var mockCommand = new Create.Command
            {
                Answer = new Answer
                {
                    Name = name
                }
            };

            mockContext.Setup(e => e.Answers).Returns(mockDbSet.Object);

            await mockCreateHandler.Handle(mockCommand, CancellationToken.None);

            mockDbSet.Verify(e => e.Add(It.Is<Answer>(c => c.Name == name)), Times.Once());
            mockContext.Verify(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task TestAnswerCreationFailDueToBadData()
        {
            var mockCreateHandler = new Create.Handler(mockContext.Object);
            var mockCommand = new Create.Command
            {
                Answer = new Answer
                {
                    Name = null
                }
            };

            mockContext.Setup(e => e.Answers).Returns(mockDbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await mockCreateHandler.Handle(mockCommand, CancellationToken.None));
            Assert.Equal("Answer must have name", exception.Message);
        }
    }
}
