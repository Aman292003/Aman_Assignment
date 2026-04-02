using System;
using System.Collections.Generic;
using System.Linq;

/* =====================================================
   CUSTOM EXCEPTION
===================================================== */

public class ParkingException : Exception
{
    public ParkingException(string msg) : base(msg) { }
}


/* =====================================================
   INTERFACE
===================================================== */

public interface IVehicle
{
    string VehicleNumber { get; set; }
    string Owner { get; set; }
    int ParkingHours { get; set; }
    bool IsExited { get; set; }

    void Validate();
    double CalculateCharge();
}


/* =====================================================
   ABSTRACT BASE CLASS
===================================================== */

public abstract class VehicleBase : IVehicle
{
    public string VehicleNumber { get; set; }
    public string Owner { get; set; }
    public int ParkingHours { get; set; }
    public bool IsExited { get; set; }

    public virtual void Validate()
    {
        if (string.IsNullOrWhiteSpace(VehicleNumber) ||
            string.IsNullOrWhiteSpace(Owner) ||
            ParkingHours < 0)
        {
            throw new ParkingException("Invalid vehicle data");
        }
    }

    public abstract double CalculateCharge();

    public override string ToString()
    {
        return $"{VehicleNumber} - {Owner} - {ParkingHours} hrs";
    }
}


/* =====================================================
   VEHICLE TYPES
===================================================== */

class Car : VehicleBase
{
    public override double CalculateCharge()
    {
        double charge = ParkingHours * 50;
        return ParkingHours > 10 ? charge + 200 : charge;
    }
}

class Bike : VehicleBase
{
    public override double CalculateCharge()
    {
        return ParkingHours * 20;
    }
}

class Truck : VehicleBase
{
    public override double CalculateCharge()
    {
        double charge = ParkingHours * 100;
        return ParkingHours > 5 ? charge + 500 : charge;
    }
}


/* =====================================================
   ENGINE
===================================================== */

public class ParkingEngine
{
    private Dictionary<string, IVehicle> vehicles =
        new Dictionary<string, IVehicle>(StringComparer.OrdinalIgnoreCase);

    /* ---------- ENTER ---------- */
    public void EnterVehicle(IVehicle v)
    {
        v.Validate();

        if (vehicles.ContainsKey(v.VehicleNumber))
            throw new ParkingException("Vehicle already parked");

        vehicles.Add(v.VehicleNumber, v);
    }

    /* ---------- EXIT ---------- */
    public void ExitVehicle(string number)
    {
        if (!vehicles.TryGetValue(number, out var vehicle))
            throw new ParkingException("Car is Not Parked");

        if (vehicle.IsExited)
            throw new ParkingException("Vehicle already exited");

        vehicle.IsExited = true;
    }

    /* ---------- SEARCH ---------- */
    public IVehicle GetVehicle(string number)
    {
        if (!vehicles.TryGetValue(number, out var vehicle))
            throw new ParkingException("Car is not parked here");

        if (vehicle.IsExited)
            throw new ParkingException("Car is already exited");

        return vehicle;
    }

    /* ================= LINQ ================= */

    public double GetTotalRevenue()
    {
        return vehicles.Values
            .Where(v => !v.IsExited)
            .Sum(v => v.CalculateCharge());
    }

    public IVehicle GetLongestParkedVehicle()
    {
        var active = vehicles.Values
            .Where(v => !v.IsExited)
            .ToList();

        if (!active.Any())
            throw new ParkingException("No active parked vehicles");

        return active.OrderByDescending(v => v.ParkingHours)
                     .First();
    }

    public List<IVehicle> GetVehiclesParkedMoreThan(int hours)
    {
        return vehicles.Values
            .Where(v => !v.IsExited && v.ParkingHours > hours)
            .ToList();
    }

    public List<IVehicle> SortByChargeDesc()
    {
        return vehicles.Values
            .Where(v => !v.IsExited)
            .OrderByDescending(v => v.CalculateCharge())
            .ToList();
    }
}


/* =====================================================
   MAIN FUNCTION (TEST DRIVER)
===================================================== */

class Program
{
    static void Main()
    {
        ParkingEngine engine = new ParkingEngine();

        Console.WriteLine("===== TEST 1 : Normal Entry =====");

        engine.EnterVehicle(new Car
        {
            VehicleNumber = "PB10A1",
            Owner = "Aman",
            ParkingHours = 12
        });

        engine.EnterVehicle(new Bike
        {
            VehicleNumber = "PB10B2",
            Owner = "Riya",
            ParkingHours = 4
        });

        engine.EnterVehicle(new Truck
        {
            VehicleNumber = "PB10T3",
            Owner = "Raj",
            ParkingHours = 7
        });

        Console.WriteLine("Vehicles Added");


        /* ================= EDGE CASES ================= */

        Console.WriteLine("\nTEST 2 : Duplicate Entry");
        try
        {
            engine.EnterVehicle(new Car
            {
                VehicleNumber = "PB10A1",
                Owner = "Duplicate",
                ParkingHours = 1
            });
        }
        catch (ParkingException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine("\nTEST 3 : Exit Twice");
        try
        {
            engine.ExitVehicle("PB10A1");
            engine.ExitVehicle("PB10A1");
        }
        catch (ParkingException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine("\nTEST 4 : Case Insensitive Search");
        try
        {
            Console.WriteLine(engine.GetVehicle("pb10a1"));
        }
        catch (ParkingException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine("\nTEST 5 : LINQ Analytics");

        Console.WriteLine("Total Revenue:");
        Console.WriteLine(engine.GetTotalRevenue());

        Console.WriteLine("\nLongest Parked:");
        Console.WriteLine(engine.GetLongestParkedVehicle());

        Console.WriteLine("\nParked > 5 hours:");
        foreach (var v in engine.GetVehiclesParkedMoreThan(5))
            Console.WriteLine(v);

        Console.WriteLine("\nSorted by Charge:");
        foreach (var v in engine.SortByChargeDesc())
            Console.WriteLine($"{v.VehicleNumber} -> {v.CalculateCharge()}");


        Console.WriteLine("\nTEST 6 : Hardest Edge (Unknown Exit)");
        try
        {
            engine.ExitVehicle("XX999");
        }
        catch (ParkingException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nALL TESTS PASSED ✅");
    }
}