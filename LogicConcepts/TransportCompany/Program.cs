using Shared;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;

var answer = String.Empty;
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
    var numParcelsBelow10 = ConsoleExtensions.GetInt("Número de encomiendas de menos de 10Kg..........: ");
    var numParcelsbetween10AndLess20 = ConsoleExtensions.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg:");
    var numParcelsAbove20 = ConsoleExtensions.GetInt("Número de encomiendas de 20Kg o más.............: ");

    //Calculos

    float routeValue = 0;

    if (route == "1")
        routeValue = 500000;
    else if (route == "2")
        routeValue = 600000;
    else if (route == "3")
        routeValue = 800000;
    else if (route == "4") 
        routeValue = 1000000;

    var valueTrips = routeValue * numTrips;

    var passengerIn = CalculatePassengerIn(route, numPassagers, valueTrips);
    var parcelsIn = CalculateparcelsIn(numParcelsBelow10,  numParcelsbetween10AndLess20, numParcelsAbove20, route);

    var TotalIn = passengerIn + parcelsIn;
    var payAssistant;
    var paySecure;
    var payFuel;

    var TotalDeductions;
    var TotalToSettled;

    do
    {
        answer = ConsoleExtensions.GetValidOptions("desea iniciar otra vez? (si/no): ", options);
    } while (!options.Any(x => string.Equals(x, answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

float CalculateparcelsIn(int numParcelsBelow10, int numParcelsbetween10AndLess20, int numParcelsAbove20, string route)
{
    {
        int totalPackages = numParcelsBelow10 +
                            numParcelsbetween10AndLess20 +
                            numParcelsAbove20;

        float priceBelow10 = 0;
        float priceBetween10And20 = 0;
        float priceAbove20 = 0;

        bool isRoute12 = route == "1" || route == "2";

        if (totalPackages < 50)
        {
            if (isRoute12)
            {
                priceBelow10 = 100;
                priceBetween10And20 = 120;  
                priceAbove20 = 120;         
            }
            else
            {
                priceBelow10 = 130;
                priceBetween10And20 = 140;
                priceAbove20 = 170;
            }
        }
        else if (totalPackages <= 100)
        {
            if (isRoute12)
            {
                priceBelow10 = 120;
                priceBetween10And20 = 140;
                priceAbove20 = 140;
            }
            else
            {
                priceBelow10 = 160;
                priceBetween10And20 = 180;
                priceAbove20 = 210;
            }
        }
        else if (totalPackages <= 130)
        {
            if (isRoute12)
            {
                priceBelow10 = 150;
                priceBetween10And20 = 160;
                priceAbove20 = 160;
            }
            else
            {
                priceBelow10 = 175;
                priceBetween10And20 = 200;
                priceAbove20 = 250;
            }
        }
        else
        {
            if (isRoute12)
            {
                priceBelow10 = 160;
                priceBetween10And20 = 180;
                priceAbove20 = 180;
            }
            else
            {
                priceBelow10 = 200;
                priceBetween10And20 = 250;
                priceAbove20 = 300;
            }
        }

        float total =
            (numParcelsBelow10 * priceBelow10) +
            (numParcelsbetween10AndLess20 * priceBetween10And20) +
            (numParcelsAbove20 * priceAbove20);

        return total;
    }

}
float CalculatePassengerIn(string route, int numPassengers, float valueTrips)
{
    float percentage = 0;
    float extraMoney = 0;

    if (route == "1")
    {
        if (numPassengers <= 50)
            percentage = 0f;

        else if (numPassengers <= 100)
            percentage = 0.05f;

        else if (numPassengers <= 150)
            percentage = 0.06f;

        else if (numPassengers <= 200)
            percentage = 0.07f;

        else
        {
            percentage = 0.07f;
            int extraPassengers = numPassengers - 200;
            extraMoney = extraPassengers * 50;
        }
    }
    else if (route == "2")
    {
        if (numPassengers <= 50)
            percentage = 0f;
        else if (numPassengers <= 100)
            percentage = 0.07f;
        else if (numPassengers <= 150)
            percentage = 0.08f;
        else if (numPassengers <= 200)
            percentage = 0.09f;
        else
        {
            percentage = 0.09f;
            int extraPassengers = numPassengers - 200;
            extraMoney = extraPassengers * 60;
        }
    }
   else  if (route == "3")
    {
        if (numPassengers <= 50)
            percentage = 0f;
        else if (numPassengers <= 100)
            percentage = 0.10f;
        else if (numPassengers <= 150)
            percentage = 0.13f;
        else if (numPassengers <= 200)
            percentage = 0.15f;
        else
        {
            percentage = 0.15f;
            int extraPassengers = numPassengers - 200;
            extraMoney = extraPassengers * 100;
        }
    }
    else if (route == "4")
    {
        if (numPassengers <= 50)
            percentage = 0f;
        else if (numPassengers <= 100)
            percentage = 0.125f;
        else if (numPassengers <= 150)
            percentage = 0.15f;
        else if (numPassengers <= 200)
            percentage = 0.17f;
        else
        {
            percentage = 0.17f;
            int extraPassengers = numPassengers - 200;
            extraMoney = extraPassengers * 150;
        }
    }
    return (valueTrips * percentage) + extraMoney;

}

    Console.WriteLine("Game Over");