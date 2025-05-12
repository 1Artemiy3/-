
using LB7._2;
using System;


    
    public class ElectronicPart : IPart
    {
        public string PartName { get; set; }
        public string Purpose { get; set; }  // Призначення електронної частини

        public ElectronicPart(string name, string purpose)
        {
            PartName = name;
            Purpose = purpose;
        }

        // Реалізація методу з інтерфейсу IPart
        public void DisplayPartInfo()
        {
            Console.WriteLine($"Електронна частина: {PartName}");
            Console.WriteLine($"Призначення: {Purpose}");
        }
    }
