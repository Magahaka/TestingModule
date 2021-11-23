using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SportTracker.Controllers;
using SportTracker.Data;
using SportTracker.Mappings.Answers;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static SportTracker.Controllers.List;

namespace Tests.AnswerTests
{
    public class AnswerListTest
    {
        private Mock<AppDbContext> mockContext;
        private Mock<DbSet<Answer>> mockDbSet;

        public AnswerListTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().Options;
            mockContext = new(options);
            mockDbSet = new();
        }

        [Fact]
        public async Task TestCategoryList()
        {
            List<Answer> list = new()
            {
                new Answer() { Name = "First" },
                new Answer() { Name = "Second" },
                new Answer() { Name = "Third" }
            };

            mockDbSet = list.AsQueryable().BuildMockDbSet();
            mockContext.Setup(e => e.Answers).Returns(mockDbSet.Object);

            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<Answer, AnswerViewModel>(It.IsAny<Answer>()))
                .Returns(new AnswerViewModel());

            var listHandler = new List.Handler(mockContext.Object, mapper.Object);

            var result = listHandler.Handle(new Query(), CancellationToken.None);

            mockContext.Verify(c => c.Answers, Times.Once);
            Assert.Equal(list.Count, mockContext.Object.Answers.Count());

        }
    }
}
