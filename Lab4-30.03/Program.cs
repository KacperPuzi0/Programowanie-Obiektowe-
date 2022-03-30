public enum Degree{
    A = 50,
    B = 45,
    C = 40,
    D = 35,
    E = 30,
    F = 20
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
        }
        catch (ArgumentException a)
        {

            Console.WriteLine("Wpisałeś nieznaną ocenę");
        }
    }
}