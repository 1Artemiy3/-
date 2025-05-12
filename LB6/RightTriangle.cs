

    // Похідний клас "Прямокутний трикутник"
    public class RightTriangle : NumberPair
    {
        // Конструктор без параметрів
        public RightTriangle() : base()
        {
        }

        // Конструктор з параметрами
        public RightTriangle(double cathetus1, double cathetus2) : base(cathetus1, cathetus2)
        {
            // Перевірка, що катети додатні
            if (cathetus1 <= 0 || cathetus2 <= 0)
            {
                Console.WriteLine("Помилка: катети повинні бути додатними");
                // Встановлюємо значення за замовчуванням
                number1 = 1;
                number2 = 1;
            }
        }

        // Властивості для катетів
        public double Cathetus1
        {
            get { return number1; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Помилка: катет повинен бути додатним");
                else
                    number1 = value;
            }
        }

        public double Cathetus2
        {
            get { return number2; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Помилка: катет повинен бути додатним");
                else
                    number2 = value;
            }
        }

        // Метод для обчислення гіпотенузи
        public double GetHypotenuse()
        {
            // Теорема Піфагора: c = √(a² + b²)
            double hypotenuse = Math.Sqrt(number1 * number1 + number2 * number2);
            return hypotenuse;
        }

        // Метод для обчислення площі
        public double GetArea()
        {
            // Площа прямокутного трикутника: S = (a * b) / 2
            double area = (number1 * number2) / 2;
            return area;
        }

        // Перевизначення ToString
        public override string ToString()
        {
            return "Прямокутний трикутник: катети = (" + number1 + ", " + number2 +
                   "), гіпотенуза = " + Math.Round(GetHypotenuse(), 2) +
                   ", площа = " + Math.Round(GetArea(), 2);
        }

        // Перевизначення Equals
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        // Перевизначення GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
