namespace PongGame
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int x, int y)
        {
            this.y = y;
            this.x = x;
        }

        public Vector2 ToVector2()
        {
            return new Vector2(x, y);
        }
    }
}