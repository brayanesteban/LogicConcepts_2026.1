using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
    Console.WriteLine("Ingrese tres numeros para ordenarlos de mayor a menor");

    var number1 = ConsoleExtensions.GetInt("ingrese primer numero: ");
    var number2 = ConsoleExtensions.GetInt("ingrese segundo numero: ");
    if (number1 == number2)
    {
        Console.WriteLine("Los numeros no pueden ser iguales, por favor ingrese numeros diferentes");
        continue;
    }
    var number3 = ConsoleExtensions.GetInt("ingrese tercer numero: ");
    if (number2==number3 || number3 == number1)
    {
        Console.WriteLine("Los numeros no pueden ser iguales, por favor ingrese numeros diferentes");
        continue;
    }

    if (number1 > number2 && number1 > number3)
    {
        if (number2 > number3)
        {
            Console.WriteLine($"El mayor es: {number1} el medio es {number2} y el menor es {number3}");
        }
        else
        {
            Console.WriteLine($"El mayor es: {number1} el medio es {number3} y el menor es {number2}");
        }

    }
    else if (number2 > number1 && number2 > number3)
    {
            if (number1 > number3)
            {
                Console.WriteLine($"El mayor es: {number2} el medio es {number1} y el menor es {number3}");
            }
            else
            {
                Console.WriteLine($"El mayor es: {number2} el medio es {number3} y el menor es {number1}");
            }
        }
        else
        {
            if (number1 > number2)
            {
                Console.WriteLine($"El mayor es: {number3} el medio es {number1} y el menor es {number2}");
            }
            else
            {
                Console.WriteLine($"El mayor es: {number3} el medio es {number2} y el menor es {number1}");
            }
        }
    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea ingresar otro numero? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");