using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace Text_Control
{
    class Program
    {      
        public static void SentSplit(string row)                      // разбиение на предложения
        {
            string[] Stext = row.Split('.', '!', '?');

            Console.WriteLine("Ваш текст, разбитый на предложения:");

            for (int i = 0; i < Stext.Length; i++)
                 Console.WriteLine(Stext[i]); 
        }

        public static void UnicsDefine(string row,string[] words)                   // уникальные слова текста
        {            
            string[] compare = new string[words.Length];
            int kol = 0;
            Console.WriteLine("Уникальные слова из вашего текста:");

            if (true)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    compare[i] = words[i + 1];
                    words[i + 1] = null;
                }

                for (int i = 0; i < words.Length; i++)
                {
                    if (((compare[i] == words[words.Length - 1 - i]) ||
                       (compare[i] == words[i])) == false)
                    {
                        Console.WriteLine(compare[i]);
                        kol = kol++;
                    }
                }
                if (kol > 0)
                    return;
            }
        }

        public static void TheBwordsDefine(string[] words)                // самое длинное слово в тексте (чет/нечет)
        {
            int max = 0;
            string remember = "ky";
            Console.WriteLine("Самое длинное слово (если в нем четное количество букв, " +
                              "то вы увидите вторую половину,иначе центральный символ станет '*')");

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > max)
                {
                    max = words[i].Length;
                    remember = words[i];
                }
            }

            if (max/2==0)
            {
                string rightpart;
                Console.WriteLine(rightpart = remember.Substring(max / 2, max / 2 - max));
            }
            else
            {
                string middle = remember.Substring((max - 1) / 2, 1);
                string brandnew;
                string star = "*";
                Console.WriteLine(brandnew = middle.Replace( middle , star));
            }
        }

       /* public static void Print()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }*/

        public static void Main(string[] args)
        {           
            Console.WriteLine("Введите произвольный текст:");
            string row = Console.ReadLine();
            Console.WriteLine();
            string[] words = row.Split(' ');

            Console.WriteLine($"Количество знаков препинания в тексте:{row.Count(char.IsPunctuation)}");   // колчество знаков препинания
            Console.WriteLine();
            Console.ReadKey();

            SentSplit(row);
            Console.WriteLine();
            Console.ReadKey();

            UnicsDefine(row,words);
            Console.WriteLine();
            Console.ReadKey();

            TheBwordsDefine(words);
            Console.ReadKey();
        }
    }
}
