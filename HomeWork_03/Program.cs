using System;

namespace HomeWork_03
{
    class Program
    {
        /// <summary>
        /// Количество попыток ввода игроков
        /// </summary>
        private static int countTry;

        /// <summary>
        /// Максимально вводимое число для игроков
        /// </summary>
        private static int maxValueTry = 4;

        /// <summary>
        /// Минимальное вводимое число для игроков
        /// </summary>
        private static int minValueTry = 1;

        /// <summary>
        /// Переменная для хранения псевдослучайного числа
        /// </summary>
        private static int gameNumber;

        /// <summary>
        /// Массив для хранения имен игроков
        /// </summary>
        private static string[] userNames;

        private static int countUsers;

        /// <summary>
        /// Переменная для получения псевдослучайного числа
        /// </summary>
        /// <returns>Возращает псевдослучайное число</returns>
        private static Random random = new();

        

        private static void Main()
        {
            // gameNumber = 4;

            // // Просим ввести количество игроков, после чего создаем массив с нужным кол-вом
            // Console.WriteLine("Введите количество игроков");
            // var count = CheckInputUser();

            // InputUserNames(count);

            // Console.WriteLine($"Число равно: {gameNumber}");

            // MainLoop();

            TwoPlayers();
        }

        public static int CheckInputUser()
        {
            var userInput = Console.ReadLine();

            if (userInput == "exit")
            {
                Environment.Exit(0);
            }

            if (!int.TryParse(userInput, out var number))
            {
                Console.WriteLine("Данные введены некорректно");
                return CheckInputUser();
            }

            return number;
        }

        public static int UserTryInput(string userName)
        {
            var input = CheckInputUser();
            var maxValue = 4;
            var minValue = 1;
            var checkInput = input <= maxValue && input >= minValue;

            if (!checkInput)
            {
                if (countTry < 1)
                {
                    countTry++;
                    Console.WriteLine($"{userName}, введите верное число или будете оштрафованы");
                    return UserTryInput(userName);
                }
                else
                {
                    Console.WriteLine($"{userName}, вы оштрафованы");
                    countTry = 0;
                    return 0;
                }
            }
            else
            {
                countTry = 0;
            }

            return input;
        }

        public static string[] InputUserNames(int count)
        {
            Console.WriteLine("Введите имена игроков");

            userNames = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Игрок - {i + 1}, введите имя");
                userNames[i] = Console.ReadLine();
            }

            return userNames;
        }

        /// <summary>
        /// Основной цикл программы, проверяющий выполнение условия gameNumber <= 0
        /// </summary>
        public static void MainLoop()
        {
            while (gameNumber > 0)
            {
                foreach (var userName in userNames)
                {
                    Console.WriteLine($"Игрок {userName}, введите число от {minValueTry} до {maxValueTry}");

                    var userTry = UserTryInput(userName);

                    gameNumber -= userTry;

                    if (gameNumber <= 0)
                    {
                        Console.WriteLine($"Победитель: {userName}. Поздровляем!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Число равно: {gameNumber}");    
                    }
                }
            }
        }

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

        public static void EasyDifficultyGame()
        {
            // Вносим в переменную псевдослучайное число от 12 до 100
            gameNumber = random.Next(12, 101);
            MainLoop();
        }

        public static void MediumDifficultyGame()
        {

        }

        public static void HardDifficultyGame()
        {

        }

        public static void TwoPlayers()
        {
            countUsers = 2;

            InputUserNames(countUsers);

            DifficultySelection();
        }

        public static void ManyPlayers()
        {
            DifficultySelection();
        }

        public static void PlayingWithCoumputer()
        {
            DifficultySelection();
        }

    }
}
