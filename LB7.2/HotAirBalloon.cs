using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB7._2
{
   
    public class HotAirBalloon : Device
    {
        
        public HotAirBalloon(string name, double weight, int capacity, string electronics, int engineCount)
            : base(name, weight, capacity, electronics, engineCount)
        {
        }
        public override string Description => "Повітряна куля";
   
        public override bool HasElectronics => Electronics != null;
  
        public override string EngineType => "Газовий нагрівач";

        public override object Clone()
        {
            return new HotAirBalloon(Name, Weight, Capacity, Electronics, EngineCount);
        }

    }
}
