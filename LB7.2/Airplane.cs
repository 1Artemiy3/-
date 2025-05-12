using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB7._2
{

    public class Airplane : Device
    {
        public int MaxSpeed { get; set; }  // Максимальна швидкість у км/год

        // Конструктор
        public Airplane(string name, double weight, int capacity, int maxSpeed, string electronics, int engineCount)
            : base(name, weight, capacity, electronics, engineCount)
        {
            MaxSpeed = maxSpeed;
        }

        // Реалізація абстрактного властивості Description
        public override string Description => "Літак";

        // Літаки завжди мають електроніку
        public override bool HasElectronics => true;

        // Тип двигуна для літаків
        public override string EngineType => "Авіаційний";

        // Перевизначення методу відображення інформації
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Максимальна швидкість: {MaxSpeed} км/год");
        }

        // Реалізація методу Clone
        public override object Clone()
        {
            return new Airplane(Name, Weight, Capacity, MaxSpeed, Electronics, EngineCount);
        }
    }
}
