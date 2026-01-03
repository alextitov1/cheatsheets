
```C#
using System;
using System.Text;

namespace PropertiesExample
{
    // Define class program
    class Program
    {
        static void Main(string[] args)
        {
            // create an instance of the Shed class
            Shed myFirstShed = new Shed();

            // Set property values
            myFirstShed.Height = 10;
            myFirstShed.Width = 20;
            myFirstShed.Lengthwise = myFirstShed.Width;

            // Display values
            Console.WriteLine("Height: " + myFirstShed.Height);
            Console.WriteLine("Width: " + myFirstShed.Width);
            Console.WriteLine("Lengthwise: " + myFirstShed.Lengthwise);

            Console.ReadLine();
        }
    }

    // Define class Shed
    class Shed
    {
        // Fields for the Shed class
        // These fields are private and can only be accessed through properties
        int width;
        int height;

        // Properties for the Shed class
        public int Width {
            get { return width; }
            set { width = value; }
        }

        public int Height {
            get { return height; }
            set { height = value; }
        }

        public int Lengthwise { get; set; }
    }
}
```