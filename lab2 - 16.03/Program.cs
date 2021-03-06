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



//interface IAggregate
//{
//    IIterator createIterator();
//}

//interface IIterator
//{
//    bool HasNext();
//    int GetNext();
//}

//class SimpleAggregate : IAggregate
//{
//    internal int a = 5;
//    internal int b = 6;
//    internal int c = 2;
//    public IIterator createIterator()
//    {
//        return new SimpleAggregateIterator(this);
//    }
//}


//class SimpleAggregateIterator : IIterator
//{
//    private SimpleAggregate _aggregate;
//    private int cout = 0;
//    public SimpleAggregateIterator(SimpleAggregate aggregate)
//    {
//        _aggregate = aggregate;
//    }

//    public int GetNext()
//    {

//        switch (++cout)
//        {
//            case 1:
//                return _aggregate.a;
//            case 2:
//                return _aggregate.b;
//            case 3:
//                return _aggregate.c;
//            default:
//                throw new ArgumentException();
//        }
//    }

//    public bool HasNext()
//    {
//        return cout < 3;
//    }
//}

/// ///////////////////////////////////////////////////////////////////////////////////////
/// ĆWICZENIE 1 



public abstract class Scooter
{
    public double Weight { get; init; }
    public int MaxSpeed { get; init; }
    protected int _mileage;
    public int Mileage { get { return _mileage; } }
    public abstract decimal Drive(int distance);
    public override string ToString()
    {
        return $"Scooter{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
    }
}

class ElectricScooter : Scooter
{
    private decimal _batterieslevel = 100;
    public decimal BatteriesLevel
    {
        get { return _batterieslevel; }
    }
    public decimal MaxRange { get; init; }
    public decimal ChargeBatteries()
    {
        if (_batterieslevel != 100 || _batterieslevel < 100)
        {
            while (_batterieslevel != 100)
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
        if (oneDrive > 0)
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
        return $"Scooter{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {Mileage}}}";
    }
}

class KickScooter : Scooter
{
    public override decimal Drive(int distance)
    {
        throw new NotImplementedException();
    }
}




/// //////////////////////////////////////////////////////////////////////////////////
/// ĆWICZENIE 2 



public interface Flyable
{
    void Fly();
}
public interface Swimmingable
{
    void Swim();

}
public class Duck : Flyable, Swimmingable
{
    public string Name { get; set; }
    public string Surname { get; set;}

    public void Fly()
    {
        throw new NotImplementedException();
    }

    public void Swim()
    {
        throw new NotImplementedException();
    }
}

public class Wasp : Flyable
{
    public string Name { get; set;}
    public string Surname { get; set;}
    public void Fly()
    {
        throw new NotImplementedException();
    }

}

public class Hydroplane : Flyable, Swimmingable
{
    public string Name { get; set;}
    public string Surname { get; set; }

    public void Swim()
    {
        throw new NotImplementedException();
    }

    public void Fly()
    {
        throw new NotImplementedException();
    }
}




/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// ĆWICZENIE 3



public abstract class Aggregate
{
    public abstract Iterator CreateIterator();
}

public abstract class Iterator
{
    public abstract int GetNext();
    public abstract bool HasNext();
}

public class ArrayIntAggregate : Aggregate
{
    internal int[] array = {1,2,3,4,5};
    public override Iterator CreateIterator()
    {
        return new ArrayIntIterator(this);
    }
}

public sealed class ArrayIntIterator : Iterator
{
    private int _index = 0;
    private ArrayIntAggregate _aggregate;
    public ArrayIntIterator(ArrayIntAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    public override int GetNext()
    {
        return _aggregate.array[_index++];
    }

    public override bool HasNext()
    {
        return _index < _aggregate.array.Length;
    }
}

// REVERSE 

public class ReverseAggregate : Aggregate
{
    internal int[] array1 = { 1, 2, 3, 4, 5 };
    public override Iterator CreateIterator()
    {
        return new ReverseIterator(this);
    }
}
public sealed class ReverseIterator : Iterator
{
    private int _index1 = 0;
    private ReverseAggregate _aggregate1;
    public ReverseIterator(ReverseAggregate aggregate1)
    {
        _aggregate1 = aggregate1;    
    }
    public override int GetNext()
    {
        int[] reverseArray = new int[_aggregate1.array1.Length];
        for (int i = 0; i < _aggregate1.array1.Length; i++)
        {
            reverseArray[i] = _aggregate1.array1[_aggregate1.array1.Length - 1 - i];
        }
        return reverseArray[_index1++];
    }

    public override bool HasNext()
    {
        return _index1 < _aggregate1.array1.Length;
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

        //Przykład iteratora 
        //IAggregate aggregate = new SimpleAggregate();
        //IIterator iterator = aggregate.createIterator();
        //while (iterator.HasNext())
        //{
        //    Console.WriteLine(iterator.GetNext());
        //}


        // ćwiczenie 1
        ElectricScooter[] scooters =
        {
            new ElectricScooter(){Weight = 15, MaxSpeed = 100, MaxRange = 5},
            new ElectricScooter(){Weight = 25, MaxSpeed = 120, MaxRange = 10 }
        };
        foreach (var scooter in scooters)
        {
            Console.WriteLine("Zostało :" + " " + scooter.Drive(5) + "%" + " " + "Bateri");
            Console.WriteLine("Bateria naładowana w :" + " " + scooter.ChargeBatteries() + " " + "%");
        }

        // ćwiczenie 2
        Object[] objects =
        {
            new Duck(){Name = "Kasia", Surname= "Kaaczucha"},
            new Wasp(){Name = "Jolanta", Surname="Osa"},
            new Hydroplane(){Name ="Bob", Surname = "Budowniczy"},
            new Wasp(){Name = "Antonio", Surname = "Szerszeń"},
            new Hydroplane(){Name ="Karo", Surname= "XXX"},
            new Duck(){Name = "Julia", Surname="Gołąbek"}
        };
        int ObjectCounter = 0;
        foreach (var obj in objects)
        {
            if (obj is Flyable && obj is Swimmingable)
            {
                ObjectCounter++;
            }
        }
        Console.WriteLine($"Objektów pływająco latających jest : {ObjectCounter}");

        // ćwieczenie 3
        Aggregate aggregate = new ArrayIntAggregate();
        for (var iterator = aggregate.CreateIterator(); iterator.HasNext();)
        {
            Console.WriteLine(iterator.GetNext());
        }

        Aggregate reverseaggregate = new ReverseAggregate();
        for (var iterator = reverseaggregate.CreateIterator(); iterator.HasNext();)
        {
            Console.WriteLine(iterator.GetNext());
        }
    }
}