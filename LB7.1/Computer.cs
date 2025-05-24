using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Computer
{
    private Person owner;
    private TypeOfWork typeOfWork;
    private string ipAddress;
    private List<Device> devices;

    // Конструктор з параметрами
    public Computer(Person owner, TypeOfWork typeOfWork, string ipAddress, Device[] devices)
    {
        this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
        this.typeOfWork = typeOfWork;

        // Перевірка IP-адреси (проста валідація)
        if (string.IsNullOrEmpty(ipAddress) || !IsValidIPAddress(ipAddress))
            throw new ArgumentException("Некоректна IP-адреса", nameof(ipAddress));

        this.ipAddress = ipAddress;
        this.devices = devices != null ? new List<Device>(devices) : new List<Device>();
    }

    // Конструктор без параметрів
    public Computer()
    {
        owner = new Person();
        typeOfWork = TypeOfWork.Home;
        ipAddress = "192.168.1.1";
        devices = new List<Device>();
    }

    // Перевірка валідності IP-адреси
    private bool IsValidIPAddress(string ipAddress)
    {
        // Спрощена перевірка
        string[] parts = ipAddress.Split('.');
        if (parts.Length != 4) return false;

        foreach (string part in parts)
        {
            if (!int.TryParse(part, out int num) || num < 0 || num > 255)
                return false;
        }
        return true;
    }

    // Властивості для доступу до полів
    public Person Owner
    {
        get { return owner; }
        set { owner = value ?? throw new ArgumentNullException(nameof(value)); }
    }

    public TypeOfWork TypeOfWork
    {
        get { return typeOfWork; }
        set { typeOfWork = value; }
    }

    public string IPAddress
    {
        get { return ipAddress; }
        set
        {
            if (string.IsNullOrEmpty(value) || !IsValidIPAddress(value))
                throw new ArgumentException("Некоректна IP-адреса", nameof(value));
            ipAddress = value;
        }
    }

    public Device[] Devices
    {
        get { return devices.ToArray(); }
        set { devices = value != null ? new List<Device>(value) : new List<Device>(); }
    }

    // Властивість для отримання сумарної вартості пристроїв
    public double TotalPrice
    {
        get { return devices.Sum(d => d.Price); }
    }

    // Індексатор для перевірки типу роботи
    public bool this[TypeOfWork type]
    {
        get { return typeOfWork == type; }
    }

    public void AddDevices(params Device[] newDevices)
    {
        if (newDevices != null)
        {
            devices.AddRange(newDevices);
        }
    }

    // Перевантажений метод ToString()
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Власник: {owner}");
        sb.AppendLine($"Тип роботи: {typeOfWork}");
        sb.AppendLine($"IP-адреса: {ipAddress}");
        sb.AppendLine($"Загальна вартість: {TotalPrice:C}");
        sb.AppendLine("Пристрої:");

        if (devices.Count == 0)
        {
            sb.AppendLine("  Немає встановлених пристроїв");
        }
        else
        {
            for (int i = 0; i < devices.Count; i++)
            {
                sb.AppendLine($"  {i + 1}. {devices[i]}");
            }
        }
        return sb.ToString();
    }

    // Метод ToShortString()
    public string ToShortString()
    {
        return $"Власник: {owner.ToShortString()}, Тип роботи: {typeOfWork}, IP-адреса: {ipAddress}, Загальна вартість: {TotalPrice:C}, Кількість пристроїв: {devices.Count}";
    }
}