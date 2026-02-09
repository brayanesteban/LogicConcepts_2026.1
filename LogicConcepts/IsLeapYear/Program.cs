using Shared;
using System.ComponentModel.Design;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

Console.WriteLine("ingresa dos numeros por favor");

do
{
    var currentYear = DateTime.Now.Year;
    var message = String.Empty;
    var year = ConsoleExtensions.GetInt("ingrese año: ");

    if (year == currentYear)
    {
        message = "es";
    }
     else if (year > currentYear)
            {
                message = "va ser";    
            }
    else
    {
        message = "fue";
    }

    if (year % 4 == 0 )
    {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
            {
                Console.WriteLine($"el año {year}, {message} bisiesto");
            }
            else
            {
                Console.WriteLine($"el año {year}, no {message} bisiesto");
            }
        }
        else
        {
            Console.WriteLine($"el año {year}, {message} bisiesto");
        }
    }
    else
    {
        Console.WriteLine($"el año {year}, no {message} bisiesto");    
    }

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea ingresar otro numero? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");


