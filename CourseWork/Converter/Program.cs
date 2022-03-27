using System;
using System.Collections.Generic;
using System.Linq; 
namespace Converter
{
    class Program
    {/* Превърнете в 2,8,16ична бройна система числото 2001*/
        static void Main(string[] args)
        {
            int n = 2001;//int.Parse(Console.ReadLine()); 
            Binary(n);
            Console.WriteLine("Octal number: "+ToOctal(n));
            Console.WriteLine("Hex number: "+n.ToString("X")); 
        }
        public static int ToOctal(int x)
        {
            if (x == 0)
            {
                return 0;
            }
            return x % 8 + 10 * ToOctal(x / 8);
        }  
        public static void Binary(int n)
        {
            int remainder;
            string result = string.Empty;
            while (n > 0)
            {
                remainder = n % 2;
                n /= 2;
                result = remainder.ToString() + result;
            }
            Console.WriteLine("Binary:  {0}", result);
        }
    }
}
