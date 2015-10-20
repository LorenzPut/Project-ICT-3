using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    
    class Level1
    {
        private int teller = 0;
        private int i = 0;
        public Hero held;
        public bool StaatOpBlok = false;
        private int[,] IntTylearray = new int[,]
        { 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,1,1,1,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {2,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,2,0,0,2,0,0,0,2,2,2},
            {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},

        };
        public List<GameObject> GameObjects;
        public List<Enemy> Vijanden;
        public List<Grass> GrassObjects;
        public List<LifeItem> LifeObjects;
        public List<MetalBlock> MetalObjects;
        public List<NextLevelDoor> NextLevelObjects;
        public List<Leeg> EmptyBlocks;
        public Level1()
        {
            held = new Hero();
            GameObjects = new List<GameObject>();
            Vijanden = new List<Enemy>();
            GrassObjects = new List<Grass>();
            LifeObjects = new List<LifeItem>();
            MetalObjects = new List<MetalBlock>();
            NextLevelObjects = new List<NextLevelDoor>();
            EmptyBlocks = new List<Leeg>();

            Createworld();

        }
        public void Createworld()
        {
            
        }
       
        public void Draw(SdlDotNet.Graphics.Surface video)
        {
            foreach (Hero h in GameObjects)
            {
                h.Draw(video); 
            }
            
            foreach (Enemy v in Vijanden)
            {
                v.Draw(video);
            }
            foreach (Grass g in GrassObjects)
            {
                g.Draw(video);
            }
            foreach (LifeItem l in LifeObjects)
            {
                l.Draw(video);
            }
            foreach (MetalBlock m in MetalObjects)
            {
                m.Draw(video);
            }
            foreach (NextLevelDoor n in NextLevelObjects)
            {
                n.Draw(video);
            }

        }


         public void MoveLevel(Hero held)
        {
            //48866
            Console.WriteLine(teller);
            if (held.Position.X >= 650 && held.MoveRight == true && teller < 48866)
            {
                foreach (MetalBlock m in MetalObjects)
                {
                    teller++;
                    m.Position.X -= 5;
                    held.Position.X = 649;

                }
                foreach (Enemy v in Vijanden)
                {
                    v.Position.X -= 5;
                }
                foreach (LifeItem l in LifeObjects)
                {
                    l.Position.X -= 5;
                }
                foreach (NextLevelDoor n in NextLevelObjects)
                {
                    n.Position.X -= 5;
                }
            }
            
             if (held.Position.X <= 600 && held.MoveLeft == true && teller > 0)
            {
                foreach (MetalBlock m in MetalObjects)
                {
                    teller--;
                    m.Position.X += 5;
                    held.Position.X = 601;
                }
                foreach (Enemy v in Vijanden)
                {
                    v.Position.X += 5;

                }
                foreach (LifeItem l in LifeObjects)
                {
                    l.Position.X += 5;
                }
                foreach (NextLevelDoor n in NextLevelObjects)
                {
                    n.Position.X += 5;
                }
                     
            }

        }    
        
    }
}
