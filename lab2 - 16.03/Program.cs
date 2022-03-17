abstract class AbstractMessage
{
    public string Content { get; init; }
    public abstract bool Send();
}

class EmailMessage : AbstractMessage
{
    public string To { get; init; }
    public string From { get; init; }
    public string Subject { get; init; }

    public override bool Send()
    {
        Console.WriteLine($"Sending email from: {From} to {To} with content {Content}");
        return true;
    }
}

class SMSMessage : AbstractMessage
{
    public string ToPhone { get; init; }
    public string FromPhone { get; init; }
    public override bool Send()
    {
        Console.WriteLine($"Sending SMS from: {FromPhone} to {ToPhone} with content {Content}");
        return true;
    }
}

class MessengerMessage : AbstractMessage
{
    public string nameFrom { get; init; }
    public string nameTo { get; init; } 
    public override bool Send()
    {
        Console.WriteLine($"Sending MessengerMessage from: {nameFrom} to {nameTo} with content {Content}");
        return true;
    }
}

class User
{
    public string Name { get; init; }
    public AbstractMessage LastMessage { get; set; }
}

public interface Ifly 
{
    void fly();
}
public interface Iswim
{
    void swim();
}
public class Duck : Ifly, Iswim
{
    public void fly()
    {
        throw new NotImplementedException();
    }

    public void swim()
    {
        throw new NotImplementedException();
    }
}

public class Hydro : Ifly, Iswim
{
    public void fly()
    {
        throw new NotImplementedException();
    }

    public void swim()
    {
        throw new NotImplementedException();
    }
}

interface IAggregate
{
    IIterator createIterator();
}

interface IIterator
{
    bool HasNext();
    int GetNext();
}

class SimpleAggregate : IAggregate
{
    internal int a = 5;
    internal int b = 6;
    internal int c = 2;
    public IIterator createIterator()
    {
        return new SimpleAggregateIterator(this);
    }
}


class SimpleAggregateIterator : IIterator
{
    private SimpleAggregate _aggregate;
    private int cout = 0;
    public SimpleAggregateIterator(SimpleAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    public int GetNext()
    {

        switch (++cout)
        {
            case 1:
                return _aggregate.a;
            case 2:
                return _aggregate.b;
            case 3:
                return _aggregate.c;
            default:
                throw new ArgumentException();
        }
    }

    public bool HasNext()
    {
        return cout < 3;
    }
}




/// ///////////////////////////////////////////////////////////////////////////////////////




public abstract class Scooter
{
    public double Weight { get; init; }
    public int MaxSpeed { get; init; }
    protected int _mileage;
    public int Mileage { get { return _mileage; } }
    public abstract decimal Drive(int distance);
    public override string ToString()
    {
        return $"Vehicle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
    }
}

class ElectricScooter : Scooter
{
    private decimal _batterieslevel = 100;
    public decimal BatteriesLevel
    {
        get { return _batterieslevel; }
    }
    public int MaxRange { get; set; }
    public decimal ChargeBatteries()
    {
        if (_batterieslevel != 100 || _batterieslevel < 100)
        {
            while (_batterieslevel == 100)
            {
                _batterieslevel++;
            }
            return _batterieslevel;
        }
        else
        {
            return _batterieslevel;
        }
    }
    public override decimal Drive(int distance)
    {
        decimal oneDrive = _batterieslevel / MaxRange;
        if (_batterieslevel > 0)
        {
            while (distance != 0)
            {
                distance--;
                _batterieslevel = _batterieslevel - oneDrive;
            }
            _mileage += distance;
            return _batterieslevel;
        }
        return -1;
    }
    public override string ToString()
    {
        return $"ElectricScooter{{ BatteriesLevel: {BatteriesLevel}, MaxRange: {MaxRange}}}";
    }
}

class KickScooter : Scooter
{
    public override decimal Drive(int distance)
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        //string messageType = "SMS";
        //switch (messageType)
        //{
        //    case "SMS":
        //        Console.WriteLine("Sending SMS");
        //        break;
        //    case "Email":
        //        Console.WriteLine("Sending SMS");
        //        break;
        //}
        User[] users =
        {
            new User()
            {
                Name = " Jurand",
                LastMessage = new SMSMessage()
                {
                    Content = "Hello",
                    FromPhone = "0092232",
                    ToPhone =   "0098898",
                }
            },
            new User()
            {
                Name = " Mateusz",
                LastMessage = new EmailMessage()
                {
                    Content = "Hello",
                    To = "MefjuN@spoko.pl",
                    From =   "KasperP@spoko.pl",
                }
            },
            new User()
            {
                Name = " Maciek",
                LastMessage = new MessengerMessage()
                {
                    Content = "Hello",
                    nameTo = "Kuba Franas",
                    nameFrom =   "Maciej Misiak",
                }
            }
        };
        int EmailCounter = 0;
        foreach (var user in users)
        {
            user.LastMessage.Send();
            //czy wiadomość w LastMessage jest typu EmailMessage
            if (user.LastMessage is EmailMessage)
            {
                EmailCounter++;
            }
            if (user.LastMessage is SMSMessage)
            {
                SMSMessage sms = (SMSMessage)user.LastMessage;
                Console.WriteLine(sms.ToPhone);
            }
        }
        Console.WriteLine($"Wysłano wiadomości email: {EmailCounter}");

        Ifly[] flyingObject =
        {
            new Duck(),
            new Hydro()
        };

        //Przykład iteratora 
        IAggregate aggregate = new SimpleAggregate();
        IIterator iterator = aggregate.createIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.GetNext());
        }

        ElectricScooter[] scooters =
        {
            new ElectricScooter(){Weight = 15, MaxSpeed = 100},
            new ElectricScooter(){Weight = 25, MaxSpeed = 120},
        };
        foreach (var scooter in scooters)
        {
            Console.WriteLine("time for distance" + scooter.Drive(96));
        }
    }
}