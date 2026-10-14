﻿/*
* Name:            Tyler Himes
* Course:          CSCI 1250, Section 001
* Assignment:      Lab 04, The Group Trip
* Date:            October 7, 2026
* Description:     Rebuilds the trip calculator with methods and arrays so it 
*                  reports on a whole group instead of one person.
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

//CONSTANTS
const double taxRate = 0.18;
const int pizzaSlices = 8;

//Welcome!
Console.WriteLine("Welcome to the trip calculator!\n");

//=== PART ONE THE TRIP ===

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

//CALCULATIONS PT 1

//FuelCost METHOD
double fuelCost = FuelCost(roundTrip, milesPerGallon, costPerGallon);

double totalPizzaCost = pizzaCount * pizzaCost;

double totalCost = fuelCost + totalPizzaCost;

//OUTPUT PT 1
System.Console.WriteLine("\n\n=== Part 1: The Trip ===");
System.Console.WriteLine($"Fuel cost: {fuelCost.ToString("C")}");
System.Console.WriteLine($"Pizza cost: {totalPizzaCost.ToString("C")}");
System.Console.WriteLine($"Trip total: {totalCost.ToString("C")}\n\n");

//=== PART TWO THE GROUP ===

//ARRAYS PT 2
string[] names = {"Ada", "Grace", "Alan", "Katherine"};
double[] hoursWorked = { 22, 15, 30, 18};
double [] hourlyRates = {13.50, 16.00, 11.20, 14.80};

//PT 2 CALCULATIONS
int peopleGoing = names.Length;
double slicesEach = pizzaCount * pizzaSlices / peopleGoing;
double costPerPerson = totalCost / peopleGoing;

//OUTPUT PT 2
System.Console.WriteLine("=== Part 2: The Group ===");
System.Console.WriteLine($"People going: {peopleGoing.ToString()}");
System.Console.WriteLine($"Slices each: {slicesEach.ToString("F1")}");
System.Console.WriteLine($"Cost per person: {costPerPerson.ToString("C")}\n\n");

//=== PART THREE THE REPORT ===
double totalHours = 0;
double totalTakeHome = 0;
double longest = 0;

//FOR LOOP, FIND THE VALUES FOR EACH INDIVIDUAL IN names
System.Console.WriteLine("=== Part 3: Who Works How Long ===");
for (int i = 0; i < names.Length; i++)
{
    //PT 3 CALCULATIONS

    //TakeHomePay METHOD
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);

    //HOURLY WAGE MINUS TAX
    double takeHomePayPerHours = takeHomePay / hoursWorked[i];

    //HoursToCover METHOD
    double hoursToCover = HoursToCover(costPerPerson, takeHomePayPerHours);

    totalHours = totalHours += hoursWorked[i];
    totalTakeHome = totalTakeHome += takeHomePay;
    longest = Math.Max(longest, hoursToCover);

    //OUTPUT PT 3: EACH INDIVIDUAL
    System.Console.WriteLine($"{names[i]}: takes home {takeHomePay.ToString("C")} for {hoursWorked[i].ToString("F0")} hours, {takeHomePayPerHours.ToString("C")} per hour, must work {hoursToCover.ToString("f2")} hours");
}

//OUTPUT PT 3: OVERALL
System.Console.WriteLine($"\n\nTotal hours worked: {totalHours.ToString("F0")}");
System.Console.WriteLine($"Total take home pay: {totalTakeHome.ToString("C")}");
System.Console.WriteLine($"Longest anyone must work: {longest.ToString("F2")}");

//METHODS

//FuelCost, returns the total cost of fuel
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

//TakeHomePay, returns your net pay (gross pay minus the taxes withheld)
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{ 
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}

//HoursToCover, returns the amount each individual must pay divided by the their net take home pay
static double HoursToCover(double amountOwed, double takeHomePayPerHour)
{
    return amountOwed/takeHomePayPerHour;
}