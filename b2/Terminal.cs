using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace b2
{
    public class Terminal
    {
        private static Terminal _instance;
        private bool _isLoading = true;
        private readonly object _lock = new object();

        public static Terminal gI()
        {
            if (_instance == null) _instance = new Terminal();
            return _instance;
        }
        public int SizeX { get; set; } = 100;
        public int SizeY { get; set; } = 20;

        public void SetTitle(string title, int time = 75)
        {
            string currentTitle = "";
            foreach (char c in title)
            {
                currentTitle += c;
                Console.Title = currentTitle;
                Thread.Sleep(time);
            }
        }                                             // gắn giá trị mặc định: nếu không được chuyền vô, nó tự lấy cái t gán
        public void EfectPrintf(string s, int x, int y, ConsoleColor color = ConsoleColor.White, int time = 100)
        {
            string Stringsub = "";
            foreach (char c in s)
            {
                Stringsub += c;
                Print(Stringsub, x, y, color);
                Thread.Sleep(time);
            }
        }
        public void Print(string s, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            lock (_lock)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.WriteLine(s);
                Console.ResetColor();
                Console.SetCursorPosition(0, SizeY);
            }
        }
        public void StartLoading()
        {
            new Thread(() =>
            {
                for (int i = SizeX; i >= 4; i--)
                {
                    Print("-", i, 0, ConsoleColor.Green);
                    Thread.Sleep(2);
                }
                while (_isLoading)
                {
                    for (int i = 4; i < SizeX - 1; i++)
                    {
                        Print("=", i, 0, ConsoleColor.Yellow);
                        if (i > 0)
                        {
                            Print("-", i - 1, 0, ConsoleColor.Green);
                        }
                        Thread.Sleep(1);
                    }

                    for (int i = SizeX; i >= 4; i--)
                    {
                        Print("##", i, 0, ConsoleColor.Red);
                        if (i < SizeX)
                        {
                            Print("-", i + 2, 0, ConsoleColor.Green);
                        }
                        Thread.Sleep(1);
                    }
                }
            }).Start();
        }

        public void StopLoading()
        {
            _isLoading = false;
        }

        // menu
        public void ShowMenuChucNang()
        {
            Print("Chức Năng", 2, 1, ConsoleColor.Cyan);
            for (int i = 0; i < Data.gI().ChucNang.Length; i++)
            {
                Print(Data.gI().ChucNang[i], 2, i + 2, ConsoleColor.Green);
                if (Data.gI().pChucNang == i)
                    Print(Data.gI().ChucNang[i], 2, i + 2, ConsoleColor.Red);
            }
        }
        public void ShowMenuTeacher(List<Teacher> teachers)
        {
            Print(Data.gI().supChucNang[0], SizeX / 2 - 30, 1, ConsoleColor.Green);
            for (int i = 0; i < teachers.Count; i++)
            {

                Print(teachers[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.White);
                if (Data.gI().pTeacher == i)
                    Print(teachers[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.Red);
            }
            ShowMenuTinhNang(teachers.Select(s => s.Name).ToArray());
        }
        public void ShowMenuStudent(List<Student> students)
        {
            Print(Data.gI().supChucNang[1], SizeX / 2 - 30, 1, ConsoleColor.Green);
            for (int i = 0; i < students.Count; i++)
            {
                Print(students[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.White);
                if (Data.gI().pStudent == i) {
                    Print(students[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.Red);
                    Print("                                        ", 50, 0);
                    Print(students[i].Name, 50, 0, ConsoleColor.DarkRed);
                }
            }
            ShowMenuTinhNang(students.Select(s => s.Name).ToArray());
            ShowMenuChucNangPhu();
        }
        public void ShowMenuTinhNang(string[] arr)
        {
            for (int i = 0; i < Data.gI().TinhNang.Length; i++)
            {
                Print(Data.gI().TinhNang[i], ((SizeX / 2) - 30) + 7 * i, arr.Length + 2, ConsoleColor.Cyan);
            }
        }
        public void ShowMenuChucNangPhu()
        {
            for (int i = 0; i < Data.gI().ChucNangPhu.Length; i++)
            {
                Print(Data.gI().ChucNangPhu[i], 50 + (i * 10), 1, ConsoleColor.Cyan);
            }
        }
    }
}
