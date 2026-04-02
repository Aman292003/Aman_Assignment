using System;
using System.Collections.Generic;

/*
=====================================================
SMART PAYMENT PROCESSING SYSTEM
(HackerRank Starter Code)

TODO:
1. Create InvalidPaymentException
2. Implement ProcessPayment() in all classes
3. Add validation:
      - amount <= 0 → throw exception
4. Complete payment execution loop
=====================================================
*/


/* ================= CUSTOM EXCEPTION ================= */

// TODO 1: Implement properly
class InvalidPaymentException : Exception
{
    public InvalidPaymentException(string message) : base(message) { }
}


/* ================= INTERFACE ================= */

public interface IPayment
{
    double ProcessPayment(double amount);
}


/* ================= ABSTRACT CLASS ================= */

public abstract class PaymentBase : IPayment
{
    public string TransactionId { get; set; }

    public PaymentBase(string id)
    {
        TransactionId = id;
    }

    public void PrintTransaction()
    {
        Console.WriteLine($"Transaction: {TransactionId}");
    }

    public abstract double ProcessPayment(double amount);
}


/* ================= PAYMENT TYPES ================= */

// TODO 2
class CreditCardPayment : PaymentBase
{
    public CreditCardPayment(string id) : base(id) { }

    public override double ProcessPayment(double amount)
    {
        if (amount < 0)
        {
            throw new InvalidPaymentException("amount can not be negative");
        }
        else
        {
            return amount * 1.02;
        }
        
    }
}

// TODO 2
class UpiPayment : PaymentBase
{
    public UpiPayment(string id) : base(id) { }

    public override double ProcessPayment(double amount)
    {
        if (amount < 0)
        {
            throw new InvalidPaymentException("amount can not be negative");
        }
        else
        {
            return amount ;
        }
    }
}

// TODO 2
class WalletPayment : PaymentBase
{
    public WalletPayment(string id) : base(id) { }

    public override double ProcessPayment(double amount)
    {
        if (amount < 0)
        {
            throw new InvalidPaymentException("amount can not be negative");
        }
        else
        {
            return amount * 0.95;
        }
    }
}


/* ================= MAIN PROGRAM ================= */

class Program
{
    static void Main()
    {
        List<PaymentBase> payments = new List<PaymentBase>()
        {
            new CreditCardPayment("TXN101"),
            new UpiPayment("TXN102"),
            new WalletPayment("TXN103")
        };

        double[] testAmounts = { 1000, 500, -200 };

        // TODO 4:
        // Process all payments using try-catch
        // Print error message if exception occurs

        foreach (var payment in payments)
        {
            foreach (var amount in testAmounts)
            {
                try
                {
                    payment.PrintTransaction();

                    double result = payment.ProcessPayment(amount);

                    Console.WriteLine($"Processed Amount: {result}");
                }
                catch (InvalidPaymentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}