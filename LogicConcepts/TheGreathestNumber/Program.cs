
using Shared;

var response = string.Empty;
do

{
    try
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
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }



    Console.Write("desea continuar S/N ");
    response = Console.ReadLine()!.ToUpper();
} while (response == "S");