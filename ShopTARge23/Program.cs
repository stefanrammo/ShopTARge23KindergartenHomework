using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;

//Teha uus CRUD e lisamine, vataamine, uuendamine ja andmete kustutamine.
//Teha uus branch.
//Teemaks on Kindergarten.
//Muutujateks on Id, GroupName, ChildrenCount, KindergartenName, Teacher, CreatedAt ja UpdatedAt.
//NB! Piltide lisamist ei tee.
//T�� on hindeline. T�� panna githubi ja link saata emailile.
 
//�petus, kuidas teha uut branchi:
//https://www.youtube.com/watch?v=DYStzH7L6EQ
//https://www.youtube.com/watch?v=8-EqOFXjV8Q
//Tunnis vaatan t�� �le.

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
            builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();

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

            app.Run();
        }
    }
}
