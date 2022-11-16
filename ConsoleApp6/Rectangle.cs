namespace PongGame
{
    public class Rectangle
    {
        public int x;
        public int y;
        public int width;
        public int height;


        public Rectangle(Point location, Point size)
        {
            this.x = location.x;
            this.y = location.y;
            this.width = size.x;
            this.height = size.y;
        }

        public int Left
        {
            get { return this.x; }
        }

        public int Right
        {
            get { return (this.x + this.width); }
        }

        public int Top
        {
            get { return this.y; }
        }

        public int Bottom
        {
            get { return (this.y + this.height); }
        }

        public Point Center
        {
            get
            {
                return new Point(this.x + (this.width / 2), this.y + (this.height / 2));
            }
        }
    }
}