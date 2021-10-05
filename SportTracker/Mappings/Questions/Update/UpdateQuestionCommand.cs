using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Questions.Update
{
    public class UpdateQuestionCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? QuestionNumber { get; set; }
    }
}
