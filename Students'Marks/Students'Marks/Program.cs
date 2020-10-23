using System;
using System.Runtime.InteropServices;

namespace Students_Marks
{
    class Program
    {
        static string marks;
        static int disciplinesQuantity;
        static int studentsQuantity;
        static string name;
        static string discipline;

        static void Main(string[] args)
        {
            string[][] shedule = AddStudentsQuantity();
            InitializeTheList(shedule);
        }

        static void InitializeTheList(string[][] shedule)
        {
            for (int i = 0; i < studentsQuantity; i++)
            {
                Console.WriteLine("Tell student's name");
                name = Console.ReadLine();

                AddDisciplinesQuantity(shedule,i);
                for (int j = 0; j < disciplinesQuantity; j++)
                {
                    Console.WriteLine("Tell student's discipline");
                    discipline = Console.ReadLine();

                    AddMarks(shedule,i,j);
                    Console.WriteLine(GetAverageMark(shedule, i, j));
                }
            }
        }

        static string[][] AddStudentsQuantity()
        {
            Console.WriteLine("Tell the quantity of students");
            studentsQuantity = int.Parse(Console.ReadLine());
            string[][] shedule = new string[studentsQuantity][];
            return shedule;
        }

        static void AddDisciplinesQuantity(string[][] shedule,int i)
        {
            Console.WriteLine("Tell the quantity of the student's disciplines");
            disciplinesQuantity = int.Parse(Console.ReadLine());
            shedule[i] = new string[disciplinesQuantity];
        }

        static void AddMarks(string[][] shedule,int i,int j)
        {
            Console.WriteLine("Tell the student's discipline's marks");
            marks = Console.ReadLine();
            shedule[i][j] = marks;
        }
        
        static double GetAverageMark(string[][] shedule,int i, int j)
        {
            int summ = 0, count = 0, number = 0;
            double result = 0;

            foreach (char e in shedule[i][j])
                shedule[i][j] = shedule[i][j].Replace(" ", null);

            for (int s = 0; s < shedule[i][j].Length; s++)
            {
                number = Convert.ToInt32((shedule[i][j])[s]);
                summ += number-48;
                count++;
            }
            return
                result = Math.Round((double)summ / count);
        }
    }
}
