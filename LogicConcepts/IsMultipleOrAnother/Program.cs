using Shared;
using System.ComponentModel.Design;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

Console.WriteLine("ingresa dos numeros por favor");

do
{

    var a = ConsoleExtensions.GetInt("ingrese primer numero: ");
    var b = ConsoleExtensions.GetInt("ingrese segundo numero: ");

    if (b % a == 0)
    {
        Console.WriteLine($"el numero {a}, es múltiplo de {b}");
    }
    else 
    {
        Console.WriteLine($"el numero {a} , no es multiplo de  {b}");
    }

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea ingresar otro numero? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");

