using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs05_nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            Console.WriteLine(a==null);
            //Console.WriteLine(a.GetType());

            int b = 0;
            Console.WriteLine(b == null);
            Console.WriteLine(b.GetType());

            // 값형식 
            // null

            float? c = null;
            Console.WriteLine(c.HasValue);

            c = 3.14f;
            Console.WriteLine(c.HasValue);  
            Console.WriteLine(c.Value);
            Console.WriteLine(c);
        }
    }
}
