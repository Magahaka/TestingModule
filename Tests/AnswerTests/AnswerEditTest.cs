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
    public class AnswerEditTest
    {
        private readonly Mock<AppDbContext> mockContext;
        private readonly Mock<DbSet<Answer>> mockDbSet;

        public AnswerEditTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().Options;
            mockContext = new(options);
            mockDbSet = new();
        }

        [Fact]
        public async Task TestCategoryEdit()
        {
            var answer = new Answer { Name = "AAA" };

            mockContext.Setup(e => e.Answers).Returns(mockDbSet.Object);
            mockDbSet.Setup(e => e.FindAsync(answer.Id).Result).Returns(answer);

            var editHandler = new Edit.Handler(mockContext.Object);
            var command = new Edit.Command
            {
                Answer = answer
            };

            await editHandler.Handle(command, CancellationToken.None);

            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task TestCategoryEditFailDueToBadData()
        {
            var mockEditHandler = new Edit.Handler(mockContext.Object);
            var mockCommand = new Edit.Command
            {
                Answer = new Answer
                {
                    Name = null
                }
            };

            mockContext.Setup(e => e.Answers).Returns(mockDbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await mockEditHandler.Handle(mockCommand, CancellationToken.None));
            Assert.Equal("Answer must have a name", exception.Message);
        }
    }
}
