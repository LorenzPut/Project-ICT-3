using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    class Level2 : Level
    {
        //De level2 kalsse bevat dezelfde code als de level1 klasse.
        //Enkel de uitbreidingen van de level klasse bevatten andere blokjes

        public Level2()
        {
            IntTylearray = new int[,]
            { 
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	7,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	8,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
                {0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	0,	1,	0,	0,	0,	0,	0,	0,	0,	6,	6,	6,	6,	6,	6,	6,	0,	0,	0,	1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	0},
                {5,	0,	0,	0,	0,	0,	0,	6,	0,	0,	6,	6,	0,	0,	0,	0,	3,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	6,	0,	0,	6,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	0,	0,	0,	6,	0,	0},
                {0,	0,	0,	0,	0,	0,	6,	0,	0,	0,	6,	0,	6,	0,	0,	6,	6,	6,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	3,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	1,	6,	8,	6,	0,	6,	0,	0,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	0,	0,	6,	0,	0,	0},
                {0,	0,  0,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	1,	7,	0,	0,	0,	0,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	6,	6,	6,	6,	6,	6,	6,	6,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	0,	0,	0,	0,	0,	9,	6},
                {0,	0,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	6,	6,	0,	0,	0,	0,	0,	0,	0,	0},
                {6,	0,	0,	6,	1,	0,	0,	0,	0,	0,	0,	0,	1,	0,	0,	0,  0,	0,	0,	0,	6,	6,	6,	6,	6,	6,	6,	6,	0,	0,	0,	0,	0,	6,	0,	0,	0,	6,	0,	0,	1,	0,	1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	0,	0,	1,	0,	0,	0,	0,	0,	0,	0,	0,	1,	1,	0,	0,	6,	0},
                {6,	6,	6,	0,	0,	7,	0,	0,	0,	0,	6,	0,	0,	0,	0,	0,	0,	0,	0,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	0,	0,	0,	0,	0,	6,	6,	6,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	8,	0,	6,	0,	0,	0,	0,	7,	0,	0,	0,	0,	3,	6,	6,	6,	6,	0,	0,	0,	6,	0,	0,	0},
                {6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6,	6}

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
       
        public override void Draw(SdlDotNet.Graphics.Surface video)
        {
            base.Draw(video);
            foreach (Stone s in StoneObjects)
            {
                s.Draw(video);
            }
            foreach (FinishDoor f in FinishDoors)
            {
                f.Draw(video);
            }
        }

        public override void MoveLevel(Hero held)
        {
            //48866
            if (held.Position.X >= 650 && held.MoveRight == true && Teller < 72611)
            {
                foreach (Stone s in StoneObjects)
                {
                    Teller++;
                    s.Position.X -= Movelevelspeed;
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
                foreach (FinishDoor f in FinishDoors)
                {
                    f.Position.X -= Movelevelspeed;
                }
            }

            if (held.Position.X <= 600 && held.MoveLeft == true && Teller > 0)
            {
                foreach (Stone m in StoneObjects)
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
                foreach (FinishDoor f in FinishDoors)
                {
                    f.Position.X += Movelevelspeed;
                }                     
            }
        }
        public override void CheckCollisionsHeldWithBackground()
        {
            base.CheckCollisionsHeldWithBackground();
            Stone savestoneblok = new Stone();
            foreach (Stone s  in StoneObjects)
            {
                if (Held.Rightcollisionrectangle.IntersectsWith(s.Leftcollisionrectangle))
                {
                    Held.MoveLeft = false;
                    Held.Position.X -= Held.Speed;
                }
                if (Held.Leftcollisionrectangle.IntersectsWith(s.Rightcollisionrectangle))
                {
                    Held.MoveRight = false;
                    Held.Position.X += Held.Speed;
                }
                if (Held.Uppercollisionrectangle.IntersectsWith(s.Lowercollisionrectangle))
                {
                    savestoneblok = s;
                    Held.Jump = false;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(s.Uppercollisionrectangle))
                {
                    Held.Ground = (s.Position.Y - 76);
                    savestoneblok = s;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(savestoneblok.Uppercollisionrectangle) == false)
                {
                    Held.Ground = 500;
                } 
            }
            
                
            
        }
        
    }
}
