using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2
{
    public class Student : Human
    {
        public double GPA { get; set; }
        public Student(string Id, string Name,int Gender, int age, string Class, double GPA) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Gender = Gender;
            this.Age = age;
            this.Class = Class;
            this.GPA = GPA;
        }
        public bool IsPassing() // kiểm tra coi qua môn hay hok :>
        {
            return GPA >= 2.0;
        }
    }
}
