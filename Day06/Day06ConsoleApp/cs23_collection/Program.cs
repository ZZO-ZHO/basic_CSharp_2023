using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs23_collection
{
    class CustomEnumerator : IEnumerable
    {
        public int[] list = { 1, 3, 5, 7, 9 };

        public IEnumerator GetEnumerator()
        {
            yield return list[0];   // 메서드를 빠져나가지않음
            yield return list[1];
            yield return list[2];
            yield return list[3];
            yield break;
            yield return list[4];

        }
    }

    class MyArrayList : IEnumerator, IEnumerable
    {
        int[] array;
        int position = -1;

        public MyArrayList()
        {
            this.array = new int[3];
        }

        public int this[int index]
        {
            get { return this.array[index]; }
            set
            {
                if (index >= this.array.Length)
                {
                    Array.Resize<int>(ref this.array, index + 1);
                    Console.WriteLine("MyArrayList Resize : {0}", array.Length);
                }

                array[index] = value;
            }
        }


        #region < IEnumerable 인터페이스 구현 >
        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
        #endregion

        #region < IEnumerator 인터페이스 구현 >
        public object Current
        {
            get
            {
                return array[position];
            }
        }

        public bool MoveNext()
        {
            if (position == array.Length -1 )
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new CustomEnumerator();

            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
            var myArrayList = new MyArrayList();
            for (var i = 0; i< obj.list.Length; i++)
            {
                myArrayList[1] = 1;
            }

            foreach (var item in myArrayList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
