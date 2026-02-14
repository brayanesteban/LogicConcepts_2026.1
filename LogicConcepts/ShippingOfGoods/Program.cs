using Shared;
using System.ComponentModel.Design;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
    var weights = ConsoleExtensions.GetInt("Peso de la mercancia ");
    var commodity = ConsoleExtensions.GetDecimal("Valor de la mercancia ");
    var monday = ConsoleExtensions.GetString("Es lunes? [S]i o [N]o: ");
    var paymentMethod = ConsoleExtensions.GetString("Tipo de pago [E]fectivo [T]arjeta ");

    var fee = CalculateValue(weights);
    var promotion = CalculatePromotions(fee, commodity, monday, paymentMethod);

    decimal discount = 0;
    decimal total;

    if (promotion > 0)
    {
        total = fee - promotion;
    }
    else
    {
        discount = CalculateDiscount(fee, commodity);
        total = fee - discount;
    }

    Console.WriteLine($"tarifa: {fee}");
    Console.WriteLine($"promocion: {promotion}");
    Console.WriteLine($"descuento: {discount}");
    Console.WriteLine($"total a pagar: {total}");

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));



Console.WriteLine("Game Over");


decimal CalculateValue(int weights)
{

    if (weights < 100)
    {
        return 20000;
    }
    else if (weights >= 100 && weights <= 150)
    {
        return 25000;
    }
    else if (weights > 150 && weights <= 200)
    {
        return 30000;
    }
    else
    {
        int extraWeight = weights - 200;
        int blocks = extraWeight / 10;
        decimal extraCost = blocks * 2000;

        return 35000 + extraCost;

    }


}

decimal CalculateDiscount(decimal fee, decimal commodity)
{
    if (commodity >= 300000 && commodity <= 600000)
    {
        return fee * 0.10M;
    }
    else if (commodity > 600000 && commodity <= 1000000)
    {
        return fee * 0.20M;
    }
    else if (commodity > 1000000)
    {
        return fee * 0.30M;
    }

    return 0;
}

decimal CalculatePromotions(decimal fee, decimal commodity, string monday, string paymentMethod)
{
    if (monday.Equals("s", StringComparison.CurrentCultureIgnoreCase)
            && paymentMethod.Equals("t", StringComparison.CurrentCultureIgnoreCase))
    {
        return fee * 0.50M;
    }
    else if (paymentMethod.Equals("e", StringComparison.CurrentCultureIgnoreCase)
             && commodity > 1000000)
    {
        return fee * 0.40M;
    }

    return 0;
}
