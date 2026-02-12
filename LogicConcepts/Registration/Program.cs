using Shared;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
    var NumberCredits = ConsoleExtensions.GetInt("Numero de creditos: ");
    var CreditValue = ConsoleExtensions.GetInt("Valor del credito: ");
    var Stratum = ConsoleExtensions.GetInt("Estrato del estudiante: ");

    decimal tuitionCost = CalculateTuition(NumberCredits, CreditValue, Stratum);
    int subsidy = CalculateSubsidy(Stratum);

    Console.WriteLine($"Costo de la matricula: {tuitionCost:C0}");
    Console.WriteLine($"Valor del subsidio: {subsidy:C0}");

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");


decimal CalculateTuition(int NumberCredits, int CreditValue, int Stratum)
{
    int total;

    if (NumberCredits <= 20)
    {
        total = NumberCredits * CreditValue;
    }
    else
    {
        int NormalCredits = 20;
        int ExtraCredits = NumberCredits - 20;

        int NormalTotal = NormalCredits * CreditValue;
        int ExtraTotal = ExtraCredits * (CreditValue * 2);

        total = NormalTotal + ExtraTotal;
    }

    decimal discount =
        Stratum == 1 ? 0.80M :
        Stratum == 2 ? 0.50M :
        Stratum == 3 ? 0.30M :
        0m;

    return total * (1 - discount);
}

int CalculateSubsidy(int Stratum)
{
    if (Stratum == 1)
        return 200000;
    else if (Stratum == 2)
        return 100000;
    else
        return 0;
}