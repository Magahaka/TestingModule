using AutoMapper;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.SportPlans
{
    public class PlanWorkoutProfile : Profile
    {
        public PlanWorkoutProfile()
        {
            CreateMap<PlanWorkout, PlanWorkoutViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.WeekDay, opt => opt.MapFrom(e => e.WeekDay))
                .ForMember(pDTO => pDTO.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(pDTO => pDTO.PlannedDistance, opt => opt.MapFrom(e => e.PlannedDistance))
                .ForMember(pDTO => pDTO.PlanId, opt => opt.MapFrom(e => e.PlanId));                
        }      
    }
}
