
using Microsoft.EntityFrameworkCore;
using ProductTask.Models;

namespace ProductTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

            builder.Services.AddScoped<IProduct, ProductService>();

            // Add services to the container.

            builder.Services.AddControllersWithViews();

          
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProductUI}/{action=Index}/{id?}"
);

            app.Run();
        }
    }
}
