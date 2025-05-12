using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB7._2
{
    public class Helicopter : Device
    {
        public int MaxSpeed { get; set; }  // Максимальна швидкість у км/год

        
        public Helicopter(string name, double weight, int capacity, int maxSpeed, string electronics, int engineCount)
            : base(name, weight, capacity, electronics, engineCount)
        {
            MaxSpeed = maxSpeed;
        }

     
        public override string Description => "Вертоліт";

        
        public override bool HasElectronics => true;

        
        public override string EngineType => "Роторний";

        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Максимальна швидкість: {MaxSpeed} км/год");
        }

        
        public override object Clone()
        {
            return new Helicopter(Name, Weight, Capacity, MaxSpeed, Electronics, EngineCount);
        }
    }
}
