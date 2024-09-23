namespace InternalSortingAlgorithms
{
    /// <summary>
    /// Сортировка слиянием (Merge Sort)
    /// Разделение массива: Исходный массив делится на две примерно равные части.
    /// Рекурсивная сортировка: Каждая из частей сортируется рекурсивно тем же алгоритмом.
    /// Слияние: Два отсортированных подмассива объединяются в один отсортированный массив.
    /// Сложность: O(n * log(n))
    /// </summary>
    public class MergeSorter
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

            MergeSort(array, 0, array.Length - 1);

            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = array[index++];
                }
            }
        }

        private void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private void Merge(int[] array, int left, int middle, int right)
        {
            int leftSize = middle - left + 1;
            int rightSize = right - middle;
            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            Array.Copy(array, left, leftArray, 0, leftSize);
            Array.Copy(array, middle + 1, rightArray, 0, rightSize);

            int i = 0, j = 0, k = left;
            while (i < leftSize && j < rightSize)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            while (i < leftSize)
            {
                array[k++] = leftArray[i++];
            }

            while (j < rightSize)
            {
                array[k++] = rightArray[j++];
            }
        }
    }
}
