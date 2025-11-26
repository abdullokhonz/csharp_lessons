// See https://aka.ms/new-console-template for more information
using LSP.Classes;

Console.WriteLine("Hello, World!");

var sparrow = new Sparrow();
sparrow.Fly();

var ostrich = new Ostrich();
// ostrich.Fly(); // This line would cause a compile-time error since Ostrich does not implement IFlyingBird
