using ClassLibrary;
using Microsoft.VisualBasic;
using Shared;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

var answer = String.Empty;
var options = new List<string> { "si", "no" };


do
{
    var a = ConsoleExtensions.GetDouble("Ingrese el valor de a: ");
    var b = ConsoleExtensions.GetDouble("Ingrese el valor de b: ");
    var c = ConsoleExtensions.GetDouble("Ingrese el valor de c: ");

    Quadratic(a, b, c);

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

void Quadratic(double a, double b, double c)
{
    double discriminante = b * b - 4 * a * c;
    double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
    double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);

    Console.WriteLine($" x1 = {x1}");
    Console.WriteLine($" x2 = {x2}");
}

Console.WriteLine("Game Over");