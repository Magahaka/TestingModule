using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Answers.Create
{
    public class CreateAnswerCommand
    {
        public string Name { get; set; }
        public int QuestionId { get; set; }
        public int QuestionnaireId { get; set; }
        public double Points { get; set; }
    }
}
