using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_enums
{
    internal class Program
    {
        enum HomeTown
        {
            SEOUL,
            DAEJEON,
            DAEGU,
            BUSAN,
            JEJU
        }
        static void Main(string[] args)
        {
            HomeTown myHomeTown;
            myHomeTown = HomeTown.BUSAN;

            if (myHomeTown == HomeTown.SEOUL)
            {
                Console.WriteLine("서울 출신이군요!");
            }else if (myHomeTown == HomeTown.DAEJEON)
            {
                Console.WriteLine("충청도입니당~");
            }else if (myHomeTown == HomeTown.DAEGU)
            {
                Console.WriteLine("대구 입니당~");
            }
            else if (myHomeTown == HomeTown.BUSAN)
            {
                Console.WriteLine("부산 입니당~");
            }
        }
    }
}
