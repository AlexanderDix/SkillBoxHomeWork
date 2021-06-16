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
            int ageFirst = Convert.ToInt32(Console.ReadLine());

            if (ageFirst <= 0) // Проверяем веденный возраст
            {
                Console.WriteLine("Ваш возраст не может быть отрицательным");
                ageFirst = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваш рост, в сантиметрах: ");
            int growthFirst = Convert.ToInt32(Console.ReadLine());

            if (growthFirst <= 0) // Проверяем введенный рост
            {
                Console.WriteLine("Ваш рост не может быть отрицательным");
                growthFirst = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по русскому языку: ");
            int scoresRussianLanguageFirst = Convert.ToInt32(Console.ReadLine());

            if (scoresRussianLanguageFirst > 100 || scoresRussianLanguageFirst < 0) // Проверка баллов
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresRussianLanguageFirst = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по истории: ");
            int scoresHistoryFirst = Convert.ToInt32(Console.ReadLine());

            if (scoresHistoryFirst > 100 || scoresHistoryFirst < 0) // Проверка баллов
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresHistoryFirst = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по математике: ");
            int scoresMathFirst = Convert.ToInt32(Console.ReadLine());

            if (scoresMathFirst > 100 || scoresMathFirst < 0) // Проверка баллов
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresMathFirst = Convert.ToInt32(Console.ReadLine());
            }

            Console.Clear(); // Очищаем консоль

            #endregion

            #region Второй сотрудник

            // Создаем переменные для хранения данных о втором сотруднике,
            // а также просим пользователя ввести данные
            Console.WriteLine("Второй сотрудник \nВведите Ваше имя: ");
            string nameSecond = Console.ReadLine();

            Console.WriteLine("Введите Ваш полный возраст: ");
            int ageSecond = Convert.ToInt32(Console.ReadLine());

            if (ageSecond <= 0) // Проверяем веденный возраст
            {
                Console.WriteLine("Ваш возраст не может быть отрицательным");
                ageSecond = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваш рост, в сантиметрах: ");
            double growthSecond = Convert.ToDouble(Console.ReadLine());

            if (growthSecond <= 0) // Проверяем введенный рост
            {
                Console.WriteLine("Ваш рост не может быть отрицательным");
                growthSecond = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по русскому языку: ");
            int scoresRussianLanguageSecond = Convert.ToInt32(Console.ReadLine());

            if (scoresRussianLanguageSecond > 100 || scoresRussianLanguageSecond < 0) // Проверка баллов
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresRussianLanguageSecond = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по истории: ");
            int scoresHistorySecond = Convert.ToInt32(Console.ReadLine());

            if (scoresHistorySecond > 100 || scoresHistorySecond < 0)
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresHistorySecond = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по математике: ");
            int scoresMathSecond = Convert.ToInt32(Console.ReadLine());

            if (scoresMathSecond > 100 || scoresMathSecond < 0)
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresMathSecond = Convert.ToInt32(Console.ReadLine());
            }

            Console.Clear(); // Очищаем консоль

            #endregion

            #region Третий сотрудник

            // Создаем переменные для хранения данных о втором сотруднике,
            // а также просим пользователя ввести данные
            Console.WriteLine("Третий сотрудник \nВведите Ваше имя: ");
            string nameThird = Console.ReadLine();

            Console.WriteLine("Введите Ваш возраст: ");
            int ageThird = Convert.ToInt32(Console.ReadLine());

            if (ageThird <= 0) // Проверяем веденный возраст
            {
                Console.WriteLine("Ваш возраст не может быть отрицательным");
                ageThird = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваш рост: ");
            double growthThird = Convert.ToDouble(Console.ReadLine());

            if (growthThird <= 0) // Проверяем введенный рост
            {
                Console.WriteLine("Ваш рост не может быть отрицательным");
                growthThird = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по русскому языку: ");
            int scoresRussianLanguageThird = Convert.ToInt32(Console.ReadLine());

            if (scoresRussianLanguageThird > 100 || scoresRussianLanguageThird < 0) // Проверка баллов
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresRussianLanguageThird = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по истории: ");
            int scoresHistoryThird = Convert.ToInt32(Console.ReadLine());

            if (scoresHistoryThird > 100 || scoresHistoryThird < 0)
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresHistoryThird = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите Ваши баллы по математике: ");
            int scoresMathThird = Convert.ToInt32(Console.ReadLine());

            if (scoresMathThird > 100 || scoresMathThird < 0) // Проверка баллов
            {
                Console.WriteLine("Ваши баллы должны находиться в диапазоне от нуля до ста");
                scoresMathThird = Convert.ToInt32(Console.ReadLine());
            }

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
    }
}
