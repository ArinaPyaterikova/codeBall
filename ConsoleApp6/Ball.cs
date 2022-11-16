using System;

namespace PongGame
{  
    public class Ball
    {
        // Statics
        public static Vector2 InitialSpeed = new Vector2(60f, 60f);

        // Private data members
        private Random _random = new Random();     // Random Number Generator

        // Public data members
        public Vector2 Position = new Vector2();
        public Vector2 Speed;
        public int LeftmostX { get; private set; }      // Bounds
        public int RightmostX { get; private set; }
        public int TopmostY { get; private set; }
        public int BottommostY { get; private set; }

        // What gets hit
        public Rectangle CollisionArea
        {
            get { return new Rectangle(Position.ToPoint(), GameGeometry.BallSize); }
        }

        

        // this is used to reset the postion of the ball to the center of the board
        public void Initialize()
        {
            // Center the ball
            Rectangle playAreaRect = new Rectangle(new Point(0, 0), GameGeometry.PlayArea);
            Position = playAreaRect.Center.ToVector2();
            Position = Vector2.Subtract(Position, GameGeometry.BallSize.ToVector2() / 2f);

            // Set the velocity
            Speed = InitialSpeed;

            // Randomize direction
            if (_random.Next() % 2 == 1)
                Speed.x *= -1;
            if (_random.Next() % 2 == 1)
                Speed.y *= -1;

            // Set bounds
            LeftmostX = 0;
            RightmostX = playAreaRect.width - GameGeometry.BallSize.x;
            TopmostY = 0;
            BottommostY = playAreaRect.height - GameGeometry.BallSize.y;
        }

        // Moves the ball, should only be called on the server
        public void ServerSideUpdate(GameTime gameTime)
        {
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Add the distance
            Position = Vector2.Add(Position, Speed * timeDelta);
        }

        // Draws the ball to the screen, only called on the client

    }
}