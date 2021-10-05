using Newtonsoft.Json;
using SistemuPagrindai.Helpers;
using SportTracker.Mappings.Questions;
using SportTracker.Mappings.Questions.Create;
using SportTracker.Mappings.Questions.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportTracker.Services
{
    public class QuestionService
    {
        private readonly HttpClient client;
        private string baseUrl;

        public QuestionService(HttpClient client)
        {
            this.client = client;
            baseUrl = "https://localhost:44371/";
        }

        public async Task<QuestionListViewModel> GetQuestionsAsync(int? questionnaireId, int? answerId)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Questions?questionnaireId={questionnaireId}&answerId={answerId}");
            return JsonConvert.DeserializeObject<QuestionListViewModel>(json);
        }

        public async Task<QuestionViewModel> GetQuestionAsync(int id)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Questions/{id}");
            return JsonConvert.DeserializeObject<QuestionViewModel>(json);
        }

        public async Task<int> InsertQuestionAsync(CreateQuestionCommand command)
        {
            try
            {
                var result = await client.PostAsync($"{baseUrl}api/Questions/", RequestHelper.GetStringContentFromObject(command));
                return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception w)
            {
                return 0;
            }
            
        }

        public async Task<int> UpdateQuestionAsync(UpdateQuestionCommand command)
        {
            try
            {
                var result = await client.PutAsync($"{baseUrl}api/Questions/", RequestHelper.GetStringContentFromObject(command));
                return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                return 0;
            }
            
        }

        public async Task<HttpResponseMessage> DeleteQuestionAsync(int id)
        {
            return await client.DeleteAsync($"{baseUrl}api/Questions/{id}");
        }
    }
}
