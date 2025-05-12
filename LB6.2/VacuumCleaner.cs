


    // Клас "Пилосос"
    public class VacuumCleaner : HouseholdAppliance
    {
        // Додаткові поля
        private int powerConsumption; // Споживана потужність у Вт
        private int dustContainerCapacity; // Об'єм контейнера для пилу в літрах

        // Конструктор без параметрів
        public VacuumCleaner() : base()
        {
            powerConsumption = 0;
            dustContainerCapacity = 0;
        }

        // Конструктор з одним параметром
        public VacuumCleaner(string name) : base()
        {
            this.name = name;
            powerConsumption = 1500;
            dustContainerCapacity = 2;
        }

        // Конструктор з усіма параметрами
        public VacuumCleaner(string name, double price, double weight, string manufacturer,
                            int powerConsumption, int dustContainerCapacity)
                            : base(name, price, weight, manufacturer)
        {
            this.powerConsumption = powerConsumption;
            this.dustContainerCapacity = dustContainerCapacity;
        }

        // Властивості
        public int PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }

        public int DustContainerCapacity
        {
            get { return dustContainerCapacity; }
            set { dustContainerCapacity = value; }
        }

        // Перевизначений метод для виконання дії
        public override void DoWork()
        {
            if (isOn)
            {
                Console.WriteLine(name + " збирає пил з підлоги");
            }
            else
            {
                Console.WriteLine("Спочатку увімкніть пилосос!");
            }
        }

        // Метод для очищення контейнера для пилу
        public void CleanDustContainer()
        {
            Console.WriteLine("Контейнер для пилу очищено");
        }

        // Перевизначений метод ToString
        public override string ToString()
        {
            return base.ToString() +
                   ", Потужність: " + powerConsumption + " Вт" +
                   ", Об'єм контейнера: " + dustContainerCapacity + " л";
        }
    }
