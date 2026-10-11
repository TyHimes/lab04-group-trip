using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

//constants
const double taxRate = 0.18;
const int pizzaSlices = 8;

//Welcome!
Console.WriteLine("Welcome to the trip calculator!\n");

System.Console.WriteLine("=== Part 1: The Trip ===");

//INPUT PT 1
Console.Write("How many miles will the road trip take in total? ");
double roundTrip = Convert.ToSingle(Console.ReadLine());

Console.Write("How many miles per gallon does your car get? ");
double milesPerGallon = Convert.ToSingle(Console.ReadLine());

Console.Write("How much does gas cost per gallon right now? ");
double costPerGallon = Convert.ToSingle(Console.ReadLine());

Console.Write("How many pizzas are you purchasing? ");
double pizzaCount = Convert.ToSingle(Console.ReadLine());

Console.Write("How much does each pizza cost? ");
double pizzaCost = Convert.ToSingle(Console.ReadLine());

double totalSlices = pizzaCount * pizzaSlices;
double totalPizzaCost = pizzaCount * pizzaCost;

//CALCULATIONS PT 1

double fuelCost = FuelCost(roundTrip, milesPerGallon, costPerGallon);

double totalCost = fuelCost + totalPizzaCost;

//OUTPUT PT 1
System.Console.WriteLine($"Fuel cost: {fuelCost.ToString("C")}\n");
System.Console.WriteLine($"Pizza cost: {totalPizzaCost.ToString("C")}\n");
System.Console.WriteLine($"Trip total: {totalCost.ToString("C")}\n");


static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{ 
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}
static double HoursToCover(double amountOwed, double takeHomePayPerHour)
{
    return amountOwed;
}