using System;

namespace Array_sJob
{
    class Program
    {
        public static int[] arrayMain1D;
        public static int[,] arrayMain2D;
        public static int[] subArray1D;
        public static int[,] subArray2D;

        static void Main(string[] args)
        {
            int[] array1D = new int[0];
            int[,] array2D = new int[0, 0];

            int arrayLength = 0;
            int arrayWidth = 0;

            CreateAndFillMainArray(array1D, array2D, arrayLength, arrayWidth);
            CreateAndFillSubArray(array1D, array2D, arrayLength, arrayWidth);

            if (arrayMain1D.Rank == 1)
                Console.WriteLine(DecideIsSubArrayCase1(arrayMain1D, subArray1D));
            else if (subArray1D.Rank == 1) 
                Console.WriteLine(DecideIsSubArrayCase2(arrayMain2D, subArray1D));
            else
                Console.WriteLine(DecideIsSubArrayCase3(arrayMain2D, subArray2D));
        }

        static int Initialize1D()
        {
            Console.WriteLine("Tell the array's length");
            return int.Parse(Console.ReadLine());
        }

        static int Initialize2D()
        { 
            Console.WriteLine("Tell the array's width");
            return int.Parse(Console.ReadLine());
        }

        static int DefineArrayRank()
        {   
            Console.WriteLine("Tell the array's rank");
            return int.Parse(Console.ReadLine());
        }

        static int[] FillArray1D(int[] array1D)
        {
            Console.WriteLine("Tell the array's elements");
            for (int i = 0; i < array1D.Length; i++)
                array1D[i] = int.Parse(Console.ReadLine());
            return array1D;
        }

        static int[,] FillArray2D(int arrayLength, int arrayWidth, int[,] array2D)
        {
            Console.WriteLine("Tell the array's elements");
            for (int i = 0; i < arrayLength; i++)
                for (int j = 0; j < arrayWidth; j++)
                    array2D[i,j] = int.Parse(Console.ReadLine());
            return array2D;
        }

        static bool CheckAndFillArray(int arrayLength, int arrayWidth,ref int[] array1D,ref int[,] array2D)
        {
            if (DefineArrayRank() == 1)
            {
                arrayLength = Initialize1D();
                array1D = new int[arrayLength];
                array1D = FillArray1D(array1D);
                return true;
            }
            else
            {
                arrayLength = Initialize1D();
                arrayWidth = Initialize2D();
                array2D = new int[arrayLength, arrayWidth];
                array2D = FillArray2D(arrayLength, arrayWidth, array2D);
                return false;
            }
        }

        static void CreateAndFillMainArray(int[] array1D, int[,] array2D, int arrayLength, int arrayWidth)
        {
            Console.WriteLine("Create the main_array");
            Console.WriteLine();

            if (CheckAndFillArray(arrayLength, arrayWidth,ref array1D,ref array2D))
                arrayMain1D = array1D;
            else
                arrayMain2D = array2D;

            Console.Clear();
        }

        static void CreateAndFillSubArray(int[] array1D, int[,] array2D, int arrayLength, int arrayWidth)
        {
            Console.WriteLine("Create the sub_array");
            Console.WriteLine();

            if (CheckAndFillArray(arrayLength, arrayWidth,ref array1D,ref array2D))
                subArray1D = array1D;
            else
                subArray2D = array2D;

            Console.Clear();
        }

        static string DecideIsSubArrayCase1(int[] arrayMain1D, int[] subArray1D)
        {
            for (var i = 0; i < arrayMain1D.Length - subArray1D.Length + 1; i++)
                if (ContainsAtIndex(arrayMain1D, subArray1D, i))
                    return Convert.ToString(true);
            return Convert.ToString(false);

            static bool ContainsAtIndex(int[] arrayMain1D, int[] subArray1D, int i)
            {
                foreach (int element in subArray1D)
                    if (arrayMain1D[i] != element) return false;
                    else i++;
                return true;

                //for (int k = 0; k < subArray1D.Length; k++)
                //    if (arrayMain1D[i] != subArray1D[k])
                //        return false;
                //return true;
            }
        }

        static string DecideIsSubArrayCase2(int[,] arrayMain2D, int[] subArray1D)
        {
            var j = 0;
            for (var i = 0; i < arrayMain2D.Length - subArray1D.Length + 1; i++)
                if (ContainsAtIndex(arrayMain2D, subArray1D, i, j))
                    return Convert.ToString(true);
            return Convert.ToString(false);

            static bool ContainsAtIndex(int[,] arrayMain2D, int[] subArray1D, int i, int j)
            {
                foreach (int element in subArray1D)
                    if (arrayMain2D[i, j] != element) return false;
                    else
                    {
                        i++;
                        j++;
                    }
                return true;
            }
        }

        static string DecideIsSubArrayCase3(int[,] arrayMain2D, int[,] subArray2D)
        {
            var j = 0;
            for (var i = 0; i < arrayMain2D.Length - subArray2D.Length + 1; i++)
                if (ContainsAtIndex(arrayMain2D, subArray2D, i, j))
                    return Convert.ToString(true);
            return Convert.ToString(false);

            static bool ContainsAtIndex(int[,] arrayMain2D, int[,] subArray1D, int i, int j)
            {
                foreach (int element in subArray1D)
                    if (arrayMain2D[i, j] != element) return false;
                    else
                    {
                        i++;
                        j++;
                    }
                return true;
            }
        }
    }
}
