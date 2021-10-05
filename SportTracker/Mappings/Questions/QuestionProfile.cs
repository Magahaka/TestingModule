using AutoMapper;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Questions
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(e => e.Name));
        }
    }
}
