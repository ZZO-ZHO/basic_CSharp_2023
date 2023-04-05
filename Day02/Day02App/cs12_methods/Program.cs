using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs12_methods
{
    class Calc
    {
        public static int Plus(int a, int b)
        {
            return a + b;
        }

        public static int Minus(int a, int b)
        { 
            return a - b; 
        }
    }
    internal class Program
    {
        // 실행시 메모리에 최초 올라가야 하기때문에 static이 되어야 하고
        // 메서드 이름이 Main이면 실행될때 알아서 제일 처음 시작한다.
        static void Main(string[] args)
        {
            #region < static 메서드 >
            int result = Calc.Plus(1, 2);
            // static은 최초실행때 메모리에 바로 올라가기때문에
            // 클래스의 객체를 만들 필요가 없다 like new Calc();
            
            // Calc.Minus(3, 2);   // Minus는 static이 아니기 때문에 접근불가( 객체생성해야 접근가능) 
            result = new Calc().Minus(3, 2);
            Console.WriteLine(result);
            #endregion

            #region < Call by reference Vs Call by value 비교 >
            int x = 10; int y = 3;
            Swap(ref x, ref y); // x,y가 가지고있는 주소를 전달 Call by reference == pointer

            Console.WriteLine(" x = {0}, y = {1}", x, y);

            Console.WriteLine(GetNumber());

            #endregion

            #region < out 매개변수 >

            int divid = 30;
            int divor = 2;
            int rem = 0;

            Divide(divid, divor, out result, out rem);  // ref를 쓰든 out을 쓰든 결과에 노상관
            Console.WriteLine("나누지 값 {0}, 나머지 {1}", result, rem);

            (result, rem) = Divide(20, 6);
            Console.WriteLine("나누기값 {0} ", result, rem);
            #endregion

            #region < 가변길이 매개변수 >

            Console.WriteLine(Sum(1, 3, 5, 7, 9));
            #endregion
        }

        /*static int Divide( int x, int y )
        {
            return x / y;
        }
        static int Reminder(int x, int y)
        {
            return x % y;
        }*/
        static void Divide(int x, int y, out int val, out int rem)
        {
            val = x / y;
            rem = x % y;
        }

        static (int result, int rem) Divide(int x, int y)
        {
            return (x / y, x % y);
        }

        static (float result, float rem) Divide(float x, float y)
        {
            return (x / y, x % y);
        }
        // 메인 메서드와 같은 레벨에 있는 메서드들은 전부 static이 되어야함 (무적권~)
        public static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = b;
            b = a;
            a = temp;
        }

        static int val = 100;

        public static ref int GetNumber()
        {
            return ref val;
        }

        public static int Sum(params int[] args)    // Python 가변길이 매개변수랑 비교
        {
            int sum = 0;
            foreach(var item in args)
            {
                sum += item;
            }
            return sum;
        }
    }
}