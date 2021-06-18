using System;

namespace HomeWork_03
{
    class Program
    {
        static void Main()
        {
            // Создание переменной random для получения псевдослучайного числа
            Random random = new();

            // Создание переменной gameNumber для получения числа в диапазоне от 12 до 100
            var gameNumber = random.Next(12, 101);

            while (gameNumber > 0)
            {
                Console.WriteLine("Введите число от 1 до 4");
                // Создание переменной userTry для пользовательского ввода
                var userTry = Convert.ToInt32(Console.ReadLine()); 

                switch (userTry)
                {
                    case 1:
                        gameNumber -= 1;
                        break;
                    case 2:
                        gameNumber -= 2;
                        break;
                    case 3:
                        gameNumber -= 3;
                        break;
                    case 4:
                        gameNumber -= 4;
                        break;
                    default:
                        continue;
                }

                Console.WriteLine($"Число равно: {gameNumber}");
            }
        }
    }
}
