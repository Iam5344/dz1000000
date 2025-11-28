using System;

class Program
{
    enum TaskType { One, Two, Three }

    static void Main(string[] args)
    {

        Console.Write("Введіть вираз (+, -): ");
        string expr = Console.ReadLine();

        int result = 0;
        int number = 0;
        char op = '+';

        for (int i = 0; i < expr.Length; i++)
        {
            char c = expr[i];

            if (char.IsDigit(c))
            {
                number = number * 10 + (c - '0');
            }
            else if (c == '+' || c == '-')
            {
                if (op == '+') result += number;
                else result -= number;

                number = 0;
                op = c;
            }
        }

        if (op == '+') result += number;
        else result -= number;

        Console.WriteLine("Результат: " + result);
        Console.WriteLine();

        if (args.Length < 2)
        {
            Console.WriteLine("Потрібно передати: текст зсув");
        }
        else
        {
            string text = args[0];
            int shift = int.Parse(args[1]);

            string encrypted = "";

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (char.IsLetter(ch))
                {
                    char baseChar = char.IsUpper(ch) ? 'A' : 'a';
                    char enc = (char)(baseChar + (ch - baseChar + shift) % 26);
                    encrypted += enc;
                }
                else
                {
                    encrypted += ch;
                }
            }

            Console.WriteLine("Результат: " + encrypted);
        }

        Console.WriteLine();

        Console.Write("Введіть неприпустиме слово: ");
        string bad = Console.ReadLine();

        Console.WriteLine("Введіть текст:");
        string input = Console.ReadLine();

        string stars = new string('*', bad.Length);
        string resultText = input.Replace(bad, stars, StringComparison.OrdinalIgnoreCase);
        int count = input.Split(bad, StringSplitOptions.None).Length - 1;

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(resultText);
        Console.WriteLine("Статистика: " + count + " заміни.");
    }
}
