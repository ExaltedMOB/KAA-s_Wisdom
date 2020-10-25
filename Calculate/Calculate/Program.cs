using System;
using System.Collections.Generic;

namespace Calculate
{
    /*class Program
    {
        enum RomanNumbers: int
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

            Console.ReadKey(true);


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
                    if (((number % 10) % 5 == 0)  ||  ((number % 10) == 1))
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
                }
            }
            return dividedArray;
        }
        
        static void PrintTheConvertedArray(char[] dividedArray)
        {
            foreach (char value in dividedArray)
                Console.Write(value);
        }
    }*/








    public static class RomanNumerals
    {
        //static string Input(string s)
        //{
        //    Console.WriteLine("Give me the number I will decode it into Roman");
        //    return Console.ReadLine();
        //}


        private static readonly Dictionary<char, int> romanDigits =
        new Dictionary<char, int> 
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static int Decode(string s)
        {
            int total = 0;
            int prev = 0;
            foreach (char c in s)
            {
                int curr = romanDigits[c];
                total += curr < prev ? -curr : curr;
                prev = curr;
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in args)
            {
                Console.WriteLine(RomanNumerals.Decode(s));
            }
        }
    }



}
