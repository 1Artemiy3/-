


    // Клас "Кухонний комбайн"
    public class FoodProcessor : HouseholdAppliance
    {
        // Додаткові поля
        private int speed; // Кількість швидкостей
        private int numberOfAttachments; // Кількість насадок

        // Конструктор без параметрів
        public FoodProcessor() : base()
        {
            speed = 0;
            numberOfAttachments = 0;
        }

        // Конструктор з трьома параметрами
        public FoodProcessor(string name, double price, string manufacturer) : base()
        {
            this.name = name;
            this.price = price;
            this.manufacturer = manufacturer;
            speed = 5;
            numberOfAttachments = 7;
            weight = 4.2;
        }

        // Конструктор з усіма параметрами
        public FoodProcessor(string name, double price, double weight, string manufacturer,
                             int speed, int numberOfAttachments)
                             : base(name, price, weight, manufacturer)
        {
            this.speed = speed;
            this.numberOfAttachments = numberOfAttachments;
        }

        // Властивості
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int NumberOfAttachments
        {
            get { return numberOfAttachments; }
            set { numberOfAttachments = value; }
        }

        // Перевизначений метод для виконання дії
        public override void DoWork()
        {
            if (isOn)
            {
                Console.WriteLine(name + " подрібнює продукти");
            }
            else
            {
                Console.WriteLine("Спочатку увімкніть кухонний комбайн!");
            }
        }

        // Метод для зміни швидкості
        public void ChangeSpeed(int newSpeed)
        {
            if (newSpeed > 0 && newSpeed <= speed)
            {
                Console.WriteLine("Швидкість змінено на " + newSpeed);
            }
            else
            {
                Console.WriteLine("Такої швидкості не існує!");
            }
        }

        // Перевизначений метод ToString
        public override string ToString()
        {
            return base.ToString() +
                   ", Швидкості: " + speed +
                   ", Кількість насадок: " + numberOfAttachments;
        }
    }
