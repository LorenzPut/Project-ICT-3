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
            {0,0,0,0,0,2,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };
        public List<Grass> GrassObjects;
        public List<LifeItem> LifeObjects;
        public List<MetalBlock> MetalObjects;
        public List<NextLevelDoor> NextLevelObjects;
        public List<Leeg> EmptyBlocks;
        public Level()
        {
            GrassObjects = new List<Grass>();
            LifeObjects = new List<LifeItem>();
            MetalObjects = new List<MetalBlock>();
            NextLevelObjects = new List<NextLevelDoor>();
            EmptyBlocks = new List<Leeg>();

            Createworld();

        }
        private void Createworld()
        {
            for (int x = 0; x <11; x++)
            {
                for (int y = 0; y < 25; y++)
                {

                    if (IntTylearray[x,y] == 0)
                    {
                        Leeg l = new Leeg();
                        EmptyBlocks.Add(l);
                                                
                    }
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

        
        //public int CheckcollisionMetalBlockWithEnemy(Enemy v)
        //{
        //    foreach (MetalBlock m in MetalObjects)
        //    {
        //        if (v.Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
        //        {
        //            return 1;                    
        //        }
        //        if (v.Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
        //        {
        //            return 2;
        //        }
             
        //    }
        //    return 0;

        //}
        
        
    }
}
