namespace interfaces.Robots
{
    public interface IRobot
    {
        public string GetInfo();

        public List<string> GetComponents();

        public string GetRobotType()
        {
            return "I'm a simple robot";
        }

    }
}

