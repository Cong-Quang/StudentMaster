using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace b2
{
    public class Handle
    {
        private static Handle instance;

        // Phương thức Singleton để đảm bảo chỉ có một thể hiện của Handle
        public static Handle gI()
        {
            if (instance == null)
                instance = new Handle();
            return instance;
        }

        // Các biến để lưu trữ trạng thái của menu và vị trí của các mục menu
        private Vector vector = new Vector(0, 0);
        private Vector vectorGV = new Vector(0, 0);
        private Vector vectorHS = new Vector(0, 0);
        private const string MenuGV = "Giảng viên";
        private const string MenuHS = "Học Sinh";
        private const string MenuExit = "Thoát";
        public bool isRunning = true;

        // Hiển thị menu chính và xử lý điều hướng
        public void ShowMenuStart(ConsoleKeyInfo key, List<Teacher> Teachers, List<Student> Students)
        {
            if (key.Key != ConsoleKey.NoName)
            {
                DisplayMenu();
            }

            HandleNavigation(key);

            switch (vector.y)
            {
                case 0:
                    DisplaySubMenu(key, Teachers, MenuGV, vectorGV, menuGV);
                    break;
                case 1:
                    DisplaySubMenu(key, Students, MenuHS, vectorHS, menuHS);
                    break;
                case 2:
                    ShowMenu(3, Terminal.gI().SizeX / 2 - 30);
                    break;
            }

            Terminal.gI().Print($"{vector.x} {vector.y}", 0, 0, ConsoleColor.Green); // Debugging
        }

        // Hiển thị menu chính với các tùy chọn
        private void DisplayMenu()
        {
            Terminal.gI().Print("Chức Năng", 3, 1, ConsoleColor.Cyan);
            Terminal.gI().Print(MenuGV, 3, 2, ConsoleColor.Green);
            Terminal.gI().Print(MenuHS, 3, 3, ConsoleColor.Green);
            Terminal.gI().Print(MenuExit, 3, 4, ConsoleColor.Green);
        }

        // Xử lý điều hướng trong menu
        private void HandleNavigation(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                vector.y = Math.Max(0, vector.y - 1);
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                vector.y = Math.Min(2, vector.y + 1);
            }
                                                // số 2 ở đây dùng để kiểm tra, có thể bỏ và test thử heng :'>
            if ((key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape) && vector.y == 2) 
            {
                isRunning = false;
            }
        }

        // Hiển thị submenu với danh sách và xử lý hành động từ menu
        //Trong C#, Action<T> là một delegate (con trỏ hàm) dùng để tham chiếu đến một phương thức không trả về giá trị (void) và có thể nhận một hoặc nhiều tham số. 
        private void DisplaySubMenu<T>(ConsoleKeyInfo key, List<T> list, string menuName, Vector vector, Action<ConsoleKeyInfo, List<T>> menuAction)
        {
            Console.Clear();
            Terminal.gI().Print(menuName, 3, vector.y + 2, ConsoleColor.Red);
            menuAction(key, list); // Gọi action để xử lý menu tương ứng, kéo xuống 2 hàm cuối để đọc thêm
        }

        // Hiển thị danh sách các mục và xử lý điều hướng
        private void displaySupMenu(ConsoleKeyInfo key, string[] listName, Vector vector)
        {
            while (key.Key == ConsoleKey.RightArrow)
            {
                ConsoleKeyInfo keyx = Console.ReadKey();

                if (keyx.Key == ConsoleKey.DownArrow)
                {
                    vector.y = Math.Min(listName.Length - 1, vector.y + 1);
                }
                else if (keyx.Key == ConsoleKey.UpArrow)
                {
                    vector.y = Math.Max(0, vector.y - 1);
                }
                else if (keyx.Key == ConsoleKey.LeftArrow || keyx.Key == ConsoleKey.Escape)
                {
                    return;
                }

                DisplayList(listName, vector, Terminal.gI().SizeX / 2 - 30);
            }
        }

        // Hiển thị danh sách các mục với màu sắc tùy theo lựa chọn
        private void DisplayList(string[] listName, Vector vector, int positions)
        {
            int index = 2;
            for (int i = 0; i < listName.Length; i++)
            {
                var color = (i == vector.y) ? ConsoleColor.Red : ConsoleColor.White;
                Terminal.gI().Print(listName[i], positions, index++, color);
            }
            Terminal.gI().Print($"{vector.x} {vector.y}", 0, 0, ConsoleColor.Red); // Debugging
        }

        // Hiển thị menu phụ theo loại danh sách (Giảng viên/Học sinh)
        private void ShowMenu(int index, int positon)
        {
            Console.Clear();
            Terminal.gI().Print(index == 1 ? "Danh sách Giảng viên" : "Danh sách Học Sinh:", positon, 1, ConsoleColor.Green);
            Terminal.gI().Print("Chức Năng", 3, 1, ConsoleColor.Cyan);
            Terminal.gI().Print(MenuGV, 3, 2, index == 1 ? ConsoleColor.Red : ConsoleColor.Green);
            Terminal.gI().Print(MenuHS, 3, 3, index == 2 ? ConsoleColor.Red : ConsoleColor.Green);
            Terminal.gI().Print(MenuExit, 3, 4, index == 3 ? ConsoleColor.Red : ConsoleColor.Green);
            if (index == 3) // tại ko có menu riêng cho thằng exit nên t làm z heng :>
            {
                Terminal.gI().EfectPrintf("Ấn enter để thoát nhé Baybe :3", positon, 1, ConsoleColor.Cyan, 20);
            }
        }

        // Xử lý menu cho Giảng viên
        private void menuGV(ConsoleKeyInfo key, List<Teacher> Teachers) // Action được gọi nếu danh sách là list Teacher
        {
            int p = Terminal.gI().SizeX / 2 - 30;
            ShowMenu(1, p);
            DisplayList(Teachers.Select(t => t.Name).ToArray(), vectorGV, p);
            displaySupMenu(key, Teachers.Select(t => t.Name).ToArray(), vectorGV);
        }

        // Xử lý menu cho Học Sinh
        private void menuHS(ConsoleKeyInfo key, List<Student> Students) // Action được gọi nếu danh sách là list Student
        {
            int p = Terminal.gI().SizeX / 2 - 30;
            ShowMenu(2, p);
            DisplayList(Students.Select(s => s.Name).ToArray(), vectorHS, p);
            displaySupMenu(key, Students.Select(s => s.Name).ToArray(), vectorHS);
        }
    }
}
