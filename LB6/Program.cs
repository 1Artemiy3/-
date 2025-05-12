

using System.ComponentModel;
using System.Text;

class program
{
 
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Тестування класів");
        Console.WriteLine("----------------");

        
        Console.WriteLine("Тестування класу Пара чисел:");

        // Створюємо об'єкти
        NumberPair pair1 = new NumberPair(3, 4);
        NumberPair pair2 = new NumberPair(3, 4);
        NumberPair pair3 = new NumberPair(5, 2);

        // Виводимо інформацію
        Console.WriteLine(pair1);
        Console.WriteLine("Добуток чисел: " + pair1.GetProduct());

        // Змінюємо значення
        pair1.Number1 = 7;
        pair1.Number2 = 8;
        Console.WriteLine("Після зміни: " + pair1);
        Console.WriteLine("Новий добуток: " + pair1.GetProduct());

        // Порівнюємо об'єкти
        Console.WriteLine("pair2 дорівнює pair3: " + pair2.Equals(pair3));
        Console.WriteLine("----------------");

        // Тестування класу 
        Console.WriteLine("Тестування класу Прямокутний трикутник:");

        // Створюємо об'єкти
        RightTriangle triangle1 = new RightTriangle(3, 4);
        RightTriangle triangle2 = new RightTriangle(5, 12);
        RightTriangle triangle3 = new RightTriangle(3, 4);

        // Виводимо інформацію
        Console.WriteLine(triangle1);
        Console.WriteLine("Гіпотенуза: " + triangle1.GetHypotenuse());
        Console.WriteLine("Площа: " + triangle1.GetArea());

        // Змінюємо значення
        triangle1.Cathetus1 = 8;
        triangle1.Cathetus2 = 6;
        Console.WriteLine("Після зміни: " + triangle1);

        // Порівнюємо об'єкти
        Console.WriteLine("triangle2 дорівнює triangle3: " + triangle2.Equals(triangle3));
        Console.WriteLine("----------------");

        
        Console.WriteLine("Тестування масиву об'єктів:");

        // Створюємо масив
        NumberPair[] figures = new NumberPair[4];
        figures[0] = new NumberPair(1, 2);
        figures[1] = new RightTriangle(3, 4);
        figures[2] = new NumberPair(7, 3);
        figures[3] = new RightTriangle(5, 12);

        // Виводимо інформацію про об'єкти
        for (int i = 0; i < figures.Length; i++)
        {
            Console.WriteLine("Об'єкт " + (i + 1) + ": " + figures[i]);
            Console.WriteLine("Результат GetProduct(): " + figures[i].GetProduct());

            // Перевіряємо тип об'єкта
            if (figures[i] is RightTriangle)
            {
                RightTriangle triangle = (RightTriangle)figures[i];
                Console.WriteLine("Площа трикутника: " + triangle.GetArea());
            }
            Console.WriteLine();
        }

        // Тестування з неправильними даними
        Console.WriteLine("Тестування з неправильними даними:");
        RightTriangle badTriangle = new RightTriangle(-1, 4);

        // Тестування зміни значень на неправильні
        triangle1.Cathetus1 = -5;

        Console.WriteLine("\nНатисніть Enter для завершення...");
        Console.ReadLine();
    }

}