using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cs16_inheritance
{
    class Base
    {
        protected string Name;
        private String Color;
        public int Age;

        public Base(string name, string color, int age)
        {
            this.Name = name;
            this.Color = color;
            this.Age = age;
            Console.WriteLine("{0}.Base()");
        }   
        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()");
        }
        public void GetColor()
        {
            Console.WriteLine("{0}.Base() {1}", Name, Color);
        }
    }

    class Child : Base
    {

        public Child(string Name, string Color, int Age) : base(Name, Color, Age)
        {
            Console.WriteLine("{0}.Child()", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", Name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("NameB", "White", 1);
            b.BaseMethod();

            Child c = new Child("NameC", "Black", 2);
            c.BaseMethod();
            c.ChildMethod();
            c.GetColor();
        }
    }
}
