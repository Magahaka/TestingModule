using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Questions.Create
{
    public class CreateQuestionCommand
    {
        public string Name { get; set; }
        public int QuestionnaireId { get; set; }
        public int? QuestionNumber { get; set; }
        public int? AnswerId { get; set; }
        public int Depth { get; set; }
    }
}
