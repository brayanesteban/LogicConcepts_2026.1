using Shared;
using System.ComponentModel.Design;

var answer = String.Empty;
var options = new List<string> { "si", "no" };

do
{
    //datos de entrada
    var cost = ConsoleExtensions.GetFloat("Costo de compra ");
    var productType = ConsoleExtensions.GetOption("tipo de producto [P]erecedero o [N]o perecedero: ",
        new List<string> { "P", "N" });
    if (productType == "P")
    {
      Console.WriteLine("Es un producto perecedero");
    }
    else
    {
        Console.WriteLine("Es un producto no perecedero");
    }

    var conservation = ConsoleExtensions.GetOption("Tipo de conservación [F]rio, [A]mbiente: ",
        new List<string> { "F", "A"});
    if (conservation == "F")
    {
        Console.WriteLine("El producto se conserva en frio");
    }
    else
    {
        Console.WriteLine("El producto se conserva a ambiente");
    }
    var conservationPeriod = ConsoleExtensions.GetInt("Periodo de conservacion (dias): ");
    var storagePeriod = ConsoleExtensions.GetInt("Periodo de almacenamiento (dias): ");
    var volume = ConsoleExtensions.GetInt("Volumen (litros)");
    var storageMedium = ConsoleExtensions.GetOption("Medio de almacenamiento [N]evera, [C]ongelador, [E]stanteria, [G]uacal: ",
        new List<string> { "N", "C", "E", "G" });
    if (storageMedium == "N")
    {
        Console.WriteLine("El producto se guarda en Nevera");
    }
    else if (storageMedium == "C")
    {
        Console.WriteLine("El producto se guarda en Congelador");
    }
    else if (storageMedium == "E")
    {
        Console.WriteLine("El producto se guarda en Estantería");
    }
    else if (storageMedium == "G")
    {
        Console.WriteLine("El producto se guarda en Guacal");
    }
    //Calculos

    var storageCost = CalculateStorageCost(cost, productType, conservation, conservationPeriod, storagePeriod, volume);
    var depretationPorcentage = CalculateDepretationPercentage(productType, conservation, conservationPeriod, storagePeriod);
    var exhibitionCost = CalculateExhibitionsCost(productType, conservation, storageMedium, storageCost);
    var productValue = (cost + storageCost + exhibitionCost) * depretationPorcentage; 
    float saleValue;

    if (productType == "N")
    {
        saleValue = productValue * 1.20f;
    }
    else
    {
        saleValue = productValue * 1.40f;
    }



    Console.WriteLine($"Costo almacenamiento: {storageCost}");
    Console.WriteLine($"Porcentaje de depreciación: {depretationPorcentage:P2}");
    Console.WriteLine($"Costo exhibición: {exhibitionCost}");
    Console.WriteLine($"Valor producto base: {productValue}");
    Console.WriteLine($"Valor de venta: {saleValue}");
    

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

    Console.WriteLine("Game Over");

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

float CalculateExhibitionsCost(string productType, string conservation, string storageMedium, float storageCost)
{
    if (productType == "P")
    {
        if (conservation == "F" && storageMedium == "N")
        {
            return storageCost * 2;
        }
        else if (conservation == "F" && storageMedium == "C")
        {
            return storageCost;
        }
    }
    if (productType == "N")
    {
        if (storageMedium == "E")
        {
            return storageCost * 0.05f;
        }
        else if (storageMedium == "G")
        {
            return storageCost * 0.07f;
        }
    }

    return 0;
}

float CalculateDepretationPercentage(string productType, string conservation, int conservationPeriod, int storagePeriod)
{
    if (storagePeriod < 30)
        return 0.95f;
    else if (storagePeriod >= 30)
        return 0.85f;
    return 0;
}

float CalculateStorageCost(float cost, string productType, string conservation, int conservationPeriod, int storagePeriod, int volume)
{
    if (productType == "P")
    {
        if (conservation == "F")
        {
            if (conservationPeriod < 10)
                return cost * 0.05f;
            else
                return cost * 0.10f;
        }

        if (conservation == "A")
        {
            if (storagePeriod < 20)
                return cost * 0.03f;
            else if (storagePeriod == 20)
                return cost * 0.05f;
            else
                return cost * 0.10f;
        }
    }

    if (productType == "N")
    {
        if (volume < 50)
            return cost * 0.20f;
       else
            return cost * 0.10f;
    }

    return 0;

}


