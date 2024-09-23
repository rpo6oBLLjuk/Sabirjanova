namespace InternalSortingAlgorithms
{
    /// <summary>
    /// Сортировка методом Шелла — это алгоритм сортировки, который является обобщением сортировки вставками.
    /// Этот алгоритм эффективен и имеет временную сложность от O(n log n) до O(n^2) в зависимости от выбора промежутков.
    /// Основные шаги сортировки методом Шелла:
    /// Выбор промежутков: Определение промежутков для сравнения элементов.
    /// Сортировка: Сравнение и обмен элементов, находящихся на определенных промежутках,
    ///     с последующим уменьшением промежутков.
    /// </summary>
    public class ShellSorter
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

            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }

            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = array[index++];
                }
            }
        }
    }
}
