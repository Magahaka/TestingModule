using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Models
{
    public class AnswerQuestion
    {
        public int Id { get; set; }
        public int? AnswerId { get; set; }
        public int? QuestionId { get; set; }
        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
}
