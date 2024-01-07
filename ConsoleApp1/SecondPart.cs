using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class SecondPart
    {
        private readonly int[,] matrix;

        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(cols));
            }

            matrix = new int[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public int GetColsWithoutZerosCount()
        {
            int counter = matrix.GetLength(1);

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        counter--;
                        break;
                    }
                }
            }

            return counter;
        }


        public int[,] GetMatrixOrderedByCharacteristics(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int[] characteristics = new int[rows];

            // Рассчитываем характеристику для каждой строки
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                characteristics[i] = sum;
            }

            // Сортируем индексы строк на основе характеристики
            int[] sortedIndices = Enumerable.Range(0, rows)
                                            .OrderBy(i => characteristics[i])
                                            .ToArray();

            // Создаем новую матрицу, переставляя строки по отсортированным индексам
            int[,] reorderedMatrix = new int[rows, matrix.GetLength(1)];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    reorderedMatrix[i, j] = matrix[sortedIndices[i], j];
                }
            }

            return reorderedMatrix; // Возвращаем отсортированную матрицу
        }

    }
}