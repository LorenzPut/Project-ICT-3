using SdlDotNet.Audio;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformGame
{
    class Manager
    {
        Surface achtergrond; //achtergrond
        private Hero held;
        //private Enemy vijand;
        //private Enemy vijand2;
        //private Enemy vijand3;
        //private Enemy vijand4;
        Music muziek;
        private NumberOfLives AantalLevens;
        private Surface mVideo;
        private Level level1;
        private List<GameObject> Gameobjecten;
        private List<Enemy> Vijanden;
        
        public Manager()
        {

            try
            {
                 mVideo = Video.SetVideoMode(1300,600);
                 achtergrond = new Surface("Background.jpg");// achtergrond
                 muziek = new Music("Commander Keen 4.mp3");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);  
            }
            

            held = new Hero();

            //vijand = new Enemy(200, 500,true,false);
            //vijand2 = new Enemy(300, 500, false, true);
            //vijand3 = new Enemy(600, 500, false, true);
            //vijand4 = new Enemy(700, 500, true, false);

            level1 = new Level();
            AantalLevens = new NumberOfLives();
            Gameobjecten = new List<GameObject>();

            Gameobjecten.Add(held);
            //Gameobjecten.Add(vijand);
            //Gameobjecten.Add(vijand2);
            //Gameobjecten.Add(vijand3);
            //Gameobjecten.Add(vijand4);

            Vijanden = new List<Enemy>();
            //Vijanden.Add(vijand);
            //Vijanden.Add(vijand2);
            //Vijanden.Add(vijand3);
            //Vijanden.Add(vijand4);

            MusicPlayer.Volume = 30;
            MusicPlayer.Load(muziek);
            muziek.Play();

            Events.Tick += Events_Tick;
            //Events.Fps = 5;
            Events.KeyboardUp += Events_KeyboardUp;
            Events.Quit += Events_Quit;            
            Events.Run();
        }

        void Events_KeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {


            if (e.Key== SdlDotNet.Input.Key.Escape)
            {
                Events.QuitApplication();
            }
        }

        void Events_Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            muziek = new Music("Commander Keen 4.mp3");
            
            
            mVideo.Blit(achtergrond); //achtergrond

            //CheckCollisionsWithBackground();
            //CheckCollisionsWithEnemy();
            //EnemyMovement();
            //MoveLevel();
            CheckCollisions();
            //AantalLevens.Draw(mVideo, held);

            
            foreach (GameObject g in Gameobjecten)
            {
                g.Update();
                g.Draw(mVideo);
            }  
            level1.Draw(mVideo);

            mVideo.Update();

        }
 
        //private void CheckCollisionsWithEnemy()
        //{
        //    foreach (Enemy v in Vijanden)
        //    {
        //        if (held.Rightcollisionrectangle.IntersectsWith(v.Leftcollisionrectangle))
        //        {
        //            Console.WriteLine("Ik ben geraakt door de vijand. Ik verlies 1 leven");
                    
        //            held.Position.X -= 20;
                   
        //            held.NumberOflives -= 1;
        //        }
        //        if (held.Leftcollisionrectangle.IntersectsWith(v.Rightcollisionrectangle))
        //        {
        //            Console.WriteLine("Ik wordt weer geraakt");
        //            held.Position.X += 20;
        //            held.NumberOflives -= 1;

        //        }
        //        if (held.Lowercollisionrectangle.IntersectsWith(v.Uppercollisionrectangle))
        //        {
        //            Console.WriteLine("Ik heb de vijand gedood");
        //            v.NumberOflives -= 1;
                    
        //        }
                
        //    }
        //}
        //private void EnemyMovement()
        //{
        //    foreach (Enemy v in Vijanden)
        //    {
        //        if (v.Position.X <= 0)
        //        {
        //            v.MoveLeft = false;
        //            v.MoveRight = true;
        //        }
        //        if (v.Position.X >= 1245)
        //        {
        //            v.MoveRight = false;
        //            v.MoveLeft = true;
        //        }
        //        if (level1.CheckcollisionMetalBlockWithEnemy(v) == 1)
        //        {
        //            v.MoveRight = true;
        //            v.MoveLeft = false;
        //        }
        //        if (level1.CheckcollisionMetalBlockWithEnemy(v) == 2)
        //        {
        //            v.MoveRight = false;
        //            v.MoveLeft = true;
        //        }
        //        else
        //            v.MoveLeft = true;
                
        //    }
 
        //}
        //public void MoveLevel()
        //{
        //    if (held.Position.X >= 650 && held.MoveRight == true)
        //    {
        //        foreach (MetalBlock m in level1.MetalObjects)
        //        {
        //            m.Position.X -= 5;
        //            held.Position.X -= 1;
        //        }

        //    }
        //}

        public void CheckCollisions()
        {          
            foreach (MetalBlock m in level1.MetalObjects)
            {
                if (held.Rightcollisionrectangle.IntersectsWith(m.Leftcollisionrectangle))
                {
                    held.MoveLeft = false;
                    held.Position.X -= 10;
                }
                if (held.Leftcollisionrectangle.IntersectsWith(m.Rightcollisionrectangle))
                {
                    held.MoveRight = false;
                    held.Position.X += 10;
                }
                if (held.Uppercollisionrectangle.IntersectsWith(m.Lowercollisionrectangle))
                {
                    Console.WriteLine("Ik spring tegen het blokje.");
                }

                if (held.Lowercollisionrectangle.IntersectsWith(m.Uppercollisionrectangle))
                {
                    held.ground = held.Position.Y;
                }
                //else if (held.Lowercollisionrectangle.IntersectsWith(m.Uppercollisionrectangle) == false)
                //    held.ground = 500;
                
            }
        }
    }
}
