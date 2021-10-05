using Newtonsoft.Json;
using SistemuPagrindai.Helpers;
using SportTracker.Mappings.Workouts;
using SportTracker.Mappings.Workouts.Create;
using SportTracker.Mappings.Workouts.Update;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportTracker.Services
{
    public class WorkoutService
    {
        private readonly HttpClient client;
        private string baseUrl;

        public WorkoutService(HttpClient client)
        {
            this.client = client;
            baseUrl = "https://localhost:44371/";
        }

        public async Task<WorkoutListViewModel> GetWorkoutsAsync(string userId)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Workouts?userId={userId}");
            return JsonConvert.DeserializeObject<WorkoutListViewModel>(json);
        }

        public async Task<WorkoutViewModel> GetWorkoutAsync(int id)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/Workouts/{id}");
            return JsonConvert.DeserializeObject<WorkoutViewModel>(json);
        }

        public async Task<int> InsertWorkoutAsync(CreateWorkoutCommand command)
        {
            var result = await client.PostAsync($"{baseUrl}api/Workouts/", RequestHelper.GetStringContentFromObject(command));
            return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<int> UpdateWorkoutAsync(UpdateWorkoutCommand command)
        {
            var result = await client.PutAsync($"{baseUrl}api/Workouts/", RequestHelper.GetStringContentFromObject(command));
            return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<HttpResponseMessage> DeleteWorkoutAsync(int id)
        {
            return await client.DeleteAsync($"{baseUrl}api/Workouts/{id}");
        }
    }
}
