using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoftwareInstallationBusinessLogic.BusinessLogic;
using SoftwareInstallationBusinessLogic.HelperModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationDatabaseImplement.Implementations;
using System;
using System.Threading;

namespace SoftwareInstallationRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IPackageStorage, PackageStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<OrderLogic>();
            services.AddTransient<ClientLogic>();
            services.AddTransient<PackageLogic>();
            services.AddTransient<MailLogic>();
            services.AddControllers().AddNewtonsoftJson();

            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = Configuration["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(Configuration["SmtpClientPort"]),
                MailLogin = Configuration["MailLogin"],
                MailPassword = Configuration["MailPassword"],
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var timer = new Timer(new TimerCallback(MailCheck), new MailCheckInfo
            {
                PopHost = Configuration["PopHost"],
                PopPort = Convert.ToInt32(Configuration["PopPort"]),
                Storage = new MessageInfoStorage(),
                ClientStorage = new ClientStorage()
            }, 0, 100000);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }
    }
}