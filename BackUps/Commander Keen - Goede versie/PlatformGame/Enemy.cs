using System;
using System.Collections.Generic;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;

namespace PlatformGame
{
    internal class Enemy : GameObject
    {
        public bool MoveRight, MoveLeft, StaatOpBlok;
        public int NumberOflives = 1;
        private readonly Surface _imageLeft;
        private readonly Surface _imageRight;

        public Enemy(int x, int y, bool moveleft, bool moveright)
        {
            try
            {
                Image = new Surface("Enemy_CommanderKeen_rechts.png");
                _imageLeft = new Surface("Enemy_CommanderKeen_links.png");
                _imageRight = new Surface("Enemy_CommanderKeen_rechts.png");
                Position = new Point(x, y);
                ShowPartImage = new Rectangle(0, 0, 50, 71);
                Leftcollisionrectangle = new Rectangle(Position.X, (Position.Y + 2), 5, 50);
                Rightcollisionrectangle = new Rectangle((Position.X + 47), Position.Y, 5, 50);
                Uppercollisionrectangle = new Rectangle(Position.X, (Position.Y - 3), 50, 5);
                Lowercollisionrectangle = new Rectangle(Position.X, (Position.Y + 71), 50, 5);
            }
            catch (Exception error)
            {
                Console.WriteLine("Er is een fout opgetreden : " + error.Message);
            }

            MoveLeft = moveleft;
            MoveRight = moveright;
        }

        public override void Update()
        {
            Leftcollisionrectangle.X = Position.X;
            Leftcollisionrectangle.Y = (Position.Y + 2);
            Rightcollisionrectangle.X = (Position.X + 47);
            Rightcollisionrectangle.Y = (Position.Y + 2);
            Uppercollisionrectangle.X = Position.X;
            Uppercollisionrectangle.Y = (Position.Y + 3);
            Lowercollisionrectangle.X = Position.X;
            Lowercollisionrectangle.Y = (Position.Y + 76);
        }

        public override void Draw(Surface video)
        {
            base.Draw(video);
            Box0.Location = Leftcollisionrectangle.Location;
            Box0.Width = 5;
            Box0.Height = 71;
            Box0.Draw(video, Color.Red);

            Box1.Location = Rightcollisionrectangle.Location;
            Box1.Width = 5;
            Box1.Height = 71;
            Box1.Draw(video, Color.Red);

            Box2.Location = Uppercollisionrectangle.Location;
            Box2.Width = 55;
            Box2.Height = 5;
            Box2.Draw(video, Color.Red);

            Box3.Location = Lowercollisionrectangle.Location;
            Box3.Width = 55;
            Box3.Height = 5;
            Box3.Draw(video, Color.Red);
        }
        //Deze functie regelt de bewegingen van de vijand en detecteert tevens of een botsing is met één van de achtergrondafbeeldingen.
        public void EnemyMovement(List<MetalBlock> metalObjects, List<Leeg> emptyBlocks, List<Stone> stoneObjects)
        {
            //De deelafbeelding wordt veranderd en x-positie schuift 2 pixels op.
            if (MoveLeft || MoveRight)
            {
                ShowPartImage.Y += 71;
                if (ShowPartImage.Y >= 284)
                    ShowPartImage.Y = 0;
            }

            if (MoveRight)
            {
                Position.X += 2;
                Image = _imageRight;
                MoveLeft = false;
            }
            if (MoveLeft)
            {
                Position.X -= 2;
                Image = _imageLeft;
                MoveRight = false;
            }
            //Wordt op altijd op false gezet, wordt alleen true indien de vijand op een blokje loopt.
            StaatOpBlok = false;
            //Er wordt voor de metaalobjecten en de steenobjecten gecheckt of er een botsing gebeurd.
            foreach (var m in metalObjects)
            {
                if (Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
                {
                    MoveRight = true;
                    MoveLeft = false;
                }
                if (Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
                {
                    MoveRight = false;
                    MoveLeft = true;
                }
                if (Lowercollisionrectangle.IntersectsWith(m.Uppercollisionrectangle))
                {
                    StaatOpBlok = true;
                }
                else
                    MoveLeft = true;
            }
            foreach (var s in stoneObjects)
            {
                if (Leftcollisionrectangle.IntersectsWith(s.Rightcollisionrectangle))
                {
                    MoveRight = true;
                    MoveLeft = false;
                }
                if (Rightcollisionrectangle.IntersectsWith(s.Leftcollisionrectangle))
                {
                    MoveRight = false;
                    MoveLeft = true;
                }
                if (Lowercollisionrectangle.IntersectsWith(s.Uppercollisionrectangle))
                {
                    StaatOpBlok = true;
                }
                else
                    MoveLeft = true;
            }
            //Dit is de zwaartekracht die ervoor zorgt dat de vijand naar beneneden valt indien niet op een blokje staat.
            if (StaatOpBlok == false)
            {
                Position.Y += 7;
            }
        }
    }
}