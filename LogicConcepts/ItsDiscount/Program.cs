using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

decimal deskPrice = 650000;
do
{
    
    var NumberDesk = ConsoleExtensions.GetInt("numero de Escritorios ");

    decimal discount =
       NumberDesk < 5 ? 0.10M :
       NumberDesk <= 10 ? 0.20M :
       0.40M;

    decimal TotalPrice = deskPrice * NumberDesk * (1 - discount);

    Console.WriteLine($"El valor a pagar es {TotalPrice:C0}");

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");