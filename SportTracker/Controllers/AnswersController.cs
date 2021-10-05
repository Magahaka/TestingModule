using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemuPagrindai.Helpers;
using SportTracker.Data;
using SportTracker.Mappings.Answers;
using SportTracker.Mappings.Answers.Create;
using SportTracker.Mappings.Answers.Update;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AnswersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<AnswerListViewModel> GetAll(int questionId)
        {
            var model = new AnswerListViewModel
            {
                Answers = _mapper.Map<List<AnswerViewModel>>(_context.Answers.Where(e => e.QuestionId == questionId))
            };

            return model;
        }

        [HttpGet("{id}")]
        public async Task<AnswerViewModel> GetOne(int id)
        {
            var dto = _mapper.Map<AnswerViewModel>(await _context.Answers.FirstOrDefaultAsync(e => e.Id == id));

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateAnswerCommand command)
        {
            var answer = new Answer
            {
                Name = command.Name,
                QuestionId = command.QuestionId,
                Points = command.Points
            };

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return answer.Id;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<int> Put([FromBody] UpdateAnswerCommand command)
        {
            var entity = await _context.Answers.FirstOrDefaultAsync(e => e.Id == command.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Question), command.Id);
            }

            entity.Name = command.Name;
            entity.Points = command.Points;

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok();
        }
    }
}
