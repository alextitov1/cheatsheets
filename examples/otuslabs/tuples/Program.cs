namespace tuples;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello, World!");
        var Catalog = new PlanetCatalog();

        foreach (var planet in new List<string> { "Venus", "Lemonland", "Earth", "Mars" })
        {
            var (IndexNumber, EquatorLength, Error) = Catalog.GetPlanet(planet);
            if (Error == null)
                Console.WriteLine($"Planet {planet}, its index from Sun = {IndexNumber}, length of the equator= {EquatorLength}");
            else
                Console.WriteLine($"An error \"{Error}\" occurred while searching for a planet {planet}");
        }
    }
}

class Planet
{
    public string Name { get; private set; }
    public int IndexNumber { get; private set; }
    public int EquatorLength { get; private set; }
    public Planet PreviousPlanet { get; private set; }

    public Planet(string name, int indexNumber, int equatorLength, Planet previousPlanet)
    {
        Name = name;
        IndexNumber = indexNumber;
        EquatorLength = equatorLength;
        PreviousPlanet = previousPlanet;
    }
}

public class PlanetCatalog
{
    private List<Planet> _planetList = new List<Planet>();
    private int _requestcount;

    public PlanetCatalog()
    {
        _planetList.Add(new Planet("Venus", 2, 222, null));
        _planetList.Add(new Planet("Earth", 3, 333, _planetList.Last()));
        _planetList.Add(new Planet("Mars", 4, 444, _planetList.Last()));
        _requestcount = 0;
    }

    public Tuple<int?, int?, string> GetPlanet(string name)
    {
        _requestcount++;
        if (_requestcount % 3 != 0)
        {
            foreach (var planet in _planetList)
            {
                if (name == planet.Name)
                    return new Tuple<int?, int?, string>(planet.IndexNumber, planet.EquatorLength, null);
            }
            return new Tuple<int?, int?, string>(null, null, "unknown planet");
        }
        return new Tuple<int?, int?, string>(null, null, "request limit exceeded");
    }
}
