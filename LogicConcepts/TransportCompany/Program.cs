using Shared;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;

var answer = string.Empty;
var options = new List<string> { "si", "no" };

do
{
    Console.WriteLine("*** Datos de entrada ***");
    var route = ConsoleExtensions.GetOption("Ruta [1][2][3][4]...............................: ",
            new List<string> { "1", "2", "3", "4" });
    if (route == "1")
    {
        Console.WriteLine("Ruta 1");
    }
    else if (route == "2")
    {
        Console.WriteLine("ruta 2");
    }
    else if (route == "3")
    {
        Console.WriteLine("ruta 3");
    }
    else if (route == "4")
    {
        Console.WriteLine("ruta 4");
    }
    var numTrips = ConsoleExtensions.GetInt("Numero de viajes................................: ");
    var numPassagers = ConsoleExtensions.GetInt("Numero de pasajeros total.......................: ");
    var packages10 = ConsoleExtensions.GetInt("Número de encomiendas de menos de 10Kg..........: ");
    var packages10to20 = ConsoleExtensions.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg:");
    var packages20plus = ConsoleExtensions.GetInt("Número de encomiendas de 20Kg o más.............: ");

    //Calculos 
    var passengerIn = CalculatePassengerIn(route, numPassagers, numTrips);
    decimal parcelsIn = CalculateparcelsIn(packages10,  packages10to20, packages20plus, route);

    var totalIn = passengerIn + parcelsIn;
    decimal payAssistant = CalculatePayAssistant(totalIn);

    decimal paySecure = CalculatePaySecure(totalIn);
    decimal payFuel = CalculatePayFuel(numPassagers, packages10, packages10to20, packages20plus, route, numTrips);

    var TotalDeductions = payAssistant + paySecure + payFuel;
    var TotalToSettled = totalIn - TotalDeductions;

    Console.WriteLine("*** Calculos ***");
    Console.WriteLine($"Ingresos por Pasajeros.........................: { passengerIn:C}");
    Console.WriteLine($"Ingresos por Encomiendas.......................: { parcelsIn:C}");
    Console.WriteLine("                                                :---------------------------------------------");
    Console.WriteLine($"TOTAL INGRESOS.................................: { totalIn:C}");
    Console.WriteLine($"Pago al Ayudante...............................: { payAssistant:C}");
    Console.WriteLine($"Pago Seguro....................................: {paySecure:C}");
    Console.WriteLine($"Pago Combustible...............................: {payFuel:C}");
    Console.WriteLine("                                                :---------------------------------------------");
    Console.WriteLine($"TOTAL DEDUCCIONES..............................: { TotalDeductions:C}");
    Console.WriteLine("                                                :---------------------------------------------");
    Console.WriteLine($"TOTAL A LIQUIDAR...............................: { TotalToSettled:C}");


    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

decimal CalculatePayFuel(int numPassagers, int packages10, int packages10to20, int packages20plus, string route, int numTrips)
{
    float km;
    switch (route)
    {
        case "1":
            km = 150 * numTrips;
            break;
        case "2":
            km = 167 * numTrips;
            break;
        case "3":
            km = 184 * numTrips;
            break;
        default:
            km = 203 * numTrips;
            break;  
    }
    
    
    var gallons = km / 39;
    var value = (decimal)gallons * 8860m;
    var weight = numPassagers * 60 + packages10 * 10 + packages10to20 * 15 + packages20plus * 20;
    if (weight < 5000) return value;
    else if (weight <= 10000) return value * 1.1m;
    return value * 1.25m;

}

decimal CalculatePaySecure(decimal totalIn)
{
    if (totalIn < 1000000) return totalIn * 0.03m;
    if (totalIn < 2000000) return totalIn * 0.04m;
    if (totalIn < 4000000) return totalIn * 0.06m;
    return totalIn * 0.09m;
}

decimal CalculatePayAssistant(decimal totalIn)
{
    if (totalIn < 1000000) return totalIn * 0.05m;
    if (totalIn < 2000000) return totalIn * 0.08m;
    if (totalIn < 4000000) return totalIn * 0.1m;
    return totalIn * 0.13m;
}

decimal CalculateparcelsIn(int packages10, int packages10to20, int packages20plus, string route)
{
    decimal value = 0;
    switch (route)
    {
        case "1":
        case "2":
            if (packages10 <= 50) value += packages10 * 100;
            else if (packages10 <= 100) value += packages10 * 120;
            else if (packages10 <= 130) value += packages10 * 150;
            else value += packages10 * 160;
            var packagesGreater10 = packages10to20 + packages20plus;

            if (packagesGreater10 <= 50) value += packagesGreater10 * 120;
            else if (packagesGreater10 <= 100) value += packagesGreater10 * 140;
            else if (packagesGreater10 <= 130) value += packagesGreater10 * 160;
            else value += packagesGreater10 * 180;

            return value;
        default: 

            if (packages10 <= 50) value += packages10 * 130;
            else if (packages10 <= 100) value += packages10 * 160;
            else if (packages10 <= 130) value += packages10 * 175;
            else value += packages10 * 200;

            if (packages10to20 <= 50) value += packages10to20 * 140;
            else if (packages10to20 <= 100) value += packages10to20 * 180;
            else if (packages10to20 <= 130) value += packages10to20 * 200;
            else value += packages10to20 * 250;

            if (packages20plus <= 50) value += packages20plus * 170;
            else if (packages20plus <= 100) value += packages20plus* 210;
            else if (packages20plus <= 130) value += packages20plus * 250;
            else value += packages20plus * 300;

            return value;
    }
}
decimal CalculatePassengerIn(string route, int numPassengers, int numTrips)
{
    decimal value;
    switch (route)
    {
        case "1":
            value = 500000m * numTrips;
            if (numPassengers <= 50) return value;
            if (numPassengers <= 100) return value * 1.05m;
            if (numPassengers <= 150) return value * 1.06m;
            if (numPassengers <= 200) return value * 1.07m;
            return value * 1.07m + (numPassengers - 200) * 50m;
        case "2":
            value = 600000m * numTrips;
            if (numPassengers <= 50) return value;
            if (numPassengers <= 100) return value * 1.07m;
            if (numPassengers <= 150) return value * 1.08m;
            if (numPassengers <= 200) return value * 1.09m;
            return value * 1.07m + (numPassengers - 200) * 60m;
        case "3":
            value = 800000m * numTrips;
            if (numPassengers <= 50) return value;
            if (numPassengers <= 100) return value * 1.1m;
            if (numPassengers <= 150) return value * 1.13m;
            if (numPassengers <= 200) return value * 1.15m;
            return value * 1.15m + (numPassengers - 200) * 100m;
        default:
            value = 1000000m * numTrips;
            if (numPassengers <= 50) return value;
            if (numPassengers <= 100) return value * 1.125m;
            if (numPassengers <= 150) return value * 1.15m;
            if (numPassengers <= 200) return value * 1.17m;
            return value * 1.17m + (numPassengers - 200) * 150m;
    }

}

    Console.WriteLine("Game Over");