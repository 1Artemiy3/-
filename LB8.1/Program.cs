



using System;


class Program
{
  
    static void DisplayCurrentTime()
    {

        Console.WriteLine($"Поточний час: {DateTime.Now.ToLongTimeString()}");
    }

    
    static void DisplayCurrentDate()
    {
        
        Console.WriteLine($"Поточна дата: {DateTime.Now.ToLongDateString()}");
    }

    
    static void DisplayCurrentDayOfWeek()
    {
        
        Console.WriteLine($"Поточний день тижня: {DateTime.Now.DayOfWeek}");
    }

    // Метод для перевірки, чи є число простим 
    static bool IsPrimeNumber(int number)
    {
        // Перевірка базових випадків
        if (number <= 1) return false; 
        if (number == 2) return true;  
        if (number % 2 == 0) return false; 

        // Оптимізація перевірки простих чисел 
        var boundary = (int)Math.Floor(Math.Sqrt(number));

        // Перевірка непарних дільників
        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false; // число не просте
        }

        return true; // число просте
    }

    //  чи є число числом Фібоначчі 
    static bool IsFibonacciNumber(int number)
    {
      // Фібоначчі
        return IsPerfectSquare(5 * number * number + 4) ||
               IsPerfectSquare(5 * number * number - 4);
    }

    //  чи є число perfect square
    static bool IsPerfectSquare(int number)
    {
        int sqrt = (int)Math.Sqrt(number);
        return sqrt * sqrt == number;
    }

    //  обчислення площі трикутника 
    static double CalculateTriangleArea(double baseLength, double height)
    {
        
        return 0.5 * baseLength * height;
    }

   
    static double CalculateRectangleArea(double length, double width)
    {
        // Формула площі прямокутника
        return length * width;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
       
        Action displayTime = DisplayCurrentTime;
        Action displayDate = DisplayCurrentDate;
        Action displayDayOfWeek = DisplayCurrentDayOfWeek;

        // Виклик методів через делегати
        displayTime();
        displayDate();
        displayDayOfWeek();

        // Демонстрація Predicate делегатів
        Predicate<int> isPrime = IsPrimeNumber;
        Predicate<int> isFibonacci = IsFibonacciNumber;

        Console.WriteLine("\nПеревірка простих чисел:");
        int[] numbersToPrimeTest = { 2, 3, 4, 5, 6, 7, 11, 13, 17 };
        foreach (var num in numbersToPrimeTest)
        {
            Console.WriteLine($"{num} є простим числом: {isPrime(num)}");
        }

        Console.WriteLine("\nПеревірка чисел Фібоначчі:");
        int[] numbersToFibTest = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 13, 21 };
        foreach (var num in numbersToFibTest)
        {
            Console.WriteLine($"{num} є числом Фібоначчі: {isFibonacci(num)}");
        }

        //делегати для обчислення площ
        Func<double, double, double> triangleArea = CalculateTriangleArea;
        Func<double, double, double> rectangleArea = CalculateRectangleArea;

        Console.WriteLine("\nОбчислення площ:");
        Console.WriteLine($"Площа трикутника (основа 5, висота 4): {triangleArea(5, 4)}");
        Console.WriteLine($"Площа прямокутника (довжина 6, ширина 3): {rectangleArea(6, 3)}");
    }
}
