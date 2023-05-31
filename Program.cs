using System.Text;

namespace CourseProject
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int passwordLength;
            int choice;

            Console.WriteLine("Генератор случайных паролей".ToUpper());
            Console.WriteLine();
            Console.Write("Введите длину пароля: ");

            while (!int.TryParse(Console.ReadLine(), out passwordLength) || passwordLength <= 0)
            {
                Console.WriteLine("Некорректная длина пароля. Пожалуйста, введите положительное целое число.");
                Console.Write("Введите длину пароля: ");
            }

            Console.WriteLine();
            Console.WriteLine("Выберите набор символов для пароля:");
            Console.WriteLine("1. Только цифры");
            Console.WriteLine("2. Только буквы верхнего и нижнего регистра");
            Console.WriteLine("3. Цифры и буквы верхнего и нижнего регистра");
            Console.WriteLine("4. Цифры, буквы верхнего и нижнего регистра, специальные символы");
            Console.WriteLine();
            Console.Write("Ваш выбор (1-4): ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, введите число от 1 до 4.");
                Console.Write("Ваш выбор (1-4): ");
            }

            string password = GeneratePassword(passwordLength, choice);

            Console.WriteLine();
            Console.WriteLine("Сгенерированный пароль:");
            Console.WriteLine(password);

            Clipboard.SetText(password);

            Console.WriteLine();
            Console.WriteLine("Пароль был успешно скопирован");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static string GeneratePassword(int length, int choice)
        {
            string passwordChars = "";

            switch (choice)
            {
                case 1:
                    passwordChars = "0123456789";
                    break;
                case 2:
                    passwordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                case 3:
                    passwordChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                case 4:
                    passwordChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()";
                    break;
            }

            Random random = new Random();
            StringBuilder passwordBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                passwordBuilder.Append(passwordChars[random.Next(passwordChars.Length)]);
            }

            return passwordBuilder.ToString();
        }
    }
}