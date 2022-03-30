using static Degrees;

class Degrees
{
    public enum Degree
    {
        A = 50,
        B = 45,
        C = 40,
        D = 35,
        E = 30,
        F = 20
    }

    public static double Convert(Degree degree)
    {
        return degree switch
        {
            Degree.A => 5.0,
            Degree.B => 4.5,
            Degree.C => 4.0,
            Degree.D => 3.5,
            Degree.E => 3.0,
            Degree.F => 2.0

        };
    }

    public static string MessageFromDegree(Degree degree)
    {
        return degree switch
        {
            Degree.A or Degree.B or Degree.C or Degree.D or Degree.E => "Pozytywna",
            _ => "Negatywna"
        };

    }
}

class Program
{
    static void Main(string[] args)
    {
        Degree degree = Degree.A;
        Console.WriteLine((int)degree);
        Console.WriteLine((int)Degree.B);
        Console.WriteLine(degree);

        string[] names = Enum.GetNames<Degree>();
        Degree[] degrees = Enum.GetValues<Degree>();
        Array.Sort(degrees, (a, b) => -a.CompareTo(b));
        Console.WriteLine("Wpisz jedną z ocen");
        foreach (var d in degrees)
        {
            Console.WriteLine(d);
        }
        string degreeString = Console.ReadLine();
        try
        {
            Degree studentDegree = Enum.Parse<Degree>(degreeString);
            Console.WriteLine("Wpisałeś ocenę " + studentDegree);
            Console.WriteLine(Convert(studentDegree));
        }
        catch (ArgumentException a)
        {

            Console.WriteLine("Wpisałeś nieznaną ocenę");
        }
    }
}