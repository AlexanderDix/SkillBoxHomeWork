using System;

namespace HomeWork_05
{
    class CalculationMatrices
    {
        /// <summary>
        /// Количество столбцов для матрицы
        /// </summary>
        private static int _columnsMatrix;

        /// <summary>
        /// Количество строк для матрицы
        /// </summary>
        private static int _rowsMatrix;

        /// <summary>
        /// Генератор псевдослучайного числа
        /// </summary>
        private static readonly Random Random = new();
        
        /// <summary>
        /// Выбор действий с матрицей
        /// </summary>
        public static void SelectingActionWithMatrix()
        {
            while (true)
            {
                var matrixAddition = "1 - Сложение матриц \n";
                var matrixSubtraction = "2 - Вычитание матриц \n";
                var matrixMultiplication = "3 - Умножение матриц \n";
                var matrixMultiByNumber = "4 - Умножение матрицы на число ";
                var printScreen = $" {matrixAddition} {matrixSubtraction} {matrixMultiplication} {matrixMultiByNumber}";

                Print.Text("Выберите, что нужно сделать с матрицей", ConsoleColor.DarkCyan);
                Print.Text(printScreen);

                var input = Check.InputUser();

                switch (input)
                {
                    case 1:
                        InputMatrix('+');
                        break;
                    case 2:
                        InputMatrix('-');
                        break;
                    case 3:
                        InputMatrix('*');
                        break;
                    case 4:
                        InputMatrix();
                        break;
                    default:
                        Print.Text("Такого пункта нет \n", ConsoleColor.DarkRed);
                        break;
                }
                break;
            }
        }

        /// <summary>
        /// Просим пользователя ввести размеры матриц и число на которое нужно умножить
        /// </summary>
        public static void InputMatrix()
        {
            Print.Text("Введите размеры матрицы A");
            var matrixA = FillMatrix();

            Print.Text("Введите число, на которое нужно умножить матрицу", ConsoleColor.DarkCyan);
            var number = Check.InputUser();

            if (number == 0)
            {
                Print.Text("Введите ненулевое значение", ConsoleColor.DarkRed);
            }
            else
            {
                var resultMatrix = MultiplicationNumberWithMatrix(matrixA, number);

                PrintMatrix(matrixA, resultMatrix, number);
            }

            Program.BackChoice();

            SelectingActionWithMatrix();
        }

        /// <summary>
        /// Просим пользователя ввести размеры матриц,
        /// затем перебрасываем к нужному методу
        /// </summary>
        /// <param name="symbol">Указываем символ: '+' - сложение, '-' - вычитание, '*' - умножение</param>
        public static void InputMatrix(char symbol)
        {
            Print.Text("Введите размеры матрицы A");
            var matrixA = FillMatrix();

            Print.Text("Введите размеры матрицы B");
            var matrixB = FillMatrix();

            if (CheckMatrix(matrixA, matrixB))
            {
                Print.Text(symbol is '+' or '-'
                        ? "Укажите одинаковые размеры матриц"
                        : "Количество столбцов матрицы A, должно быть равно количеству строк матрицы B",
                    ConsoleColor.DarkRed);
            }
            else
            {
                int[,] matrixC;
                switch (symbol)
                {
                    case '+':
                        matrixC = AdditionOrSubtractionMatrix(matrixA, matrixB, true);
                        break;
                    case '-':
                        matrixC = AdditionOrSubtractionMatrix(matrixA, matrixB, false);
                        break;
                    default:
                        matrixC = MultiplicationMatrix(matrixA, matrixB);
                        break;
                }

                PrintMatrix(matrixA, matrixB, matrixC, symbol);
            }

            Program.BackChoice();

            SelectingActionWithMatrix();
        }

        /// <summary>
        /// Проверяем матрицы на правильные размеры
        /// </summary>
        /// <param name="matrixA">Матрица A</param>
        /// <param name="matrixB">Матрица B</param>
        /// <returns>Возвращаем true - при неправильном указании размеров, false - при правильном</returns>
        public static bool CheckMatrix(int[,] matrixA, int[,] matrixB)
        {
            var checkFirst = matrixA.GetLength(0) != matrixB.GetLength(1);
            var checkSecond = matrixA.GetLength(1) != matrixB.GetLength(0);
            var checkThree = matrixA.GetLength(1) != matrixB.GetLength(0);
            var check = checkFirst || checkSecond || checkThree;

            return check;
        }

