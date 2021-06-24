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
        /// Матрица A
        /// </summary>
        private static int[,] _matrixA;

        /// <summary>
        /// Матрица B
        /// </summary>
        private static int[,] _matrixB;

        /// <summary>
        /// Матрица C
        /// </summary>
        private static int[,] _matrixC;

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
            ChoiceProgram();
        }

        /// <summary>
        /// Программа по учету финансов компании
        /// </summary>
        public static void FinanceAccountingProgram()
        {
            Console.Clear();

            Console.WriteLine("Программа по учету финансов в компании \n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{"Номер месяца",20} {"Доход, тыс. руб.",20} {"Расход, тыс. руб.",20} {"Прибыль, тыс. руб.",20}");
            Console.ResetColor();

            PrintTableFinance();

            BackMenu();

            ChoiceProgram();
        }

        /// <summary>
        /// Вывод таблицы по учету финансов
        /// </summary>
        public static void PrintTableFinance()
        {
            var amount = 200_000;
            var numberMonthPositiveProfit = 0;
            _columnsMatrix = 1;
            _rowsMatrix = 12;
            _matrixIncome = new int[_rowsMatrix, _columnsMatrix];
            _matrixConsumption = new int[_rowsMatrix, _columnsMatrix];
            _matrixProfit = new int[_rowsMatrix, _columnsMatrix];

            for (var i = 0; i < _rowsMatrix; i++)
            {
                // Выводим числа месяцев
                Console.Write($"{i + 1,20}");
                
                for (var j = 0; j < _columnsMatrix; j++)
                {
                    // Заполняем и выводим массив с доходами
                    _matrixIncome[i, j] = Random.Next(amount);
                    Console.Write($"{_matrixIncome[i, j],20}");

                    // Заполняем и выводим массив с расходами
                    _matrixConsumption[i, j] = Random.Next(amount);
                    Console.Write($"{_matrixConsumption[i, j],20}");

                    // Заполняем и выводим массив с прибылью
                    _matrixProfit[i, j] = _matrixIncome[i, j] - _matrixConsumption[i, j];

                    Console.ForegroundColor = _matrixProfit[i, j] <= 0 ? ConsoleColor.DarkRed : ConsoleColor.DarkGreen;

                    Console.Write($"{_matrixProfit[i, j],20}");

                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.Write("Месяцы с худшей прибылью: ");

            // Находим и выводим месяцы с худшей прибылью
            // Вычисляем количество месяцев с положительной прибылью
            for (var i = 0; i < _rowsMatrix; i++)
            {
                for (var j = 0; j < _columnsMatrix; j++)
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

            Console.WriteLine($"Месяцев с положительной прибылью: {numberMonthPositiveProfit}\n");
        }

        /// <summary>
        /// Вывод треугольника Паскаля
        /// </summary>
        public static void PrintPascalTriangle()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Введите количество строк для трегольника Паскаля: ");
            Console.ResetColor();

            var input = CheckUserInput();

            var triangle = FillPascalTriangle(input);

            // Вывод треугольника Паскаля
            for (var i = 0; i < input; i++)
            {
                for (var j = 0; j <= (input - i); j++)
                {
                    var str = " ";
                    Console.Write($"{str,6}");
                }

                for (var j = 0; j <= i; j++)
                {
                    Console.Write($"{triangle[i][j],12}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            BackMenu();

            ChoiceProgram();
        }

        /// <summary>
        /// Заполняем зубчатый массив значениями треугольника Паскаля
        /// </summary>
        /// <param name="rows">Количество строк в треугольнике</param>
        /// <returns>Возвращаем заполненный треугольник Паскаля</returns>
        public static int[][] FillPascalTriangle(int rows)
        {
            int[][] triangle = new int[rows][];
            triangle[0] = new[] {1};

            // Расчет треугольника Паскаля и заполнение зубчатого массива значениями
            for (var i = 0; i < triangle.Length; i++)
            {
                triangle[i] = new int[i + 1];
                for (var j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        triangle[i][j] = 1;
                    }
                    else
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
            }
            return triangle;
        }

        /// <summary>
        /// Просим пользователя выбрать программу для отображения на экране
        /// </summary>
        public static void ChoiceProgram()
        {
            while (true)
            {
                var programOne = "1 - Приложение по учету финансов \n";
                var programTwo = "2 - Приложение строящее N строк треугольника Паскаля \n";
                var programThree = "3 - Приложение по работе с матрицами \n";
                var programExit = "4 - Завершить работу";

                var printScreen = $" {programOne} {programTwo} {programThree} {programExit}";

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Выберите какую программу вывести на экран:");
                Console.ResetColor();

                Console.WriteLine(printScreen);

                var userInput = CheckUserInput();

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        FinanceAccountingProgram();
                        break;
                    case 2:
                        Console.Clear();
                        PrintPascalTriangle();
                        break;
                    case 3:
                        Console.Clear();
                        CalculationMatrices();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет \n");
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Проверяем ввод пользователя на ввод лишних символов
        /// </summary>
        /// <returns>Возвращает число введенное пользователем</returns>
        public static int CheckUserInput()
        {
            var input = Console.ReadLine();
            var checkInput = int.TryParse(input, out var number);

            while (!checkInput || number < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Данные введены некорректно");
                Console.ResetColor();
                break;
            }

            return number;
        }

        /// <summary>
        /// Просим пользователя выбрать действия с матрицей
        /// </summary>
        public static void CalculationMatrices()
        {
            while (true)
            {
                var matrixAddition = "1 - Сложение матриц \n";
                var matrixSubtraction = "2 - Вычитание матриц \n";
                var matrixMultiplication = "3 - Умножение матриц \n";
                var matrixMultiByNumber = "4 - Умножение матрицы на число \n";
                var backChoice = "5 - Вернуться назад";
                var printScreen = $" {matrixAddition} {matrixSubtraction} {matrixMultiplication} {matrixMultiByNumber} {backChoice}";

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Выберите, что нужно сделать с матрицей");
                Console.ResetColor();
                Console.WriteLine(printScreen);

                var input = CheckUserInput();

                switch (input)
                {
                    case 1:
                        MatrixAdditionOrSubtraction(true);
                        break;
                    case 2:
                        MatrixAdditionOrSubtraction(false);
                        break;
                    case 3:
                        MatrixMultiplication();
                        break;
                    case 4:
                        MatrixMultiplicationNumber();
                        break;
                    case 5:
                        Console.Clear();
                        ChoiceProgram();
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет \n");
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Просим пользователя ввести количество строк и столбцов матриц
        /// </summary>
        /// <returns>Возвращаем заполненную матрицу с указанными строками и столбцами</returns>
        public static int[,] RowsColumnsMatrix()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Введите количество строк матрицы:");
                Console.ResetColor();
                _rowsMatrix = CheckUserInput();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Введите количество столбцов матрицы:");
                Console.ResetColor();
                _columnsMatrix = CheckUserInput();

                if (_rowsMatrix == 0 || _columnsMatrix == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Введите ненулевые значения");
                    Console.ResetColor();

                    continue;
                }

                var matrix = new int[_rowsMatrix, _columnsMatrix];

                for (var i = 0; i < _rowsMatrix; i++)
                {
                    for (var j = 0; j < _columnsMatrix; j++)
                    {
                        matrix[i, j] = Random.Next(100);
                    }
                }

                return matrix;
            }
        }

        /// <summary>
        /// Выводим матрицу на экран
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
        /// После нажатия любой кнопки, консоль очищается и пользователя возращает в меню выбора действий
        /// </summary>
        public static void BackMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Нажмите кнопку чтобы вернуться к меню выбора действий с матрицей...");
            Console.ResetColor();

            Console.ReadKey();

            Console.Clear();
        }

        /// <summary>
        /// Просим ввести пользователей размеры матриц
        /// </summary>
        public static void InputMatrix()
        {
            Console.WriteLine("Введите размеры матрицы A:");
            _matrixA = RowsColumnsMatrix();

            Console.WriteLine("Введите размеры матрицы B:");
            _matrixB = RowsColumnsMatrix();
        }

        /// <summary>
        /// Сложение и вычитание матриц
        /// </summary>
        /// <param name="checkSelection">Передаем true - при сложении, false - при вычитании</param>
        public static void MatrixAdditionOrSubtraction(bool checkSelection)
        {
            InputMatrix();

            // Проверяем матрицы на одинаковые размеры
            var checkFirst = _matrixA.GetLength(0) != _matrixB.GetLength(1);
            var checkSecond = _matrixA.GetLength(1) != _matrixB.GetLength(0);

            if (checkFirst || checkSecond)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Укажите одинаковые размеры матриц");
                Console.ResetColor();
            }
            else
            {
                // Создаем матрицу для заполнения результатом сложения матриц
                _matrixC = new int[_matrixA.GetLength(0), _matrixB.GetLength(1)];

                // Выводим первую матрицу
                Console.WriteLine("Матрица A:");
                PrintMatrix(_matrixA);

                Console.WriteLine("+");

                // Выводим вторую матрицу
                Console.WriteLine("Матрица B:");
                PrintMatrix(_matrixB);

                Console.WriteLine("=");

                // Проверяем checkSelection, при true - складываем матрицы, при false - вычитаем матрицы
                if (checkSelection)
                {
                    for (var i = 0; i < _rowsMatrix; i++)
                    {
                        for (var j = 0; j < _columnsMatrix; j++)
                        {
                            _matrixC[i, j] = _matrixA[i, j] + _matrixB[i, j];
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < _rowsMatrix; i++)
                    {
                        for (var j = 0; j < _columnsMatrix; j++)
                        {
                            _matrixC[i, j] = _matrixA[i, j] - _matrixB[i, j];
                        }
                    }
                }

                // Выводим результат действий с матрицей
                Console.WriteLine("Матрица C: ");
                PrintMatrix(_matrixC);
            }

            BackMenu();

            CalculationMatrices();
        }

        /// <summary>
        /// Умножение матрицы на матрицу
        /// </summary>
        public static void MatrixMultiplication()
        {
            InputMatrix();

            var checkMatrixFirst = _matrixA.GetLength(0) != _matrixB.GetLength(1);
            var checkMatrixSecond = _matrixA.GetLength(1) != _matrixB.GetLength(0);

            if (checkMatrixFirst || checkMatrixSecond)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Количество столбцов матрицы A, должно быть равно количеству строк матрицы B");
                Console.ResetColor();
            }
            else
            {
                _matrixC = new int[_matrixA.GetLength(0), _matrixB.GetLength(1)];

                for (var i = 0; i < _matrixA.GetLength(0); i++)
                {
                    for (var j = 0; j < _matrixB.GetLength(1); j++)
                    {
                        for (var k = 0; k < _matrixB.GetLength(0); k++)
                        {
                            _matrixC[i, j] += _matrixA[i, k] * _matrixB[k, j];
                        }
                    }
                }

                Console.WriteLine("Матрица A:");
                PrintMatrix(_matrixA);

                Console.WriteLine("*");

                Console.WriteLine("Матрица B:");
                PrintMatrix(_matrixB);

                Console.WriteLine("=");

                Console.WriteLine("Матрица C:");
                PrintMatrix(_matrixC);
            }

            BackMenu();

            CalculationMatrices();
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        public static void MatrixMultiplicationNumber()
        {
            // Просим пользователя ввести размеры матриц
            Console.WriteLine("Введите размеры матрицы A:");
            _matrixA = RowsColumnsMatrix();

            Console.WriteLine("Введите число на которое нужно умножить матрицу:");
            var number = CheckUserInput();

            if (number == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Введите ненулевое значение");
                Console.ResetColor();
            }
            else
            {
                _matrixC = new int[_matrixA.GetLength(0), _matrixA.GetLength(1)];

                for (var i = 0; i < _matrixA.GetLength(0); i++)
                {
                    for (var j = 0; j < _matrixA.GetLength(1); j++)
                    {
                        _matrixC[i, j] = _matrixA[i, j] * number;
                    }
                }

                Console.WriteLine("Матрица A:");
                PrintMatrix(_matrixA);

                Console.WriteLine("*");

                Console.WriteLine($"На число: {number}");

                Console.WriteLine("Матрица C");
                PrintMatrix(_matrixC);
            }

            BackMenu();

            CalculationMatrices();
        }
    }
}
