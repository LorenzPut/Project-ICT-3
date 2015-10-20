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
    class MetalBlock : GameObject
    {
        public MetalBlock()
        { 
        }
        public MetalBlock(int x, int y)
        {
            try
            {
                Image = new Surface("MetalBlock.png");

            }
            catch (Exception error)
            {

                Console.WriteLine(error);
            }
            Position = new Point(x, y);
            ShowPartImage = new Rectangle(0, 0, 50, 50);
            Collisionrectangle = new Rectangle(Position.X,Position.Y,30,30);
            Leftcollisionrectangle = new Rectangle(Position.X, Position.Y, 3, 50);
            Rightcollisionrectangle = new Rectangle((Position.X + 50), Position.Y, 3, 50);
            Uppercollisionrectangle = new Rectangle(Position.X, Position.Y, 50, 3);
            Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 50), 50, 3);
        }
        
        public override void Update()
        {
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
            box2.Height = 3;
            box2.Draw(video, Color.Red);

            box3.Location = Lowercollisionrectangle.Location;
            box3.Width = 50;
            box3.Height = 3;
            box3.Draw(video, Color.Red);

        }
    
    }
}
