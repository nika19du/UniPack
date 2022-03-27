using System; 
namespace Test2_Igrupa_3zad
{
    class Program
    {//130стр. Тест2 зад.3 1група 
        static void Main(string[] args)
        {
            Console.WriteLine("y1:");
            for (int i =1; i<4; i+=1)
            {
               var x = -i;
                Console.WriteLine("\r x {0} = {1}", x,(2*(x*x))/ (x+4));
            }
            Console.WriteLine("y2:");
            var temp = -4;
            while (temp!=4)
            {
                var x = temp;
                Console.WriteLine("\r x {0} = {1}", x, (Math.Log(x - 4) * Math.Exp(x)) / ((x * x * x * x * x) + Math.Sqrt(x)));
                temp++; 
            }
            Console.WriteLine();
            for (int x = 10; x > 4; x--)
            {
                Console.WriteLine("\r x{0} = {1}", x, (Math.Log(x - 4) * Math.Exp(x)) / ((x * x * x * x * x) + Math.Sqrt(x)));
            }

        }
    }
}
