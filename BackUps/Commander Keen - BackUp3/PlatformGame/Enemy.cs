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
        public bool MoveRight = false, MoveLeft= false, StaatOpBlok = false;
        public int NumberOflives = 1;
        public int BeginPositie = 0;
        public int ID = 0;

        public Enemy(int x, int y,bool moveleft, bool moveright)
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
            ShowPartImage = new Rectangle(0, 0,50,71 );
            BeginPositie = Position.X;
            Leftcollisionrectangle = new Rectangle(Position.X, (Position.Y+2), 5, 50);
            Rightcollisionrectangle = new Rectangle((Position.X + 47), Position.Y, 5, 50);
            Uppercollisionrectangle = new Rectangle(Position.X, (Position.Y-3), 50, 5);
            Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 71), 50, 5);

            MoveLeft = moveleft;
            MoveRight = moveright;
        }  
       
        public override void Update()
        {
            if (MoveRight)
            {
                Position.X += 2;
                Image = ImageRight;
                ShowPartImagemethod();
                MoveLeft = false;                
            }
            if (MoveLeft)
            {
                Position.X -= 2;
                Image = ImageLeft;
                ShowPartImagemethod();
                MoveRight = false;                
            }
              
            Leftcollisionrectangle.X = Position.X;
            Leftcollisionrectangle.Y = (Position.Y+2);
            Rightcollisionrectangle.X = (Position.X + 47);
            Rightcollisionrectangle.Y = (Position.Y+2);
            Uppercollisionrectangle.X = Position.X;
            Uppercollisionrectangle.Y = (Position.Y+3);
            Lowercollisionrectangle.X = Position.X;
            Lowercollisionrectangle.Y = (Position.Y + 76);
        }

        Box box0 = new Box();
        Box box1 = new Box();
        Box box2 = new Box();
        Box box3 = new Box();

        public override void Draw(Surface video)
        {
            base.Draw(video);
            box0.Location = Leftcollisionrectangle.Location;
            box0.Width = 5;
            box0.Height = 71;
            box0.Draw(video, Color.Red);

            box1.Location = Rightcollisionrectangle.Location;
            box1.Width = 5;
            box1.Height = 71;
            box1.Draw(video, Color.Red);

            box2.Location = Uppercollisionrectangle.Location;
            box2.Width = 55;
            box2.Height = 5;
            box2.Draw(video, Color.Red);

            box3.Location = Lowercollisionrectangle.Location;
            box3.Width = 55;
            box3.Height = 5;
            box3.Draw(video, Color.Red);
            if (StaatOpBlok == false)
            {
                Position.Y += 7;
                
            }
        }
        public void ShowPartImagemethod()
        {
            ShowPartImage.Y += 71;
            if (ShowPartImage.Y >= 284)
                ShowPartImage.Y = 0;
        }
        public void EnemyMovement(List<MetalBlock> MetalObjects, List<Leeg> EmptyBlocks, List<Grass>GrassObjects)
        {
            StaatOpBlok = false;
            foreach (MetalBlock m in MetalObjects)
            {                
                if (this.Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
                {
                    this.MoveRight = true;
                    this.MoveLeft = false;
                }
                if (this.Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
                {
                    this.MoveRight = false;
                    this.MoveLeft = true;
                }
                if (this.Lowercollisionrectangle.IntersectsWith(m.Uppercollisionrectangle))
                {
                    StaatOpBlok = true;
                }
                else
                    this.MoveLeft = true;
     
            }
            foreach (var g in GrassObjects)
            {
                if (this.Leftcollisionrectangle.IntersectsWith(g.Rightcollisionrectangle))
                {
                    this.MoveRight = true;
                    this.MoveLeft = false;
                }
                if (this.Rightcollisionrectangle.IntersectsWith(g.Leftcollisionrectangle))
                {
                    this.MoveRight = false;
                    this.MoveLeft = true;
                }
                if (this.Lowercollisionrectangle.IntersectsWith(g.Uppercollisionrectangle))
                {
                    StaatOpBlok = true;
                }
                else
                    this.MoveLeft = true;
            }
        }

    }
}

