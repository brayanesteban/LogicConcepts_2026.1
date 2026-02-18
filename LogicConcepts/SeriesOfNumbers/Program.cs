using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
  var n = ConsoleExtensions.GetInt("Cuantos números desea: ");
    float sum = 0;

    for (int i = 1; i  <= n; i++)
    {
        Console.Write($"{i}\t");
        sum += i;   
    }
    var average = sum / n; 
    Console.WriteLine();
    Console.WriteLine($"La suma de los numeros es: {sum,20:N0}");
    Console.WriteLine($"El promedio de los numeros es: {average,20:N2}");


    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");
