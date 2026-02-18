using ClassLibrary;
using Shared;
using System.Numerics;

var answer = String.Empty;
var options = new List<string> { "si", "no" };


do
{

    var n = ConsoleExtensions.GetInt("Ingrese un número: ");
    if (n < 0)
        throw new ArgumentException("No permitido");

    var factorial = MyMath.Factorial(n);
    Console.WriteLine($"El factorial es: {factorial:N0}");

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");