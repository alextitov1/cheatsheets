```C#
namespace interfaces;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var person = new Alexander();
        //var p2 = new Human();
        person.MyAge();

        if (person is IContract)
        {
            var contract = person as IContract;
            var contract = person as IContract;
            var contract2 = (IContract)person;

        }
    }

    public interface IContract
    {
        string MyName();
        int MyAge();
    }

    public interface IContract2
    {
        string AA();
        int BB();
    }

    public abstract class Human
    {
        public Human Father1 { get; set; }

        public Human Father2 { get; set; }

        public abstract int MyAge();
        //{
        //    return 10;
        //}
    }

    public class Gender : Human, IContract, IContract2
    {
        public bool IsBoy { get; set; }

        public bool IsGirl { get; set; }

        public string AA()
        {
            throw new NotImplementedException();
        }

        public int BB()
        {
            throw new NotImplementedException();
        }

        public override int MyAge()
        {
            return 10;
        }

        public string MyName()
        {
            throw new NotImplementedException();
        }

        public virtual int SomeMethod()
        {
            return 15;
        }
    }

    public class Alexander : Gender
    {
        public override int MyAge()
        {
            return base.MyAge();
        }

        public override int SomeMethod()
        {
            return base.SomeMethod();
        }
    }
}
```