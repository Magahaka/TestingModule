using AutoMapper;
using SportTracker.Mappings.QuestionnaireQuestion;
using SportTracker.Models;
using System.Linq;
using SportTracker.Mappings.Answers;

namespace SportTracker.Mappings.Questionnaires
{
    public class QuestionnaireProfile : Profile
    {
        public QuestionnaireProfile()
        {
            CreateMap<Questionnaire, QuestionnaireViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(p => p.UserId, opt => opt.MapFrom(e => e.UserId))
                .ForMember(pDTO => pDTO.Questions, opt => opt.MapFrom(e => e.QuestionnaireQuestions.Any() ? e.QuestionnaireQuestions.Select(x => new QuestionnaireQuestionViewModel()
                {
                    Id = x.Id,
                    QuestionId = x.QuestionId,
                    QuestionnaireAnswerId = x.QuestionnaireAnswerId,
                    QuestionnaireId = x.QuestionnaireId,
                    QuestionNumber = x.QuestionNumber,
                    Question = x.Question.Name,
                    Depth = x.Question.Depth,
                    Answers = x.Question.Answers != null ? x.Question.Answers.Select(y => new AnswerViewModel()
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Points = y.Points,
                        AnswerQuestions = y.AnswerQuestions != null ? y.AnswerQuestions.Select(e => new AnswerQuestion.AnswerQuestionViewModel() 
                        { 
                            AnswerId = e.AnswerId,
                            Id = e.Id,
                            QuestionId = e.QuestionId,
                            Question = e.Question.Name,
                            Answers = e.Question.Answers.Any() ? e.Question.Answers.Select(y => new AnswerViewModel()
                            {
                                Id = y.Id,
                                Name = y.Name,
                                Points = y.Points
                            }).ToList() : null
                        }).ToList() : null
                    }).ToList() : null
                }) : null));
        }
    }
}
