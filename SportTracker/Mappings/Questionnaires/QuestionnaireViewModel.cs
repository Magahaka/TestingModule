using SportTracker.Mappings.QuestionnaireQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Mappings.Questionnaires
{
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public List<QuestionnaireQuestionViewModel> Questions { get; set; }
    }
}
