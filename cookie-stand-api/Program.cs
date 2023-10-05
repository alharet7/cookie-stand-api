using cookie_stand_api.Data;
using cookie_stand_api.Models.Interfaces;
using cookie_stand_api.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services
                .AddDbContext<CookieDbContext>
                (opions => opions.UseSqlServer(connString));

            builder.Services.AddTransient<ICookieStand, CookieStandService>();

            //------------ Swagger implementation -----------------------------------------------\\
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()

                {
                    Title = "Meghem-System",
                    Version = "v1",
                });
            });


            var app = builder.Build();
            app.UseRouting();

            //------------ Swagger implementation -----------------------------------------------\\
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Meghem-System");
                options.RoutePrefix = "docs";
            });

            app.MapGet("/", () => "Hello World!");
            app.MapControllers();
            app.Run();
        }
    }
}