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
            string[] lines = ReadTheFile();

            lines = DeleteSpaces(lines);

            string[] dividedLine = new string[3];

            for (int i = 0; i < lines.Length; i++)
            {
                string result = "";
                DivideTheExpression(dividedLine, lines, i);
                lines[i] = CalculateTheLine(dividedLine[0], dividedLine[1], dividedLine[2], result);
            }

            File.WriteAllLines("output.txt", lines);
        }

        static string[] ReadTheFile()
        {
            return File.ReadAllLines("input.txt");
        }

        static string[] DeleteSpaces(string[] lines)
        {
            for(int s = 0; s < lines.Length; s++)
            {
                var newLine = "";

                for (int i = 0; i < lines[s].Length; i++)
                {
                    if (!char.IsWhiteSpace(lines[s][i]))
                        newLine += lines[s][i];
                }
                lines[s] = newLine;
            }
            return lines;
        }

        static string[] DivideTheExpression(string[] dividedLine, string[] lines, int i)
        {
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

            return dividedLine;
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
                    if (int.Parse(firstNumber) != 0)
                    {
                        result = "1";
                        for (int i = 1; i <= int.Parse(firstNumber); i++)
                            result = Convert.ToString(int.Parse(result) * i);
                    }
                    else result = "1 // 0! = 1 //";
                    break;
            }
            return result;
        }
    }
}
