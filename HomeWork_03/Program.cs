using System;

namespace HomeWork_03
{
    class Program
    {
        /// <summary>
        /// Количество попыток ввода игроков
        /// </summary>
        private static int countTryUser;

        /// <summary>
        /// Количество попыток для ввода
        /// </summary>
        private static int countTry;

        /// <summary>
        /// Максимально вводимое число для игроков
        /// </summary>
        private static int maxValueTry;

        /// <summary>
        /// Минимальное вводимое число для игроков
        /// </summary>
        private static int minValueTry;

        /// <summary>
        /// Переменная для хранения псевдослучайного числа
        /// </summary>
        private static int gameNumber;

        /// <summary>
        /// Максимальное число для генерации gameNumber
        /// </summary>
        private static int maxGameNumber;

        /// <summary>
        /// Минимальное число для генерации gameNumber
        /// </summary>
        private static int minGameNumber;

        /// <summary>
        /// Массив для хранения имен игроков
        /// </summary>
        private static string[] userNames;

        /// <summary>
        /// Переменная для хранения количества игроков
        /// </summary>
        private static int countUsers;

        /// <summary>
        /// Переменная для получения псевдослучайного числа
        /// </summary>
        /// <returns>Возращает псевдослучайное число</returns>
        private static Random random = new();

        
        private static void Main()
        {
            Help();

            SelectingGameMode();
        }

        /// <summary>
        /// Проверяем ввод пользователя на лишние символы.
        /// А также на "exit" если пользователь хочет выйти.
        /// </summary>
        /// <returns>Возращаем введеное число пользователя</returns>
        public static int CheckInputUser()
        {
            var userInput = Console.ReadLine();

            if (userInput == "exit")
            {
                Environment.Exit(0);
            }

            if (userInput == "help")
            {
                Help();
                return CheckInputUser();
            }

            if (!int.TryParse(userInput, out var number))
            {
                Console.WriteLine("Данные введены некорректно");
                return CheckInputUser();
            }

            if (number < 0)
            {
                Console.WriteLine("Не указывайте отрицательные значения");
                return CheckInputUser();
            }

            return number;
        }

        /// <summary>
        /// Проверяем ввел ли пользователь число в заданых границах.
        /// Границы заданы в переменных maxValueTry и minValueTry.
        /// </summary>
        /// <param name="userName">Передаем имена игроков</param>
        /// <returns>Возвращаем число</returns>
        public static int UserTryInput(string userName)
        {
            var input = CheckInputUser();

            // Проверяем ввод на нахождение в заданом диапазоне
            var checkInput = input <= maxValueTry && input >= minValueTry;

            // Проверяем gameNumber с максимально возможным вводом для пользователей
            // Также проверяем ввод пользователя, и при совпадении запрещаем вводить
            var check = gameNumber == maxValueTry && input == maxValueTry;

            if (!checkInput || check)
            {
                if (countTryUser < countTry)
                {
                    countTryUser++;
                    Console.WriteLine($"{userName}, введите верное число или будете оштрафованы");
                    return UserTryInput(userName);
                }
                else
                {
                    Console.WriteLine($"{userName}, вы оштрафованы");
                    countTryUser = 0;
                    return 0;
                }
            }
            else
            {
                countTryUser = 0;
            }

            return input;
        }

        /// <summary>
        /// Просим пользователей ввести свои имена.
        /// </summary>
        /// <param name="count">Получаем количество игроков</param>
        /// <returns>Возращаем массив с игроками</returns>
        public static string[] InputUserNames(int count)
        {
            Console.WriteLine("Введите имена игроков");
            //userNames = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Игрок - {i + 1}, введите имя");

                var input = Console.ReadLine();

                if (input == "Computer")
                {
                    Console.WriteLine("Это имя нельзя использовать");
                    return InputUserNames(count);
                }

                userNames[i] = input;
            }

            return userNames;
        }

        /// <summary>
        /// Основной цикл программы, проверяющий выполнение условия gameNumber <= 0
        /// </summary>
        public static void MainLoop()
        {
            int userTry;

            while (gameNumber > 0)
            {
                foreach (var userName in userNames)
                {
                    Console.WriteLine($"Игрок {userName}, введите число от {minValueTry} до {maxValueTry}");

                    if (userName == "Computer")
                    {
                        userTry = random.Next(minValueTry, maxValueTry);
                    }
                    else
                    {
                        userTry = UserTryInput(userName);
                    }

                    gameNumber -= userTry;

                    if (gameNumber <= 0)
                    {
                        Console.WriteLine($"Победитель: {userName}. Поздровляем!");
                        NextGame();
                    }
                    else
                    {
                        Console.WriteLine($"Число равно: {gameNumber}");    
                    }
                }
            }
        }

        /// <summary>
        /// Просим пользователя выбрать сложность игры
        /// </summary>
        public static void DifficultySelection()
        {
            var easyGame = "1 - легкая \n";
            var mediumGame = "2 - средняя \n";
            var hardGame = "3 - сложная \n";

            Console.WriteLine($"Выберите сложность игры: \n {easyGame} {mediumGame} {hardGame}");
            var numberDifficulty = CheckInputUser();

            switch (numberDifficulty)
            {
                case 1:
                    EasyDifficultyGame();
                    break;
                case 2:
                    MediumDifficultyGame();
                    break;
                case 3:
                    HardDifficultyGame();
                    break;
                default:
                    DifficultySelection();
                    break;
            }
        }

