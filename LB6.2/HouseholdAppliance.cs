

    // Абстрактний клас "Побутовий пристрій"
    public abstract class HouseholdAppliance
    {
        // Поля
        protected string name;        // Назва пристрою
        protected double price;       // Ціна пристрою
        protected double weight;      // Вага пристрою в кг
        protected string manufacturer; // Виробник
        protected bool isOn;          // Чи ввімкнено пристрій

        // Конструктор без параметрів
        public HouseholdAppliance()
        {
            name = "Невідомий пристрій";
            price = 0;
            weight = 0;
            manufacturer = "Невідомо";
            isOn = false;
        }

        // Конструктор з параметрами
        public HouseholdAppliance(string name, double price, double weight, string manufacturer)
        {
            if (name == "" || name == null)
            {
                Console.WriteLine("Помилка: назва пристрою не може бути порожньою");
                name = "Невідомий пристрій";
            }

            if (price < 0)
            {
                Console.WriteLine("Помилка: ціна не може бути від'ємною");
                price = 0;
            }

            if (weight <= 0)
            {
                Console.WriteLine("Помилка: вага повинна бути більше нуля");
                weight = 1;
            }

            this.name = name;
            this.price = price;
            this.weight = weight;
            this.manufacturer = manufacturer;
            this.isOn = false;
        }

        // Властивості
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public bool IsOn
        {
            get { return isOn; }
        }

        // Методи
        public virtual void TurnOn()
        {
            isOn = true;
            Console.WriteLine(name + " увімкнено");
        }

        public virtual void TurnOff()
        {
            isOn = false;
            Console.WriteLine(name + " вимкнено");
        }

        // Абстрактний метод для виконання дії пристроєм
        public abstract void DoWork();

        // Перевизначений метод ToString
        public override string ToString()
        {
            return "Назва: " + name +
                   ", Виробник: " + manufacturer +
                   ", Ціна: " + price + " грн" +
                   ", Вага: " + weight + " кг";
        }
    }
