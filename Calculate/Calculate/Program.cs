using System;
using System.Collections.Generic;

namespace Calculate
{
    class Program
    {
        enum RomanNumbers : int
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }

        const char one = 'I';
        const char five = 'V';
        const char ten = 'X';
        const char fifty = 'L';
        const char oneHundred = 'C';
        const char fiveHundred = 'D';
        const char thousand = 'M';

        static void Main(string[] args)
        {
            int number = int.Parse(ReadTheNumber());

            string numberString = Convert.ToString(number);
            char[] dividedArray = new char[numberString.Length];

            dividedArray = DivideTheNumber(number, numberString, dividedArray);

            PrintTheConvertedArray(BuildRomanStyle(dividedArray));

            //Console.WriteLine((int)RomanNumbers.X);
        }

        static string ReadTheNumber()
        {
            Console.WriteLine("Give me the number to convert it to the Roman_Style");
            return Console.ReadLine();
        }

        static char[] DivideTheNumber(int number, string numberString, char[] dividedArray)
        {
            int rank = 1;
            while (number != 0)
            {
                for (int i = 0; i < numberString.Length; i++)
                {
                    if (((number % 10) % 5 == 0) || ((number % 10) == 1))
                    {
                        dividedArray[numberString.Length - i - 1] = Convert.ToChar((number % 10) * rank);
                        rank *= 10;
                        number /= 10;
                    }
                }
            }
            return dividedArray;
        }

        static char[] BuildRomanStyle(char[] dividedArray)
        {
            for (int s = 0; s < dividedArray.Length; s++)
            {
                switch (Convert.ToInt32(dividedArray[s]))
                {
                    case 1:
                        dividedArray[s] = one;
                        break;
                    case 5:
                        dividedArray[s] = five;
                        break;
                    case 10:
                        dividedArray[s] = ten;
                        break;
                    case 50:
                        dividedArray[s] = fifty;
                        break;
                    case 100:
                        dividedArray[s] = oneHundred;
                        break;
                    case 500:
                        dividedArray[s] = fiveHundred;
                        break;
                    case 1000:
                        dividedArray[s] = thousand;
                        break;
                    default:
                        ConvertTheIrregulars(dividedArray);
                        break;
                }
            }
            return dividedArray;
        }

        static char[] ConvertTheIrregulars(char[] dividedArray)
        {   
            for (int i = 0; i < dividedArray.Length; i++)
            {
                if (Convert.ToInt32(dividedArray[i]) < 4) 
                {
                    var count = 0;
                    char temp = ' ';

                    while (Convert.ToInt32(dividedArray[i]) != count)
                    {
                        temp += one;
                        count++;
                    }

                    dividedArray[i] = temp;
                }
            }

            return dividedArray;
        }

        static void PrintTheConvertedArray(char[] dividedArray)
        {
            foreach (char value in dividedArray)
                Console.Write(value);
        }
    }
}
