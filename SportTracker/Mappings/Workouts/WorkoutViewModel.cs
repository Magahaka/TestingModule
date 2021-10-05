using System;
using System.ComponentModel.DataAnnotations;

namespace SportTracker.Mappings.Workouts
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Workout name has to be shorter than 50 words")]
        public string Name { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public double? Duration { get; set; }

        [Range(30, 250, ErrorMessage = "Display Heart Rate between 30 - 250")]
        public double? AverageHeartRate { get; set; }
        [Range(0, 80, ErrorMessage = "Display Average speed between 0 - 80")]
        public double? AverageSpeed { get; set; }
        [Range(0, 10000, ErrorMessage = "Display Average speed between 0 - 10000")]
        public double? BurnedCalories { get; set; }
        public string Description { get; set; }
        public double? Distance { get; set; }
        public string UserId { get; set; }
    }
}
