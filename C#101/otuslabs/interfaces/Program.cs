using System.Text.Json;
using interfaces.FlyingRobot;
using interfaces.classQuadcopter;

namespace interfaces;
class Program
{
    static void Main(string[] args)
    {
        var MyRobot = new Quadcopter();
        Console.WriteLine($"Hello, World!, {((IFlyingRobot)MyRobot).GetRobotType()}");
        Console.WriteLine($"I consist of {JsonSerializer.Serialize(MyRobot.GetComponents())} ");
        MyRobot.Charge();
    }
}
