using Newtonsoft.Json;
using SportTracker.Mappings.SportPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportTracker.Services
{
    public class SportPlanService
    {
        private readonly HttpClient client;
        private string baseUrl;

        public SportPlanService(HttpClient client)
        {
            this.client = client;
            baseUrl = "https://localhost:44371/";
        }

        public async Task<SportPlanListViewModel> GetPlansAsync()
        {
            var json = await client.GetStringAsync($"{baseUrl}api/SportPlan");
            return JsonConvert.DeserializeObject<SportPlanListViewModel>(json);
        }

        public async Task<SportPlanViewModel> GetPlanAsync(int planId)
        {
            try
            {
                var json = await client.GetStringAsync($"{baseUrl}api/SportPlan/{planId}");
                return JsonConvert.DeserializeObject<SportPlanViewModel>(json);
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
