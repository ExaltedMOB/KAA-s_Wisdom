using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Calculate
{
    class Program
    {
        //public static int converted = 0;

        static void Main(string[] args)
        {
            char one = 'I';
            char five = 'V';
            char ten = 'X';
            char fifty = 'L';
            char oneHundred = 'C';
            char fiveHundred = 'D';
            char thousand = 'M';
            char fiveThousand = 'F';
            char tenThousand = 'T';

            
            var index = 0;

            string number = ReadTheNumber();
            string[] convertedArray = new string[number.Length];

            if (int.TryParse(number, out int result))
                PrintTheConvertedArray(BuildTheRomanNumber(number, convertedArray, one, five, ten, fifty, oneHundred, fiveHundred, thousand, fiveThousand, tenThousand, index));
            //else
            //    Console.WriteLine(ConvertBack(number, convertedArray, one, five, ten, fifty, oneHundred, fiveHundred, thousand, fiveThousand, tenThousand, index));

            Console.ReadKey();
        }

        static string ReadTheNumber()
        {
            Console.WriteLine("'F' represents 5000 and 'T' stands for 10000");
            Console.WriteLine("Let's convert a number to Roman style or vice versa!");
            return Console.ReadLine();
        }
        
        static string ConvertASymbol(string input, string[] convertedArray, char situationalOne, char situationalFive, char situationalTen, int index)
        {
            if ((Convert.ToInt32(Convert.ToString(input[index])) > 0) && (Convert.ToInt32(Convert.ToString(input[index])) < 4))           // from 1 to 3
            {
                for (int i = 0; i < Convert.ToInt32(Convert.ToString(input[index])); i++)
                    convertedArray[index] += situationalOne;
            }
            else if (Convert.ToInt32(Convert.ToString(input[index])) == 4)                   // 4
                convertedArray[index] = situationalOne + situationalFive.ToString();
            else if (Convert.ToInt32(Convert.ToString(input[index])) == 5)                   // 5
                convertedArray[index] = situationalFive.ToString();
            else if ((Convert.ToInt32(Convert.ToString(input[index])) > 5) && (Convert.ToInt32(Convert.ToString(input[index])) < 9))              // from 6 to 8
            {
                convertedArray[index] = situationalFive.ToString();
                for (int k = 0; k < Convert.ToInt32(Convert.ToString(input[index])) - 5; k++)
                    convertedArray[index] += situationalOne;
            }
            else if (Convert.ToInt32(Convert.ToString(input[index])) == 9)                   // 9
                convertedArray[index] = situationalOne + situationalTen.ToString();
            else if (Convert.ToInt32(Convert.ToString(input[index])) == 0)                       // empty case : just roll over
                return convertedArray[index];
            return convertedArray[index];
        }

        static string[] BuildTheRomanNumber(string inputnumber, string[] convertedArray, char one, char five, char ten, char fifty, char oneHundred, char fiveHundred, char thousand, char fiveThousand, char tenThousand, int index)
        { 
            switch (inputnumber.Length)
            {
                case 1:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, one, five, ten, index);
                    break;
                case 2:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, ten, fifty, oneHundred, index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, one, five, ten, index);
                    break;
                case 3:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, oneHundred, fiveHundred, thousand, index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, ten, fifty, oneHundred, index);
                    index = 2;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, one, five, ten, index);
                    break;
                case 4:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, thousand, fiveThousand, tenThousand, index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, oneHundred, fiveHundred, thousand, index);
                    index = 2;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, ten, fifty, oneHundred, index);
                    index = 3;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, one, five, ten, index);
                    break;
            }
            return convertedArray;
        }

        static void PrintTheConvertedArray(string[] convertedArray)
        {
            foreach (string value in convertedArray)
                Console.Write(value);
        }

        //static string ConvertBack(string number, string[] convertedArray, char one, char five, char ten, char fifty, char oneHundred, char fiveHundred, char thousand, char fiveThousand, char tenThousand, int index)
        //{
        //    for (converted = 1; ; converted++)
        //    {
        //        if (BuildStringFromArray(convertedArray, one, five, ten, fifty, oneHundred, fiveHundred, thousand, fiveThousand, tenThousand, index) == number)
        //            break;
        //    }
        //    return Convert.ToString(converted);
        //}

        //static string BuildStringFromArray(string[] convertedArray, char one, char five, char ten, char fifty, char oneHundred, char fiveHundred, char thousand, char fiveThousand, char tenThousand, int index)
        //{
        //    string rowArray = "";
        //    string[] temp = BuildTheRomanNumber(Convert.ToString(converted), convertedArray, one, five, ten, fifty, oneHundred, fiveHundred, thousand, fiveThousand, tenThousand, index);
        //    for (int i = 0; i < temp.Length; i++)
        //        rowArray += temp[i];
        //    return rowArray;
        //}
    }
}
