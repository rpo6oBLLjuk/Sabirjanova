namespace InternalSortingAlgorithms
{
    /// <summary>
    /// Быстрая сортировка (QuickSort)
    /// Выбор опорного элемента: Из массива выбирается один элемент, называемый опорным.
    /// Разделение массива: Все элементы массива сравниваются с опорным и переставляются так,
    ///     чтобы образовались три группы: элементы меньше опорного, равные ему и больше его.
    /// Рекурсивная сортировка: Для подмассивов, содержащих элементы меньше и больше опорного,
    ///     рекурсивно повторяются те же действия.
    /// Сложность: O(n log(n)) - O (n*n)
    /// </summary>
    public class QuickSorter
    {
        public void Sort(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[] array = new int[rows * columns];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[index++] = matrix[i, j];
                }
            }

            QuickSort(array, 0, array.Length - 1);

            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = array[index++];
                }
            }
        }

        private void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        private void Swap(int[] array, int i, int j)
        {
            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}
