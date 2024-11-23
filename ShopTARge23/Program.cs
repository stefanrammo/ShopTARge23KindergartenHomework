using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;

/*Teha api call OpenWeather api kohta.
Saata githubi link ja tunnis näitate ette.
Teha valmis uus api call. Samasugune nagu oli seda tunnis harjutatud AccuWeatheri oma, aga seekord teete OpenWeathermapi oma.
 
Siin asub koduleht:
https://api.openweathermap.org
Siit saab koodi abil ilmaennustuse teada:
https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}

Nõuded:
1.Valite Current Weather Data variandi.
2. Tuleb teha Teie olemasolevale projektile uus branch nimega OpenWeather
3. Ühendus teise API-ga tuleb luua Serviceclassis ja ühendada controlleriga ning controller omakorda vaatega.
4. Tulemus peab olema selline nagu on seda õppematerjalide all kujutatud pildil nimega OpenWeathermap
5. Kogu koodi ei või teha olemasoleva töötava Accuweatheri asemele.*/

namespace ShopTARge23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddScoped<IRealEstateServices, RealEstateServices>();
            builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
            builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
            builder.Services.AddScoped<IFreeToGamesServices, FreeToGamesServices>();
            builder.Services.AddScoped<IFreeToGamesServices, FreeToGamesServices>();
            builder.Services.AddScoped<ICocktailServices, CocktailServices>();
            builder.Services.AddScoped<IOpenWeatherServices, OpenWeatherServices>();


            builder.Services.AddDbContext<ShopTARge23Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider
                (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
                RequestPath = "/multipleFileUpload"
            });

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}
