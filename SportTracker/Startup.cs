using AutoMapper;
using Blazored.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemuPagrindai.Services.EmailService;
using SportTracker.Areas.Identity.Data;
using SportTracker.Data;
using SportTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using NETCore.MailKit.Core;

namespace SportTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AppDbContextConnection")));
            services.AddIdentity<AspNetUser, IdentityRole>(e =>
            {
                e.Password.RequireUppercase = false;
                e.Password.RequiredUniqueChars = 0;
                e.Password.RequiredLength = 6;
                e.Password.RequireNonAlphanumeric = false;

                e.User.RequireUniqueEmail = true;

                e.SignIn.RequireConfirmedEmail = true;
                e.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddHttpContextAccessor();
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton<HttpClient>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddSingleton<WorkoutService>();
            services.AddSingleton<PlanWorkoutService>();
            services.AddSingleton<SportPlanService>();
            services.AddSingleton<QuestionnaireService>();
            services.AddSingleton<QuestionService>();
            services.AddSingleton<QuestionnaireQuestionService>();
            services.AddSingleton<AnswerService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddBlazoredModal();
            services.AddMailKit(Configure => Configuration.GetSection("email").Get<MailKitOptions>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
