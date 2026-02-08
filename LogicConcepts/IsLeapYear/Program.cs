using Shared;
using System.ComponentModel.Design;

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

} while (true);

