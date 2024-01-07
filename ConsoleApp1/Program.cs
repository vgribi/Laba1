using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);

            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Сумма положительных: " + firstPart.GetSumOfNegativeElements());
            Console.WriteLine("Произведение между Min по модулю & Max по модулю: " + firstPart.GetMultiplicationBetweenMinMax());

            firstPart.SortByDescending();
            Console.WriteLine("После сортировки по убыванию:");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Часть 2:");

            var secondPart = new SecondPart(4, 5);
            PrintMatrix(secondPart.Matrix);
            Console.WriteLine("Столбцов без нулей: " + secondPart.GetColsWithoutZerosCount());

            int[,] NewMatrix = secondPart.GetMatrixOrderedByCharacteristics(secondPart.Matrix);
            PrintMatrix(NewMatrix);
        }

        static void PrintVector(IEnumerable<int> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}