using System;

namespace SkillBoxHomeWork_02
{
    class Program
    {
        /// <summary>
        /// Точка входа приложения
        /// </summary>
        static void Main()
        {

            #region Первый сотрудник

            // Создаем переменные для хранения данных о первом сотруднике,
            // а также просим пользователя ввести данные 
            Console.WriteLine("Первый сотрудник \nВведите Ваше имя: ");
            string nameFirst = Console.ReadLine();

            Console.WriteLine("Введите Ваш полный возраст: ");
            int ageFirst = CheckInputNumber();

            Console.WriteLine("Введите Ваш рост, в сантиметрах: ");
            int growthFirst = CheckInputNumber();

            Console.WriteLine("Введите Ваши баллы по русскому языку: ");
            int scoresRussianLanguageFirst = CheckInputScores();

            Console.WriteLine("Введите Ваши баллы по истории: ");
            int scoresHistoryFirst = CheckInputScores();

            Console.WriteLine("Введите Ваши баллы по математике: ");
            int scoresMathFirst = CheckInputScores();

            Console.Clear(); // Очищаем консоль

            #endregion

            #region Второй сотрудник

            // Создаем переменные для хранения данных о втором сотруднике,
            // а также просим пользователя ввести данные
            Console.WriteLine("Второй сотрудник \nВведите Ваше имя: ");
            string nameSecond = Console.ReadLine();

            Console.WriteLine("Введите Ваш полный возраст: ");
            int ageSecond = CheckInputNumber();

            Console.WriteLine("Введите Ваш рост, в сантиметрах: ");
            double growthSecond = CheckInputNumber();

            Console.WriteLine("Введите Ваши баллы по русскому языку: ");
            int scoresRussianLanguageSecond = CheckInputScores();

            Console.WriteLine("Введите Ваши баллы по истории: ");
            int scoresHistorySecond = CheckInputScores();

            Console.WriteLine("Введите Ваши баллы по математике: ");
            int scoresMathSecond = CheckInputScores();

            Console.Clear(); // Очищаем консоль

            #endregion

            #region Третий сотрудник

            // Создаем переменные для хранения данных о втором сотруднике,
            // а также просим пользователя ввести данные
            Console.WriteLine("Третий сотрудник \nВведите Ваше имя: ");
            string nameThird = Console.ReadLine();

            Console.WriteLine("Введите Ваш возраст: ");
            int ageThird = CheckInputNumber();

            Console.WriteLine("Введите Ваш рост: ");
            int growthThird = CheckInputNumber();

            Console.WriteLine("Введите Ваши баллы по русскому языку: ");
            int scoresRussianLanguageThird = CheckInputScores();

            Console.WriteLine("Введите Ваши баллы по истории: ");
            int scoresHistoryThird = CheckInputScores();

            Console.WriteLine("Введите Ваши баллы по математике: ");
            int scoresMathThird = CheckInputScores();

            Console.Clear(); // Очищаем консоль

            #endregion

            #region Расчет среднего балла сотрудника

            // Переменная в которой указано количество предметов
            double numberSubjects = 3;

            // Создаем переменные для хранения средних баллов для каждого сотрудника и проводим расчет
            var averageScoreFirst = (((double)scoresRussianLanguageFirst + scoresHistoryFirst + scoresMathFirst) / numberSubjects).ToString("#.##");
            var averageScoreSecond = (((double)scoresRussianLanguageSecond + scoresHistorySecond + scoresMathSecond) / numberSubjects).ToString("#.##");
            var averageScoreThird = (((double)scoresRussianLanguageThird + scoresHistoryThird + scoresMathThird) / numberSubjects).ToString("#.##");

            #endregion

            #region Вывод данных

            // Выводим данные о первом сотруднике простым методом
            Console.WriteLine("Данные первого сотрудника: \nИмя:" + nameFirst + 
                              " Возраст:" + ageFirst + 
                              " Рост:" + growthFirst + 
                              " Баллы по русскому языку:" + scoresRussianLanguageFirst + 
                              " Баллы по истории:" + scoresHistoryFirst + 
                              " Баллы по математике:" + scoresMathFirst + 
                              " Средний балл:" + averageScoreFirst);

            Console.WriteLine(); // Пустая строка между данными

            // Выводим данные о втором сотруднике, используя форматированный вывод
            // Создадим переменную в которой будет находиться шаблон
            var pattern =
                "Данные второго сотрудника: \n" +
                "Имя: {0} \n" +
                "Возраст: {1} \n" +
                "Рост: {2} \n" +
                "Баллы по русскому языку: {3} \n" +
                "Баллы по истории: {4} \n" +
                "Баллы по математике: {5} \n" +
                "Средний балл: {6}";

            Console.WriteLine(pattern,
                              nameSecond,
                              ageSecond,
                              growthSecond,
                              scoresRussianLanguageSecond,
                              scoresHistorySecond,
                              scoresMathSecond,
                              averageScoreSecond);

            Console.WriteLine(); // Пустая строка между данными

            // Создаем переменные для использования в интерполяционном выводе
            var employee = "Данные третьего сотрудника: ";
            var name = "Имя: ";
            var age = "Возраст: ";
            var growth = "Рост: ";
            var scoresRussianLang = "Баллы по русскому языку: ";
            var scoresHistory = "Баллы по истории: ";
            var scoresMath = "Баллы по математике: ";
            var avgScore = "Средний балл: ";

            // Не совсем понял как реализовать пятое задание, вывод текста по центру
            // Точнее я нашел два способа, и дабы себя не мучить решил реализовать сразу два

            // Первый способ вывода по центру
            // Здесь мы задаем начальную позицию курсора относительно размеров консоли
            Console.SetCursorPosition((Console.WindowWidth - employee.Length) / 2, Console.CursorTop);

            // Выводим данные о третьем сотруднике, используя интерполяцию строк
            // Второй способ вывода по центру
            Console.WriteLine($"{employee} \n" + 
                              $"{name,70} {nameThird} \n" + 
                              $"{age,70} {ageThird} \n" +
                              $"{growth,70} {growthThird}  \n" +
                              $"{scoresRussianLang,70} {scoresRussianLanguageThird}  \n" +
                              $"{scoresHistory,70} {scoresHistoryThird}  \n" +
                              $"{scoresMath,70} {scoresMathThird}  \n" +
                              $"{avgScore,70} {averageScoreThird}  \n");

            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// Просим ввести пользователя число, пока она не будет в нужном формате
        /// </summary>
        /// <returns>Возвращает число</returns>
        public static int CheckInputNumber()
        {
            // Получаем пользовательский ввод
            var userInput = Console.ReadLine();

            // Проверяем ввод на наличие лишних символов
            if (!int.TryParse(userInput, out var number))
            {
                Console.WriteLine("Данные введены некорректно");
                return CheckInputNumber();
            }

            // Проверяем число на отрицательность
            if (number <= 0)
            {
                Console.WriteLine("Число не должно быть отрицательным");
                return CheckInputNumber();
            }

            // Возвращаем число
            return number;
        }

        /// <summary>
        /// Просим ввести пользователя балл за предмет, пока он не будет в нужно формате
        /// </summary>
        /// <returns>Возвращаем балл за предмет</returns>
        public static int CheckInputScores()
        {
            // Получаем пользовательский ввод
            var userInput = Console.ReadLine(); 

            // Проверяем ввод на наличие лишних символов
            if (!int.TryParse(userInput, out var score)) 
            {
                Console.WriteLine("Данные введены некорректно");
                return CheckInputScores();
            }

            // Проверяем число на нахождение в диапазоне
            if (score > 100 || score < 0)
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                return CheckInputScores();
            }

            // Возвращаем балл
            return score; 
        }
    }
}
