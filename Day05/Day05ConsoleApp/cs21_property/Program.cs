using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{
    class Boiler
    {
        public int temp;    // 멤버변수

        public int Temp // 프로퍼타(속성)
        {
            get { return temp; }

            set
            {
                if (value <= 10 || value >= 70)
                {
                    temp = 10;  // 제일 낮은 온도로 설정
                } else
                {
                temp = value;

                }
            }
        }

        // 위의 get set과
        public void SetTemp(int temp)
        {
            if (temp <= 10 || temp >= 70)
            {
                Console.WriteLine(" 정상 범위 아닙니다. ");
                return;
            }
            else { 
            this.temp = temp;
            
            }

        }
        public int GetTemp() {  return this.temp; }
    }

    class Car
    {
        string name;
        string color;
        int year;
        string furlType;
        int door;
        string tireType;
        string company;
        int price;
        string carIdNumber;
        string carPlateNumber;

        public string Name { get; set; }
        public string Color { get => color; set => color = value; }
        public int Year
        {
            get => year;
            set
            {
                if (value <= 1900 || value >= 2023)
                {
                    value = 2023;
                }
                year = value;
            }
        }
        public string FurlType
        {
            get => furlType;
            set
            {
                if (value != "휘발유" || value != "경유")
                {
                    value = "휘발유";
                }

                furlType = value;
            }
        }
        private int door;
        public int Door
        {
            get { return door; }
            set
            {
                if (value != 2 || value != 4)
                {
                    value = 4;
                }
            }
        }
        public string TireType { get => tireType; set => tireType = value; }
        public string Company { get => company; set => company = value; }
        public int Price { get => price; set => price = value; }
        public string CarIdNumber { get => carIdNumber; set => carIdNumber = value; }
        public string CarPlateNumber { get => carPlateNumber; set => carPlateNumber = value; }
    }

    interface
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler();
            //kitturami.temp = 60;

            //// ...
            //kitturami.temp = 300000;    // 불가능
            //kitturami.temp = -120;
            kitturami.SetTemp(50);
            Console.WriteLine(kitturami.GetTemp());

            Boiler navien = new Boiler();
            navien.temp = 5000;
            Console.WriteLine(navien.Temp);

            Car ionic = new Car() { Name = "아이오닉" };
            ionic.Name = "아이오닉";

            Console.WriteLine(ionic.Name);

            Car genesis = new Car()
            {
                Name = "제네시스",
                FurlType = "휘발유",
                Color = "흰색",
                Door = 4,
                TireType = "광폭타이어",
                Year = 0,

            };
            Console.WriteLine(genesis.Company);
        }
    }
}
