using System;
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
            if(_instance == null) _instance = new Terminal();
            return _instance;
        }
        public int SizeX { get; set; } = 100;
        public int SizeY { get; set; } = 20;

        public void SetTitle(string title)
        {
            string currentTitle = "";
            foreach (char c in title)
            {
                currentTitle += c;
                Console.Title = currentTitle;
                Thread.Sleep(75);
            }
        }                                             // gắn giá trị mặc định: nếu không được chuyền vô, nó tự lấy cái t gán
        public void EfectPrintf(string s,int x, int y, ConsoleColor color = ConsoleColor.White, int time = 100)
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
            new Thread( () =>
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
    }
}
