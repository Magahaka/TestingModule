using Newtonsoft.Json;
using SistemuPagrindai.Helpers;
using SportTracker.Mappings.Answers;
using SportTracker.Mappings.Answers.Create;
using SportTracker.Mappings.Answers.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportTracker.Services
{
    public class AnswerService
    {
        private readonly HttpClient client;
        private string baseUrl;

        public AnswerService(HttpClient client)
        {
            this.client = client;
            baseUrl = "https://localhost:44371/";
        }

        public async Task<AnswerListViewModel> GetAnswersAsync(int questionId)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Answers?questionId={questionId}");
            return JsonConvert.DeserializeObject<AnswerListViewModel>(json);
        }

        public async Task<AnswerViewModel> GetAnswerAsync(int id)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Answers/{id}");
            return JsonConvert.DeserializeObject<AnswerViewModel>(json);
        }

        public async Task<int> InsertAnswerAsync(CreateAnswerCommand command)
        {
            try
            {
                var result = await client.PostAsync($"{baseUrl}api/Answers/", RequestHelper.GetStringContentFromObject(command));
                return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception w)
            {
                return 0;
            }

        }

        public async Task<int> UpdateAnswerAsync(UpdateAnswerCommand command)
        {
            try
            {
                var result = await client.PutAsync($"{baseUrl}api/Answers/", RequestHelper.GetStringContentFromObject(command));
                return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public async Task<HttpResponseMessage> DeleteAnswerAsync(int id)
        {
            return await client.DeleteAsync($"{baseUrl}api/Answers/{id}");
        }
    }
}
