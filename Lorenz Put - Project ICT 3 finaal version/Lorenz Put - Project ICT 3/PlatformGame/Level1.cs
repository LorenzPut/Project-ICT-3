using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    
    class Level1 : Level
    {
        public Level1()
        {
            IntTylearray = new int[,]
            {
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,  1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	3,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	7,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	2,	8,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	2,	2,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	7,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {5,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	2,	2,	2,	0,	0,	0,	0,	0,	2,	2,	2,	2,	2,	2,	0,	0,	3,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	2,	2,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	1,	0,	0,	0,	0,	0,	2,	0,	0,	2,	2,	2,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	2,	0,	2,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	2,	0,	0,	0,	2,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	2,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	2,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	2,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	1,	0,  1,	0,	0,	0,	2,	0,	0,	0,	2,	2,	2,	0,	0,	0,	1,	0,	0,	0,	0,	0,	2,	0,	0,	0,	1,	0,	0,	0,	0,	1,	1,	1,	0,	0,	0,	0,	0,	0,	8,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	0,	1,	0,	0,	0,	0,	0,	2,	2,	2,	1,	0,	0,	2,	1,	4,	0},
                {2,	0,	0,	0,	0,	0,	0,	2,	2,	0,	0,	2,	2,	2,	2,	0,	0,	0,	0,	0,	0,	0,	2,	2,	2,	0,	0,	0,	0,	0,	0,	2,	0,	0,  0,	0,	2,	0,	0,	0,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	2,	2,	2,	2,	0,	0,	2,	2,	0,	0,	0},
                {2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2},

            };
            GameObjects = new List<GameObject>();
            Vijanden = new List<Enemy>();
            StoneObjects = new List<Stone>();
            LifeObjects = new List<LifeItem>();
            MetalObjects = new List<MetalBlock>();
            NextLevelObjects = new List<NextLevelDoor>();
            Items = new List<Item>();
            KlockObjects = new List<Klock>();
            FinishDoors = new List<FinishDoor>();

            Createworld();
        }
               
        public override void Draw(Surface video)
        {
            base.Draw(video);
            foreach (MetalBlock m in MetalObjects)
            {
                m.Draw(video);
            }          

        }
        public override void MoveLevel(Hero held)
         {
            //69003 is het getal waarop het level niet meer achteruit mag bewegen. Dit getal is bepaalt door het level te doorlopen terwijl een teller op het scherm getoond wordt.
            //Deze teller wordt verhoogd elke keer het level beweegt.
            //Zo kon een juist waarde ingesteld worden wanneer het level moest stoppen met bewegen.


            //Als de x-positie van de held groter is dan 650 gaat het level achteruit bewegen terwijl de held eigenlijk ter plaatse blijft staan..
            if (held.Position.X >= 650 && held.MoveRight && Teller < 68303)
            {
                foreach (MetalBlock m in MetalObjects)
                {
                    Teller++;
                    m.Position.X -= Movelevelspeed;
                    held.Position.X = 649;
                }
                foreach (Enemy v in Vijanden)
                {
                    v.Position.X -= Movelevelspeed;
                }
                foreach (LifeItem l in LifeObjects)
                {
                    l.Position.X -= Movelevelspeed;
                }
                foreach (NextLevelDoor n in NextLevelObjects)
                {
                    n.Position.X -= Movelevelspeed;
                }
                foreach (Item i in Items)
                {
                    i.Position.X -= Movelevelspeed;
                }
                foreach (Klock k in KlockObjects)
                {
                    k.Position.X -= Movelevelspeed;
                }                
            }
            
            if (held.Position.X <= 600 && held.MoveLeft && Teller > 0)
            {
                foreach (MetalBlock m in MetalObjects)
                {
                    Teller--;
                    m.Position.X += Movelevelspeed;
                    held.Position.X = 601;
                }
                foreach (Enemy v in Vijanden)
                {
                    v.Position.X += Movelevelspeed;
                }
                foreach (LifeItem l in LifeObjects)
                {
                    l.Position.X += Movelevelspeed;
                }
                foreach (NextLevelDoor n in NextLevelObjects)
                {
                    n.Position.X += Movelevelspeed;
                }
                foreach (Item i in Items)
                {
                    i.Position.X += Movelevelspeed;
                }
                foreach (Klock k in KlockObjects)
                {
                    k.Position.X += Movelevelspeed;
                }
                
            }         
        }
        // CheckCollisionsHeldWithBackground functie uit de level klasse wordt gebruikt en meer uitgebreid.
        public override void CheckCollisionsHeldWithBackground()
        {
            base.CheckCollisionsHeldWithBackground();
            //Dit gedeelte checkt of er een botsing voor komt tussen het metaalblokje en de held.
            MetalBlock savemetaalblok = new MetalBlock();
            foreach (MetalBlock m in MetalObjects)
            {
                if (Held.Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
                {
                    Held.MoveLeft = false;
                    Held.Position.X -= Held.Speed;
                }
                if (Held.Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
                {
                    Held.MoveRight = false;
                    Held.Position.X += Held.Speed;
                }
                if (Held.Uppercollisionrectangle.IntersectsWith(m.Lowercollisionrectangle))
                {
                    Held.Jump = false;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(m.Uppercollisionrectangle))
                {
                    Held.Ground = (m.Position.Y - 76);
                    savemetaalblok = m;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(savemetaalblok.Uppercollisionrectangle) == false)
                {
                    Held.Ground = 500;
                }
            }
           
                    
                          
            
        }
    }
}
