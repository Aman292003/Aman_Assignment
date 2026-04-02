namespace Constructordemo
{
    class Vehicle
    {
        public string Make { set; get; }
        public string Model { set; get; }

        public Vehicle()
        {
            Console.WriteLine("Default Constructor called");
        }
        public Vehicle(string make1, string model1)
        {
            this.Make = make1;
            this.Model = model1;
            Console.WriteLine($"Parameterized Constructor called: Make={Make}, Model={Model}");
        }
        public Vehicle(Vehicle v)
        {
            this.Make = v.Make;
            this.Model = v.Model;
            Console.WriteLine($"Copy Constructor called: Make={Make}, Model={Model}");
        }

    }
    class car : Vehicle
    {
        public int doors { set; get; }
        public car(string make, string model, int doors) : base(make, model)
        {
            this.doors = doors;
            Console.WriteLine($"Car Constructor called: Doors={doors}");
        }

    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle v1 = new Vehicle();
            Vehicle v2 = new Vehicle("Toyota", "Camry");
            Vehicle v3 = new Vehicle(v2);
            car C = new car("Honda", "Civic", 4);
            Console.ReadLine();
        }
    }
}
