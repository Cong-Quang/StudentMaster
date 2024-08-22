using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace b2
{
    internal class Program
    {
        // Danh sách giáo viên và học sinh
        static List<Teacher> Teachers;
        static List<Student> Students;

        // Mảng lớp học để tham khảo
        static string[] lopHoc = { "23DTHA5", "23DTHA6", "23DTHA7" };

        static void Main(string[] args)
        {
            // Cấu hình bảng mã và ẩn con trỏ
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            // Thêm dữ liệu mẫu cho học sinh và giáo viên
            addStudent();
            addTeacher();

            // Hiển thị menu khởi đầu
            menuStartH();
            

            Terminal.gI().SetTitle("Menu");

            Terminal.gI().StartLoading();
            Thread.Sleep(30);
            Terminal.gI().StartLoading();
            loop();
        }

        static void loop() // giống đệ quy ý, mà ko giảm giá trị thôi
        {
            ConsoleKeyInfo key = Console.ReadKey();

            // Hiển thị menu dựa trên phím nhấn và danh sách học sinh, giáo viên
            Handle.gI().ShowMenuStart(key, Teachers, Students);

            // Tạm dừng một khoảng thời gian để tránh quá tải CPU
            Thread.Sleep(10);

            // Tiếp tục vòng lặp nếu chương trình đang chạy
            if (Handle.gI().isRunning)
            {
                loop();
                Terminal.gI().StopLoading();
            }
            else
            {
                Console.Clear();
                new Thread(() => Terminal.gI().SetTitle("Cảm ơn bạn đã dùng")).Start();
                Terminal.gI().EfectPrintf("Tạm biệt", Terminal.gI().SizeX / 2, Terminal.gI().SizeY / 2, ConsoleColor.Red);
                Console.SetCursorPosition(0, Terminal.gI().SizeY);
            }
        }

        // Hiển thị menu khởi đầu
        static void menuStartH()
        {
            Terminal.gI().Print($"{0} {0}", 0, 0, ConsoleColor.Green);
            Terminal.gI().Print("Ấn phím bất kỳ để bắt đầu", 3, 1, ConsoleColor.Cyan);
        }

        // Thêm dữ liệu mẫu cho giáo viên
        static void addTeacher()
        {
            Teachers = new List<Teacher>
            {
                new Teacher("A1T", "Võ Văn Vậu", 2, 30, "23DTHA5"),
                new Teacher("A2T", "Nguyễn Nguyên Ngọ", 2, 55, "23DTHA6"),
                new Teacher("A3T", "Trần Trị Trương", 1, 31, "23DTHA7")
            };
        }

        // Thêm dữ liệu mẫu cho học sinh
        static void addStudent()
        {
            Students = new List<Student>
            {
                new Student("A1", "Nguyễn Thành Bảo Ngân", 1, 19, "23DTHA5", 3.9),
                new Student("A2", "Nguyễn Công Quang", 2, 21, "23DTHA6", 1.9),
                new Student("A3", "Nguyễn Trường Phát", 1, 19, "23DTHA7", 3.7),
                new Student("A1", "Lê Huỳnh Ngọc", 1, 19, "23DTHA5", 2.6),
                new Student("A2", "Huỳnh Ngọc Anh Tuấn", 1, 19, "23DTHA6", 3.6)
            };
        }
    }
}