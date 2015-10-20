using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    class NextLevelDoor : GameObject
    {
        public NextLevelDoor()
        { 
        }
        public NextLevelDoor(int x, int y)
        {
            try
            {
                Image = new Surface("NextLevelDoor.png");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            Position = new Point(x, y);
            ShowPartImage = new Rectangle(0, 0, 50, 50);
            Collisionrectangle = new Rectangle(Position.X, Position.Y, 50, 50);
            Leftcollisionrectangle = new Rectangle(Position.X, Position.Y, 2, 50);
            Rightcollisionrectangle = new Rectangle((Position.X + 50), Position.Y, 2, 50);
            Uppercollisionrectangle = new Rectangle(Position.X, Position.Y, 50, 2);
            Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 50), 50, 2);
        }
        public override void Update()
        {
            
        }
    }

}
