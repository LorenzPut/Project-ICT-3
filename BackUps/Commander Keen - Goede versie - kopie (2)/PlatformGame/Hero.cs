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
        //Een afbeelding voor naar links en een afbeelding naar rechts te wandelen.
        readonly Surface _imageRight;
        readonly Surface _imageLeft;
       //Deze variabelen bepalen :  
        /* - of de held naar links of rechts wandelt
           - of hij springt of op een blokje staat
           - of hij onverslaanbaar
           - of geraakt door een vijand
           - of een klokje heeft "opgeraapt"
           - of hij dood is
           - of de finish heeft bereikt.*/
        public bool MoveRight, MoveLeft, Jump = false, Savejump = false, StaatOpBlok = false, Invincible = false, Level2 = false, Hit = false, Plustime, IamDead = false, Finish = false;
        //Deze variabelen bepalen :  tot welke hoogte de held mag vallen, maximaal kan springen, wat zijn score is en hoe rap hij over het scherm mag bewegen
        public int Ground = 424, TopY = 0, Score = 0, Speed = 8;
        //Wordt gebruikt om te bewaren op welke positie de held gestart is met springen.
        public int Beginpositie = 0;
        //Regelt met welke snelheid het springen van de held vertraagt wordt.
        public double Springvertraging = 12;
        //Aantal levens waarmee de held begint.
        public int NumberOflives = 1;

        
        public Hero()
        {
        }
        public Hero(int x, int y)
        {
            try
            {
                Image = new Surface("Commander_Keen_links.png");
                _imageLeft = new Surface("Commander_Keen_links.png");
                _imageRight = new Surface("Commander_Keen_rechts.png");
                Position = new Point(x, y);
                ShowPartImage = new Rectangle(0, 0, 50, 76);
                Leftcollisionrectangle = new Rectangle(Position.X, (Position.Y + 3), 3, 68);
                Rightcollisionrectangle = new Rectangle((Position.X + 50), (Position.Y + 3), 3, 68);
                Uppercollisionrectangle = new Rectangle(Position.X, (Position.Y - 5), 53, 5);
                Lowercollisionrectangle = new Rectangle((Position.X+2), (Position.Y + 75), 46, 5);
            }
            catch (Exception error)
            {
                Console.WriteLine("Er is een fout opgetreden : " + error.Message);
            }
            
           

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
            if (e.Key == SdlDotNet.Input.Key.Space)
            {
                //Savejump zorgt ervoor dat de held niet nog een kan springen terwijl hij al aan het springen is.
                if (Jump == false && Savejump == true)
                {
                    //De huidige status van Jump wordt opgeslagen in Savejump. 
                    Savejump = Jump;
                    //De held ag springe
                    Jump = true;
                    //De huidge y-positie wordt opgeslagen in beginpositie
                    Beginpositie = Position.Y;
                }
            }

        }
        public override void Update()
        {
            Movements();

            if (Jump)
            {
                //Er wordt uitgerekend met hoeveel de y- positie moet verminderen tijdens het springen.
                double add_Y = (double)Springvertraging * (Math.Pow(1, 2));

                //Als de held buiten het scherm springt moet hij stoppen met springen.
                if (Position.Y <= TopY)
                {
                    Position.Y = TopY;
                    Jump = false;
                }
                    //Indien dit niet het geval is wordt de berekende y waarde van de huidige y - waarde af getrokken.
                else if (Position.Y > TopY)
                {
                    Position.Y -= (int)add_Y;
                    //De formule voor de y - waarde wordt telkens met 0.2 verminderd. Indien dit niet gedaan wordt zou de held oneindig lang blijven springen.
                    Springvertraging -= 0.2;
                }
                //Als de held 140 pixels onder zijn beginpositie zit, mag er niet meer gesprongen worden en wordt de springvertraging terug op 12 gezet.
                if (Position.Y < (Beginpositie - 140))
                {
                    Springvertraging = 12;
                    Jump = false;
                }   

            }
            //Dit zorgt voor de zwaartekracht zolang springen vals is en de y-positie niet groter is als de onderkant van het scherm - 76 (= hoogte speler)
            //Indien er een blokje geraakt wordt, zal de speler ook stoppen met vallen
            if (Jump == false)
            {
                if (Position.Y >= Ground)
                {
                    Position.Y = Ground;
                    Savejump = true;
                    Springvertraging = 12;
                }
                else if (Position.Y < Ground)
                {
                    Savejump = false;
                    Position.Y += 6;
                }
            }
            //De speler kan niet buiten het scherm lopen
            if (Position.Y <= 0 )
            {
                Jump = false;
            }
            if (Position.X <= 0)
            {
                MoveLeft = false;
                Position.X += Speed;
            }
            if (Position.X >= 1250)
            {
                MoveRight = false;
                Position.X -= Speed;
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


        public override void Draw(Surface video)
        {
            base.Draw(video);
            Box0.Location = Leftcollisionrectangle.Location;
            Box0.Width = 3;
            Box0.Height = 68;
            Box0.Draw(video, Color.Red);

            Box1.Location = Rightcollisionrectangle.Location;
            Box1.Width = 3;
            Box1.Height = 68;
            Box1.Draw(video, Color.Red);

            Box2.Location = Uppercollisionrectangle.Location;
            Box2.Width = 53;
            Box2.Height = 5;
            Box2.Draw(video, Color.Red);

            Box3.Location = Lowercollisionrectangle.Location;
            Box3.Width = 45;
            Box3.Height = 5;
            Box3.Draw(video, Color.Red);

        }
        public void Movements()
        {
            if (MoveLeft)
            {
                Position.X -= Speed;
                Image = _imageLeft;
            }
            if (MoveRight)
            {
                Position.X += Speed;
                Image = _imageRight;
            }

            if (MoveLeft || MoveRight)
            {
                ShowPartImage.Y += 76;
                if (ShowPartImage.Y >= 380)
                    ShowPartImage.Y = 0;
            }


        }
       //Indien het aantal levens van de held 0 is en hij is niet onoverwinnelijk wordt hij uit de lijst van gameobjecten verwijdert waardoor hij dus niet meer getekend wordt of sterft.
        public void Die(List<GameObject> Gameobjecten)
        {
            foreach (GameObject g in Gameobjecten)
            {

                if (NumberOflives == 0 && Invincible == false)
                {
                    Gameobjecten.Remove(g);
                    IamDead = true;
                    break;
                }

            }
        }

    }
}
