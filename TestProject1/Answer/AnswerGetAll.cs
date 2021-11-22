using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportTracker.Controllers;
using System.Net.Http;
using Moq;
using SportTracker.Data;
using AutoMapper;
using SportTracker.Services;
using SportTracker.Mappings.Answers;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Xunit;

namespace TestProject1.Answer
{
    [TestClass]
    public class AnswerGetAll
    {
        private readonly IMapper _mapper;

        [Fact]
        public async Task GetOne()
        {
            //var mock = new Mock<AnswerService>();
            //mock.Setup(e => e.GetAnswerAsync(1)).Returns(Task.FromResult(new AnswerViewModel { })) ;
            using (var m = AutoMock.GetLoose()) 
            {
                var mock = m.Create<AnswerService>();
                var expected = lempa();
                var actual = await mock.GetAnswerAsync(1);

                Xunit.Assert.Equal(expected.Name, actual.Name);
            }
        }

        [Fact]
        public async Task GetOne2()
        {
            //var mock = new Mock<AnswerService>();
            //mock.Setup(e => e.GetAnswerAsync(1)).Returns(Task.FromResult(new AnswerViewModel { })) ;
            using (var m = AutoMock.GetLoose())
            {
                var mock = m.Create<AnswerService>();
                var expected = lempa();
                var actual = await mock.GetAnswerAsync(2);

                Xunit.Assert.Equal(actual.Name, null);
            }
        }
        private AnswerViewModel lempa()
        {
            return new AnswerViewModel { Id = 1, Name = "a1", QuestionId = 1, Question = "q1", Points = 1 };
               
        }
    }
}
