using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            string[] lines = File.ReadAllLines("TestCalculations.txt");
            Console.WriteLine(lines[0]);
            //string[] lines = File.ReadAllLines("TestCalculations");
            //Console.WriteLine(lines[0]);
        }
    }
}
