using SdlDotNet.Core;
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
    class Enemy: GameObject
    {            
        Surface ImageRight, ImageLeft;
        public bool MoveRight = false, MoveLeft= false;
        public int NumberOflives = 1;
        public int BeginPositie = 0;
        public int ground = 390;
        

        public Enemy(int x, int y,bool moveright, bool moveleft)
        {
            try
            {
                Image = new Surface("Enemy_CommanderKeen_rechts.png");
                ImageLeft = new Surface("Enemy_CommanderKeen_links.png");
                ImageRight = new Surface("Enemy_CommanderKeen_rechts.png");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            

            Position = new Point(x, y);
            ShowPartImage = new Rectangle(0, 0,55,71 );
            BeginPositie = Position.X;
            Collisionrectangle = new Rectangle(Position.X, Position.Y, 55, 71);
            Leftcollisionrectangle = new Rectangle(Position.X, Position.Y, 3, 71);
            Rightcollisionrectangle = new Rectangle((Position.X + 55), Position.Y, 3, 71);
            Uppercollisionrectangle = new Rectangle(Position.X, Position.Y, 55, 3);
            Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 71), 55, 3);

            MoveLeft = moveleft;
            MoveRight = moveright;
        }  
       
        public override void Update()
        {
            if (MoveRight)
            {
                Position.X += 1;
                Image = ImageRight;
                ShowPartImagemethod();
                MoveLeft = false;
                if (Position.X >= 1250)
                {
                    MoveLeft = true;
                    MoveRight = false;
                }
            }
            if (MoveLeft)
            {

                Position.X -= 1;
                Image = ImageLeft;
                ShowPartImagemethod();
                MoveRight = false;
                if (Position.X <= 0)
                {
                    MoveLeft = false;
                    MoveRight = true;
                }
            }
            if (NumberOflives == 0)
            {
                Console.WriteLine("Ik ben dood.");
            }
            
                     
            Collisionrectangle.X = Position.X;
            Collisionrectangle.Y = Position.Y;
            Leftcollisionrectangle.X = Position.X;
            Leftcollisionrectangle.Y = Position.Y;
            Rightcollisionrectangle.X = (Position.X + 55);
            Rightcollisionrectangle.Y = Position.Y;
            Uppercollisionrectangle.X = Position.X;
            Uppercollisionrectangle.Y = Position.Y;
            Lowercollisionrectangle.X = Position.X;
            Lowercollisionrectangle.Y = (Position.Y + 71);
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
            box0.Height = 71;
            box0.Draw(video, Color.Red);

            box1.Location = Rightcollisionrectangle.Location;
            box1.Width = 3;
            box1.Height = 71;
            box1.Draw(video, Color.Red);

            box2.Location = Uppercollisionrectangle.Location;
            box2.Width = 55;
            box2.Height = 3;
            box2.Draw(video, Color.Red);

            box3.Location = Lowercollisionrectangle.Location;
            box3.Width = 55;
            box3.Height = 3;
            box3.Draw(video, Color.Red);
        }
        public void ShowPartImagemethod()
        {
            ShowPartImage.Y += 71;
            if (ShowPartImage.Y >= 284)
                ShowPartImage.Y = 0;
        }
        
                   
      
    }
}

