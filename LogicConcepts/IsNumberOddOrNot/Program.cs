var numberString = string.Empty;
do
{
    Console.Write("ingrese Numero entero o la palabra 'salir' para salir ");
    numberString = Console.ReadLine();
    if (numberString!.ToLower() == "Salir")  
    {
        continue;
    }

    var numberInt = 0;
    if (int.TryParse(numberString, out numberInt))

        if (numberInt % 2 == 0)
        {
            Console.WriteLine($"El numero {numberInt} es par");

        }
        else
        {
            Console.WriteLine($"El numero {numberInt} es impar");
        }
    else
        {
            Console.WriteLine($"El valor ingresado {numberString}, no es un numero entero");
        }
} while (numberString.ToLower() != "salir");
Console.WriteLine("game over");
