using System.Threading;

namespace interfaces;
class Program
{
    static void Main(string[] args)
    {

        var MyRobot = new Quadcopter();
        MyRobot.Charge();
        Console.WriteLine($"Hello, World!, {MyRobot.GetRobotType()}");

    }
}

public interface IRobot
{
    public string GetInfo();
    public List<string> GetComponents();
    public string GetRobotType()
    {
        return "I'm a sinple robot";
    }

}

public interface IChargeable
{
    public void Charge();
    public string GetInfo();
}

public interface IFlyingRobot : IRobot
{
    public new string GetRobotType()
    {
        return "I'm a flying robot";
    }
}

class Quadcopter : IFlyingRobot, IChargeable
{
    private List<string> _component = new List<string> { "rotor1", "rotor2", "rotor3", "rotor4" };


    public List<string> GetComponents()
    {
        return _component;
    }

    public string GetInfo()
    {
        throw new NotImplementedException();
    }

    public void Charge()
    {
        Console.WriteLine("Charging..");
        Thread.Sleep(3000);
        Console.WriteLine("Charged");
    }

}