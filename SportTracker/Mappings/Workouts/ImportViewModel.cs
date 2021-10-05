using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Workouts
{
    public class ImportViewModel
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double Duration { get; set; }
        public double TotalDistance { get; set; }
        public double AverageHeartRate { get; set; }
        public double AverageSpeed { get; set; }
        public double MaxSpeed { get; set; }
        //public double AveragePace { get; set; }
        //public double MaxPace { get; set; }
        public double Calories { get; set; }
        public double TrainingLoad { get; set; }
        public double Ascent { get; set; }
        public double Descent { get; set; }
        public string Description { get; set; }
    }
}
