using SportTracker.Areas.Identity.Data;
using SportTracker.Helpers.Enums;
using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.SportPlans
{
    public class SportPlanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public int Gender { get; set; }
        public int CaloriesPerWeek { get; set; }
        public SportZoneEnum SportZones { get; set; }
        public int NumberOfSportsDays { get; set; }
        public ICollection<PlanWorkout> PlanWorkouts { get; set; }
        public ICollection<AspNetUser> Users { get; set; }
    }
}
