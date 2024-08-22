using System;
using System.Collections.Generic;
using System.Linq;
namespace b2
{
    public class Handle
    {
        private static Handle instance;
        public static Handle gI()
        {
            if (instance == null) instance = new Handle();
            return instance;
        }
        private Vector vector = new Vector(0, 0);
        private Vector vectorGV = new Vector(0, 0);
        private Vector vectorHS = new Vector(0, 0);
        private const string MenuGV = "Giảng viên";
        private const string MenuHS = "Học Sinh";
        private const string MenuExit = "Thoát";
        public bool isRunning = true;
        public void ShowMenuStart(ConsoleKeyInfo key, List<Teacher> Teachers, List<Student> Students)
        {
            // Kiểm tra phím bấm hợp lệ
            if (key.Key != ConsoleKey.NoName)
            {
                // Hiển thị tiêu đề menu
                Terminal.gI().Print("Chức Năng", 3, 1, ConsoleColor.Cyan);
                Terminal.gI().Print(MenuGV, 3, 2, ConsoleColor.Green);
                Terminal.gI().Print(MenuHS, 3, 3, ConsoleColor.Green);
                Terminal.gI().Print(MenuExit, 3, 4, ConsoleColor.Green);
            }

            // Điều hướng menu bằng phím mũi tên
            if (key.Key == ConsoleKey.UpArrow)
            {
                vector.y = Math.Max(0, vector.y - 1);  // Di chuyển lên
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                vector.y = Math.Min(2, vector.y + 1);  // Di chuyển xuống
            }
            else if (key.Key == ConsoleKey.Enter && vector.y == 2)
            {
                isRunning = false;
                return;
            }

            switch (vector.y)
            {
                case 0: //Giảng viên
                    Console.Clear();
                    Terminal.gI().Print(MenuGV, 3, 2, ConsoleColor.Red);
                    menuGV(key, Teachers);
                    break;

                case 1: // Lựa chọn "Học sinh"
                    Console.Clear();
                    Terminal.gI().Print(MenuHS, 3, 3, ConsoleColor.Red);
                    menuHS(key, Students);
                    break;

                case 2: // Lựa chọn "Thoát"
                    Terminal.gI().Print(MenuExit, 3, 4, ConsoleColor.Red);
                    break;
            }
            // In tọa độ hiện tại của vector (dùng để debug)
            Terminal.gI().Print($"{vector.x} {vector.y}", 0, 0, ConsoleColor.Green);
        }
        private void displaySupMenu(ConsoleKeyInfo key, string[] listName, Vector vector)
        {
            if (key.Key == ConsoleKey.RightArrow)
            {
                while (true)
                {
                    ConsoleKeyInfo keyx = Console.ReadKey();

                    if (keyx.Key == ConsoleKey.DownArrow)
                    {
                        vectorGV.y = Math.Min(listName.Length - 1, vectorGV.y + 1);
                    }
                    else if (keyx.Key == ConsoleKey.UpArrow)
                    {
                        vectorGV.y = Math.Max(0, vectorGV.y - 1);
                    }
                    else if (keyx.Key == ConsoleKey.LeftArrow || keyx.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    int index = 2;
                    for (int i = 0; i < listName.Length; i++)
                    {
                        var color = (i == vector.y) ? ConsoleColor.Red : ConsoleColor.White;
                        Terminal.gI().Print(listName[i], Terminal.gI().SizeX / 2 - 30, index++, color);
                    }
                    Terminal.gI().Print($"{vector.x} {vector.y}", 0, 0, ConsoleColor.Red); //(dùng để debug)
                }
            }
        }
        private void menuGV(ConsoleKeyInfo key, List<Teacher> Teachers)
        {
            Terminal.gI().Print("Danh sách Giảng viên:", Terminal.gI().SizeX / 2 - 30, 1, ConsoleColor.Green);
            Terminal.gI().Print("Chức Năng", 3, 1, ConsoleColor.Cyan);
            Terminal.gI().Print(MenuHS, 3, 3, ConsoleColor.Green);
            Terminal.gI().Print(MenuExit, 3, 4, ConsoleColor.Green);
            int yPosition = 2;
            for (int i = 0; i < Teachers.Count; i++)
            {
                var color = (i == vectorGV.y) ? ConsoleColor.Red : ConsoleColor.White;
                Terminal.gI().Print(Teachers[i].Name, Terminal.gI().SizeX / 2 - 30, yPosition++, color);
            }
            displaySupMenu(key, Teachers.Select(t => t.Name).ToArray(), vectorGV);
            Terminal.gI().Print("Danh sách Giảng viên:", Terminal.gI().SizeX / 2 - 30, 1, ConsoleColor.Green);
            Terminal.gI().Print("Chức Năng", 3, 1, ConsoleColor.Cyan);
            Terminal.gI().Print(MenuHS, 3, 3, ConsoleColor.Green);
            Terminal.gI().Print(MenuExit, 3, 4, ConsoleColor.Green);
        }
        private void menuHS(ConsoleKeyInfo key, List<Student> Students)
        {
            Terminal.gI().Print("Danh sách Học sinh:", Terminal.gI().SizeX / 2 - 30, 1, ConsoleColor.Green);
            Terminal.gI().Print("Chức Năng", 3, 1, ConsoleColor.Cyan);
            Terminal.gI().Print(MenuGV, 3, 2, ConsoleColor.Green);
            Terminal.gI().Print(MenuExit, 3, 4, ConsoleColor.Green);
            int yPosition = 2;
            for (int i = 0; i < Students.Count; i++)
            {
                var color = (i == vectorGV.y) ? ConsoleColor.Red : ConsoleColor.White;
                Terminal.gI().Print(Students[i].Name, Terminal.gI().SizeX / 2 - 30, yPosition++, color);
            }
            displaySupMenu(key, Students.Select(t => t.Name).ToArray(), vectorGV);
            Terminal.gI().Print(MenuGV, 3, 2, ConsoleColor.Green);
            Terminal.gI().Print(MenuExit, 3, 4, ConsoleColor.Green);
        }
    }
}