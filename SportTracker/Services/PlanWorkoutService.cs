using Newtonsoft.Json;
using SistemuPagrindai.Helpers;
using SportTracker.Mappings.SportPlans;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportTracker.Services
{
    public class PlanWorkoutService
    {
        private readonly HttpClient client;
        private string baseUrl;

        public PlanWorkoutService(HttpClient client)
        {
            this.client = client;
            baseUrl = "https://localhost:44371/";
        }

        public async Task<PlanWorkoutListViewModel> GetPlanWorkoutsAsync(int planId)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/PlanWorkout?planId={planId}");
            return JsonConvert.DeserializeObject<PlanWorkoutListViewModel>(json);
        }

        public async Task<PlanWorkoutViewModel> GetPlanWorkoutAsync(int id)
        {
            var json = await client.GetStringAsync($"{baseUrl}api/PlanWorkout/{id}");
            return JsonConvert.DeserializeObject<PlanWorkoutViewModel>(json);
        }
    }
}
