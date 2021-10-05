using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemuPagrindai.Helpers;
using SportTracker.Data;
using SportTracker.Mappings.Workouts;
using SportTracker.Mappings.Workouts.Create;
using SportTracker.Mappings.Workouts.Update;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public WorkoutsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<WorkoutListViewModel> GetAll(string userId)
        {
            var model = new WorkoutListViewModel
            {
                Workouts = _mapper.Map<List<WorkoutViewModel>>(_context.Workouts.Where(e => e.UserId == userId))
            };

            return model;
        }

        [HttpGet("{id}")]
        public async Task<WorkoutViewModel> GetOrder(int id)
        {
            var dto = _mapper.Map<WorkoutViewModel>(await _context.Workouts.FirstOrDefaultAsync(e => e.Id == id));

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateWorkoutCommand command)
        {
            var entity = new Workout
            {
                Name = command.Name,
                StartDateTime = command.StartDateTime,
                EndDateTime = command.EndDateTime,
                Duration = command.Duration,
                AverageHeartRate = command.AverageHeartRate,
                AverageSpeed = command.AverageSpeed,
                BurnedCalories = command.BurnedCalories,
                Description = command.Description,
                Distance = command.Distance,
                UserId = command.UserId
            };

            _context.Workouts.Add(entity);

            await _context.SaveChangesAsync();

            return Ok(entity.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<int> Put([FromBody] UpdateWorkoutCommand command)
        {
            var entity = await _context.Workouts.FirstOrDefaultAsync(e => e.Id == command.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Workout), command.Id);
            }

            entity.Name = command.Name;
            entity.StartDateTime = command.StartDateTime;
            entity.EndDateTime = command.EndDateTime;
            entity.Duration = command.Duration;
            entity.AverageHeartRate = command.AverageHeartRate;
            entity.AverageSpeed = command.AverageSpeed;
            entity.BurnedCalories = command.BurnedCalories;
            entity.Description = command.Description;
            entity.Distance = command.Distance;

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Workouts.FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
