using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;

namespace PlatformGame
{
    internal class FinishDoor : GameObject
    {
        //Deze code code komt grotendeels overeen met de andere GameObjecten (die niet held of vijand zijn). 
        //Het enige verschil zijn dat er een andere afbeelding wordt ingeladen.
        public FinishDoor()
        {
        }

        public FinishDoor(int x, int y)
        {
            try
            {
                Image = new Surface("Finish_Line.png");
                Position = new Point(x, y);
                ShowPartImage = new Rectangle(0, 0, 100, 100);
                Leftcollisionrectangle = new Rectangle(Position.X, Position.Y, 2, 100);
                Rightcollisionrectangle = new Rectangle((Position.X + 100), Position.Y, 2, 100);
                Uppercollisionrectangle = new Rectangle(Position.X, Position.Y, 100, 2);
                Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 100), 100, 2);
            }
            catch (Exception error)
            {
                Console.WriteLine("Er is een fout opgetreden : " + error.Message);
            }
        }

        public override void Update()
        {
            Leftcollisionrectangle.X = Position.X;
            Leftcollisionrectangle.Y = Position.Y;
            Rightcollisionrectangle.X = (Position.X + 100);
            Rightcollisionrectangle.Y = Position.Y;
            Uppercollisionrectangle.X = Position.X;
            Uppercollisionrectangle.Y = Position.Y;
            Lowercollisionrectangle.X = Position.X;
            Lowercollisionrectangle.Y = (Position.Y + 100);
        }

        public override void Draw(Surface video)
        {
            base.Draw(video);
            Box0.Location = Leftcollisionrectangle.Location;
            Box0.Width = 2;
            Box0.Height = 100;
            Box0.Draw(video, Color.Red);

            Box1.Location = Rightcollisionrectangle.Location;
            Box1.Width = 2;
            Box1.Height = 100;
            Box1.Draw(video, Color.Red);

            Box2.Location = Uppercollisionrectangle.Location;
            Box2.Width = 100;
            Box2.Height = 2;
            Box2.Draw(video, Color.Red);

            Box3.Location = Lowercollisionrectangle.Location;
            Box3.Width = 100;
            Box3.Height = 2;
            Box3.Draw(video, Color.Red);
        }
    }
}