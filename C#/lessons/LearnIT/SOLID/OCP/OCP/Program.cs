// See https://aka.ms/new-console-template for more information
using OCP.Classes;

Console.WriteLine("Hello, World!");

// Using Regular Discount Strategy
var calc1 = new DiscountCalculator(new RegularDiscount());
double result1 = calc1.Calculate(100);
Console.WriteLine(result1);

// Using VIP Discount Strategy
// 2. VIP скидка
var calc2 = new DiscountCalculator(new VIPDiscount());
double result2 = calc2.Calculate(100);
Console.WriteLine(result2);

// Using Student Discount Strategy
var calc3 = new DiscountCalculator(new StudentDiscount());
double result3 = calc3.Calculate(100);
Console.WriteLine(result3);
