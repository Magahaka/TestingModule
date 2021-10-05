using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Answers.Update
{
    public class UpdateAnswerCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Points { get; set; }
    }
}
