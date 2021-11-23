using Microsoft.AspNetCore.Identity;
using SportTracker.Models;

namespace SportTracker.Areas.Identity.Data
{
    public class AspNetUser : IdentityUser
    {
        public int? SportPlanId { get; set; }
        public SportPlan SportPlan { get; set; }
        public string DisplayName { get; set; }
    }
}
