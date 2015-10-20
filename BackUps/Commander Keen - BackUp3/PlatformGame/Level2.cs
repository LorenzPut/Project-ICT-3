using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    class Level2
    {
        int teller = 0, i = 0;
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
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4},
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
        public Level2()
        {
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
            for (int x = 0; x <12; x++)
            {
                for (int y = 0; y < 72; y++)
                {
                    if (IntTylearray[x,y] == 0)
                    {
                        Leeg L = new Leeg(y * 50, x* 50);
                        EmptyBlocks.Add(L);
                        
                    }
                    if (IntTylearray[x, y] == 1)
                    {
                             if (i == 0)
                            {
                                //De vijand zal nu beginnen met naar rechts te lopen.
                                Enemy v = new Enemy(y * 50, x * 50, false, true);
                                Vijanden.Add(v);
                                i++;
                            }
                            else if(i == 1)
                            {
                                //De vijand zal nu beginnen met naar links te lopen.
                                Enemy v = new Enemy(y * 50, x * 50, true, false);
                                Vijanden.Add(v);
                                i = 0;
                            }                         
			 
                    }                   
                    if (IntTylearray[x, y] == 2)
                    {
                        Grass m = new Grass (y * 50, x * 50);
                        GrassObjects.Add(m);

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
                    if (IntTylearray[x, y] == 5)
                    {
                        held = new Hero(y * 50,x * 50);
                        GameObjects.Add(held);
                    }
                }
            }
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
                foreach (Grass m in GrassObjects)
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
                foreach (Grass m in GrassObjects)
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
