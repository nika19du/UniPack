using System;
using System.Linq;
namespace _372ab
{
    class Program
    {/* Задача 372/стр.211
       Елементите на масив са имена на  населени места, започващи с главна буква. Да се съставят методи за:
        а) въвеждане на елементите на масива (не повече от 50).
        б) извеждане на екрана на всички населени места, които съдържат в името си подниз "град" или "Град". Например Ивайловград, Крумовград, Градешница.
     */
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете градове:");
            string input;
            int count = 1;
            string[] data = new string[50];
            while (!string.IsNullOrEmpty(input = Console.ReadLine()) && count <= 50)
            {
                if (input.Contains("град") || input.Contains("Град"))
                    data[count] = input;
                count++;
            }
            //print output:
            Console.WriteLine(data.Any(x => x != null) ? "Градове съдържащи град в себе си са:" : "Няма градове съдържащи град в себе си!");
            foreach (var el in data.Where(x => x != null))
            {
                Console.WriteLine(char.ToUpper(el[0]) + el.Substring(1));
            }
        }
    }
}
