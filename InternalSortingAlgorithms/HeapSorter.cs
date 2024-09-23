namespace InternalSortingAlgorithms
{
    /// <summary>
    /// Бинарная пирамидальная сортировка, также известная как пирамидальная сортировка или Heap Sort,
    ///     — это алгоритм сортировки, который использует структуру данных, называемую бинарной кучей.
    /// Этот алгоритм эффективен и имеет временную сложность O(n log(n)).
    /// Основные шаги пирамидальной сортировки:
    /// Построение кучи: Преобразование массива в бинарную кучу.
    /// Сортировка: Повторное извлечение максимального элемента из кучи и его перемещение в конец массива,
    ///     затем восстановление свойства кучи для оставшихся элементов.
    /// </summary>
    public class HeapSorter
    {
        public void Sort(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] array = new int[rows * cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[index++] = matrix[i, j];
                }
            }

            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, array.Length, i);
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                (array[i], array[0]) = (array[0], array[i]);
                Heapify(array, i, 0);
            }

            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = array[index++];
                }
            }
        }

        private void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                (array[largest], array[i]) = (array[i], array[largest]);
                Heapify(array, n, largest);
            }
        }
    }
}

