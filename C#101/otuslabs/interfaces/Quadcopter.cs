using interfaces.FlyingRobot;
using interfaces.Chargeable;
namespace interfaces.classQuadcopter
{
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
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged");
        }
    }
}

