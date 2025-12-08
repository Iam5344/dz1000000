using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericMedian
{
    class Program
    {
        static T FindMedian<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentException("Колекція не може бути порожньою");
            }

            var sorted = collection.OrderBy(x => x).ToList();
            int count = sorted.Count;
            int middle = count / 2;

            if (count % 2 == 1)
            {
                return sorted[middle];
            }
            else
            {
                if (typeof(T) == typeof(int) || typeof(T) == typeof(double) || typeof(T) == typeof(decimal))
                {
                    dynamic val1 = sorted[middle - 1];
                    dynamic val2 = sorted[middle];
                    return (val1 + val2) / 2;
                }
                else
                {
                    return sorted[middle - 1];
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Приклад 1: Непарна кількість чисел ");
            var numbers1 = new List<int> { 5, 2, 9, 1, 6 };
            Console.WriteLine($"Колекція: [{string.Join(", ", numbers1)}]");
            var median1 = FindMedian(numbers1);
            Console.WriteLine($"Медіана = {median1}");

            Console.WriteLine("\n Приклад 2: Непарна кількість рядків");
            var strings1 = new List<string> { "apple", "banana", "cherry", "date", "fig" };
            Console.WriteLine($"Колекція: [{string.Join(", ", strings1)}]");
            var median2 = FindMedian(strings1);
            Console.WriteLine($"Медіана = {median2}");

            Console.WriteLine("\nПриклад 3: Парна кількість чисел");
            var numbers2 = new List<int> { 4, 1, 7, 9, 3, 8 };
            Console.WriteLine($"Колекція: [{string.Join(", ", numbers2)}]");
            var median3 = FindMedian(numbers2);
            Console.WriteLine($"Медіана = {median3}");

            Console.WriteLine("\nПриклад 4: Парна кількість рядків ");
            var strings2 = new List<string> { "apple", "banana", "cherry", "date" };
            Console.WriteLine($"Колекція: [{string.Join(", ", strings2)}]");
            var median4 = FindMedian(strings2);
            Console.WriteLine($"Медіана = {median4}");

            Console.ReadKey();
        }
    }
}
