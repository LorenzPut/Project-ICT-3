using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    class Grass: GameObject
    {
        public Grass()
        { 
        }
        public Grass(int x, int y)
        {
            Image = new Surface("grass.jpg");
            Position = new Point(x, y);
            ShowPartImage = new Rectangle(0, 0, 50, 50);
            Leftcollisionrectangle = new Rectangle(Position.X, Position.Y, 5, 50);
            Rightcollisionrectangle = new Rectangle((Position.X + 50), Position.Y, 5, 50);
            Uppercollisionrectangle = new Rectangle(Position.X, Position.Y, 50, 5);
            Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 50), 50, 5);
        }        
        public override void Update()
        {
            Leftcollisionrectangle.X = Position.X;
            Leftcollisionrectangle.Y = Position.Y;
            Rightcollisionrectangle.X = (Position.X + 50);
            Rightcollisionrectangle.Y = Position.Y;
            Uppercollisionrectangle.X = Position.X;
            Uppercollisionrectangle.Y = Position.Y;
            Lowercollisionrectangle.X = Position.X;
            Lowercollisionrectangle.Y = (Position.Y + 50);
        }
        Box box0 = new Box();
        Box box1 = new Box();
        Box box2 = new Box();
        Box box3 = new Box();
        public override void Draw(Surface video)
        {
            base.Draw(video);
            box0.Location = Leftcollisionrectangle.Location;
            box0.Width = 2;
            box0.Height = 50;
            box0.Draw(video, Color.Red);

            box1.Location = Rightcollisionrectangle.Location;
            box1.Width = 2;
            box1.Height = 50;
            box1.Draw(video, Color.Red);

            box2.Location = Uppercollisionrectangle.Location;
            box2.Width = 50;
            box2.Height = 2;
            box2.Draw(video, Color.Red);

            box3.Location = Lowercollisionrectangle.Location;
            box3.Width = 50;
            box3.Height = 2;
            box3.Draw(video, Color.Red);

        }
    }
}
