using System;
using System.Net.NetworkInformation;

namespace NumberSystems
{
    class Program
    {
        static void Main(string[] args)
        {

            var count = InsertTheNumber();
            var countBase = InsertOriginalSystem();
            var convertedBase = InsertConvertedSystem();
            int[] powArray = new int[Convert.ToString(count).Length];
            Console.Clear();

            PrintTheResult(count, countBase, powArray, convertedBase);
            Console.ReadKey();
        }

        //1) перевод в любую систему счисления но к сожалению без A,B... (не успел допилить + вышло нагромождение принтов из-за просьбы "для пятиклассника" +
        //                                                                 + из-за них стало тяжело читать код а как отдельно их сделать я не придумал)
        //2) перевод в римские 

        static int InsertTheNumber()
        {
            Console.WriteLine("Enter the number");
            return int.Parse(Console.ReadLine()); 
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
                                                                                                          //   powArray[index](further pow)          =    0 1 2     
        static int[] SetToPowArray(int count,int[] powArray)                                         // perform the count as in ex.: number 135  ---->    5 3 1   
        {
            var temp = count;

            while (temp != 0)
            {
                for (int i = 0; i < Convert.ToString(count).Length; i++)
                {
                    powArray[i] = temp % 10;
                    Console.WriteLine($"Index ={i} numeral ={powArray[i]}");
                    temp /= 10;
                }
            } 

            return powArray;
        }

        static int CalculateDecimal(int countBase, int[] powArray)
        {
            var decimalCount = 0;

            for (int i = 0; i < powArray.Length; i++)
            {
                decimalCount += powArray[i] * (int)Math.Pow(countBase, i);
                Console.WriteLine($"{powArray[i]} * ({countBase} ^ {i}) = {decimalCount} ");
            }
            Console.WriteLine();
            Console.WriteLine("Now we got the decimal value!");
            Console.WriteLine();
            return decimalCount;
        }

        static void PrintTheResult(int count,int countBase,int[] powArray,int convertedBase)
        {
            Console.WriteLine($"We need to perform number: {count} which base is {countBase} into the number with base equal to: {convertedBase}");
            Console.WriteLine();
            Console.WriteLine($"Our first step is to build an inverted format (where the indexes from 0 to {Convert.ToString(count).Length - 1} are equal to the pows)");
            Console.WriteLine();
            SetToPowArray(count, powArray);
            Console.WriteLine();
            Console.WriteLine($"The next step is to multiply each element of the array by the base = {countBase} extented to power of each index and summ the multiplies");
            Console.WriteLine();
            Console.WriteLine(CalculateConverted(convertedBase, countBase, powArray));
            Console.WriteLine();
        }

        static string CalculateConverted(int convertedBase,int countBase,int[] powArray)
        {
            var tempDecimal = CalculateDecimal(countBase, powArray);
            string convertedCount = null;

            if (convertedBase == 10)
                return convertedCount;
            else
            {
                Console.WriteLine($"Now we need to convert the number from decimal to the number with base: {convertedBase}");
                Console.WriteLine();
                Console.WriteLine($"We must divide the decimal number by {convertedBase} and write the rests from the the last decimal_number/base to the first rest");
                Console.WriteLine();

                while (tempDecimal > convertedBase)
                {
                    Console.WriteLine($"{tempDecimal} % {convertedBase} = {tempDecimal % convertedBase}");
                    Console.WriteLine();

                    convertedCount += Convert.ToString(tempDecimal % convertedBase);
                    tempDecimal = tempDecimal / convertedBase;
                }

                convertedCount += Convert.ToString(tempDecimal % convertedBase);

                char[] reversedCount = convertedCount.ToCharArray();
                Array.Reverse(reversedCount);
                return new string(reversedCount);  
            }         
        }
    }
}
