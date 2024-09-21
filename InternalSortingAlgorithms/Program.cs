using System.Text;

namespace InternalSortingAlgorithms
{
    class InternalSortingAlgorithms
    {
        private static readonly HeapSorter heapSorter = new();
        private static readonly ShellSorter shellSorter = new();

        public static int[,] BaseMatrix
        {
            get 
            {
                Console.WriteLine("Матрица сброшена до базовой"); Console.WriteLine();
                return (int[,])baseMatrix.Clone(); //boxing|unboxing
            } 
        }
        private static int[,] baseMatrix = {
                { 12, 11, 13 },
                { 5, 6, 7 },
                { 1, 9, 10 }};

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;


            int[,] testMatrix = BaseMatrix;
            heapSorter.Sort(testMatrix);
            PrintMatrix<HeapSorter>(testMatrix);

            testMatrix = BaseMatrix;
            shellSorter.Sort(testMatrix);
            PrintMatrix<ShellSorter>(testMatrix);
        }

        private static void PrintMatrix<T>(int[,] matrix)
        {
            Console.WriteLine($"• Матрица, отсортированная с помощью {typeof(T).Name}:");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("    ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}