using System;

namespace HomeWork_05
{
    public class Progression
    {
        public static void MainLogic()
        {
            var numberArray = InputNumbers();

            ProgressionNumbers(numberArray);
        }

        public static double[] InputNumbers()
        {
            while (true)
            {
                Print.Text("Введите длину последовательности чисел: ", ConsoleColor.DarkCyan);
                var count = Check.InputUser();

                if (count < 3)
                {
                    Print.Text("Длина последовательности не может быть меньше трех", ConsoleColor.DarkRed);
                    continue;
                }

                Print.Text("Введите последовательность чисел: ", ConsoleColor.DarkCyan);
                var numberArray = new double[count];

                for (int i = 0; i < count; i++)
                {
                    numberArray[i] = Check.InputDouble();
                }

                return numberArray;
            }
        }

        public static void ProgressionNumbers(params double[] array)
        {
            Print.Text(ArithmeticProgression(array)
                            ? "Данная последовательность чисел, арифмтическая прогрессия"
                            : "Данная последовательность чисел, не арифмитическая прогрессия");
            
            Print.Text(GeometricProgression(array)
                            ? "Данная последовательность чисел, геометрическая прогрессия"
                            : "Данная последовательность чисел, не геометрическая прогрессия");

            Program.BackChoice();
            Program.ChoiceProgram();
        }

        public static bool ArithmeticProgression(params double[] array)
        {
            double step = array[1] - array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] + step != array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool GeometricProgression(params double[] array)
        {
            double step = array[1] / array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] * step != array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}