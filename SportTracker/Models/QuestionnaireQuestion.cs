using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Models
{
    public class QuestionnaireQuestion
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public int? QuestionnaireId { get; set; }
        public int? QuestionNumber { get; set; }
        public int? QuestionnaireAnswerId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public Question Question { get; set; }
    }
}
