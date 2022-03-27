using System; 
namespace _4a
{
    class Program
    {/*зад.4a стр.22
      b-a
      ----(a-c)*cosx
      2b+c 
      */
        static void Main(string[] args)
        {
            double x, a, b, c; 
            Console.Write("x=");
            x = double.Parse(Console.ReadLine());
            Console.Write("a=");
            a= double.Parse(Console.ReadLine());
            Console.Write("b=");
            b = double.Parse(Console.ReadLine());
            Console.Write("c=");
            c = double.Parse(Console.ReadLine()); 
            var result = ((b - a) / ((2 * b) + c)) *
                (a - b) * Math.Cos(x); 
            Console.WriteLine($"Резултат={result}");
        }
    }
}
