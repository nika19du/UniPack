using System;

namespace _78
{
    class Program
    {/*зад.78/54
      Да се напише програма за изчисляване на сумата 
        100
        ---
        \      k*k
         |   _______
        /    k*k*k+1
        ---
        k=1
      */
        static void Main(string[] args)
        {
            double z = 0;
            // 4.60251845189155
            for (double k = 0; k < 100; k++)
            {
                z += (k * k) / ((k * k * k) + 1);
            }
            Console.WriteLine("Z=" + z);
        }
    }
}
