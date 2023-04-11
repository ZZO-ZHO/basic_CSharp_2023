using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs25_exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3 };

            try
            {
                for(var i = 0; i <5; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (Exception ex)    // 모르겠으면 Exception
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 예외가 발생해도 무조건 처리해야하는 로직
                // file 객체 close
                // db연결 close
                // 네트워트소켓 close
                Console.WriteLine("계속가요");
            }
            try
            {
                DevideTest(array[2], array[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("프로그램 종료");

            //try
            //{
            //    Console.WriteLine("Test Test");
            //    throw new Exception("커스텀 예외");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private static void DevideTest(int v1, int v2)
        {
            try
            {
            Console.WriteLine(v1 / v2);

            }
            catch (Exception)
            {
                throw new Exception("DevideTest 메서드에서 예외발생");

            }
        }
    }
}
