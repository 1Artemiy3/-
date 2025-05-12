using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB7._2
{
    public class Deltaplane : Device
    {
        // Конструктор
        public Deltaplane(string name, double weight, int capacity, string electronics, int engineCount)
            : base(name, weight, capacity, electronics, engineCount)
        {
        }

        // Реалізація абстрактного властивості Description
        public override string Description => "Дельтаплан";

        // Дельтаплани зазвичай не мають електроніки
        public override bool HasElectronics => Electronics != null;

        // Тип двигуна для дельтапланів (зазвичай немає)
        public override string EngineType => "Відсутній";

        // Реалізація методу Clone
        public override object Clone()
        {
            return new Deltaplane(Name, Weight, Capacity, Electronics, EngineCount);
        }
    }
}
