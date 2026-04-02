namespace Instance_reference_variable
{
    class car
    {
        public string brand;
        public int speed;
        public static int totalcar = 0;

        public car(string brand, int speed)
        {
            this.brand = brand;
            this.speed = speed;
            totalcar++;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            car c1 = new car("Toyota", 120);
            car c2 = new car("Maruti", 80);
            Console.WriteLine($"Total cars are {car.totalcar}");
        }
    }
}
