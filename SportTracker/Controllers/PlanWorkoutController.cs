using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemuPagrindai.Helpers;
using SportTracker.Data;
using SportTracker.Mappings.SportPlans;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SportTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanWorkoutController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PlanWorkoutController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PlanWorkoutListViewModel> GetAll(int planId)
        {
            var model = new PlanWorkoutListViewModel
            {
                PlanWorkouts = _mapper.Map<List<PlanWorkoutViewModel>>(_context.PlanWorkouts.Where(e => e.PlanId == planId))
            };

            return model;
        }

        [HttpGet("{id}")]
        public async Task<PlanWorkoutViewModel> GetOrder(int id)
        {
            var dto = _mapper.Map<PlanWorkoutViewModel>(await _context.Workouts.FirstOrDefaultAsync(e => e.Id == id));

            return dto;
        }

    }
}
