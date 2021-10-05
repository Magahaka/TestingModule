using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTracker.Models;

namespace SportTracker.Mappings.QuestionnaireQuestion
{
    public class QuestionnaireQuestionProfile : Profile
    {
        public QuestionnaireQuestionProfile()
        {
            CreateMap<SportTracker.Models.QuestionnaireQuestion, QuestionnaireQuestionViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.QuestionId, opt => opt.MapFrom(e => e.QuestionId))
                .ForMember(pDTO => pDTO.QuestionnaireId, opt => opt.MapFrom(e => e.QuestionnaireId))
                .ForMember(pDTO => pDTO.QuestionNumber, opt => opt.MapFrom(e => e.QuestionNumber))
                .ForMember(pDTO => pDTO.QuestionnaireAnswerId, opt => opt.MapFrom(e => e.QuestionnaireAnswerId));
        }
    }
}
