using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace b2
{

    internal class Program
    {
        static List<Teacher> Teachers;
        static List<Student> Students;
        static string[] lopHoc = { "23DTHA5", "23DTHA6", "23DTHA7" };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            addStudent();
            addTeacher();
            menuStartH();
            Terminal.gI().SetTitle("Menu");
            loop();
        }
        static void loop()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            Handle.gI().ShowMenuStart(key,Teachers,Students);
            Thread.Sleep(10);
            if (Handle.gI().isRunning)
            {
                loop();
            }
            else
            {
                Console.Clear();
                Terminal.gI().SetTitle("Cảm ơn m đã dùng");
                Terminal.gI().Print("Tạm biệt", Terminal.gI().SizeX / 2, Terminal.gI().SizeY / 2, ConsoleColor.Red);
                Console.SetCursorPosition(0, Terminal.gI().SizeY);
            }
        }
        static void menuStartH() // in ra lúc ban đầu, menu mẫu
        {
            Terminal.gI().Print($"{0} {0}", 0, 0, ConsoleColor.Green);
            Terminal.gI().Print("Chức Năng", 3, 1, ConsoleColor.Cyan);
            Terminal.gI().Print("Giảng viên", 3, 2, ConsoleColor.Red);
            Terminal.gI().Print("Học Sinh", 3, 3, ConsoleColor.Green);
            Terminal.gI().Print("Thoát", 3, 4, ConsoleColor.Green);
        }
        static void addTeacher()
        {
            Teachers = new List<Teacher>();
            Teachers.Add(new Teacher("A1T","Võ Văn Vậu",2,30,"23DTHA5"));
            Teachers.Add(new Teacher("A2T","Nguyễn Nguyên Ngọ",2,55,"23DTHA6"));
            Teachers.Add(new Teacher("A3T","Trần Trị Trương",1,31,"23DTHA7"));
        }
        static void addStudent()
        {
            Students = new List<Student>();
            Students.Add(new Student("A1","Nguyễn Thành Bảo Ngân",1,19,"23DTHA5",3.9));
            Students.Add(new Student("A2","Nguyễn Công Quang",2,21,"23DTHA6",1.9));
            Students.Add(new Student("A3","Nguyễn Trường Phát",1,19,"23DTHA7",3.7));
            Students.Add(new Student("A1","Lê Huỳnh Ngọc",1,19,"23DTHA5",2.6));
            Students.Add(new Student("A2","Huỳnh Ngọc Anh Tuấn",1,19,"23DTHA6",3.6));
        }

    }
}