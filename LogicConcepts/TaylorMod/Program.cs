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

    var taylor = Taylor(x, n);

    Console.WriteLine($"f(x) = {taylor}");



    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");
double Taylor(double x, int n)
{
    double sum = 0;
    int signo = 1;
    for (int i = 0; i < n; i++)
    {
        sum += Math.Pow(x, i) / MyMath.Factorial(i) * signo;
        signo *= -1;
    }
    
    return sum;
}

