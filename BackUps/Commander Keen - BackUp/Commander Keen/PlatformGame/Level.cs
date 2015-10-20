using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    
    class Level
    {
        public bool StaatOpBlok = false;
        public int[,] IntTylearray = new int[,]
        { 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };
        public List<Grass> GrassObjects;
        public List<LifeItem> LifeObjects;
        public List<MetalBlock> MetalObjects;
        public List<NextLevelDoor> NextLevelObjects;
        public Level()
        {
            GrassObjects = new List<Grass>();
            LifeObjects = new List<LifeItem>();
            MetalObjects = new List<MetalBlock>();
            NextLevelObjects = new List<NextLevelDoor>();

            Createworld();

        }
        private void Createworld()
        {
            for (int x = 0; x <11; x++)
            {
                for (int y = 0; y < 25; y++)
                {

                    if (IntTylearray[x, y] == 1)
                    {
                        Grass g = new Grass(y * 50, x * 50);
                        GrassObjects.Add(g);
                    }                   
                    if (IntTylearray[x, y] == 2)
                    {
                        MetalBlock m = new MetalBlock (y * 50, x * 50);
                        MetalObjects.Add(m);

                    }
                    if (IntTylearray[x, y] == 3)
                    {
                        LifeItem l = new LifeItem(y * 50, x * 50);
                        LifeObjects.Add(l);

                    }
                    if (IntTylearray[x, y] == 4)
                    {
                        NextLevelDoor n = new NextLevelDoor(y * 50, x * 50);
                        NextLevelObjects.Add(n);

                    }

                }
            }
        }
       
        public void Draw(SdlDotNet.Graphics.Surface video)
        {
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

        public int CheckCollisionMetalBlockWithHero(Hero h)
        {
            foreach (MetalBlock m in MetalObjects)
            {
                if (h.Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
                {
                    return 1;
                }
                if (h.Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
                {
                    return 2;
                }
                if (h.Uppercollisionrectangle.IntersectsWith(m.Lowercollisionrectangle))
                {
                    Console.WriteLine("Ik spring tegen het blokje");
                    return 3;
                    
                }
                if (h.Lowercollisionrectangle.IntersectsWith(m.Uppercollisionrectangle))
                {                    
                    Console.WriteLine("Ik heb het blokje geraakt");
                    StaatOpBlok = true;
                    return 4;
                }
                
            }
            return 0;
        }
        public int CheckCollisionLifeItemWithHero(Hero h)
        {
            foreach (LifeItem l in LifeObjects)
            {
                if (h.Uppercollisionrectangle.IntersectsWith(l.Lowercollisionrectangle))
                {
                    Console.WriteLine("Whoehoew extra leven");
                }
            }            

            return 0;
        }
        public int CheckcollisionMetalBlockWithEnemy(Enemy v)
        {
            foreach (MetalBlock m in MetalObjects)
            {
                if (v.Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
                {
                    return 1;                    
                }
                if (v.Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
                {
                    return 2;
                }
             
            }
            return 0;

        }
        
        
    }
}
