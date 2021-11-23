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
    public class WorkoutCreateTest
    {
        private readonly Mock<DbSet<Workout>> dbSet;
        private readonly Mock<AppDbContext> context;
        private readonly CreateWorkout.Handler handler;

        public WorkoutCreateTest()
        {
            dbSet = new Mock<DbSet<Workout>>();
            var options = new DbContextOptionsBuilder<AppDbContext>().Options;
            context = new Mock<AppDbContext>(options);
            handler = new CreateWorkout.Handler(context.Object);
        }

        [Fact]
        public async Task CanCreateWorkout()
        {
            var command = new CreateWorkout.Command
            {
                Workout = new Workout
                {
                    Id = 1,
                    Name = "Workout",
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now,
                    UserId = new string("108654"),
                    Description = "Just a comment"
                }
            };

            context.Setup(e => e.Workouts).Returns(dbSet.Object);

            await handler.Handle(command, new CancellationToken());

            dbSet.Verify(m => m.Add(It.IsAny<Workout>()), Times.Once());
            context.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task CantCreateWorkoutWithoutName()
        {
            var command = new CreateWorkout.Command
            {
                Workout = new Workout
                {
                    Id = 1,
                    Name = string.Empty,
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now,
                    UserId = new string("108654"),
                    Description = "Just a comment"
                }
            };

            context.Setup(e => e.Workouts).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Workout must have a name", exception.Message);
        }

        [Fact]
        public async Task CantCreateWorkoutWithoutDescription()
        {
            var command = new CreateWorkout.Command
            {
                Workout = new Workout
                {
                    Id = 1,
                    Name = "Workout",
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now,
                    UserId = new string("108654"),
                    Description = string.Empty
                }
            };

            context.Setup(e => e.Workouts).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Workout must have a description", exception.Message);
        }

        [Fact]
        public async Task CantImportWorkoutWithoutStartDateTime()
        {
            var command = new CreateWorkout.Command
            {
                Workout = new Workout
                {
                    Id = 1,
                    Name = "Workout",
                    StartDateTime = null,
                    EndDateTime = DateTime.Now,
                    UserId = new string("108654"),
                    Description = "Just a comment"
                }
            };

            context.Setup(e => e.Workouts).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Workout must have start date time", exception.Message);
        }

        [Fact]
        public async Task CantImportWorkoutWithoutEndDateTime()
        {
            var command = new CreateWorkout.Command
            {
                Workout = new Workout
                {
                    Id = 1,
                    Name = "Workout",
                    StartDateTime = DateTime.Now,
                    EndDateTime = null,
                    UserId = new string("108654"),
                    Description = "Just a comment"
                }
            };

            context.Setup(e => e.Workouts).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Workout must have end date time", exception.Message);
        }

        [Fact]
        public async Task CantImportWorkoutWithoutUserId()
        {
            var command = new CreateWorkout.Command
            {
                Workout = new Workout
                {
                    Id = 1,
                    Name = "Workout",
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now,
                    UserId = null,
                    Description = "Just a comment"
                }
            };

            context.Setup(e => e.Workouts).Returns(dbSet.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal("Workout must have user id", exception.Message);
        }
    }
}
