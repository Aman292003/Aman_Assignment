using System;
using System.Collections.Generic;

/* ================= INTERFACES ================= */

public interface IVehicle
{
    string VehicleNumber { get; set; }
    string VehicleType { get; set; }
    int HoursParked { get; set; }
}

public interface IParkingLot
{
    void ParkVehicle(IVehicle vehicle);
    void RemoveVehicle(string vehicleNumber);
    double CalculateFee(string vehicleNumber);
    int GetTotalVehicles();
    double GetTotalRevenue();
}


   class Vehicle : IVehicle{
    public string VehicleNumber { get; set; }
     public string VehicleType { get; set; }
     public int HoursParked { get; set; }

    public Vehicle(string VehicleNumber ,string VehicleType , int HoursParked)
    {
        this.VehicleNumber = VehicleNumber;
        this.HoursParked = HoursParked;
        this.VehicleType = VehicleType;
    }
}
   
class ParkingLot : IParkingLot
{
    private List<IVehicle> list = new List<IVehicle>();

    public void ParkVehicle(IVehicle vehicle)
    {
        list.Add(vehicle);
    }
    public void RemoveVehicle(string vehicleNumber)
    {
        list.RemoveAll(s => s.VehicleNumber.Equals(vehicleNumber, StringComparison.OrdinalIgnoreCase));
    }
    public double CalculateFee(string vehicleNumber)
    {
        return list
            .Where(s => s.VehicleNumber.Equals(vehicleNumber,
                     StringComparison.OrdinalIgnoreCase))
            .Select(s => s.VehicleType.Equals("Car",
                     StringComparison.OrdinalIgnoreCase)
                     ? s.HoursParked * 50
                     : s.HoursParked * 20)
            .FirstOrDefault();
    }

    public int GetTotalVehicles()
    {
        return list.Count;
    }
    public double GetTotalRevenue()
    {
        return list.Sum(s => s.VehicleType.Equals("Car",
                     StringComparison.OrdinalIgnoreCase)
                     ? s.HoursParked * 50
                     : s.HoursParked * 20);
    }



}

   





/* ================= MAIN FUNCTION ================= */

class Program
{
    static void Main(string[] args)
    {
        IParkingLot lot = new ParkingLot();

        lot.ParkVehicle(new Vehicle("WB01A1234", "Car", 3));
        lot.ParkVehicle(new Vehicle("WB02B5678", "Bike", 5));
        lot.ParkVehicle(new Vehicle("WB03C9999", "Car", 2));

        Console.WriteLine("Total Vehicles:");
        Console.WriteLine(lot.GetTotalVehicles());

        Console.WriteLine("\nFee for WB02B5678:");
        Console.WriteLine(lot.CalculateFee("WB02B5678"));

        lot.RemoveVehicle("WB03C9999");

        Console.WriteLine("\nVehicles After Removal:");
        Console.WriteLine(lot.GetTotalVehicles());

        Console.WriteLine("\nTotal Revenue:");
        Console.WriteLine(lot.GetTotalRevenue());
    }
}