
namespace LB4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Виводимо заголовок для завдання з перевіркою поштових адрес
            Console.WriteLine("Task 1: Email Validation");
            Console.WriteLine("------------------------");
            // Зчитуємо емейли з файлу emeil.txt за допомогою StreamReader
            try
            {
                using (StreamReader emailReader = new StreamReader("emeil.txt"))
                {
                    string emailLine;
                    while ((emailLine = emailReader.ReadLine()) != null)
                    {
                        // Викликаємо метод для перевірки поштової адреси
                        bool isValid = IsValidEmail(emailLine.Trim());
                        // Виводимо результат перевірки
                        Console.WriteLine($"Email: {emailLine} - {(isValid ? "Valid" : "Invalid")}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл emeil.txt не знайдено");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу emeil.txt: {ex.Message}");
            }

            // Виводимо заголовок для завдання з перевіркою математичних виразів
            Console.WriteLine("\nTask 2: Mathematical Expression Validation");
            Console.WriteLine("----------------------------------------");

            try
            {
                // Зчитуємо математичні вирази з файлу Math.txt за допомогою StreamReader
                using (StreamReader mathReader = new StreamReader("Math.txt"))
                {
                    string mathLine;
                    while ((mathLine = mathReader.ReadLine()) != null)
                    {
                        // Викликаємо метод для перевірки математичного виразу
                        bool isValid = IsValidMathExpression(mathLine.Trim());
                        // Виводимо результат перевірки
                        Console.WriteLine($"Expression: {mathLine} - {(isValid ? "Valid" : "Invalid")}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл Math.txt не знайдено");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу Math.txt: {ex.Message}");
            }
        }

        // Метод для перевірки валідності поштової адреси
        static bool IsValidEmail(string email)
        {
            try
            {
                // Перевірка чи email не пустий
                if (string.IsNullOrEmpty(email))
                    return false;

                // Розділяємо email на частини до і після @
                string[] parts = email.Split('@');
                if (parts.Length != 2)
                    return false;

                string localPart = parts[0];
                string domainPart = parts[1];

                // Перевірка локальної частини
                if (localPart.Length == 0)
                    return false;

                // Перший символ має бути літерою
                if (!char.IsLetter(localPart[0]))
                    return false;

                // Перевірка символів локальної частини
                foreach (char c in localPart)
                {
                    if (!char.IsLetterOrDigit(c))
                        return false;
                }

                // Перевірка доменної частини
                if (domainPart.Length == 0)
                    return false;

                // Розділяємо домен на частини до і після крапки
                string[] domainParts = domainPart.Split('.');
                if (domainParts.Length < 2)
                    return false;

                // Перевірка TLD
                string tld = domainParts[domainParts.Length - 1].ToLower();
                if (tld != "com" && tld != "localhost")
                    return false;

                // Перевірка символів доменної частини
                foreach (char c in domainPart)
                {
                    if (!char.IsLetterOrDigit(c) && c != '.' && c != '-')
                        return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Метод для перевірки валідності математичного виразу
        static bool IsValidMathExpression(string expression)
        {
            try
            {
                // Перевірка чи вираз не пустий
                if (string.IsNullOrEmpty(expression))
                    return false;

                expression = expression.Trim();

                char[] validOperators = { '+', '-', '*', '/', '×' };
                bool expectNumber = true;
                bool hasDigit = false;

                for (int i = 0; i < expression.Length; i++)
                {
                    char currentChar = expression[i];

                    // Пропускаємо пробіли
                    if (char.IsWhiteSpace(currentChar))
                        continue;

                    if (expectNumber)
                    {
                        // Очікуємо число
                        if (char.IsDigit(currentChar))
                        {
                            hasDigit = true;
                            expectNumber = false;

                            // Пропускаємо всі цифри числа
                            while (i + 1 < expression.Length && char.IsDigit(expression[i + 1]))
                                i++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // Очікуємо оператор
                        bool isValidOperator = false;
                        foreach (char op in validOperators)
                        {
                            if (currentChar == op)
                            {
                                isValidOperator = true;
                                break;
                            }
                        }

                        if (isValidOperator)
                        {
                            expectNumber = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                // Перевіряємо чи вираз закінчується числом і чи був хоча б один символ
                return !expectNumber && hasDigit;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}