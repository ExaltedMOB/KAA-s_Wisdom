using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Directory.GetCurrentDirectory());
            string[] lines = File.ReadAllLines("input.txt");

            string newLine = "";
            lines = DeleteSpaces(lines, newLine);

            string[] dividedLine = new string[3];
            string[] output = new string[lines.Length];
            output = DivideTheExpression(dividedLine, lines, output);

            File.WriteAllLines("output.txt", output);
        }

        static string[] DeleteSpaces(string[] lines, string newLine)
        {
            for(int s = 0; s < lines.Length; s++)
            {
                for(int i = 0; i < lines[s].Length; i++)
                {
                    if (!char.IsWhiteSpace(lines[s][i]))
                        newLine += lines[s][i];
                }
                lines[s] = newLine;
            }
            return lines;
        }

        static string[] DivideTheExpression(string[] dividedLine, string[] lines, string[] output)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string result = "";
                var index = 0;

                foreach (char symbol in lines[i])
                {
                    if (!int.TryParse(Convert.ToString(symbol), out int empty))
                    {
                        index = lines[i].IndexOf(symbol);
                        dividedLine[1] = Convert.ToString(symbol);
                    }
                }
                dividedLine[0] = lines[i].Substring(0, index);
                dividedLine[2] = lines[i].Substring(index + 1);

                output[i] = CalculateTheLine(dividedLine[0],dividedLine[1],dividedLine[2], result);
            }
            return output;
        }

        static string CalculateTheLine(string firstNumber, string operation, string secondNumber,string result)
        {
            switch (operation)
            {
                case "+":
                    result = Convert.ToString(int.Parse(firstNumber) + int.Parse(secondNumber));
                    break;
                case "-":
                    result = Convert.ToString(int.Parse(firstNumber) - int.Parse(secondNumber));
                    break;
                case "*":
                    result = Convert.ToString(int.Parse(firstNumber) * int.Parse(secondNumber));
                    break;
                case "/":
                    if (int.Parse(secondNumber) != 0)
                    {
                        result = Convert.ToString(int.Parse(firstNumber) / int.Parse(secondNumber));
                    }
                    else result = "Invalid Operation! // n/0 ! //";
                    break;
                case "!":
                    for(int i = 1; i <= int.Parse(firstNumber); i++)
                        result = Convert.ToString(int.Parse(result)*i);
                    return Convert.ToString(result);
            }
            return result;
        }
    }
}
