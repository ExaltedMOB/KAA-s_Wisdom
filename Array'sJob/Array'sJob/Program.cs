using System;

namespace Array_sJob
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void InitializeArrays(int[,] array2,int[] array1, int[,] subArray)
        {
            Console.WriteLine("Enter the array's rank");
            var arrayRank = int.Parse(Console.ReadLine());
            if (arrayRank == 1)
            {
                Console.WriteLine("Enter the length of the array");
                var arrayWidth = int.Parse(Console.ReadLine());
                var arrayLength = int.Parse(Console.ReadLine());
                array1 = new int[arrayLength];
            }
            else if (arrayRank == 2)
            {
                Console.WriteLine("Enter the length of the array")
            }

            Console.WriteLine("Enter the width of the subarray");
            var subArrayWidth = int.Parse(Console.ReadLine());
            var subArrayLength = int.Parse(Console.ReadLine());
            subArray = new int[subArrayWidth, subArrayLength];
        }

        static void FillArrays()
        {
            
        }

        static void FindSubarrayStartIndex(int[,] array,int[,] subArray)
        {
            InitializeArrays(array,subArray);
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
            {
                if (ContainsAtIndex(array, subArray, i))
                    Console.WriteLine("true");
                else Console.WriteLine("false");
            }
        }

        static bool ContainsAtIndex(int[,] array, int[,] subArray, int i)
        {
            for (int k = 0; k < subArray.Length; k++)
                if (array != subArray)
                    return false;
            return true;
        }
    }
}
