using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemuPagrindai.Helpers;
using SportTracker.Data;
using SportTracker.Mappings.Questionnaires;
using SportTracker.Mappings.Questionnaires.Create;
using SportTracker.Mappings.Questionnaires.Update;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnairesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuestionnairesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<QuestionnaireListViewModel> GetAll(string userId, bool? getAll)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var model = new QuestionnaireListViewModel
                {
                    Questionnaires = _mapper.Map<List<QuestionnaireViewModel>>(_context.Questionnaires.Where(e => e.UserId == userId))
                };

                return model;
            }
            else if (getAll.HasValue && getAll.Value)
            {
                var model = new QuestionnaireListViewModel
                {
                    Questionnaires = _mapper.Map<List<QuestionnaireViewModel>>(_context.Questionnaires)
                };

                return model;
            }
            else 
            {
                return new QuestionnaireListViewModel();
            }
        }

        [HttpGet("{id}")]
        public async Task<QuestionnaireViewModel> GetOrder(int id)
        {
            var dto = _mapper.Map<QuestionnaireViewModel>(await _context.Questionnaires.Include(e => e.QuestionnaireQuestions)
                                                                                            .ThenInclude(e => e.Question)
                                                                                                .ThenInclude(e => e.Answers)
                                                                                                    .ThenInclude(e => e.AnswerQuestions)
                                                                                                        .ThenInclude(e => e.Question)
                                                                                                            .ThenInclude(e => e.Answers).FirstOrDefaultAsync(e => e.Id == id));

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateQuestionnaireCommand command)
        {
            var questionnaire = new Questionnaire
            {
                Name = command.Name,
                UserId = command.UserId
            };

            _context.Questionnaires.Add(questionnaire);

            await _context.SaveChangesAsync();

            return questionnaire.Id;
            //if (!string.IsNullOrEmpty(command.Name))
            //{
            //    var questionnaire = new Questionnaire
            //    {
            //        Name = command.Name,
            //        UserId = command.UserId
            //    };

            //    _context.Questionnaires.Add(questionnaire);
            //    await _context.SaveChangesAsync();

            //    if (command.list != null && command.list.Any())
            //    {
            //        int answerOneId = 0;
            //        int answerTwoId = 0;
            //        int answerQuestionOneId = 0;
            //        int answerQuestionTwoId = 0;
            //        int counter = 0;
            //        foreach (var item in command.list)
            //        {
            //            var question = new Question
            //            {
            //                Name = item.Question
            //            };

            //            _context.Questions.Add(question);
            //            await _context.SaveChangesAsync();

            //            var questionnaireQuestion = new QuestionnaireQuestion
            //            {
            //                QuestionId = question.Id,
            //                QuestionnaireId = questionnaire.Id,
            //                QuestionNumber = item.QuestionNr
            //            };

            //            _context.QuestionnaireQuestions.Add(questionnaireQuestion);
            //            await _context.SaveChangesAsync();

            //            if (answerQuestionOneId != 0 && answerOneId != 0)
            //            {
            //                var answerQuestionOne = new AnswerQuestion
            //                {
            //                    AnswerId = answerOneId,
            //                    QuestionId = answerQuestionOneId
            //                };

            //                _context.AnswerQuestions.Add(answerQuestionOne);
            //                await _context.SaveChangesAsync();
            //            }

            //            var answerOne = new Answer
            //            {
            //                Name = item.AnswerOne,
            //                QuestionId = question.Id
            //            };

            //            _context.Answers.Add(answerOne);

            //            if (answerQuestionTwoId != 0 && answerTwoId != 0)
            //            {
            //                var answerQuestionOne = new AnswerQuestion
            //                {
            //                    AnswerId = answerTwoId,
            //                    QuestionId = answerQuestionTwoId
            //                };

            //                _context.AnswerQuestions.Add(answerQuestionOne);
            //                await _context.SaveChangesAsync();
            //            }

            //            var answerTwo = new Answer
            //            {
            //                Name = item.AnswerTwo,
            //                QuestionId = question.Id
            //            };

            //            _context.Answers.Add(answerTwo);
            //            await _context.SaveChangesAsync();
            //        }
            //    }

            //    return Ok(0);
            //}
            //else
            //{
            //    return 0;
            //}
        }

        //public void CreateQuestionsAndAnswersRecursively(List<CreateQuestionnaireCommand> list, int questionnaireId, int counter)
        //{

        //    var question = new Question
        //    {
        //        Name = list[counter].
        //    };
        //}

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<int> Put([FromBody] UpdateQuestionnaireCommand command)
        {
            var entity = await _context.Questionnaires.FirstOrDefaultAsync(e => e.Id == command.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Workout), command.Id);
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
            var result = await _context.Questionnaires.FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
