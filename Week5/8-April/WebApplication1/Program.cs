
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Service;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection");  
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddControllers();
            builder.Services.AddScoped<IProductService, ProductService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMvcFrontend", policy =>
                {
                    policy.WithOrigins(
                        "https://localhost:7129",
                        "http://localhost:5251",
                        "https://localhost:44370",
                        "https://mvcfrontend20260407170404-esewbvdzhbhjged5.centralindia-01.azurewebsites.net",
                        "http://localhost:25091")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                // Enable Swagger in production too for API testing
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowMvcFrontend");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
