using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
    var name = ConsoleExtensions.GetString("ingrese su nombre por favor ");
    var Workhours = ConsoleExtensions.GetFloat("ingrese numero de horas trabajadas ");
    var HourValue = ConsoleExtensions.GetDecimal("ingrese el valor hora ");
    var MinimunSalary = ConsoleExtensions.GetDecimal("ingrese el salario minimo mensual ");

    var Salary = (decimal)Workhours * HourValue;

    if (Salary < MinimunSalary)
    {
        Console.WriteLine($"Nombre: {name}");
        Console.WriteLine($"Salario: {MinimunSalary:C2}");
    }
    else
    {
        Console.WriteLine($"nombre: {name}");
        Console.WriteLine($"Salario: {Salary:C2}");    
    }

    do
{
    answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
} while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase)) ;

Console.WriteLine("Game Over");