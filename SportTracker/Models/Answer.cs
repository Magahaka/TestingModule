using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? QuestionId { get; set; }
        public double Points { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
