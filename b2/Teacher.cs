using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2
{
    public class Teacher : Human
    {
        public Teacher(string Id, string Name, int Gender, int age, string Class) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Gender = Gender;
            this.Age = age;
            this.Class = Class;
        }
    }
}
