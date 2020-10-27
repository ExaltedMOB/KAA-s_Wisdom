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
            string[][] schedule = AddStudentsQuantity();
            InitializeTheList(schedule);
        }

        static void InitializeTheList(string[][] schedule)
        {
            for (int i = 0; i < studentsQuantity; i++)
            {
                Console.WriteLine("Tell student's name");
                name = Console.ReadLine();

                AddDisciplinesQuantity(schedule,i);
                for (int j = 0; j < disciplinesQuantity; j++)
                {
                    Console.WriteLine("Tell student's discipline");
                    discipline = Console.ReadLine();

                    AddMarks(schedule,i,j);
                    Console.WriteLine(GetAverageMark(schedule, i, j));
                }
            }
        }

        static string[][] AddStudentsQuantity()
        {
            Console.WriteLine("Tell the quantity of students");
            studentsQuantity = int.Parse(Console.ReadLine());
            string[][] schedule = new string[studentsQuantity][];
            return schedule;
        }

        static void AddDisciplinesQuantity(string[][] schedule,int i)
        {
            Console.WriteLine("Tell the quantity of the student's disciplines");
            disciplinesQuantity = int.Parse(Console.ReadLine());
            schedule[i] = new string[disciplinesQuantity];
        }

        static void AddMarks(string[][] schedule,int i,int j)
        {
            Console.WriteLine("Tell the student's discipline's marks");
            marks = Console.ReadLine();
            schedule[i][j] = marks;
        }
        
        static double GetAverageMark(string[][] schedule,int i, int j)
        {
            int summ = 0, count = 0, number = 0;
            double result = 0;

            foreach (char e in schedule[i][j])
                schedule[i][j] = schedule[i][j].Replace(" ", null);

            for (int s = 0; s < schedule[i][j].Length; s++)
            {
                number = Convert.ToInt32((schedule[i][j])[s]);
                summ += number-48;
                count++;
            }
            return
                result = Math.Round((double)summ / count);
        }
    }
}
