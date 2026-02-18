using ClassLibrary;
using Microsoft.VisualBasic;
using Shared;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

var answer = String.Empty;
var options = new List<string> { "si", "no" };


do
{
var n = ConsoleExtensions.GetInt("cuantos terminos desea: ");
var x = ConsoleExtensions.GetDouble("Ingrese el valor de x: ");
double suma = 1;
double factorial = 1;
double potencia = 1;

    if (n <= 0)
    {
        throw new ArgumentException("No permitido");
    }
    for (int k = 1; k < n; k++)
    {
        factorial = factorial * k;
        potencia = potencia * x;
        double termino = potencia / factorial;
        suma = suma + termino;

    }
    Console.WriteLine($"El resultado de la serie de Taylor es: {suma}");


    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");