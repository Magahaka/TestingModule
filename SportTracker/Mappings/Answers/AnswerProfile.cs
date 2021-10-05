using AutoMapper;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Answers
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(pDTO => pDTO.Points, opt => opt.MapFrom(e => e.Points));
        }
    }
}
