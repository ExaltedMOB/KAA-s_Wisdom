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
        public static void Sentences(string row)
        {
            string[] Stext = row.Split('.', '!', '?');

            Console.WriteLine("Ваш текст, разбитый на предложения:");

            for (int i = 0; i < Stext.Length; i++)
                Console.WriteLine(Stext[i]);
        }

        public static void Unics(string row,string[] Words)
        {            
            string[] compare = new string[Words.Length];
            int kol = 0;
            Console.WriteLine("Уникальные слова из вашего текста:");

            if (true)
            {
                for (int i = 0; i < Words.Length; i++)
                {
                    compare[i] = Words[i + 1];
                    Words[i + 1] = null;
                }

                for (int i = 0; i < Words.Length; i++)
                {
                    if (((compare[i] == Words[Words.Length - 1 - i]) ||
                       (compare[i] == Words[i])) == false)
                    {
                        Console.WriteLine(compare[i]);
                        kol = kol++;
                    }
                }

                if (kol == 0)
                    return;
            }
        }

        public static void BiggestWords(string[] Words)
        {
            int max = 0;
            string remember = "ky";
            Console.WriteLine("Самое длинное слово (если в нем четное количество букв, " +
                              "то вы увидите вторую половину,иначе центральный символ станет '*')");

            for (int i = 0; i < Words.Length; i++)
            {
                if (Words[i].Length > max)
                {
                    max = Words[i].Length;
                    remember = Words[i];
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

        public static void Main(string[] args)
        {           
            Console.WriteLine("Введите произвольный текст:");
            string row = Console.ReadLine();
            Console.WriteLine();
            string[] Words = row.Split(' ');

            Console.WriteLine($"Количество знаков препинания в тексте:{row.Count(char.IsPunctuation)}");
            Console.WriteLine();
            Console.ReadKey();

            Sentences(row);
            Console.WriteLine();
            Console.ReadKey();

            Unics(row,Words);
            Console.WriteLine();
            Console.ReadKey();

            BiggestWords(Words);
            Console.ReadKey();
        }
    }
}
