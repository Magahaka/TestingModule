using System;

namespace SportTracker.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public double? Duration { get; set; }
        public double? AverageHeartRate { get; set; }
        public double? AverageSpeed { get; set; }
        public double? BurnedCalories { get; set; }
        public string Description { get; set; }
        public double? Distance { get; set; }
        public string UserId { get; set; }
    }
}
