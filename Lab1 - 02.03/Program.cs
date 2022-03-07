class Program
{
    static void Main(string[] args)
    {
        PersonProperties PersonProperties = PersonProperties.of("Kacperek");
        Console.WriteLine(PersonProperties.FirstName);
    }
}
public class PersonProperties
{
    private string _firstName;

    private PersonProperties(string firstName)
    {
        _firstName = firstName;
    }

    public static PersonProperties of(string firstName)
    {
        if (firstName.Length >= 2)
        {
            return new PersonProperties(firstName);
        }
        else
        {
            throw new ArgumentException("Nazwa jest za krotka");
        }
    }
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            if (value.Length >= 3)
            {
                _firstName = value;
            }
        }
    }
}