using AutoMapper;
using SportTracker.Models;

namespace SportTracker.Mappings.Workouts
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutViewModel>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(pDTO => pDTO.StartDateTime, opt => opt.MapFrom(e => e.StartDateTime))
                .ForMember(pDTO => pDTO.EndDateTime, opt => opt.MapFrom(e => e.EndDateTime))
                .ForMember(pDTO => pDTO.Duration, opt => opt.MapFrom(e => e.Duration))
                .ForMember(pDTO => pDTO.AverageHeartRate, opt => opt.MapFrom(e => e.AverageHeartRate))
                .ForMember(pDTO => pDTO.AverageSpeed, opt => opt.MapFrom(e => e.AverageSpeed))
                .ForMember(pDTO => pDTO.BurnedCalories, opt => opt.MapFrom(e => e.BurnedCalories))
                .ForMember(pDTO => pDTO.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(pDTO => pDTO.Distance, opt => opt.MapFrom(e => e.Distance))
                .ForMember(pDTO => pDTO.UserId, opt => opt.MapFrom(e => e.UserId));
        }
    }
}
