namespace Shared
{
    public class ConsoleExtensions
    {
        public static int GetInt(string message)
        {
            Console.Write(message);
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            throw new Exception("el valor ingresado no es un numero valido");
        }

        public static float GetFloat(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (float.TryParse(numberString, out float numberFloat))
            {
                return numberFloat;
            }

            return 0;
        }

        public static bool GetBool(string message)
        {
            var options = new List<string> { "s", "n" };
            Console.WriteLine(message);
            var text = Console.ReadLine();

            if (text!.ToLower() == "s")
            {
                return true;
            }
            return false;
        }

        public static decimal GetDecimal(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (decimal.TryParse(numberString, out decimal numberDecimal))
            {
                return numberDecimal;
            }

            return 0;
        }

        public static string? GetValidOptions(string message, List<string> options)
        {
            Console.Write(message);
            var answer = Console.ReadLine();
            if (options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)))
            {
                return answer;
            }
            return null;
        }
    
    public static string GetString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }

        public static string GetOption(string message, List<string> options)
        {
            while (true)
            {
                Console.Write(message);
                var answer = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(answer) &&
                    options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return answer.ToUpper();
                }

                Console.WriteLine("Opción no válida. Intente nuevamente.");
            }
        }

    }

}

