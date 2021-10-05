using SportTracker.Mappings.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.QuestionnaireQuestion
{
    public class QuestionnaireQuestionViewModel
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public int? QuestionnaireId { get; set; }
        public int? QuestionNumber { get; set; }
        public int? QuestionnaireAnswerId { get; set; }
        public string Question { get; set; }
        public int Depth { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
