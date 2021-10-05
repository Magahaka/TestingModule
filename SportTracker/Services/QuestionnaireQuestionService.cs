using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SportTracker.Mappings.QuestionnaireQuestion;

namespace SportTracker.Services
{
    public class QuestionnaireQuestionService
    {
        private readonly HttpClient client;
        private string baseUrl;

        public QuestionnaireQuestionService(HttpClient client)
        {
            this.client = client;
            baseUrl = "https://localhost:44371/";
        }

        public async Task<QuestionnaireQuestionListViewModel> GetQuestionnaireQuestionsAsync(int userId)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/QuestionnaireQuestion?userId={userId}");
            return JsonConvert.DeserializeObject<QuestionnaireQuestionListViewModel>(json);
        }

        public async Task<QuestionnaireQuestionViewModel> GetQuestionnaireQuestionAsync(int id)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/QuestionnaireQuestion/{id}");
            return JsonConvert.DeserializeObject<QuestionnaireQuestionViewModel>(json);
        }
    }
}
