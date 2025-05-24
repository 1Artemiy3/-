using System;

public class Person : IComparable<Person>, ICloneable
{
    private string firstName;
    private string lastName;
    private DateTime birthDate;

    
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
    }

    // Конструктор без параметров
    public Person()
    {
        firstName = "Артем";
        lastName = "Шулещенко";
        birthDate = new DateTime(2007, 4, 13);
    }

    // для доступу до полів
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    // для доступу до року народження
    public int BirthYear
    {
        get { return birthDate.Year; }
        set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
    }

    // Перевантажений метод ToString()
    public override string ToString()
    {
        return $"Ім'я: {firstName}, Прізвище: {lastName}, Дата народження: {birthDate.ToShortDateString()}";
    }

    // Метод ToShortString()
    public string ToShortString()
    {
        return $"Ім'я: {firstName}, Прізвище: {lastName}";
    }

    
    public int CompareTo(Person other)
    {
        if (other == null)
            return 1;

        int result = lastName.CompareTo(other.lastName);
        if (result == 0)
        {
            result = firstName.CompareTo(other.firstName);
        }
        return result;
    }

    public object Clone()
    {
        return new Person(firstName, lastName, birthDate);
    }
}