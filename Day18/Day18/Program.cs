namespace Day18
{
    public class seatnotavailable: Exception
    {
        public seatnotavailable() : base("Seat already booked!")
    {
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter total seats  ");

            int tseats = Convert.ToInt32(Console.ReadLine());

            int[] seats = new int[tseats];

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter no of seats you want ");

                    int sno = Convert.ToInt32(Console.ReadLine());
                    if (sno <= 0 || sno > tseats)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    
                    if(seats[sno - 1] == 1)
                    {
                        throw new seatnotavailable();
                    }
                    else
                    {
                        seats[sno - 1] = 1;
                        Console.WriteLine("Seat booked successfully");
                    }       
                }
                catch(seatnotavailable ex)
                {
                    Console.WriteLine("Error: " + ex.Message);

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);

                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid input!");
                }

            }
            Console.WriteLine("\nBooked Seats:");
            bool anyBooked = false;

            for(int i = 0; i < tseats; i++)
            {
                if(seats[i] == 1)
                {
                    Console.WriteLine("Seat Number: " + (i + 1));
                    anyBooked = true;
                }
            }
            if ((!anyBooked))
            {
                Console.WriteLine("\n\nThank you for using the Seat Booking System ");



            }
           

        }
    }
}
