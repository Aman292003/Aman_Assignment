namespace krystaldemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Detect launch profile from launchSettings.json
            var envValue = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var profile = envValue != null ? envValue : "Production";

            // for this take simplefunction and explain ternary operator 
            var isHttpsProfile = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")?.Contains("https") == true;

            app.MapGet("/", () =>
            {
                // IIS Express (HTTP profile) → Hello World
                if (!isHttpsProfile)
                    return "Hello World! (IIS Express)";

                // HTTPS/Kestrel profile → Hai everyone
                return "Hai everyone (HTTPS/Kestrel)";
            });

            //added this line to see the output in output window which profile is running like that 
            var envValue1 = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"RAW ENV: '{envValue1}'");
            app.Run();
        }
    }
}
