using Newtonsoft.Json;
using SistemuPagrindai.Helpers;
using SportTracker.Mappings.Questionnaires;
using SportTracker.Mappings.Questionnaires.Create;
using SportTracker.Mappings.Questionnaires.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportTracker.Services
{
    public class QuestionnaireService
    {
        private readonly HttpClient client;
        private string baseUrl;

        public QuestionnaireService(HttpClient client)
        {
            this.client = client;
            baseUrl = "https://localhost:44371/";
        }

        public async Task<QuestionnaireListViewModel> GetQuestionnairesAsync(string userId, bool getAll)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Questionnaires?userId={userId}&getAll={getAll}");
            return JsonConvert.DeserializeObject<QuestionnaireListViewModel>(json);
        }

        public async Task<QuestionnaireViewModel> GetQuestionnaireAsync(int id)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Questionnaires/{id}");
            return JsonConvert.DeserializeObject<QuestionnaireViewModel>(json);
        }

        public async Task<int> InsertQuestionnaireAsync(CreateQuestionnaireCommand command)
        {
            var result = await client.PostAsync($"{baseUrl}api/Questionnaires/", RequestHelper.GetStringContentFromObject(command));
            return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<int> UpdateQuestionnaireAsync(UpdateQuestionnaireCommand command)
        {
            var result = await client.PutAsync($"{baseUrl}api/Questionnaires/", RequestHelper.GetStringContentFromObject(command));
            return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<HttpResponseMessage> DeleteQuestionnaireAsync(int id)
        {
            return await client.DeleteAsync($"{baseUrl}api/Questionnaires/{id}");
        }
    }
}
