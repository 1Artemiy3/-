using System;

public class Device : IComparable<Device>, ICloneable
{
    // Автореалізуємі властивості
    public string Name { get; set; }
    public double Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    
    public Device(string name, double price, DateTime releaseDate)
    {
        Name = name;
        Price = price;
        ReleaseDate = releaseDate;
    }

    public Device()
    {
        Name = "Невідомий пристрій";
        Price = 0.0;
        ReleaseDate = DateTime.Now;
    }

    // Перевантажений метод ToString()
    public override string ToString()
    {
        return $"Назва: {Name}, Вартість: {Price:C}, Дата випуску: {ReleaseDate.ToShortDateString()}";
    }

    public int CompareTo(Device other)
    {
        if (other == null)
            return 1;

        return Price.CompareTo(other.Price);
    }

    public object Clone()
    {
        return new Device(Name, Price, ReleaseDate);
    }
}