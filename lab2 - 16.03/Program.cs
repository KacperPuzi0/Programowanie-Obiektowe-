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
class Program
{
    static void Main(string[] args)
    {
        string messageType = "SMS";
        switch (messageType)
        {
            case "SMS":
                Console.WriteLine("Sending SMS");
                break;
            case "Email":
                Console.WriteLine("Sending SMS");
                break;
        }
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
            if (user.LastMessage is EmailMessage)
            {
                EmailCounter++;
            }
        }
        Console.WriteLine($"Wysłano wiadomości email: {EmailCounter}");
    }
}