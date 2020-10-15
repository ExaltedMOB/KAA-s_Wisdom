using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число, я посчитаю факториал и выведу ответ в 'шикарной' рамочке");
            var number = Convert.ToUInt64(Console.ReadLine());
            ReleaseEpilepsy(number);
        }

        static void FormatNPrintTheRow(ulong result)
        {
            string middle = $"║     {DefineFact((ulong) result)}     ║";
            string symbol = "═";
            string upper = "";
            string lower = "";

            for (int i = 0; i <= middle.Length - 4; i++)
            {
                symbol += "═";
                upper = $"╔{symbol}╗";
                lower = $"╚{symbol}╝";
            }

            Console.WriteLine(upper);
            Console.WriteLine(middle);
            Console.WriteLine(lower);
        }

        static int DefineFact(ulong number)
        {
            int result = 1;

            for (int i = 1; i <= (int)number; i++)
            {          
                result *= i;
            }
            return result;
        }

        private static void ReleaseEpilepsy(ulong number)
        { 
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                FormatNPrintTheRow(number);
                Thread.Sleep(100);
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                FormatNPrintTheRow(number);
                Thread.Sleep(100);
                Console.Clear();

                Console.ResetColor();
            }
        }
    }
}
