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

    // Klasa Money 
    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR = 3
    }
    public class Money
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;   
        }

        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }

        // Ćwiczenie 1 
        public static Money? OfWithException(decimal value, Currency currency)
        {
            if (value < 0)
            {
                throw new ArgumentException("Hubert nie masz pieniędzy na koncie");
            }
            else
            {
                return new Money(value, currency);
            }
        }

        // Ćwiczenie 2 
        public static Money? ParseValue(string value, Currency currency)
        {
            decimal parseValue;
            bool succes = decimal.TryParse(value, out parseValue);
            if (succes)
            {
                return Money.Of(parseValue, currency);
            }
            else
            {
                throw new ArgumentException("Niepoprawny argument");
            }
        }

        // Ćwiczenie 3 


    }

}