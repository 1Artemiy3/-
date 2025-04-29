
public class Device
{
    // Автореалізуємі властивості
    public string Name { get; set; }
    public double Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    // Конструктор з параметрами
    public Device(string name, double price, DateTime releaseDate)
    {
        Name = name;
        Price = price;
        ReleaseDate = releaseDate;
    }

    // Конструктор без параметрів
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
}