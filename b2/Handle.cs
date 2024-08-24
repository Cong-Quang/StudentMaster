using System;
using System.Threading;
namespace b2
{
    public class Handle
    {
        private static readonly Lazy<Handle> instance = new Lazy<Handle>(() => new Handle());
        public static Handle gI() => instance.Value;

        public bool isRunning = true;
        public Handle()
        {
            Data.gI().addData();
            loop();
        }
        public void loop()
        {
            while (isRunning)
            {

                Console.SetCursorPosition(0, Terminal.gI().SizeY);
                //Terminal.gI().ShowMenuStudent(Data.gI().students);
                //Terminal.gI().ShowMenuTeacher(Data.gI().teachers);
                Terminal.gI().ShowMenuChucNang();

                Data.gI().pChucNang = ReadKeyUD(Data.gI().pChucNang, Data.gI().ChucNang);
                //Data.gI().pChucNang = ReadKeyUD(Data.gI().pStudent, Data.gI().GetStudentNames());
                //Data.gI().pStudent = ReadKeyUD(Data.gI().pStudent, Data.gI().GetStudentNames());
                //Data.gI().pTeacher = ReadKeyUD(Data.gI().pStudent, Data.gI().GetTeacherNames());

                Thread.Sleep(10);
            }
        }
        private int ReadKeyUD(int positions, string[] array)
        {
            Terminal.gI().Print(positions.ToString(), 1,0);
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                positions--;
                if (positions < 0)
                {
                    positions = array.Length - 1;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                positions++;
                if (positions > array.Length - 1)
                {
                    positions = 0;
                }
            }
            else if ((key.Key == ConsoleKey.Enter))
            {
                if (Data.gI().pChucNang == 2)
                {
                    isRunning = false;
                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                if (Data.gI().pChucNang == 2)
                {
                    isRunning = false;
                }
            }
            return positions;
        }
        private void ReadKeyRL()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {

            }
            else if (key.Key == ConsoleKey.RightArrow)
            {

            }
        }
    }
}