        /// <summary>
        /// Задаем правила легкой сложности игры
        /// </summary>
        public static void EasyDifficultyGame()
        {
            // Задаем диапазон чисел для генерации gameNumber
            maxGameNumber = 101;
            minGameNumber = 12;

            // Вносим в переменную псевдослучайное число
            gameNumber = random.Next(minGameNumber, maxGameNumber);

            // Задаем диапазон чисел для ввода пользователя
            maxValueTry = 4;
            minValueTry = 1;

            // Задаем количество попыток
            countTry = 2;

            Console.Clear();

            MainLoop();
        }

        /// <summary>
        /// Задаем правила средней сложности игры
        /// </summary>
        public static void MediumDifficultyGame()
        {
            minGameNumber = 12;
            maxGameNumber = 101;

            gameNumber = random.Next(minGameNumber, maxGameNumber);

            Console.WriteLine("Задайте минимальное значение для ввода пользователя");
            minValueTry = CheckInputUser();

            Console.WriteLine("Задайте максимальное значение для ввода пользователя");
            maxValueTry = CheckInputUser();
            
            countTry = 1;

            Console.Clear();

            MainLoop();
        }

        /// <summary>
        /// Задаем правила тяжелой сложности игры
        /// </summary>
        public static void HardDifficultyGame()
        {
            Console.WriteLine("Задайте минимальное значение в загадываемом диапазоне");
            minGameNumber = CheckInputUser();

            Console.WriteLine("Задайте максимальное значение в загадываемом диапазоне");
            maxGameNumber = CheckInputUser();

            gameNumber = random.Next(minGameNumber, maxGameNumber);

            Console.WriteLine("Задайте минимальное значение для ввода пользователя");
            minValueTry = CheckInputUser();

            Console.WriteLine("Задайте максимальное значение для ввода пользователя");
            maxValueTry = CheckInputUser();

            countTry = 0;

            Console.Clear();

            MainLoop();
        }

        /// <summary>
        /// Режим двух игроков
        /// </summary>
        public static void TwoPlayers()
        {
            countUsers = 2;
            userNames = new string[countUsers];

            InputUserNames(countUsers);

            DifficultySelection();
        }

        /// <summary>
        /// Режим множества игроков
        /// </summary>
        public static void ManyPlayers()
        {
            Console.WriteLine("Укажите количество игроков, больше двух");
            countUsers = CheckInputUser();

            if (countUsers <= 2)
            {
                ManyPlayers();
            }

            userNames = new string[countUsers];

            InputUserNames(countUsers);

            DifficultySelection();
        }

        /// <summary>
        /// Режим игры с компьютером
        /// </summary>
        public static void PlayingWithCoumputer()
        {
            countUsers = 1;
            userNames = new string[2];

            userNames[1] = "Computer";

            InputUserNames(countUsers);

            DifficultySelection();
        }

        /// <summary>
        /// Спрашиваем пользователя хочет ли он продолжить игру
        /// </summary>
        public static void NextGame()
        {
            Console.WriteLine("Продолжаем игру? 1 - продолжить. 2 - завершить.");

            var input = CheckInputUser();

            if (input == 1)
            {
                Console.Clear();
                SelectingGameMode();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Просим пользователя выбрать режим игры
        /// </summary>
        public static void SelectingGameMode()
        {
            var modes = "1 - Два игрока \n 2 - Несколько игроков \n 3 - Игра с компюьтером";

            Console.WriteLine($"Выберите режим игры: \n {modes}");
            var selectMode = CheckInputUser();

            switch (selectMode)
            {
                case 1:
                    TwoPlayers();
                    break;
                case 2:
                    ManyPlayers();
                    break;
                case 3:
                    PlayingWithCoumputer();
                    break;
                default:
                    SelectingGameMode();
                    break;
            }
        }

        /// <summary>
        /// Выводим пользователю информацию про правила игры
        /// </summary>
        private static void Help()
        {
            Console.WriteLine("Привет дорогой пользователь. Добро пожаловать в игру. \n" +
                              "Правила игры таковы. Программа выбирает случайное число. \n" +
                              "После чего игроки путем ввода чисел в заданном диапазоне, должны привести его к нулю. \n");

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("Если случайное число в результате ваших действий получило значение равное максимально возможному вводу для пользователя," + 
                              "то ввод этого числа запрещен. \n");

            Console.ResetColor();
                              
            Console.WriteLine("Есть три режима и три уровня сложности. \n Режимы: \n >Два игрока \n >Много игроков \n >Против компьютера \n" +
                              "Уровни сложности: \n >Легкий \n >Средний \n >Тяжелый \n Их различия в следующем. \n");

            Console.WriteLine("На легком - у вас есть шанс ошибиться 2 раза при вводе, случайное число находиться в диапазоне между 12 и 100. \n" + 
                              "На среднем - шанс ошибиться 1 раз, вы задаете минимальное и максимальное число для ввода пользователя. \n" +
                              "На тяжелом - шанса ошибиться нету, вы задаете диапазон случайного числа и указываете минимальное и максимальное число для ввода пользователя. \n" +
                              "Дополнительные команды: exit - выполняет завершение программы, help - вызов справки. \n" +
                              "После прочтения нажмите любую кнопку...");
            
            Console.ReadKey();
        }
    }
}
