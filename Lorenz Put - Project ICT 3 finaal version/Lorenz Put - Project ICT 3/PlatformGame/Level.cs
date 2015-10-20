using System;
using System.Collections.Generic;
using SdlDotNet.Graphics;

namespace PlatformGame
{
    //Deze klasse vormt een template voor de klassen level1 en 2. Indien nodig kunnen deze klassen bepaalde delen overriden en extra functionaliteit toe voegen.
    internal class Level
    {
        public List<FinishDoor> FinishDoors;
        public List<GameObject> GameObjects;
        //De held, de tilearray en de objectenlijsten worden aangemaakt.
        public Hero Held;
        protected int[,] IntTylearray;
        public List<Item> Items;
        public List<Klock> KlockObjects;
        public List<LifeItem> LifeObjects;
        public List<MetalBlock> MetalObjects;
        protected int Movelevelspeed = 5;
        public List<NextLevelDoor> NextLevelObjects;
        public List<Stone> StoneObjects;
        public List<Enemy> Vijanden;
        //Het cijfer in welke richting de vijand loopt en de snelheid waarmee wordt geïniitialiseerd
        protected int WelkeRichting;
        protected int Teller = 0;

        //Leest de IntTyleArray uit en voegt de objecten toe aan lijsten afhankelijk van welke cijfers in de array staan.
        public virtual void Createworld()
        {
            for (var x = 0; x < 12; x++)
            {
                for (var y = 0; y < 71; y++)
                {
                    
                    if (IntTylearray[x, y] == 1)
                    {
                        if (WelkeRichting == 0)
                        {
                            //De vijand zal nu beginnen met naar rechts te lopen.
                            var v = new Enemy(y*50, x*50, false, true);
                            Vijanden.Add(v);
                            WelkeRichting++;
                        }
                        else if (WelkeRichting == 1)
                        {
                            //De vijand zal nu beginnen met naar links te lopen.
                            var v = new Enemy(y*50, x*50, true, false);
                            Vijanden.Add(v);
                            WelkeRichting = 0;
                        }
                    }
                    if (IntTylearray[x, y] == 2)
                    {
                        var m = new MetalBlock(y*50, x*50);
                        MetalObjects.Add(m);
                    }
                    if (IntTylearray[x, y] == 3)
                    {
                        var l = new LifeItem(y*50, x*50);
                        LifeObjects.Add(l);
                    }
                    if (IntTylearray[x, y] == 4)
                    {
                        var n = new NextLevelDoor(y*50, x*50);
                        NextLevelObjects.Add(n);
                    }
                    if (IntTylearray[x, y] == 5)
                    {
                        Held = new Hero(y*50, x*50);
                        GameObjects.Add(Held);
                    }
                    if (IntTylearray[x, y] == 6)
                    {
                        var s = new Stone(y*50, x*50);
                        StoneObjects.Add(s);
                    }
                    if (IntTylearray[x, y] == 7)
                    {
                        var i = new Item(y*50, x*50);
                        Items.Add(i);
                    }
                    if (IntTylearray[x, y] == 8)
                    {
                        var k = new Klock(y*50, x*50);
                        KlockObjects.Add(k);
                    }
                    if (IntTylearray[x, y] == 9)
                    {
                        var f = new FinishDoor(y*50, x*50);
                        FinishDoors.Add(f);
                    }
                }
            }
        }
        //Er wordt door de lijsten gelopen en de objeccten hun Draw mthode wordt aan geroepen.
        public virtual void Draw(Surface video)
        {
            foreach (Hero h in GameObjects)
            {
                h.Draw(video);
            }
            foreach (var v in Vijanden)
            {
                v.Draw(video);
            }
            foreach (var l in LifeObjects)
            {
                l.Draw(video);
            }
            foreach (var n in NextLevelObjects)
            {
                n.Draw(video);
            }
            foreach (var i in Items)
            {
                i.Draw(video);
            }
            foreach (var k in KlockObjects)
            {
                k.Draw(video);
            }
        }
        //Dit wordt gedaan zodat er in de manager maar 1 movelevel functie moet worden aangeroepen voor beide levels
        public virtual void MoveLevel(Hero held)
        {
        }
        // Er wordt door de verschillende lijsten van objecten gelopen en er wordt gecheckt of er geen "botsingen" voorkomen met de held.
        public virtual void CheckCollisionsHeldWithBackground()
        {            
            if (Held.NumberOflives < 3)
            {
                foreach (var l in LifeObjects)
                {
                    if (Held.Leftcollisionrectangle.IntersectsWith(l.Rightcollisionrectangle))
                    {
                        Held.NumberOflives++;
                        LifeObjects.Remove(l);
                        break;
                    }
                    if (Held.Rightcollisionrectangle.IntersectsWith(l.Leftcollisionrectangle))
                    {
                        Held.NumberOflives++;
                        LifeObjects.Remove(l);
                        break;
                    }
                    if (Held.Lowercollisionrectangle.IntersectsWith(l.Uppercollisionrectangle))
                    {
                        Held.NumberOflives++;
                        LifeObjects.Remove(l);
                        break;
                    }
                }
            }
            foreach (var n in NextLevelObjects)
            {
                if (Held.Leftcollisionrectangle.IntersectsWith(n.Rightcollisionrectangle))
                {
                    Held.Level2 = true;
                }
                if (Held.Rightcollisionrectangle.IntersectsWith(n.Leftcollisionrectangle))
                {
                    Held.Level2 = true;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(n.Uppercollisionrectangle))
                {
                    Held.Level2 = true;
                }
            }
            foreach (var i in Items)
            {
                i.PickUpItem = false;
                if (Held.Leftcollisionrectangle.IntersectsWith(i.Rightcollisionrectangle))
                {
                    i.PickUpItem = true;
                    Held.Score++;
                    Items.Remove(i);
                    break;
                }
                if (Held.Rightcollisionrectangle.IntersectsWith(i.Leftcollisionrectangle))
                {
                    i.PickUpItem = true;
                    Held.Score++;
                    Items.Remove(i);
                    break;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(i.Uppercollisionrectangle))
                {
                    Held.Score++;
                    Items.Remove(i);
                    break;
                }
                if (Held.Uppercollisionrectangle.IntersectsWith(i.Lowercollisionrectangle))
                {
                    i.PickUpItem = true;
                    Held.Score++;
                    Items.Remove(i);
                    break;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(i.Uppercollisionrectangle))
                {
                    i.PickUpItem = true;
                    Held.Score++;
                    Items.Remove(i);
                    break;
                }
            }
            foreach (var k in KlockObjects)
            {
                Held.Plustime = false;
                if (Held.Leftcollisionrectangle.IntersectsWith(k.Rightcollisionrectangle))
                {
                    KlockObjects.Remove(k);
                    Held.Plustime = true;
                    break;
                }
                if (Held.Rightcollisionrectangle.IntersectsWith(k.Leftcollisionrectangle))
                {
                    KlockObjects.Remove(k);
                    Held.Plustime = true;
                    break;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(k.Uppercollisionrectangle))
                {
                    Held.Plustime = true;
                    KlockObjects.Remove(k);
                    break;
                }
                if (Held.Uppercollisionrectangle.IntersectsWith(k.Lowercollisionrectangle))
                {
                    KlockObjects.Remove(k);
                    Held.Plustime = true;
                    break;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(k.Uppercollisionrectangle))
                {
                    KlockObjects.Remove(k);
                    Held.Plustime = true;
                    break;
                }
            }
            foreach (var f in FinishDoors)
            {
                if (Held.Leftcollisionrectangle.IntersectsWith(f.Rightcollisionrectangle))
                {
                    Held.Finish = true;
                    break;
                }
                if (Held.Rightcollisionrectangle.IntersectsWith(f.Leftcollisionrectangle))
                {
                    Held.Finish = true;
                    break;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(f.Uppercollisionrectangle))
                {
                    Held.Finish = true;
                    break;
                }
                if (Held.Uppercollisionrectangle.IntersectsWith(f.Lowercollisionrectangle))
                {
                    Held.Finish = true;
                    break;
                }
                if (Held.Lowercollisionrectangle.IntersectsWith(f.Uppercollisionrectangle))
                {
                    Held.Finish = true;
                    break;
                }
            }
        }
    }
}