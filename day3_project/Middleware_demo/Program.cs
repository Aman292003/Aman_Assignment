namespace Middleware_demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            
            app.Use(async(HttpContext context,RequestDelegate next)=>
            {
                   await context.Response.WriteAsync("This is a middleware response1.");
                next(context);
            });
            app.Use(async(HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("\nThis is a middleware response2.");
                next(context);

            }); 
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("\nThis is a middleware response3.");
                next(context);

            });
            app.MapGet("/", () => "Hello World!");
            app.MapGet("/add/{a}/{b}", (int a, int b) => $"The sum is {a + b}");

            app.Run();
        }
    }
}
