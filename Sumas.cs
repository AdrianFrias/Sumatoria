using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Sumatoria
{
    class Sumas
    {
        static async Task Main(string[] args)
        {
            Stopwatch tiempo = new Stopwatch();
            Console.WriteLine("Secuencial");
            tiempo.Start();
            double num1 = Sumatoria1();
            double num2 = Sumatoria2();
            double num3 = Sumatoria3();
            double Rf = num1 + num2 + num3;
            tiempo.Stop();
            Console.WriteLine(Rf);
            Console.WriteLine(tiempo.Elapsed);
            Console.WriteLine(tiempo.ElapsedMilliseconds);
            ///////////////////////////////////////////////////////////////
            Stopwatch tiempo2 = new Stopwatch();
            Console.WriteLine("\nUsando hilos");
            tiempo2.Start();
            Task<double> suma1 = Task.Run<double>(Sumatoria1);
            Task<double> suma2 = Task.Run<double>(Sumatoria2);
            Task<double> suma3 = Task.Run<double>(Sumatoria3);
            double r1 = await suma1;
            double r2 = await suma2;
            double r3 = await suma3;
            double rf = r1 + r2 + r3;
            tiempo2.Stop();
            Console.WriteLine(rf);
            Console.WriteLine(tiempo2.Elapsed);
            Console.WriteLine(tiempo2.ElapsedMilliseconds);
            ////////////////////////////////////////////////////////////////////
            ///when you create a thread, it takes some extra CPU cycles to create thread context and stack.
            ///cuando crea un subproceso, se necesitan algunos ciclos de CPU adicionales para crear el contexto y la pila del subproceso.
            Console.ReadLine();
        }
        public static double Sumatoria1()
        {
            double sum = 0;
            for(int i = 0; i < 100; i++)
            {
                sum = sum + Math.Pow(i, 2);
            }
            return sum;
        }
        public static double Sumatoria2()
        {
            double sum = 0;
            for (int i = 0; i < 100; i++)
            {
                sum = sum + Math.Pow(i*Math.PI, 2);
            }
            return sum;
        }
        public static double Sumatoria3()
        {
            double sum = 0;
            for (int i = 0; i < 100; i++)
            {
                sum = sum + Math.Pow(i*Math.E, 2);
            }
            return sum;
        }
    }
}
