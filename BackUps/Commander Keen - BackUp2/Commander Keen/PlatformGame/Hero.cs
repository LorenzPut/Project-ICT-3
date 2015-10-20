using SdlDotNet.Audio;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformGame
{
    class Hero : GameObject
    {
        Surface ImageRight, ImageLeft;
        public bool MoveRight, MoveLeft, Jump = false;
        public int ground = 500;
        public int NumberOflives = 3;
        public int snelheid = -20;
        int versnelling = 1;

        public Hero()
        {
            try
            {
                Image = new Surface("Commander_Keen_links.png");
                ImageLeft = new Surface("Commander_Keen_links.png");
                ImageRight = new Surface("Commander_Keen_rechts.png");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                
            }
            

            Position = new Point(300, ground);
            ShowPartImage = new Rectangle(0, 0,50,75 );
            Collisionrectangle = new Rectangle(Position.X, Position.Y, 45, 70);
            Leftcollisionrectangle = new Rectangle(Position.X, (Position.Y+10), 3, 60);
            Rightcollisionrectangle = new Rectangle((Position.X + 45), (Position.Y+10), 3, 60);
            Uppercollisionrectangle = new Rectangle((Position.X+5), Position.Y, 45, 3);
            Lowercollisionrectangle = new Rectangle((Position.X+5), (Position.Y + 75), 45, 15);

            Events.KeyboardDown += Events_KeyboardDown;
            Events.KeyboardUp += Events_KeyboardUp;


        }

        void Events_KeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                MoveLeft = false;
            }
            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                MoveRight = false;
            }

        }

        void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                MoveLeft = true;
            }
            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                MoveRight = true;
            }
            if(e.Key==SdlDotNet.Input.Key.Space)
            {
                Jump = true;
            }
            

        }
        public override void Update()
        {
            if (MoveLeft)
            {
                Position.X -= 5;
                Image = ImageLeft;
            }
            if (MoveRight)
            {
                Position.X += 5;
                Image = ImageRight;
            }

            if (MoveLeft || MoveRight)
            {
                ShowPartImage.Y += 75;
                if (ShowPartImage.Y >= 375 )
                    ShowPartImage.Y = 0;
            }

            if (Jump)
            {
                Position.Y += snelheid;                
                snelheid += versnelling;
                Console.WriteLine("jump" + Position.Y);
              //  Console.WriteLine(Position.Y);
                //Console.WriteLine("snelheid" + snelheid);

                //Initialiseer alles op origineel
                if (Position.Y >= ground)
                {
                    Jump = false;
                    snelheid = -20;
                }
                if (Position.Y < 0)
                {
                    snelheid = 5;
                }
            
            }
            if (Position.X <= 0)
            {
                MoveLeft = false;
                Position.X += 10;
            }
            if (Position.X >= 1350)
            {
                MoveRight = false;
                Position.X -= 10;

            }
            if (Position.Y >= ground)
            {
                Position.Y = ground;
            }
            if (NumberOflives == 0)
            {
                Console.WriteLine("Ik ben dood.");
            }
                
           
            //Nodig om de collision rectangle de hero te laten volgen
            Collisionrectangle.X = Position.X;
            Collisionrectangle.Y = Position.Y;
            Leftcollisionrectangle.X = Position.X;
            Leftcollisionrectangle.Y = (Position.Y+10);
            Rightcollisionrectangle.X = (Position.X + 50);
            Rightcollisionrectangle.Y = (Position.Y +10);
            Uppercollisionrectangle.X = (Position.X+5);
            Uppercollisionrectangle.Y = Position.Y;
            Lowercollisionrectangle.X = (Position.X+5);
            Lowercollisionrectangle.Y = (Position.Y + 75);
        }

        Box box0 = new Box();
        Box box1 = new Box();
        Box box2 = new Box();
        Box box3 = new Box();

        public override void Draw(Surface video)
        {
            base.Draw(video);
            box0.Location = Leftcollisionrectangle.Location;
            box0.Width = 3;
            box0.Height = 60;
            box0.Draw(video, Color.Red);

            box1.Location = Rightcollisionrectangle.Location;
            box1.Width = 3;
            box1.Height = 60;
            box1.Draw(video, Color.Red);

            box2.Location = Uppercollisionrectangle.Location;
            box2.Width = 45;
            box2.Height = 3;
            box2.Draw(video, Color.Red);

            box3.Location = Lowercollisionrectangle.Location;
            box3.Width = 43;
            box3.Height = 3;
            box3.Draw(video, Color.Red);


        }
       
    }
}
