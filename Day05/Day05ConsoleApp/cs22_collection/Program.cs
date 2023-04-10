using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs22_collection
{
    class MyList
    {
        int[] array;

        public MyList()
        {
            array = new int[3];
        }
        public int Length
        {
            get { return array.Length; }
        }
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<int>(ref array, index+1);
                    Console.WriteLine("MyList Resized : {0}", array.Length);
                }

                array[index] = value;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;

            //Console.WriteLine(array[5]);
            char[] oldString = new char[5];
            string curString = "";

            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            list.Add(6);

            ArrayList list2 = new ArrayList();
            list2.Add(8);
            list2.Add(9);
            list2.Add(10);
            list2.Add(11);
            list2.Add(12);
            list2.Add(13);

            foreach(int item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("10 삭제후");
            list2.Remove(10);
            Console.WriteLine("3번째 데이터 삭제");
            list2.RemoveAt(3);


            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            list2.Insert(0, 7);

            foreach(var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("정렬");
            list2.Sort();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            // 새로만든 MyList
            MyList myList = new MyList();
            for (int i = 1; i <= 5; i++)
            {
                myList[i] = i * 5;
            }

            for (int i = 0;i< myList.Length;i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
