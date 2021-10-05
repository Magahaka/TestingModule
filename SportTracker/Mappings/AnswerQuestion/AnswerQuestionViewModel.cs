using SportTracker.Mappings.Answers;
using SportTracker.Mappings.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.AnswerQuestion
{
    public class AnswerQuestionViewModel
    {
        public int Id { get; set; }
        public int? AnswerId { get; set; }
        public int? QuestionId { get; set; }
        public string Question { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
