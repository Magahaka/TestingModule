using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.AnswerQuestion
{
    public class AnswerQuestionProfile : Profile
    {
        public AnswerQuestionProfile()
        {
            CreateMap<Models.AnswerQuestion, AnswerQuestionViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.AnswerId, opt => opt.MapFrom(e => e.AnswerId))
                .ForMember(pDTO => pDTO.QuestionId, opt => opt.MapFrom(e => e.QuestionId));
        }
    }
}
