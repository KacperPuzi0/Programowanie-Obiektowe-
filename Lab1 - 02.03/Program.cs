static class StringExt
{
    public static String Double(this String instance)
    {
        return instance + instance;
    }
}
public class PersonProperties
{
    static void Main(string[] args)
    {
        PersonProperties PersonProperties = PersonProperties.of("Kacperek");
        Console.WriteLine(PersonProperties.FirstName);


        Student[] student = new Student[]
       {
            new Student()
            {
                Nazwisko = "Zięba",
                Imie = "Hubert",
                Średnia = 8m
            },
            new Student()
            {
                Nazwisko = "Zięba",
                Imie = "Kacper",
                Średnia = 1m
            },
            new Student()
            {
                Nazwisko = "Zięba",
                Imie = "Maciek",
                Średnia = 6m
            }
       };
        Array.Sort(student);
        Array.ForEach(student, x => Console.WriteLine(x.Średnia + " " + x.Imie + " " + x.Nazwisko));

        Students[] students =
            {
                new Students(){ECTS=10,Name="Jurand"},
                new Students(){ECTS=45,Name="Mateusz"},
                new Students(){ECTS=3,Name="Maciek"},
                new Students(){ECTS=1,Name="Kacper"},
                new Students(){ECTS=90,Name="Pan Wykładowca"}
            };
            Array.Sort(students);
        foreach (var item in students)
        {
            Console.WriteLine(item.ECTS + " " + item.Name);
        }

        Console.WriteLine("abcd".Double());



    }
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
            if (moneya.Currency != moneyb.Currency)
            {
                throw new ArgumentException("Inne waluty");
            }
            return new Money(moneya.Value + moneyb.Value, moneya.Currency);
        }

        // Ćwiczenie 6
        // Zdefiniuj operator < dla klasy Money.

        public static bool operator >(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Inne waluty");
            }
            return a.Value > b.Value;
        }

        public static bool operator <(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Inne waluty");
            }
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
            if (amount > _level)
            {
                return false;
            }
            Level = _level - amount;
            return true;
        }

        // Ćwiczenie 9 
        // Zaimplementuj metodę przelewania z jednego zbiornika do drugiego o poniższej sygnaturze

        public bool refuel(Tank sourceTank, int amount)
        {
            if (_level + amount > Capacity)
            {
                return false;
            }
            if (sourceTank.consume(amount))
            {
                this.refuel(amount);
                return true;
            }
            return false;
        }
    }

    // Ćwiczenie 10 
    // Dla klasy Student zdefiniuj interfejs IComparable w jednej z poniższych wersji:

    public class Student : IComparable
    {

        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public decimal Średnia { get; set; }

        public int CompareTo(object?obj)
        {
            if (!(obj is Student))
            {
                throw new ArgumentException("To nie student, to wykładowca");
            }
            Student student = obj as Student;
            return Średnia.CompareTo(student.Średnia);
            return Nazwisko.CompareTo(student.Nazwisko);
            return Imie.CompareTo(student.Imie);
        }
    } 
    class Students : IComparable<Students>
    {
        public int ECTS { get; set; }
        public string Name { get; set; }

        //posortować studentów wg ECTS, a dla studentów o tym samym ECTS wg Name
        public int CompareTo(Students other)
        {
            if(ReferenceEquals(this, other)) return 0;
            if(ReferenceEquals(null, other)) return 1;  
            var Resulcik = ECTS.CompareTo(other.ECTS);
            if(Resulcik != 0) return Resulcik;
            return Name.CompareTo(other.Name);
        }
    }
}

