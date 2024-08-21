namespace b2
{
    public class Human
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public Vector Vector { get; set; }
        public bool IsAdult() // check coi đủ tủi chx
        {
            return Age >= 18;
        }
        public bool ChangeName(string newName)
        {
            if (!string.IsNullOrEmpty(newName)) // IsNullOrEmpty null hoặc rỗng
            {
                Name = newName;
                return true;
            }
            return false;
        }
        public bool ChangeGender(int newGender)// 0 nữ, 1 nam, 3 bê đê
        {
            if (newGender >= 0 || newGender < 3)
            {
                Gender = newGender;
                return true;
            }
            return false;
        }
        public bool ChangeAge(int newAge) 
        {
            if (newAge >= 10 || newAge <= 99)
            {
                Age = newAge;
                return true;
            }
            return false;
        }
        public bool ChangeID(string ID)
        {
            if (ID != null)
            {
                this.Id = ID;
                return true;
            }
            return false;
        }
        public bool ChangeClass(string Class)
        {
            if (Class != null)
            {
                this.Class = Class;
                return true;
            }
            return false;
        }
    }
}
