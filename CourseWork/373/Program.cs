using System;
using System.Collections.Generic;
using System.Linq;

namespace _373
{
    class Program
    {/* 373
      Да се генерира редица от 70 случайни цели числа  пренадлежащи на интервала [0,200]. Да се отпечатат тези от тях, които са различни от нула
    */
        static void Main(string[] args)
        {
            Random random=new Random();
            List<int> nums = new List<int>();
            for (int i = 1; i <= 70; i++)
            {
               var randomNumber=random.Next(0, 200);
                nums.Add(randomNumber);
            } 
            nums = nums.Where(n => n != 0).ToList();
            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
