using System;
using System.Threading;

namespace b2
{
    public class Handle
    {
        private static readonly Lazy<Handle> instance = new Lazy<Handle>(() => new Handle());
        public static Handle gI() => instance.Value;

        private bool isRunning = true;

        // Constructor
        public Handle()
        {
            var data = Data.gI();
            data.addData();
            MainLoop();
        }

        // Main Loop
        public void MainLoop()
        {
            Terminal.gI().SetTitle("Xin chào");
            Terminal.gI().EfectPrintf("Ấn Phím bất kỳ để bắt đầu", Terminal.gI().SizeX / 2 , Terminal.gI().SizeY / 2,ConsoleColor.Red,55);
            while (isRunning)
            {
                Console.SetCursorPosition(0, Terminal.gI().SizeY);
                Terminal.gI().ShowMenuChucNang();

                var data = Data.gI();
                ConsoleKeyInfo key = Console.ReadKey(true);
                int chucnang = data.pChucNang = ReadKeyUD(data.pChucNang, data.ChucNang, key);

                switch (chucnang)
                {
                    case 0: // Teacher
                        Console.Clear();
                        HandleTeacherMenu(key);
                        break;
                    case 1: // Student
                        Console.Clear();
                        HandleStudentMenu(key);
                        break;
                    default:
                        break;
                }

            }
            Console.Clear();
            Terminal.gI().EfectPrintf("Tạm Biệt",Terminal.gI().SizeX / 2 + 5 , Terminal.gI().SizeY / 2,ConsoleColor.Red,30);
            Terminal.gI().SetTitle("Then Kiu bây bề đã chạy thử",35);
        }

        // Method to handle the Teacher menu
        private void HandleTeacherMenu(ConsoleKeyInfo key)
        {
            var data = Data.gI();
            Terminal.gI().ShowMenuTeacher(data.teachers);
            data.pTeacher = ReadKeyUD(data.pTeacher, data.GetStudentNames(),key);
        }

        // Method to handle the Student menu
        private void HandleStudentMenu(ConsoleKeyInfo key)
        {
            var data = Data.gI();
            Terminal.gI().ShowMenuStudent(data.students);
            data.pStudent = ReadKeyUD(data.pStudent, data.GetTeacherNames(), key);
        }

        private int ReadKeyUD(int position, string[] array, ConsoleKeyInfo key)
        {
            Terminal.gI().Print(position.ToString(), 1, 0);

            if (key.Key == ConsoleKey.UpArrow)
            {
                position = (position - 1 + array.Length) % array.Length;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                position = (position + 1) % array.Length;
            }
            else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape)
            {
                if (Data.gI().pChucNang == 2)
                {
                    isRunning = false;
                }
            }

            return position;
        }

        // Placeholder for Left/Right key handling if needed
        private void ReadKeyRL()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {
                // Handle Left arrow logic
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                // Handle Right arrow logic
            }
        }
    }
}
