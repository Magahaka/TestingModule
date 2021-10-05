using SportTracker.Mappings.AnswerQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Answers
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public double Points { get; set; }
        public List<AnswerQuestionViewModel> AnswerQuestions { get; set; }
    }
}
