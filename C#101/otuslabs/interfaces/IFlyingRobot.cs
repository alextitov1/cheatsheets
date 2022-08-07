using interfaces.Robots;
namespace interfaces.FlyingRobot
{
    public interface IFlyingRobot : IRobot
    {
        public new string GetRobotType()
        {
            return "I'm a flying robot";
        }
    }
}

