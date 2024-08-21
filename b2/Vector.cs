namespace b2
{
    public class Vector
    {
        public int x; 
        public int y; 
        public Vector() { } // defau
        public Vector(int x, int y) // vector có tham số, nếu gọi tới vector ko thôi thì nó lên trên, có tham số nó gán ở đây
        {
            this.x = x;
            this.y = y;
        }
    }
}
