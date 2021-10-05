using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportTracker.Data;
using SportTracker.Mappings.QuestionnaireQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireQuestionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuestionnaireQuestionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<QuestionnaireQuestionListViewModel> GetAll(string userId, bool? getAll)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var model = new QuestionnaireQuestionListViewModel
                {
                    QuestionareQuestions = _mapper.Map<List<QuestionnaireQuestionViewModel>>(_context.Questionnaires.Where(e => e.UserId == userId))
                };

                return model;
            }
            else if (getAll.HasValue && getAll.Value)
            {
                var model = new QuestionnaireQuestionListViewModel
                {
                    QuestionareQuestions = _mapper.Map<List<QuestionnaireQuestionViewModel>>(_context.Questionnaires)
                };

                return model;
            }
            else
            {
                return new QuestionnaireQuestionListViewModel();
            }
        }

        [HttpGet("{id}")]
        public async Task<QuestionnaireQuestionViewModel> GetOrder(int id)
        {
            var dto = _mapper.Map<QuestionnaireQuestionViewModel>(await _context.QuestionnaireQuestions.FirstOrDefaultAsync(e => e.Id == id));

            return dto;
        }
    }
}
