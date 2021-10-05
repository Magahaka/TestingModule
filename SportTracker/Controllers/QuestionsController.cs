using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemuPagrindai.Helpers;
using SportTracker.Data;
using SportTracker.Mappings.Questions;
using SportTracker.Mappings.Questions.Create;
using SportTracker.Mappings.Questions.Update;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuestionsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<QuestionListViewModel> GetAll(int? questionnaireId, int? answerId)
        {
            if (questionnaireId.HasValue)
            {
                var model = new QuestionListViewModel
                {
                    Questions = _mapper.Map<List<QuestionViewModel>>(_context.Questions.Include(e => e.QuestionnaireQuestions)
                                                                                       .Include(e => e.AnswerQuestions)
                                                                                       .Where(e => e.QuestionnaireQuestions.Any(u => u.QuestionnaireId == questionnaireId && !e.AnswerQuestions.Any(x => x.QuestionId == u.QuestionId))))
                };

                return model;
            }
            else if (answerId.HasValue)
            {
                var model = new QuestionListViewModel
                {
                    Questions = _mapper.Map<List<QuestionViewModel>>(_context.Questions.Include(e => e.AnswerQuestions).Where(e => e.AnswerQuestions.Any(e => e.AnswerId == answerId)))
                };

                return model;
            }

            return null;
        }

        [HttpGet("{id}")]
        public async Task<QuestionViewModel> GetOrder(int id)
        {
            var dto = _mapper.Map<QuestionViewModel>(await _context.Questions.FirstOrDefaultAsync(e => e.Id == id));

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateQuestionCommand command)
        {
            if (command.AnswerId.HasValue)
            {
                var question = new Question
                {
                    Name = command.Name,
                    Depth = command.Depth
                };

                _context.Questions.Add(question);
                await _context.SaveChangesAsync();

                var answerQuestion = new AnswerQuestion
                {
                    AnswerId = command.AnswerId,
                    QuestionId = question.Id
                };

                _context.AnswerQuestions.Add(answerQuestion);
                await _context.SaveChangesAsync();

                var questionnaireQuestion = new QuestionnaireQuestion
                {
                    QuestionId = question.Id,
                    QuestionNumber = command.QuestionNumber,
                    QuestionnaireId = command.QuestionnaireId
                };

                _context.QuestionnaireQuestions.Add(questionnaireQuestion);
                await _context.SaveChangesAsync();

                return question.Id;
            }
            else
            {
                var question = new Question
                {
                    Name = command.Name,
                    Depth = command.Depth
                };

                _context.Questions.Add(question);
                await _context.SaveChangesAsync();

                var questionnaireQuestion = new QuestionnaireQuestion
                {
                    QuestionId = question.Id,
                    QuestionNumber = command.QuestionNumber,
                    QuestionnaireId = command.QuestionnaireId
                };

                _context.QuestionnaireQuestions.Add(questionnaireQuestion);
                await _context.SaveChangesAsync();

                return question.Id;
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<int> Put([FromBody] UpdateQuestionCommand command)
        {
            var entity = await _context.Questions.FirstOrDefaultAsync(e => e.Id == command.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Question), command.Id);
            }

            entity.Name = command.Name;

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            var questionnaireQuestions = await _context.QuestionnaireQuestions.Where(e => e.QuestionId == id).ToListAsync();

            if (questionnaireQuestions != null)
            {
                foreach (var item in questionnaireQuestions)
                {
                    _context.QuestionnaireQuestions.Remove(item);
                }

                await _context.SaveChangesAsync();
            }

            var result = await _context.Questions.FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _context.Questions.Remove(result);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
