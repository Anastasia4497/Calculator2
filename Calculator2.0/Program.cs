namespace Calculator2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Calculate();
            }
        }

        private static void Calculate()
        {
            try
            {
                Log(message: "Введите выражение: ", withNewLine: false);

                var userInput = Console.ReadLine();

                if (userInput == null)
                {
                    return;
                }

                var args = userInput.Split(" ");

                if (args.Length > 3 || args.Length < 3)
                {
                    Log("Внимание! Ошибка в выражении. Используйте простые выражения вида \"2 + 2\"");
                    return;
                }


                decimal x = decimal.Parse(args[0].Replace(".", ","));
                decimal y = decimal.Parse(args[2].Replace(".", ","));
                string op = args[1];

                decimal result;

                switch (op)
                {
                    case "+":
                        result = Add(x, y);
                        break;
                    case "-":
                        result = Minus(x, y);
                        break;
                    case "*":
                        result = Multiply(x, y);
                        break;
                    case "/":
                        result = Devide(x, y);
                        break;
                    default:
                        result = 0;
                        break;
                }

                Log("Ваш ответ: " + result, false);
            }
            catch (FormatException)
            {
                Log("Неправильный формат числа.");
            }
            catch (Exception)
            {
                Log("Что то пошло не так.");
            }
        }

        private static void Log(string message, bool printDateTime = false, bool withNewLine = true)
        {
            if (printDateTime)
            {
                message = DateTime.Now + ": " + message;
            }

            if (withNewLine)
                Console.WriteLine(message);
            else
                Console.Write(message);
        }

        private static decimal Add(decimal x, decimal y) => x + y;
        private static decimal Minus(decimal x, decimal y) => x - y;
        private static decimal Multiply(decimal x, decimal y) => x * y;
        private static decimal Devide(decimal x, decimal y) => x / y;
    }
}