using System;
using System.Collections.Generic;
using System.Linq;

namespace _395
{
    class Program
    {/*зад.395/стр.219
      Да се състави програма, в която:
        a) се дафинира метод Celf(f), в който формалният параметър f представлява температурата по Фаренхайт, а резултатът от метода е същага температура,
          изчислена в Целзиеви градуси по формулата 5/9 (f -32);
        б) се въвежда масив от до 31 числа в интервала [-100,100] - средни дневни температури по Фаренхайт за даден месец;
        в) се отпечатва на екрана максималната среднодневна температура
            - по Фаренхайт (F)
            - по Целзий (C)
        г) се извеждат на екрана тези среднодневни температури, които са по-малки от -10C (по Целзий);
      */
        static void Main(string[] args)
        {
            Console.Write("Fahrenheit: ");
            double f = double.Parse(Console.ReadLine());
            double celsius = CelF(f);
            Console.WriteLine("Celsius: " + celsius);
            //б
            Console.WriteLine("Enter 31 average fahrenheit numbers for month: ");
            var temperatures = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            //в 
            Console.WriteLine($"Maximal averageday tempF: {temperatures.Max():f2}");
            var maxCelsius = CelF(temperatures.Max());
            Console.WriteLine($"Maximal averageday tempC: {maxCelsius:f2}");
            //г  
            Console.WriteLine(temperatures.Any(x => CelF(x) < 10) ? $"Temperatures under -10C:" : "No under -10C!");
            foreach (var el in temperatures)
            {
                var underTenCel = CelF(el);
                if (underTenCel < -10)
                    Console.WriteLine($"{underTenCel:f2}C");
            }
        }
        public static double CelF(double f)
        {
            double inCelsius = (f - 32) * 5 / 9;
            return inCelsius;
        }
    }
}
