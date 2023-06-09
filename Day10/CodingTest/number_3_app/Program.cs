﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_3_app
{
    class Car
    {
        public string Name;
        public string Maker;
        public string Color;
        public int YearModel;
        public int MaxSpeed;
        public string UniqueNumber;

        public void Start()
        {
            Console.WriteLine("{0}의 시동을 겁니다.", Name);
        }

        public void Accelerate()
        {
            Console.WriteLine("최대시속 {0}km/h로 가속합니다.", MaxSpeed);
        }

        public void TurnRight()
        {
            Console.WriteLine("{0}를 우회전합니다.", Name);
        }

        public void Brake()
        {
            Console.WriteLine("{0}의 브레이크를 밟습니다.", Name);
        }

    }

    class ElectricCar : Car
    {
        public virtual void Recharge()
        {
            Console.WriteLine("충전하기위해 정차합니다");
        }
    }

    class HybridCar : ElectricCar
    {
        public override void Recharge()
        {
            Console.WriteLine("달리면서 배터리를 충전합니다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HybridCar ioniq = new HybridCar();
            ioniq.Name = "아이오닉";
            ioniq.Maker = "현대";
            ioniq.Color = "White";
            ioniq.YearModel = 2018;
            ioniq.MaxSpeed = 220;
            ioniq.UniqueNumber = "54라 3346";

            ioniq.Start();
            ioniq.Accelerate();
            ioniq.Recharge();
            ioniq.TurnRight();
            ioniq.Brake();

        }
    }
}
