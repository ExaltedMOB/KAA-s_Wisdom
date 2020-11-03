using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculate
{
    class Program
    {
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

            var increment = 1;
            var index = 0;

            string number = ReadTheNumber();
            string[] convertedArray = new string[number.Length];

            if (int.TryParse(number, out int result))
                PrintTheConvertedArray(BuildTheRomanNumber(number, convertedArray, one, five, ten, fifty, oneHundred, fiveHundred, thousand, fiveThousand, tenThousand, index));
            else
                Console.Write(ConvertBack(number, increment, convertedArray, one, five, ten, fifty, oneHundred, fiveHundred, thousand, fiveThousand, tenThousand, index));

            Console.ReadKey();
        }

        static string ReadTheNumber()
        {
            Console.WriteLine("'F' will represent 5000 and 'T' will stand for 10000");
            Console.WriteLine("Let's convert a number to Roman style or vice versa!");
            return Console.ReadLine();
        }
        
        static string ConvertASymbol(string number, string[] convertedArray, char situationalOne, char situationalFive, char situationalTen, int index)
        {
            if ((Convert.ToInt32(Convert.ToString(number[index])) > 0) && (Convert.ToInt32(Convert.ToString(number[index])) < 4))           // from 1 to 3
            {
                for (int i = 0; i < Convert.ToInt32(Convert.ToString(number[index])); i++)
                    convertedArray[index] += situationalOne;
            }
            else if (Convert.ToInt32(Convert.ToString(number[index])) == 4)                   // 4
                convertedArray[index] = situationalOne + situationalFive.ToString();
            else if (Convert.ToInt32(Convert.ToString(number[index])) == 5)                   // 5
                convertedArray[index] = situationalFive.ToString();
            else if ((Convert.ToInt32(Convert.ToString(number[index])) > 5) && (Convert.ToInt32(Convert.ToString(number[index])) < 9))              // from 6 to 8
            {
                convertedArray[index] = situationalFive.ToString();
                for (int k = 0; k < Convert.ToInt32(Convert.ToString(number[index])) - 5; k++)
                    convertedArray[index] += situationalOne;
            }
            else if (Convert.ToInt32(Convert.ToString(number[index])) == 9)                   // 9
                convertedArray[index] = situationalOne + situationalTen.ToString();
            else if (Convert.ToInt32(Convert.ToString(number[index])) == 0)                       // empty case : just roll over
                return convertedArray[index];
            return convertedArray[index];
        }

        static string[] BuildTheRomanNumber(string number, string[] convertedArray, char one, char five, char ten, char fifty, char oneHundred, char fiveHundred, char thousand, char fiveThousand, char tenThousand, int index)
        { 
            switch (number.Length)
            {
                case 1:
                    convertedArray[index] = ConvertASymbol(number, convertedArray, one, five, ten, index);
                    break;
                case 2:
                    convertedArray[index] = ConvertASymbol(number, convertedArray, ten, fifty, oneHundred, index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(number, convertedArray, one, five, ten, index);
                    break;
                case 3:
                    convertedArray[index] = ConvertASymbol(number, convertedArray, oneHundred, fiveHundred, thousand, index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(number, convertedArray, ten, fifty, oneHundred, index);
                    index = 2;
                    convertedArray[index] = ConvertASymbol(number, convertedArray, one, five, ten, index);
                    break;
                case 4:
                    convertedArray[index] = ConvertASymbol(number, convertedArray, thousand, fiveThousand, tenThousand, index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(number, convertedArray, oneHundred, fiveHundred, thousand, index);
                    index = 2;
                    convertedArray[index] = ConvertASymbol(number, convertedArray, ten, fifty, oneHundred, index);
                    index = 3;
                    convertedArray[index] = ConvertASymbol(number, convertedArray, one, five, ten, index);
                    break;
            }
            return convertedArray;
        }

        static void PrintTheConvertedArray(string[] convertedArray)
        {
            foreach (string value in convertedArray)
                Console.Write(value);
        }

        static int ConvertBack(string number, int increment, string[] convertedArray, char one, char five, char ten, char fifty, char oneHundred, char fiveHundred, char thousand, char fiveThousand, char tenThousand, int index)
        {
            while(BuildTheRomanNumber(Convert.ToString(increment), convertedArray, one, five, ten, fifty, oneHundred, fiveHundred, thousand, fiveThousand, tenThousand, index).ToString() != number)
            {
                increment++;
            }
            return increment;
        }
    }
}
