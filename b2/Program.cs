using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace b2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cấu hình bảng mã và ẩn con trỏ
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Handle.gI();
        }
    }
}