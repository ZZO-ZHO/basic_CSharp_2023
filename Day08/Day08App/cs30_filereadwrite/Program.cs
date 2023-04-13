using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace cs30_filereadwrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;     // 테스트를 읽어와서 출력
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(@".\python.py");

                line = reader.ReadLine();

                while(line != null)
                {
                    Console.WriteLine(line);   
                    
                    line = reader.ReadLine();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"예외 ! {e.Message}");
            }
            finally
            {
                reader.Close();
            }

            StreamWriter writer = new StreamWriter(@".\pythonByCsharp.py");

            try
            {
                writer.WriteLine("import sys");
                writer.WriteLine("");
                writer.WriteLine("print(sys.executable");

            }
            catch (Exception e)
            {
                Console.WriteLine($"예외 ! {e.Message}");
            }
            finally
            {
                writer.Close(); 
            }
            Console.WriteLine("파일생성 완료!");
        }
    }
}
