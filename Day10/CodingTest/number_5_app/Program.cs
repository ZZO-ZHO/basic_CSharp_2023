using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_5_app
{
    class Animal
    {
        string name;
        int age;

        public int Age { get; set; }

        public string Name { get; set; }

    }

    interface IAnimal
    {
        void Eat();
        void Sleep();
        void Sound();
    }


    class Dog : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine($"{Name}은 사료를 먹습니다.");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}은 그늘에서 잠을 잡니다.");
        }
        public void Sound()
        {
            Console.WriteLine("멍멍");
        }
    }

    class Cat : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine($"{Name}은 참치를 먹습니다.");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}은 햇빛아래에서 잠을 잡니다.");
        }
        public void Sound()
        {
            Console.WriteLine("야옹");
        }
    }
    class House : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine($"{Name}은 건초를 먹습니다.");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}은 마굿간에서 잠을 잡니다.");
        }
        public void Sound()
        {
            Console.WriteLine("히잉");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {   Dog kkoma = new Dog { Name = "꼬마", Age = 12 };
            kkoma.Eat();
            kkoma.Sleep();
            kkoma.Sound();

            Cat youngdang = new Cat { Name = "용당", Age = 3 };
            youngdang.Eat();
            youngdang.Sleep();
            youngdang.Sound();

            House mang = new House { Name = "망", Age= 5 };
            mang.Eat();
            mang.Sleep();
            mang.Sound();
        }
    }
}