        /// <summary>
        /// Заполнение матриц по количеству строк и столбцов
        /// </summary>
        /// <returns>Возвращаем заполненный массив</returns>
        public static int[,] FillMatrix()
        {
            while (true)
            {
                Print.Text("Введите количество строк матрицы:", ConsoleColor.DarkCyan);
                _rowsMatrix = Check.InputUser();

                Print.Text("Введите количество столбцов матрицы:", ConsoleColor.DarkCyan);
                _columnsMatrix = Check.InputUser();

                if (_rowsMatrix == 0 || _columnsMatrix == 0)
                {
                    Print.Text("Введите ненулевые значения", ConsoleColor.DarkRed);
                    continue;
                }

                var matrix = new int[_rowsMatrix, _columnsMatrix];

                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    for (var j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = Random.Next(100);
                    }
                }
                return matrix;
            }
        }

        #region Операции на матрицами

        /// <summary>
        /// Сложение и вычитание матриц
        /// </summary>
        /// <param name="matrixA">Матрица A</param>
        /// <param name="matrixB">Матрица B</param>
        /// <param name="checkSelection">Передаем true - при сложении, false - при вычитании</param>
        /// <returns>Возвращаем результат операции на матрицами</returns>
        public static int[,] AdditionOrSubtractionMatrix(int[,] matrixA, int[,] matrixB, bool checkSelection)
        {
            var matrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

            if (checkSelection)
            {
                for (var i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (var j = 0; j < matrixB.GetLength(1); j++)
                    {
                        matrix[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                }
            }
            else
            {
                for (var i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (var j = 0; j < matrixB.GetLength(1); j++)
                    {
                        matrix[i, j] = matrixA[i, j] - matrixB[i, j];
                    }
                }
            }

            return matrix;
        }

        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="matrixA">Матрица A</param>
        /// <param name="matrixB">Матрица B</param>
        /// <returns>Возвращаем результат умножения двух матриц</returns>
        public static int[,] MultiplicationMatrix(int[,] matrixA, int[,] matrixB)
        {
            var matrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.GetLength(1); j++)
                {
                    for (var k = 0; k < matrixB.GetLength(0); k++)
                    {
                        matrix[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrix;
        }

        /// <summary>
        /// Умножение матриц на число
        /// </summary>
        /// <param name="matrixA">Матрица A</param>
        /// <param name="number">Число, на которое умножается матрица</param>
        /// <returns>Возвращаем результат операции</returns>
        public static int[,] MultiplicationNumberWithMatrix(int[,] matrixA, int number)
        {
            var matrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];

            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrix[i, j] = matrixA[i, j] * number;
                }
            }

            return matrix;
        }

        #endregion

        #region Вывод матриц

        /// <summary>
        /// Структурированный вывод матрицы
        /// </summary>
        /// <param name="matrix">Передаем матрицу для вывода</param>
        public static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{matrix[i, j]} \t");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводим матрицы и число на консоль
        /// </summary>
        /// <param name="matrixA">Матрица A</param>
        /// <param name="matrixC">Матрица C</param>
        /// <param name="number">Число, на которое умножали матрицу</param>
        public static void PrintMatrix(int[,] matrixA, int[,] matrixC, int number)
        {
            Print.Text("Матрица A");
            PrintMatrix(matrixA);

            Print.Text("*");

            Print.Text($"На число: {number}");

            Print.Text("=");

            Print.Text("Матрица C");
            PrintMatrix(matrixC);
        }

        /// <summary>
        /// Вывод матриц на консоль
        /// </summary>
        /// <param name="matrixA">Матрица A</param>
        /// <param name="matrixB">Матрица B</param>
        /// <param name="matrixC">Матрица C</param>
        /// <param name="symbol">Символ операции</param>
        public static void PrintMatrix(int[,] matrixA, int[,] matrixB, int[,] matrixC, char symbol)
        {
            Print.Text("Матрица A");
            PrintMatrix(matrixA);

            Print.Text($"{symbol}");

            Print.Text("Матрица B");
            PrintMatrix(matrixB);

            Print.Text("=");

            Print.Text("Матрица C");
            PrintMatrix(matrixC);
        }

        #endregion
    }
}