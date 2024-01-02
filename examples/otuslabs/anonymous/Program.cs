namespace anonymous;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        var Venus = new
        {
            Name = "Venus",
            IndexNumber = 2,
            EquatorLength = 11111,
            //PreviousPlanet = null
        };

        var Earth = new
        {
            Name = "Earth",
            IndexNumber = "3",
            EquatorLength = 22222,
            PreviousPlanet = Venus
        };

        var Mars = new
        {
            Name = "Mars",
            IndexNumber = 4,
            EquatorLength = 33333,
            PreviousPlanet = Earth
        };

        var VenusAgain = new
        {
            Name = "Venus",
            IndexNumber = 2,
            EquatorLength = 11111,
            // PreviousPlanet = Mars
        };
    Console.WriteLine($"Planet = {Venus.Name}, IndexNumber = {Venus.IndexNumber} isEquals to Venus {Venus.Equals(VenusAgain)}");
    Console.WriteLine($"Planet = {Earth.Name}, IndexNumber = {Earth.IndexNumber} isEquals to Venus {Earth.Equals(VenusAgain)}");
    Console.WriteLine($"Planet = {Mars.Name}, IndexNumber = {Mars.IndexNumber} isEquals to Venus {Mars.Equals(VenusAgain)}");
    }
}
