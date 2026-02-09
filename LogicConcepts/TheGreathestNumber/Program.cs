
using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };
do

{
        Console.WriteLine("Ingrese 3 numeros diferentes: ");

        var number1 = ConsoleExtensions.GetInt("ingrese primer numero: ");
        var number2 = ConsoleExtensions.GetInt("ingrese segundo numero: ");
        var number3 = ConsoleExtensions.GetInt("ingrese tercer numero: ");

        if (number1 > number2 && number1 > number3)
        {
            Console.WriteLine($"El numero mayor es: {number1}");
        }
        else if (number2 > number1 && number2 > number3)
        {
            Console.WriteLine($"El numero mayor es: {number2}");
        }
        else
        {
            Console.WriteLine($"El numero mayor es: {number3}");
        }

        do
        {
            answer = ConsoleExtensions.GetValidOptions("desea ingresar otro numero? (si/no): ", options);
        } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

    } while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase)) ;

    Console.WriteLine("Game Over" );
