using Shared;
using System.ComponentModel.Design;

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

} while (true);

