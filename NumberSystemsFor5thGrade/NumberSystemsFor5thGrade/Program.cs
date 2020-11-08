using System;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security;
using System.Threading;

namespace Calculate
{
    class Program
    {
        static void Main(string[] args)
        {   
            string symbols = "IVXLCDMFT";
            string[] equalties = new string[9] { "1", "5", "10", "50", "100", "500", "1000", "5000", "10000" };

            char[] alphabet = new char[symbols.Length];
            alphabet = symbols.ToCharArray();


            var row = "";
            var index = 0;

            switch (ChooseTheOption(row))
            {
                case 1:                                                                                                  //case Number_Systems
                    ChooseCaseSystems(row);
                    break;
                case 2:                                                                                                   //case Roman_Numbers
                    ChooseCaseRoman(row, alphabet, index, equalties);
                    break;
                case 3:                                                                                                  //case Real_Numbers
                    Console.WriteLine("NOT YET DONE");
                    break;
            }
        }

        static void ChooseCaseSystems(string row)
        {
            var input = AproveTheNumber(row);
            Console.WriteLine("Input the number's base");
            var countBase = int.Parse(AproveTheNumber(row));
            Console.WriteLine("Input tne converting base");
            var convertedBase = int.Parse(AproveTheNumber(row));
            Console.Clear();

            string[] reversedCount = new string[input.Length];
            for (int z = 0; z < input.Length; z++)
                reversedCount[input.Length - z - 1] = Convert.ToString(input[z]);

            PrintTheResult(reversedCount, countBase, convertedBase, input);
            Console.ReadKey();
        }

        static void ChooseCaseRoman(string row,char[] alphabet,int index,string[] equalties)
        {
            var number = AproveTheNumber(row);

            string[] convertedArray = new string[number.Length];

            var k = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                Console.WriteLine($"{alphabet[i]} --- {equalties[k]}");
                k++;
            }

            Console.WriteLine();
            Console.WriteLine($"Now let us convert {number} to Roman style :");
            Console.WriteLine();
            Console.WriteLine("If the left standing number='Left' is less than the dexter one='Right'\r\n" +
                "than we should do the subtraction: 'Right'-'Left', else summ them\r\n" +
                "If you encounter the row of equal symbols also do the summ");
            Console.WriteLine();


            if (int.Parse(number) == 0)
                Console.WriteLine("Nulla");
            else
            {
                Console.WriteLine($"Number {number} converted to Roman is :");
                PrintTheConvertedArray(BuildTheRomanNumber(number, convertedArray, alphabet, index));
            }
            Console.ReadKey();
        }

        static string ReadTheNumber()
        {
            return Console.ReadLine();
        }

        static int ChooseTheOption(string row)                                                                                                                          //Options Menu 
        {
            while (true)
            {
                Console.WriteLine("Choose the options number:\r\n1) Calculate Number_Systems\r\n2) Calculate Roman_Numbers\r\n3) Calculate Real_Numbers");
                row = ReadTheNumber();
                Console.Clear();

                if ((int.TryParse(row, out int result)) && (int.Parse(row) > 0) && (int.Parse(row) < 4))
                        break;
                else
                    Console.WriteLine("Insert the option number correctly!");
            }
            return int.Parse(row);
        }

        static string AproveTheNumber(string row)
        {
            while (true)
            {
                Console.WriteLine("Insert the number : ");
                row = ReadTheNumber();
                Console.Clear();

                if (int.TryParse(row, out int result))
                    break;
                else
                    Console.WriteLine("Insert the number correctly!");
            }
            return row;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////// Roman_Numbers next
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

        static string[] BuildTheRomanNumber(string inputnumber, string[] convertedArray, char[] alphabet, int index)
        {
            switch (inputnumber.Length)
            {
                case 1:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[0], alphabet[1], alphabet[2], index);
                    break;
                case 2:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[2], alphabet[3], alphabet[4], index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[0], alphabet[1], alphabet[2], index);
                    break;
                case 3:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[4], alphabet[5], alphabet[6], index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[2], alphabet[3], alphabet[4], index);
                    index = 2;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[0], alphabet[1], alphabet[2], index);
                    break;
                case 4:
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[6], alphabet[7], alphabet[8], index);
                    index = 1;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[4], alphabet[5], alphabet[6], index);
                    index = 2;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[2], alphabet[3], alphabet[4], index);
                    index = 3;
                    convertedArray[index] = ConvertASymbol(inputnumber, convertedArray, alphabet[0], alphabet[1], alphabet[2], index);
                    break;
            }
            return convertedArray;
        }

        static void PrintTheConvertedArray(string[] convertedArray)
        {
            foreach (string value in convertedArray)
            {
                Thread.Sleep(400);
                Console.Write(value);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////   Number_Systems next
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

        static int CalculateDecimal(int countBase, string[] reversedCount)
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

        static void PrintTheResult(string[] reversedCount, int countBase, int convertedBase, string input)
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

                while (tempDecimal >= convertedBase)
                {
                    Console.WriteLine($"{tempDecimal} % {convertedBase} = {tempDecimal % convertedBase}");
                    Console.WriteLine();

                    if (tempDecimal % convertedBase > 9)
                    {
                        while (tempDecimal % convertedBase != index)
                        {
                            index++;
                            s++;
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
                    while (tempDecimal != indexLast)
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
            ///////////////////////////////////////////////////////////////////////////////////////////// Real_Numbers next
            static void ChooseCaseRealNumbers(string row)
            {
                int[] dividedNumber = new int[2];
                dividedNumber = SplitTheInput(row, dividedNumber);
                dividedNumber[0] = ReverseTheFirstPart(dividedNumber);
            }

            static int[] SplitTheInput(string row, int[] dividedNumber)
            {
                var inputNumber = AproveTheNumber(row);
                string[] temporary = new string[2];
                temporary = inputNumber.Split('.');

                for (int i = 0; i < dividedNumber.Length; i++)
                    dividedNumber[i] = int.Parse(temporary[i]);

                return dividedNumber;
            }

            static int ReverseTheFirstPart(int[] dividedNumber)
            {
                string temp = Convert.ToString(dividedNumber[0]);
                temp.Reverse();
                return int.Parse(temp);
            }
        }
    }
}