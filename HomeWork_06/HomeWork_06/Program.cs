using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace HomeWork_06
{
    class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        static void Main()
        {
            ChoiceUser();
        }

        /// <summary>
        /// Просим пользователя выбрать режим работы
        /// </summary>
        static void ChoiceUser()
        {
            while (true)
            {
                var number = NumberFromFile();
                string greeting = $"Приветствую. Ваше число: {number}. Выберите режим работы";
                string outOnlyGroups = "1 - Вывести количество групп \n";
                string outAllNumbers = "2 - Рассчитать и записать числа в группах \n";
                string exitProgramm = "3 - Завершить работу";
                string printChoice = $" {outOnlyGroups} {outAllNumbers} {exitProgramm} ";

                Print(greeting, ConsoleColor.DarkCyan);
                Print(printChoice);

                var input = InputUser();

                switch (input)
                {
                    case 1:
                        Print($"Для числа {number}, количество групп равно: {GroupsNumber(number)}", ConsoleColor.DarkGreen);
                        BackChoice();
                        break;
                    case 2:
                        NumbersInGroup(number);
                        AskUsersToCompress();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Print("Данного пункта нет.", ConsoleColor.DarkRed);
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Считываем из файла число. Если файл не существует, создаем его с числом 10
        /// </summary>
        /// <returns></returns>
        static int NumberFromFile()
        {
            string path = "input.txt";

            if (!File.Exists(path))
            {
                Print($"Файл {path} не найден. Создаем файл с числом 10.");
                using (StreamWriter writer = new(new FileStream(path, FileMode.Create, FileAccess.Write)))
                {
                    writer.WriteLine("10");
                }
            }

            using (StreamReader reader = new(path, System.Text.Encoding.Default))
            {
                if (!int.TryParse(reader.ReadLine(), out var number))
                {
                    Print("В файле находятся не число. Задаем стандартное число: 10", ConsoleColor.DarkRed);
                    number = 10;
                }

                return number;
            }
        }

        /// <summary>
        /// Записываем в файл группы чисел, а также замеряем время работы
        /// </summary>
        /// <param name="number">Заданное число</param>
        static void NumbersInGroup(int number)
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();
            string fileName = "output.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (StreamWriter writer = new(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                for (int i = 1; i <= GroupsNumber(number); i++)
                {
                    writer.WriteLine($"{i}-я группа: [{String.Join(", ", NextGroup(i, GroupsNumber(number), number))}]");
                }
            }

            stopwatch.Stop();

            Print($"Время выполнения: {stopwatch.Elapsed.TotalSeconds} сек.", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Рассчитываем количество групп для заданного числа
        /// </summary>
        /// <param name="number">Заданное число</param>
        /// <returns>Возвращаем количество групп</returns>
        static int GroupsNumber(int number)
        {
            int count = 1;

            while (number > 1)
            {
                number /= 2;
                count++;
            }

            return count;
        }

        /// <summary>
        /// Рассчитывем числа входящие в группы
        /// </summary>
        /// <param name="groupNumber">Номер группы</param>
        /// <param name="groups">Количество групп</param>
        /// <param name="number">Заданное число</param>
        /// <returns>Возвращаем массив с числами</returns>
        static int[] NextGroup(int groupNumber, int groups, int number)
        {
            if (groupNumber != groups)
                return Enumerable.Range((int)Math.Pow(2, groupNumber - 1), (int)Math.Pow(2, groupNumber) - (int)Math.Pow(2, groupNumber - 1)).ToArray();
            else
                return Enumerable.Range((int)Math.Pow(2, groupNumber - 1), number - (int)Math.Pow(2, groupNumber - 1) + 1).ToArray();
        }

        /// <summary>
        /// Спрашиваем пользователя, нужно ли архивировать файл
        /// </summary>
        static void AskUsersToCompress()
        {
            string yesNo = " 1 - Да \n 2 - Нет";
            Print("Заархивировать файл?", ConsoleColor.DarkCyan);
            Print(yesNo);
            var input = InputUser();

            switch (input)
            {
                case 1:
                    CompressFile();
                    BackChoice();
                    break;
                case 2:
                    BackChoice();
                    break;
                default:
                    Print("Данного пункта нет. Архивация сброшена.", ConsoleColor.DarkRed);
                    BackChoice();
                    break;
            }
        }

        /// <summary>
        /// Архивация файла
        /// </summary>
        static void CompressFile()
        {
            string fileName = "output.txt";
            string outputFileName = "outputArchive.zip";

            if (!File.Exists(fileName))
            {
                Print($"Файл {fileName} не найден. Архивация сброшена", ConsoleColor.DarkRed);
                BackChoice();
            }

            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

            using (FileStream fileStream = new(fileName, FileMode.Open))
            {
                using (FileStream fStream = File.Create(outputFileName))
                {
                    using (GZipStream gZipStream = new(fStream, CompressionMode.Compress))
                    {
                        fileStream.CopyTo(fStream);
                        Print($"Сжатие файла {fileName} завершено."
                            + $"Исходный размер: {fileStream.Length}."
                            + $"Сжатый размер: {fStream.Length}.", ConsoleColor.DarkGreen);
                    }
                }
            }
        }

        /// <summary>
        /// Вывод текста на консоль, без задания цвета
        /// </summary>
        /// <param name="text">Текст</param>
        static void Print(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Вывод текста на консоль, с заданием цвета
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">Цвет текста</param>
        static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Проверка пользовательского ввода
        /// </summary>
        /// <returns>Возвращаем число</returns>
        static int InputUser()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var checkInput = int.TryParse(input, out var number);

                if (!checkInput || number < 0)
                {
                    Print("Данные введены некорректно", ConsoleColor.DarkRed);
                    continue;
                }

                return number;
            }
        }

        /// <summary>
        /// Заглушка и возврат к меню выбора
        /// </summary>
        static void BackChoice()
        {
            Print("Нажмите любую кнопку, чтобы вернуться к меню выбора...", ConsoleColor.DarkCyan);

            Console.ReadKey();
            Console.Clear();

            ChoiceUser();
        }
    }
}
