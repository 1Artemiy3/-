using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB7._2
{
    
    public interface IDevice
    {
        string Name { get; set; }      
        double Weight { get; set; }    // Вага пристрою в кг
        int Capacity { get; set; }     // Кількість пасажирів
        string Description { get; }    // Опис пристрою
        bool HasElectronics { get; }   
    }

    // Інтерфейс для опису двигунів пристроїв
    public interface IEngine
    {
        int EngineCount { get; set; }  // Кількість двигунів
        string EngineType { get; }      // Тип двигуна
        bool HasEngine { get; }         // Чи має двигун
    }

    // Інтерфейс для опису частин пристроїв
    public interface IPart
    {
        string PartName { get; set; }  // Назва частини
        void DisplayPartInfo();        // Метод для відображення інформації про частину
    }
}
