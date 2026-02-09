
using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
    var number = ConsoleExtensions.GetInt("ingrese un numero entero: ");
    if (number % 2 == 0)
    {
        Console.WriteLine($"El numero {number} es par");
    }
    else
    {
        Console.WriteLine($"El numero {number}, es impar");
    }

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea ingresar otro numero? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));


} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over"); 
