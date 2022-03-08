﻿class Program
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

        public static Money Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }

        // Ćwiczenie 1 
        // Zdefiniuj metodę wytwórczą OfWithException, która w przypadku nie możności zbudowania poprawnego
        // obiektu zgłasza wyjątek.
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
        // Zdefiniuj metodę wytwórczą ParseValue(string valueStr, Currency currency), która tworzy obiekt na
        // podstawie łańcucha z wartością kwoty np. ”13,45”.
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

        public decimal Value
        {
            get { return _value; }
        }

        // Ćwiczenie 3 
        // Zdefiniuj właściwość Currency tylko do zwracania waluty

        public Currency Currency { get { return _currency; } }

        // Ćwiczenie 4 
        // Zdefiniuj operator mnożenia dla operandów typu decimal i Money.

        public static Money operator *(Money money, decimal value)
        {
            return Money.Of(money.Value * value, money.Currency);
        }

        public static Money operator *(decimal value, Money money)
        {
            return Money.Of(money._value * value, money._currency);
        }

        // Ćwiczenie 5 
        // Zdefiniuj operator dodawania dla dwóch obiektów typu Money

        public static Money operator +(Money moneya, Money moneyb)
        {
            return new Money(moneya.Value + moneyb.Value, moneya.Currency);
        }

        // Ćwiczenie 6
        // Zdefiniuj operator < dla klasy Money.

        public static bool operator >(Money a, Money b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(Money a, Money b)
        {
            return a.Value < b.Value;
        }

        // Ćwiczenie 7 
        // Zdefiniuj opereator jawnego rzutowania do typu float 

        // Operatory jawne ( explicit ) 
        // Operatory niejawne ( implicit ) 

        public static explicit operator float(Money money)
        {
            return (float)money.Value;
        }
    }

    // KLASY ZE STANEM 
    public class Tank
    {
        public readonly int Capacity;
        private int _level;

        public Tank(int capacity)
        {
            Capacity = capacity;
        }

        public int Level
        {
            get { return _level; }
            private set
            {
                if (value < 0 || value > Capacity)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _level = value;
            }
        }

        // Metoda dolewania 
        public bool refuel1(int amount)
        {
            if (amount < 0)
            {
                return false;
            }
            if (_level + amount > Capacity)
            {
                return false;
            }
            _level += amount;
            return true;
        }

        // Drugi sposób 
        public void refuel(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Argument can't be non positive");
            }
            if (_level + amount > Capacity)
            {
                throw new ArgumentException("Argument is to large!");
            }
            _level += amount;
        }


        // Ćwiczenie 8
        // Zaimplementuje metodę bool consume(int amount), która pobiera ze zbiornika ciecz o objętości w amount.
        // W sytuacji, gdy niemożliwe jest pobranie takiej ilości cieczy metoda powinna zwrócić false;

        public bool consume(int amount)
        {
            if (amount > 0)
            {
                return true;
            }
            if (_level - amount < Capacity || _level - amount > 0)
            {
                return true;
            }
            return false;
        }

        // Ćwiczenie 9 
        // Zaimplementuj metodę przelewania z jednego zbiornika do drugiego o poniższej sygnaturze

        public bool refuel(Tank sourceTank, int amount)
        {
            if (_level + amount > Capacity)
            {
                int result = Capacity - amount;
                _level = Capacity;
                return result > 0;
            }
            _level -= amount;
            return true;
        }
    }

    // Ćwiczenie 10 
    // Dla klasy Student zdefiniuj interfejs IComparable w jednej z poniższych wersji:

    class Student
    {
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public decimal Średnia { get; set; }
    } 
}