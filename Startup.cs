using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using Test_Shop1.Services;

namespace Test_Shop1
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
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                    new CultureInfo("en"),
                    new CultureInfo("en-US"),
                    //new CultureInfo("de"),
                    //new CultureInfo("fr"),
                    //new CultureInfo("es"),
                    new CultureInfo("es-US"),
                    new CultureInfo("es-PR"),
                    new CultureInfo("es-DO"),
                    //new CultureInfo("ru"),
                    //new CultureInfo("ja"),
                    //new CultureInfo("ar"),
                    //new CultureInfo("zh"),
                    //new CultureInfo("en-GB")
                };
                options.DefaultRequestCulture = new RequestCulture("es-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddSingleton<CommonLocalizationService>();


            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllers();
            services.AddMvc().AddViewLocalization();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller}/{action=Index}");
                endpoints.MapControllers();
            });
        }
    }
}
