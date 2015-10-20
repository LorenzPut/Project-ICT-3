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
        public bool MoveRight { get; set; }
        public bool MoveLeft, Jump = false, savejump = false, level2 = false;
        private int ground = 474, topY = 0, beginpositie = 0, speed = 10;
        double springvertraging = 12;
        public int NumberOflives = 3;
        //DateTime time;
        private bool up;
        private bool down;
        public bool IamDead = false;

        public Hero()
        {
        }
        public Hero(int x, int y)
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

            Position = new Point(x, y);
            ShowPartImage = new Rectangle(0, 0, 50, 76);
            Leftcollisionrectangle = new Rectangle(Position.X, (Position.Y + 3), 3, 68);
            Rightcollisionrectangle = new Rectangle((Position.X + 50), (Position.Y + 3), 3, 68);
            Uppercollisionrectangle = new Rectangle(Position.X, (Position.Y - 5), 53, 5);
            Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 75), 53, 5);

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
            if (e.Key == SdlDotNet.Input.Key.UpArrow)
            {
                up = false;
            }
            if (e.Key == SdlDotNet.Input.Key.DownArrow)
            {
                down = false;
            }
        }
        void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                MoveLeft = true;
            }
            if (e.Key == SdlDotNet.Input.Key.UpArrow)
            {
                up = true;
            }
            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                MoveRight = true;
            }
            if (e.Key == SdlDotNet.Input.Key.Space)
            {
                if (Jump == false && savejump == true)
                {
                    savejump = Jump;
                    Jump = true;
                    beginpositie = Position.Y;
                    Console.WriteLine("Dit is de beginpositie als de held springt : " + beginpositie);
                }
            }
            if (e.Key == SdlDotNet.Input.Key.DownArrow)
            {
                down = true;
            }
        }
        public override void Update()
        {
            Movements();

            if (Jump)
            {
                double add_Y = (double)springvertraging * (Math.Pow(1, 2));
                Console.WriteLine("De positie tot waar de held mag springen : " + (beginpositie - 100));

                if (Position.Y <= topY)
                {
                    Position.Y = topY;
                    Jump = false;
                }
                else if (Position.Y > topY)
                {
                    Position.Y -= (int)add_Y;
                    springvertraging -= 0.2
                        ;
                }

                if (Position.Y < (beginpositie - 140))
                {
                    springvertraging = 12;
                    Jump = false;
                }
            }


            if (up == false && down == false && Jump == false)
            {
                if (Position.Y >= ground)
                {
                    Position.Y = ground;
                    savejump = true;
                }
                else if (Position.Y < ground)
                {
                    savejump = false;
                    Position.Y += 6;
                    //Gravity();
                }
            }

            //Nodig om de collision rectangle de hero te laten volgen
            Leftcollisionrectangle.X = Position.X;
            Leftcollisionrectangle.Y = (Position.Y + 3);
            Rightcollisionrectangle.X = (Position.X + 50);
            Rightcollisionrectangle.Y = (Position.Y + 3);
            Uppercollisionrectangle.X = Position.X;
            Uppercollisionrectangle.Y = (Position.Y - 5);
            Lowercollisionrectangle.X = Position.X;
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
            box0.Height = 68;
            box0.Draw(video, Color.Red);

            box1.Location = Rightcollisionrectangle.Location;
            box1.Width = 3;
            box1.Height = 68;
            box1.Draw(video, Color.Red);

            box2.Location = Uppercollisionrectangle.Location;
            box2.Width = 53;
            box2.Height = 5;
            box2.Draw(video, Color.Red);

            box3.Location = Lowercollisionrectangle.Location;
            box3.Width = 53;
            box3.Height = 5;
            box3.Draw(video, Color.Red);

        }
        //public void Gravity()
        //{
        //    TimeSpan seconds = time - DateTime.Now;
        //    double add_y = (double)9.81 * (Math.Pow(seconds.TotalSeconds, 2));
        //    Position.Y += (int)add_y;
        //    Console.WriteLine(Position.Y);

        //}
        public void Movements()
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
                ShowPartImage.Y += 76;
                if (ShowPartImage.Y >= 380)
                    ShowPartImage.Y = 0;
            }

            if (up)
                Position.Y -= 5;
            if (down)
                Position.Y += 5;

        }
        public void CheckCollisionsWithMetalBlocks(List<MetalBlock> MetalObjects, List<Leeg> EmptyBlocks)
        {
            if (Position.X <= 0)
            {
                MoveLeft = false;
                Position.X += speed;
            }
            if (Position.X >= 1250)
            {
                MoveRight = false;
                Position.X -= speed;
            }
            MetalBlock savemetaalblok = new MetalBlock();
            foreach (MetalBlock m in MetalObjects)
            {
                if (this.Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
                {
                    this.MoveLeft = false;
                    this.Position.X -= 10;
                }
                if (this.Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
                {
                    this.MoveRight = false;
                    m.Position.X -= 0;
                    this.Position.X += 10;
                }
                if (this.Uppercollisionrectangle.IntersectsWith(m.Lowercollisionrectangle))
                {
                    savemetaalblok = m;
                    this.up = false;
                    this.Jump = false;
                }
                if (this.Lowercollisionrectangle.IntersectsWith(m.Uppercollisionrectangle))
                {
                    this.ground = (m.Position.Y - 76);
                    savemetaalblok = m;
                }
            }
            foreach (Leeg L in EmptyBlocks)
            {
                if (this.Lowercollisionrectangle.IntersectsWith(savemetaalblok.Uppercollisionrectangle) == false && this.Lowercollisionrectangle.IntersectsWith(L.Rect) == true)
                {
                    this.ground = 500;

                }
            }

        }
        public void Die(List<GameObject> Gameobjecten)
        {
            foreach (GameObject g in Gameobjecten)
            {

                if (NumberOflives == 0)
                {
                    Gameobjecten.Remove(g);
                    IamDead = true;
                    break;
                }

            }
        }
        public void CheckCollisionsWithLifeItem(List<LifeItem> LifeObjects)
        {
            if (NumberOflives < 3)
            {
                foreach (LifeItem l in LifeObjects)
                {
                    if (this.Leftcollisionrectangle.IntersectsWith(l.Rightcollisionrectangle))
                    {
                        NumberOflives++;
                        LifeObjects.Remove(l);
                        break;
                    }
                    if (this.Rightcollisionrectangle.IntersectsWith(l.Leftcollisionrectangle))
                    {
                        NumberOflives++;
                        LifeObjects.Remove(l);
                        break;
                    }
                    if (this.Lowercollisionrectangle.IntersectsWith(l.Uppercollisionrectangle))
                    {

                        NumberOflives++;
                        LifeObjects.Remove(l);
                        break;
                    }

                }
            }
        }
        public void CheckCollisionsWithNextLevelDoor(List<NextLevelDoor> NextlevelObjects)
        {
            //Console.WriteLine(level2);
            foreach (NextLevelDoor n in NextlevelObjects)
            {
                if (this.Leftcollisionrectangle.IntersectsWith(n.Rightcollisionrectangle))
                {
                    level2 = true;
                }
                if (this.Rightcollisionrectangle.IntersectsWith(n.Leftcollisionrectangle))
                {
                    level2 = true;
                }
                if (this.Lowercollisionrectangle.IntersectsWith(n.Uppercollisionrectangle))
                {
                    level2 = true;
                }
            }
        }
        public void CheckCollisionsWithGrassBlocks(List<Grass> GrassObjects, List<Leeg> EmptyBlocks)
        {
            if (Position.X <= 0)
            {
                MoveLeft = false;
                Position.X += speed;
            }
            if (Position.X >= 1250)
            {
                MoveRight = false;
                Position.X -= speed;
            }
            Grass savegrassblok = new Grass();
            foreach (Grass g in GrassObjects)
            {
                if (this.Rightcollisionrectangle.IntersectsWith(g.Leftcollisionrectangle))
                {
                    this.MoveLeft = false;
                    this.Position.X -= 10;
                }
                if (this.Leftcollisionrectangle.IntersectsWith(g.Rightcollisionrectangle))
                {
                    this.MoveRight = false;
                    g.Position.X -= 0;
                    this.Position.X += 10;
                }
                if (this.Uppercollisionrectangle.IntersectsWith(g.Lowercollisionrectangle))
                {
                    savegrassblok = g;
                    this.up = false;
                    this.Jump = false;
                }
                if (this.Lowercollisionrectangle.IntersectsWith(g.Uppercollisionrectangle))
                {
                    this.ground = (g.Position.Y - 76);
                    savegrassblok = g;
                }
            }
            foreach (Leeg L in EmptyBlocks)
            {
                if (this.Lowercollisionrectangle.IntersectsWith(savegrassblok.Uppercollisionrectangle) == false && this.Lowercollisionrectangle.IntersectsWith(L.Rect) == true)
                {
                    this.ground = 500;

                }
            }
        }
    }
}
