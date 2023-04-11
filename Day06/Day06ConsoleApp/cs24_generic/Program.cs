using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs24_generic
{
    #region < 일반화 클래스 >
    class MyArray<T> where T : class // 일반화 클래스 // where T : class
    {
        T[] array;
    }
    #endregion
    internal class Program
    {
        #region
        static void CopyArray<T>(T[] source, T[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        #endregion

        static void Main(string[] args)
        {
            #region < 일반화시키기 >
            int[] source = { 2, 4, 6, 8, 10 };
            int[] target = new int[source.Length];

            CopyArray(source, target);

            foreach (var item in target)
            {
                Console.WriteLine(item);
            }

            long[] source2 = { 2100000, 4100000, 6100000, 8100000, 1010000 };
            long[] target2 = new long[source2.Length];

            CopyArray(source2, target2);
            foreach (var item in target2)
            {
                Console.WriteLine(item);
            }

            float[] source3 = { 3.14f, 3.15f, 3.16f, 3.17f, 3.18f };
            float[] target3 = new float[source3.Length];

            CopyArray(source3, target3);
            foreach (var item in target3)
            {
                Console.WriteLine(item);
            }
            #endregion
            // 일반화 클래스
            List<int> list = new List<int>();
            for (var i = 10; i > 0; i--)
            {
                list.Add(i);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.RemoveAt(3);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            List<MyArray<string>> myStringArray = new List<MyArray<string>>();

            Stack<float> stFloat = new Stack<float>();
            stFloat.Push(3.15f);
            stFloat.Push(4.28f);
            stFloat.Push(7.24f);

            while (stFloat.Count > 0)
            {
                Console.WriteLine(stFloat.Pop());
            }

            // 일반화 Queue
            Queue<string> qString = new Queue<string>();
            qString.Enqueue("Hello");
            qString.Enqueue("World");
            qString.Enqueue("My");
            qString.Enqueue("C#");

            while (qString.Count > 0)
            {
                Console.WriteLine(qString.Dequeue());
            }
            Dictionary<string, int> dicNumbers = new Dictionary<string, int>();
            dicNumbers["하나"] = 1;
            dicNumbers["둘"] = 2;
            dicNumbers["셋"] = 3;
            dicNumbers["넷"] = 4;

            Console.WriteLine(dicNumbers["셋"]);
        }
    }
}
