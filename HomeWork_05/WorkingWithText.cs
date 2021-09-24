using System;
using System.Collections.Generic;

namespace HomeWork_05
{

    /// <summary>
    /// Класс для работы с текстом
    /// </summary>
    public class WorkingWithText
    {

        /// <summary>
        /// Просим пользователя выбрать программу
        /// </summary>
        public static void ChoiceProgram()
        {
            while (true)
            {
                var minMaxWord = "1 - Вывод слов с максимальным и минимальным количеством символов из текста \n";
                var nonDuplicate = "2 - Убрать повторяющиеся символы в введенном тексте \n";
                var backMainMenu = "3 - Назад в главное меню \n";
                var exitProgram = "4 - Закончить работу";
                var printText = $" {minMaxWord} {nonDuplicate} {backMainMenu} {exitProgram}";

                Print.Text("Выберите нужную программу: ", ConsoleColor.DarkCyan);
                Print.Text(printText);

                var input = Check.InputUser();
                
                switch (input)
                {
                    case 1:
                        MainLogic(input);
                        break;
                    case 2:
                        MainLogic(input);
                        break;
                    case 3:
                        Program.ChoiceProgram();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Print.Text("Такого пункта нет", ConsoleColor.DarkRed);
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Основная логика
        /// </summary>
        /// <param name="number">Номер программы</param>
        public static void MainLogic(int number)
        {
            var text = InputText();

            switch (number)
            {
                case 1:
                    OutputInfo(MinLengthWord(text), MaxLengthWord(text));
                    break;
                case 2:
                    OutputInfo(NonDuplicatesInText(text.ToLower()));
                    break;                
            }
        }

        /// <summary>
        /// Выводим на экран полученные слова
        /// </summary>
        /// <param name="minWord">Строка с минимальным количеством символов</param>
        /// <param name="maxWords">Список с максимальным количеством символов</param>
        public static void OutputInfo(string minWord, List<string> maxWords)
        {
            string resultWords = string.Empty;

            foreach (var word in maxWords)
            {
                resultWords += word + ",";
            }

            var resultText = $"Слово с минимальным количеством символов: {minWord}\n" +
                             $"Слова с максимальным количеством символов: {resultWords.Trim(',')}";

            Print.Text(resultText);

            Program.BackChoice();
            ChoiceProgram();
        }

        /// <summary>
        /// Вывод на экран текста, полученного в результате преобразований
        /// </summary>
        /// <param name="text">Преобразованный текст</param>
        public static void OutputInfo(string text)
        {
            var resultText = $"Текст без повторяющихся символов: {text}";

            Print.Text(resultText);

            Program.BackChoice();
            ChoiceProgram();
        }

        /// <summary>
        /// Просим пользователя ввести текст
        /// </summary>
        /// <returns>Возвращаем введенный текст</returns>
        public static string InputText()
        {
            Print.Text("Введите текст: ", ConsoleColor.DarkCyan);
            string text = Check.Input();

            return text;
        }

        /// <summary>
        /// Форматируем полученный текст. Удаляем лишние символы и пробелы.
        /// </summary>
        /// <param name="text">Текст для форматирования</param>
        /// <returns>Возвращаем без символов и пробелов</returns>
        public static string[] FormattedText(string text)
        {
            char[] separators = new char[] { ' ', '.', ',', '!', '?', ':', ';'};
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        /// <summary>
        /// Находим строку с минимальным количеством символов
        /// </summary>
        /// <param name="text">Текст, в котором будет производиться поиск</param>
        /// <returns>Возвращаем строку с минимальным количеством символов</returns>
        public static string MinLengthWord(string text)
        {
            var words = FormattedText(text);
            var min = words[0].Length;
            string minWord = string.Empty;

            foreach (var word in words)
            {
                if (word.Length <= min)
                {
                    min = word.Length;
                    minWord = word;
                }
            }

            return minWord;
        }

        /// <summary>
        /// Находим слова с максимальным количеством символов
        /// </summary>
        /// <param name="text">Текст, в котором производиться поиск</param>
        /// <returns>Возвращаем список слов с максимальным количеством символов</returns>
        public static List<string> MaxLengthWord(string text)
        {
            var words = FormattedText(text);
            var max = 0;
            List<string> maxWords = new List<string>();

            // Находим максимальное количество символов
            foreach (var word in words)
            {
                if (word.Length > max)
                {
                    max = word.Length;
                }
            }

            // Заполняем список словами с максимальным количеством символов
            foreach (var word in words)
            {
                if (word.Length == max)
                {
                    maxWords.Add(word);
                }
            }

            return maxWords;
        }

        /// <summary>
        /// Убираем в тексте повторяющиеся символы
        /// </summary>
        /// <param name="text">Текст, который необходимо преобразовать</param>
        /// <returns>Возвращаем получившийся текст</returns>
        public static string NonDuplicatesInText(string text)
        {
            var result = "" + text[0];

            for (var i = 1; i < text.Length; i++)
            {
                if (text[i] != result[result.Length - 1])
                {
                    result += text[i];
                }
            }

            return result;
        }
    }
}