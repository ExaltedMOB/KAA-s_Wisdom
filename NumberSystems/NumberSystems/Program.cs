using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;

namespace NumberSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = InsertTheNumber();
            string[] reversedCount = new string[input.Length];
            for (int z = 0; z < input.Length; z++)
                reversedCount[input.Length - z - 1] = Convert.ToString(input[z]);

            var countBase = InsertOriginalSystem();
            var convertedBase = InsertConvertedSystem();
            Console.Clear();

            PrintTheResult(reversedCount, countBase, convertedBase, input);
            Console.ReadKey();
        }


        //1) перевод из любой в любую систему счисления но я не стал добавлять после конца латинского алфавита символы ( на мой взгляд в программе это можно встроить одним движением примерно в 57 строке)
        //                                                                
        //2) перевод в римские 

        static string InsertTheNumber()
        {
            Console.WriteLine("Enter the number");
            return Console.ReadLine(); 
        }

        static int InsertOriginalSystem()
        {
            Console.WriteLine("Enter the number's base");
            return int.Parse(Console.ReadLine());
        }

        static int InsertConvertedSystem()
        {
            Console.WriteLine("Enter the converted number's base");
            return int.Parse(Console.ReadLine());
        }

        static string[] SetPowArray(string[] reversedCount)                                           
        {
            for (int i = 0; i < reversedCount.Length; i++)
            {
                try
                {
                    Convert.ToInt32(reversedCount[i]);
                }
                catch
                {
                    for (char s = 'A'; s <= 'Z'; s++)
                        for (int index = 10; index < 26; index++)
                            if (reversedCount[i] == Convert.ToString(s))
                                reversedCount[i] = Convert.ToString(index);
                }
                Console.WriteLine($"Index ={i} numeral ={reversedCount[i]}");
            }
            return reversedCount;
        }

        static int CalculateDecimal(int countBase,string[] reversedCount)
        {
            var decimalCount = 0;

            for (int i = 0; i < reversedCount.Length; i++)
            {
                decimalCount += Convert.ToInt32(reversedCount[i]) * (int)Math.Pow(countBase, i);
                Console.WriteLine($"{reversedCount[i]} * ({countBase} ^ {i}) = {decimalCount} ");
            }
            Console.WriteLine();
            Console.WriteLine("Now we got the decimal value!");
            Console.WriteLine();

            return decimalCount;
        }

        static void PrintTheResult(string[] reversedCount,int countBase, int convertedBase,string input)
        {
            Console.WriteLine($"We need to perform number: {input} which base is {countBase} into the number with base equal to: {convertedBase}");
            Console.WriteLine();
            Console.WriteLine($"Our first step is to build an inverted format (where the indexes from 0 to {Convert.ToString(reversedCount).Length - 1} are equal to the pows)");
            Console.WriteLine();
            SetPowArray(reversedCount);
            Console.WriteLine();
            Console.WriteLine($"The next step is to multiply each element of the array by the base = {countBase} extented to power of each index and summ the multiplies");
            Console.WriteLine();
            Console.WriteLine(CalculateConverted(convertedBase, countBase, reversedCount));
            Console.WriteLine();
        }

        static string CalculateConverted(int convertedBase, int countBase, string[] reversedCount)
        {
            var tempDecimal = CalculateDecimal(countBase, reversedCount);
            string convertedCount = null;
            

            if (convertedBase == 10)
                return convertedCount;
            else
            {
                Console.WriteLine($"Now we need to convert the number from decimal to the number with base: {convertedBase}");
                Console.WriteLine();
                Console.WriteLine($"We must divide the decimal number by {convertedBase} and write the rests from the the last decimal_number/base to the first rest");
                Console.WriteLine();
                int index = 10;
                char s = 'A';

                while (tempDecimal > convertedBase)
                {
                    Console.WriteLine($"{tempDecimal} % {convertedBase} = {tempDecimal % convertedBase}");
                    Console.WriteLine();

                    if (tempDecimal % convertedBase > 9)
                    {
                        while (tempDecimal % convertedBase != index) 
                        {
                            index ++;
                            s ++;
                        } 

                        convertedCount += s;
                    }
                    else convertedCount += Convert.ToString(tempDecimal % convertedBase);

                    tempDecimal /= convertedBase;
                }

                int indexLast = 10;
                char sLast = 'A';

                if (tempDecimal > 9)
                {
                    while(tempDecimal != indexLast)
                    {
                        indexLast++;
                        sLast++;
                    }

                    convertedCount += sLast;
                }
                else convertedCount += Convert.ToString(tempDecimal);

                char[] temporary = convertedCount.ToCharArray();
                Array.Reverse(temporary);
                return new string(temporary);  
            }         
        }
    }
}
