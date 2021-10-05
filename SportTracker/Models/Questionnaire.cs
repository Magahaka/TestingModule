using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTracker.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ICollection<QuestionnaireQuestion> QuestionnaireQuestions  { get; set; }
    }
}
