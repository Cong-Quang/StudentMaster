using System;
using System.Collections.Generic;
using System.Linq;

namespace b2
{
    public class Data
    {
        private static Data _instance;
        public static Data gI()
        {
            if (_instance == null) _instance = new Data();
            return _instance;
        }

        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
        public string[] ChucNang = { "Giảng Viên", "Học Sinh", "Thoát" };
        public string[] ChucNangPhu = { "ID", "Tuổi", "Lớp", "GPA" };
        public string[] supChucNang = { "Danh Sách Giảng Viên", "Danh Sách Học Sinh" };
        public string[] TinhNang = { "Thêm" , "Sửa" , "Xoá"};
        public int pTeacher = 0;
        public int pStudent = 0;
        public int pChucNang = 0;


        // Default constructor
        public Data()
        {
        }
        public void addData()
        {
            teachers = new List<Teacher>
            {
                new Teacher("A1T", "Võ Văn Vậu", 2, 30, "23DTHA5"),
                new Teacher("A2T", "Nguyễn Nguyên Ngọ", 2, 55, "23DTHA6"),
                new Teacher("A3T", "Trần Trị Trương", 1, 31, "23DTHA7")
            };
            students = new List<Student>
            {
                new Student("A1", "Nguyễn Thanh Bảo Ngân", 1, 19, "23DTHA5", 3.9),
                new Student("A2", "Nguyễn Công Quang", 2, 21, "23DTHA6", 1.9),
                new Student("A3", "Nguyễn Trường Phát", 1, 19, "23DTHA7", 3.7),
                new Student("A1", "Lê Huỳnh Ngọc", 1, 19, "23DTHA5", 2.6),
                new Student("A2", "Huỳnh Ngọc Anh Tuấn", 1, 19, "23DTHA6", 3.6)
            };
        }
        // Parameterized constructor
        public Data(List<Student> students, List<Teacher> teachers)
        {
            this.students = students;
            this.teachers = teachers;
        }

        // Convert Students list to array of specific attributes
        public string[] GetStudentIds()
        {
            return students.Select(s => s.Id).ToArray();
        }

        public string[] GetStudentNames()
        {
            return students.Select(s => s.Name).ToArray();
        }

        public int[] GetStudentAges()
        {
            return students.Select(s => s.Age).ToArray();
        }

        public string[] GetStudentClasses()
        {
            return students.Select(s => s.Class).ToArray();
        }

        public double[] GetStudentGPAs()
        {
            return students.Select(s => s.GPA).ToArray();
        }

        // Convert Teachers list to array of specific attributes
        public string[] GetTeacherIds()
        {
            return teachers.Select(t => t.Id).ToArray();
        }

        public string[] GetTeacherNames()
        {
            return teachers.Select(t => t.Name).ToArray();
        }

        public int[] GetTeacherAges()
        {
            return teachers.Select(t => t.Age).ToArray();
        }

        public string[] GetTeacherClasses()
        {
            return teachers.Select(t => t.Class).ToArray();
        }

        // Add Teacher
        public bool AddTeacher(string id, string name, int gender, int age, string className)
        {
            try
            {
                teachers.Add(new Teacher(id, name, gender, age, className));
                return true;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại AddTeacher \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }

        // Add Student
        public bool AddStudent(string id, string name, int gender, int age, string className, double gpa)
        {
            try
            {
                students.Add(new Student(id, name, gender, age, className, gpa));
                return true;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại AddStudent \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }

        // Remove Teacher
        public bool RemoveTeacher(int index)
        {
            try
            {
                if (index >= 0 && index < teachers.Count)
                {
                    teachers.RemoveAt(index);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại RemoveTeacher \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }

        // Remove Student
        public bool RemoveStudent(int index)
        {
            try
            {
                if (index >= 0 && index < students.Count)
                {
                    students.RemoveAt(index);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại RemoveStudent \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }

        // Change Teacher information (Name, Gender, Age, Class)
        public bool ChangeTeacherInfo(int index, string name, int gender, int age, string className)
        {
            try
            {
                if (index >= 0 && index < teachers.Count)
                {
                    teachers[index].Name = name;
                    teachers[index].Gender = gender;
                    teachers[index].Age = age;
                    teachers[index].Class = className;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại ChangeTeacherInfo \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }

        // Change Student information (Name, Gender, Age, Class, GPA)
        public bool ChangeStudentInfo(int index, string name, int gender, int age, string className, double gpa)
        {
            try
            {
                if (index >= 0 && index < students.Count)
                {
                    students[index].Name = name;
                    students[index].Gender = gender;
                    students[index].Age = age;
                    students[index].Class = className;
                    students[index].GPA = gpa;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại ChangeStudentInfo \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }

        // Get list of all teachers
        public List<Teacher> GetAllTeachers()
        {
            return teachers;
        }

        // Get list of all students
        public List<Student> GetAllStudents()
        {
            return students;
        }

        // Find teacher by ID
        public Teacher FindTeacherById(string id)
        {
            return teachers.FirstOrDefault(t => t.Id == id);
        }

        // Find student by ID
        public Student FindStudentById(string id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        // Find teachers by class
        public List<Teacher> FindTeachersByClass(string className)
        {
            return teachers.Where(t => t.Class == className).ToList();
        }

        // Find students by class
        public List<Student> FindStudentsByClass(string className)
        {
            return students.Where(s => s.Class == className).ToList();
        }

    }
}
