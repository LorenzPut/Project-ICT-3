using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    
    class Level1
    {
        public int teller = 0;
        public List<GameObject> GameObjects;
        public List<Enemy> Vijanden;
        public List<Stone> StoneObjects;
        public List<LifeItem> LifeObjects;
        public List<MetalBlock> MetalObjects;
        public List<NextLevelDoor> NextLevelObjects;
        public List<Leeg> EmptyBlocks;
        public Hero held;
        protected int i = 0;
        public bool StaatOpBlok = false;

        private bool level2 = false;
        public bool Level2
        { 
            get 
        {
                return level2;
        }
            set 
            
            {
                if (value != level2)
                {
                    CreateWorld2();
                }
                level2 = value;
            }
        }


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
        private int[,] IntTylearrayLevel2 = new int[,]
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
        public Level1()
        {
            held = new Hero();
            GameObjects = new List<GameObject>();
            Vijanden = new List<Enemy>();
            LifeObjects = new List<LifeItem>();
            NextLevelObjects = new List<NextLevelDoor>();
            EmptyBlocks = new List<Leeg>();
            MetalObjects = new List<MetalBlock>();
            StoneObjects = new List<Stone>();
            Createworld();

        }
        public void Createworld()
        {            
                for (int x = 0; x < 12; x++)
                {
                    for (int y = 0; y < 72; y++)
                    {
                        if (IntTylearray[x, y] == 1)
                        {
                            if (i == 0)
                            {
                                //De vijand zal nu beginnen met naar rechts te lopen.
                                Enemy v = new Enemy(y * 50, x * 50, false, true);
                                Vijanden.Add(v);
                                i++;
                            }
                            else if (i == 1)
                            {
                                //De vijand zal nu beginnen met naar links te lopen.
                                Enemy v = new Enemy(y * 50, x * 50, true, false);
                                Vijanden.Add(v);
                                i = 0;
                            }

                        }
                        if (IntTylearray[x, y] == 2)
                        {
                            MetalBlock m = new MetalBlock(y * 50, x * 50);
                            MetalObjects.Add(m);
                        }
                        if (IntTylearray[x, y] == 0)
                        {
                            Leeg L = new Leeg(y * 50, x * 50);
                            EmptyBlocks.Add(L);
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

                            held = new Hero(y * 50, x * 50);
                            GameObjects.Add(held);

                        }
                    }
                }
            }
              
      
        public void CreateWorld2()
        {
            {
                Vijanden.Clear();
                LifeObjects.Clear();
                GameObjects.Clear();
                MetalObjects.Clear();
                NextLevelObjects.Clear();
                EmptyBlocks.Clear();
                for (int w = 0; w < 12; w++)
                {
                    for (int z = 0; z < 72; z++)
                    {
                        if (IntTylearrayLevel2[w, z] == 1)
                        {
                            if (i == 0)
                            {
                                //De vijand zal nu beginnen met naar rechts te lopen.
                                Enemy v = new Enemy(z * 50, w * 50, false, true);
                                Vijanden.Add(v);
                                i++;
                            }
                            else if (i == 1)
                            {
                                //De vijand zal nu beginnen met naar links te lopen.
                                Enemy v = new Enemy(z * 50, w * 50, true, false);
                                Vijanden.Add(v);
                                i = 0;
                            }

                        }
                        if (IntTylearrayLevel2[w, z] == 2)
                        {
                            Stone m = new Stone(z * 50, w * 50);
                            StoneObjects.Add(m);                            
                        }
                        if (IntTylearrayLevel2[w, z] == 0)
                        {
                            Leeg L = new Leeg(z * 50, w * 50);
                            EmptyBlocks.Add(L);
                        }

                        if (IntTylearrayLevel2[w, z] == 3)
                        {
                            LifeItem l = new LifeItem(z * 50, w * 50);
                            LifeObjects.Add(l);

                        }
                        if (IntTylearrayLevel2[w, z] == 4)
                        {
                            NextLevelDoor n = new NextLevelDoor(z * 50, w * 50);
                            NextLevelObjects.Add(n);
                        }
                        if (IntTylearrayLevel2[w, z] == 5)
                        {

                            held = new Hero(z * 50, w * 50);
                            GameObjects.Add(held);

                        }
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
            foreach (LifeItem l in LifeObjects)
            {
                l.Draw(video);
            }
            foreach (NextLevelDoor n in NextLevelObjects)
            {
                n.Draw(video);
            }
            if (held.level2 == false)
            {
                foreach (MetalBlock m in MetalObjects)
                {
                    m.Draw(video);
                }
            }
            else if (held.level2)
            {
                foreach (Stone s in StoneObjects)
                {
                    s.Draw(video);
                }
            }

            

        }


        public void MoveLevel(Hero held)
        {
            if (held.Position.X >= 650 && held.MoveRight == true && teller < 48866)
            {
                held.Position.X = 649;
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
                if (held.level2 == false)
                {
                    foreach (MetalBlock m in MetalObjects)
                    {
                        teller++;
                        m.Position.X -= 5;
                    }
                }
                else
                {
                    foreach (Stone s in StoneObjects)
                    {
                        s.Position.X -= 5;
                    }
                }
            }

            if (held.Position.X <= 600 && held.MoveLeft == true && teller > 0)
            {
                                
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
                if (held.level2 == false)
                {
                    foreach (MetalBlock m in MetalObjects)
                    {
                        teller--;
                        m.Position.X += 5;
                        held.Position.X = 601;
                    }
                }
                else
                {
                    foreach (Stone s in StoneObjects)
                    {
                        s.Position.X +=5;
                    }
                }
            }
        }
        
    }
}
