


    // Базовий клас "Пара чисел"
    public class NumberPair
    {
        // Поля для зберігання двох чисел
        protected double number1;
        protected double number2;

        // Конструктор без параметрів
        public NumberPair()
        {
            number1 = 0;
            number2 = 0;
        }

        // Конструктор з параметрами
        public NumberPair(double num1, double num2)
        {
            number1 = num1;
            number2 = num2;
        }

       
        public double Number1
        {
            get { return number1; }
            set { number1 = value; }
        }

        public double Number2
        {
            get { return number2; }
            set { number2 = value; }
        }

        public virtual double GetProduct()
        {
            return number1 * number2;
        }

        public override string ToString()
        {
            return "Пара чисел: (" + number1 + ", " + number2 + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            NumberPair other = (NumberPair)obj;
            return number1 == other.number1 && number2 == other.number2;
        }

        public override int GetHashCode()
        {
            return number1.GetHashCode() + number2.GetHashCode();
        }
    }
