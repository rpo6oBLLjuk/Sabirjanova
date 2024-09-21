using System.Text.RegularExpressions;

namespace RegularExpressions
{
    public static class RegularExpressions
    {
        public static string pattern = @"\d+";
        public static Regex regular = new(pattern);

        public static void Main()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            MatchCollection matches = regular.Matches(input);
            Console.WriteLine("Найдены числа: ");
            foreach (Match m in matches)
            {
                Console.WriteLine($"\t{m.Value}");
            }

            bool isMatch = regular.IsMatch(input);
            Console.WriteLine($"Строка '{input}' удовлетворяет регулярному выражению: {isMatch}");

        }
    }
}