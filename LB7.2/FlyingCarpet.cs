using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB7._2
{
    public class FlyingCarpet : Device
    {
        
        public FlyingCarpet(string name, double weight, int capacity, string electronics, int engineCount)
            : base(name, weight, capacity, electronics, engineCount)
        {
        }

        
        public override string Description => "Килим, що літає";

        
        public override bool HasElectronics => Electronics != null;

       
        public override string EngineType => "Магічний";

        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Особливість: Працює на магії");
        }

       
        public override object Clone()
        {
            return new FlyingCarpet(Name, Weight, Capacity, Electronics, EngineCount);
        }
    }
}
