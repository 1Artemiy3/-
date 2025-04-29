
public class Person
{
    private string firstName;
    private string lastName;
    private DateTime birthDate;

    // Конструктор с параметрами
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
    }

    // Конструктор без параметров
    public Person()
    {
        firstName = "Артем ";
        lastName = "Шулещенко";
        birthDate = new DateTime(2007, 4, 13);
    }

    // Властивості для доступу до полів
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

    // Властивість для доступу до року народження
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
}