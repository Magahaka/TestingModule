using SportTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.SportPlans
{
    public class PlanWorkoutViewModel
    {
        public int Id { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public string Description { get; set; }
        public double PlannedDistance { get; set; }
        public int PlanId { get; set; }
    }
}
