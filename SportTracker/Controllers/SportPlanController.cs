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
    public class SportPlanController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SportPlanController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<SportPlanViewModel> GetOrder(int id)
        {
            var dto = _mapper.Map<SportPlanViewModel>(await _context.SportPlans.FirstOrDefaultAsync(e => e.Id == id));

            return dto;
        }

        [HttpGet]
        public async Task<SportPlanListViewModel> GetAll()
        {
            var model = new SportPlanListViewModel
            {
                SportPlans = _mapper.Map<List<SportPlanViewModel>>(_context.SportPlans)
            };
            return model;
        }


    }
}
