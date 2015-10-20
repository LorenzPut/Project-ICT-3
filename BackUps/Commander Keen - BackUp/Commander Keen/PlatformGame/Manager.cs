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
        private Enemy vijand;
        private Enemy vijand2;
        private Enemy vijand3;
        private Enemy vijand4;
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

            vijand = new Enemy(200, 500,true,false);
            vijand2 = new Enemy(300, 500, false, true);
            vijand3 = new Enemy(600, 500, false, true);
            vijand4 = new Enemy(700, 500, true, false);

            level1 = new Level();
            AantalLevens = new NumberOfLives();
            Gameobjecten = new List<GameObject>();

            Gameobjecten.Add(held);
            Gameobjecten.Add(vijand);
            Gameobjecten.Add(vijand2);
            Gameobjecten.Add(vijand3);
            Gameobjecten.Add(vijand4);

            Vijanden = new List<Enemy>();
            Vijanden.Add(vijand);
            Vijanden.Add(vijand2);
            Vijanden.Add(vijand3);
            Vijanden.Add(vijand4);

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

            CheckCollisionsWithBackground();
            CheckCollisionsWithEnemy();
            EnemyMovement();
            AantalLevens.Draw(mVideo, held);

            
            foreach (GameObject g in Gameobjecten)
            {
                g.Update();
                g.Draw(mVideo);
            }  
            level1.Draw(mVideo);

            mVideo.Update();
            Console.WriteLine(held.Position.Y);

        }
        private void CheckCollisionsWithBackground()
        {
            
                if (level1.CheckCollisionMetalBlockWithHero(held) == 1)
                {
                    held.MoveRight = false;
                    held.Position.X -= 10;
                }
                if (level1.CheckCollisionMetalBlockWithHero(held) == 2)
                {
                    held.MoveLeft = false;
                    held.Position.X += 10;
                }

                
                if (level1.CheckCollisionMetalBlockWithHero(held) == 3)
                {
                    Console.WriteLine("Ik ben tegen het blokje gesprongen");

                }
                if (held.JumpBool == true)
                {
                    if (level1.StaatOpBlok == false)
                    {
                        held.Position.Y = held.ground;
                    }
                }
                if (held.JumpBool == false)
                {
                    if (level1.StaatOpBlok == false)
                    {
                        held.Position.Y += 4;
                    }
                }
                
                //if (level1.CheckCollisionMetalBlockWithHero(held) == 4)
                //{
                //    held.ground = held.Position.Y;
                //    Console.WriteLine("de y positie van de held is "+held.Position.Y);

                //}

               
                
               
         
        }
        private void CheckCollisionsWithEnemy()
        {
            foreach (Enemy v in Vijanden)
            {
                if (held.Rightcollisionrectangle.IntersectsWith(v.Leftcollisionrectangle))
                {
                    Console.WriteLine("Ik ben geraakt door de vijand. Ik verlies 1 leven");
                    
                    held.Position.X -= 20;
                   
                    held.NumberOflives -= 1;
                }
                if (held.Leftcollisionrectangle.IntersectsWith(v.Rightcollisionrectangle))
                {
                    Console.WriteLine("Ik wordt weer geraakt");
                    held.Position.X += 20;
                    held.NumberOflives -= 1;

                }
                if (held.Lowercollisionrectangle.IntersectsWith(v.Uppercollisionrectangle))
                {
                    Console.WriteLine("Ik heb de vijand gedood");
                    v.NumberOflives -= 1;
                    
                }
                
            }
        }
        private void EnemyMovement()
        {
            foreach (Enemy v in Vijanden)
            {
                if (v.Position.X <= 0)
                {
                    v.MoveLeft = false;
                    v.MoveRight = true;
                }
                if (v.Position.X >= 1245)
                {
                    v.MoveRight = false;
                    v.MoveLeft = true;
                }
                if (level1.CheckcollisionMetalBlockWithEnemy(v) == 1)
                {
                    v.MoveRight = true;
                    v.MoveLeft = false;
                }
                if (level1.CheckcollisionMetalBlockWithEnemy(v) == 2)
                {
                    v.MoveRight = false;
                    v.MoveLeft = true;
                }
                else
                    v.MoveLeft = true;
                
            }
 
        }
        
       
    }

    
}
