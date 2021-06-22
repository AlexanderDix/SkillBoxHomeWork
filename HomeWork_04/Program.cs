using System;

namespace HomeWork_04
{
    class Program
    {
        /// <summary>
        /// Матрица с доходами компании
        /// </summary>
        private static int[,] _matrixIncome;

        /// <summary>
        /// Матрица с расходами компании
        /// </summary>
        private static int[,] _matrixConsumption;

        /// <summary>
        /// Матрица с прибылью компании
        /// </summary>
        private static int[,] _matrixProfit;

        /// <summary>
        /// Количество колонок для матрицы
        /// </summary>
        private static int _columnsMatrix;

        /// <summary>
        /// Количество строк для матрицы
        /// </summary>
        private static int _rowsMatrix;

        /// <summary>
        /// Переменная для получения псевдослучайных чисел
        /// </summary>
        private static readonly Random Random = new();

        private static void Main()
        {
            Print();
            Console.ReadKey();
        }

        public static void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine($"{"Номер месяца",20} {"Доход, тыс. руб.",20} {"Расход, тыс. руб.",20} {"Прибыль, тыс. руб.",20}");

            Console.ResetColor();

            PrintMatrix();
        }

        /// <summary>
        /// Вывод массивов
        /// </summary>
        public static void PrintMatrix()
        {
            var amount = 200_000;
            var numberMonthPositiveProfit = 0;
            _columnsMatrix = 1;
            _rowsMatrix = 12;
            _matrixIncome = new int[_rowsMatrix, _columnsMatrix];
            _matrixConsumption = new int[_rowsMatrix, _columnsMatrix];
            _matrixProfit = new int[_rowsMatrix, _columnsMatrix];

            for (int i = 0; i < _rowsMatrix; i++)
            {
                // Выводим числа месяцев
                Console.Write($"{i + 1,20}");

                // Заполняем и выводим массив с доходами
                for (int j = 0; j < _columnsMatrix; j++)
                {
                    _matrixIncome[i, j] = Random.Next(amount);
                    Console.Write($"{_matrixIncome[i, j],20}");
                }

                // Заполняем и выводим массив с расходами
                for (int j = 0; j < _columnsMatrix; j++)
                {
                    _matrixConsumption[i, j] = Random.Next(amount);
                    Console.Write($"{_matrixConsumption[i,j],20}");
                }

                // Заполняем и выводим массив с прибылью
                for (int j = 0; j < _columnsMatrix; j++)
                {
                    _matrixProfit[i, j] = _matrixIncome[i, j] - _matrixConsumption[i, j];

                    if (_matrixProfit[i,j] <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    Console.Write($"{_matrixProfit[i, j],20}");

                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.Write("Месяцы с худшей прибылью: ");

            // Находим и выводим месяцы с худшей прибылью
            // Вычисляем количество месяцев с положительной прибылью
            for (int i = 0; i < _rowsMatrix; i++)
            {
                for (int j = 0; j < _columnsMatrix; j++)
                {
                    if (_matrixProfit[i, j] <= 0)
                    {
                        Console.Write($"{i + 1}, ");
                    }
                    else
                    {
                        numberMonthPositiveProfit++;
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine($"Месяцев с положительной прибылью: {numberMonthPositiveProfit}");
        }
    }
}
