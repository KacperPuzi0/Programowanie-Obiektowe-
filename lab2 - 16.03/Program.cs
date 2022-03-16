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

class ConvertAggregate : IAggregate
{
    internal int a = 5;
    internal int b = 6;
    internal int c = 2;
    public IIterator createIterator()
    {
        return new SimpleAggregateIterator(this);
    }
}

class ConvertAggregateIterator : IIterator
{
    private ConvertAggregate _aggregate;
    private int backCount = 0;
    public ConvertAggregateIterator(ConvertAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    public int GetNext()
    {
        return _aggregate.a;
    }

    public bool HasNext()
    {
        return backCount > 0 || backCount < 3;
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
    }
}