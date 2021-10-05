using AutoMapper;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.SportPlans
{
    public class SportPlanProfile : Profile
    {
        public SportPlanProfile()
        {
            CreateMap<SportPlan, SportPlanViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(pDTO => pDTO.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(pDTO => pDTO.DifficultyLevel, opt => opt.MapFrom(e => e.DifficultyLevel))
                .ForMember(pDTO => pDTO.Gender, opt => opt.MapFrom(e => e.Gender))
                .ForMember(pDTO => pDTO.CaloriesPerWeek, opt => opt.MapFrom(e => e.CaloriesPerWeek))
                .ForMember(pDTO => pDTO.SportZones, opt => opt.MapFrom(e => e.SportZones))
                .ForMember(pDTO => pDTO.NumberOfSportsDays, opt => opt.MapFrom(e => e.NumberOfSportsDays))
                .ForMember(pDTO => pDTO.PlanWorkouts, opt => opt.MapFrom(e => e.PlanWorkouts.Any() ? 
                e.PlanWorkouts.Select(u => new PlanWorkoutViewModel
                {
                    Id = u.Id,
                    WeekDay = u.WeekDay,
                    Description = u.Description,
                    PlannedDistance = u.PlannedDistance,
                    PlanId = u.PlanId
                }) : null));
        }                
    }
}
