using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Depth { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public ICollection<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
