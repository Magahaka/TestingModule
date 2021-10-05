using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Questionnaires.Update
{
    public class UpdateQuestionnaireCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
