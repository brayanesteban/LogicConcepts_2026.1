using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
    var n = ConsoleExtensions.GetInt("Cuantos terminos quiere: ");

    double a = 0; 
    double b = 1;
    double suma = 0;

    for (int i = 0; i < n; i++)
    {   
        Console.Write($"{a}\t");

        suma += a;

        double temp = a + b;
        a = b;
        b = temp;
    }

    Console.WriteLine();
    Console.WriteLine($"la sumatoria es: {suma}");
    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");