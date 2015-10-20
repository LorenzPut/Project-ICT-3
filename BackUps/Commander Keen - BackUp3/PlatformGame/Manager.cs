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
    class Manager : Program
    {
        Surface achtergrond; //achtergrond
        Surface achtergrond2;
        private HeroLives AantalLevens;
        private Surface mVideo;
        private Level1 level1;
        private Level2 level2;
        public List<Enemy> saveVijanden;
        private Surface start;
        private Surface fontSurfaceStart;
        private Surface gameOver;
        private Surface fontSurfaceGameOver;
        SdlDotNet.Graphics.Font font = new SdlDotNet.Graphics.Font(@"Arial.ttf", 42);
        private bool PressedS = false, PressedR = false;
        //private Music muziek;

        
        public Manager()
        {           

            try
            {
                 mVideo = Video.SetVideoMode(1300,600);
                 achtergrond = new Surface("Background.jpg");// achtergrond
                 achtergrond2 = new Surface("Background2.jpg");// achtergrond
                 // = new Music("Commander Keen 4.mp3");
                 start = new Surface("Commander_Keen_StartScreen.jpg");
                 gameOver = new Surface("Commander_Keen_GameOverScreen.jpg");

            }
            catch (Exception error)
            {
                Console.WriteLine(error);  
            }
            
            fontSurfaceStart = font.Render("Press s to start", Color.Red);
            fontSurfaceGameOver = font.Render("Press r to restart", Color.Red);

            level1 = new Level1();
            level2 = new Level2();
            AantalLevens = new HeroLives();

           
            saveVijanden = new List<Enemy>();

           // MusicPlayer.Volume = 50;
            //MusicPlayer.Load(muziek);
            //muziek.Play();

            Video.WindowCaption = "Commander Keen";
            Events.Tick += Events_Tick;
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
            if (e.Key == SdlDotNet.Input.Key.S)
            {
                PressedS = true;
            }
            if (e.Key == SdlDotNet.Input.Key.R)
            {
                PressedR = true;
            }
        }

        void Events_Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            if (level1.held.IamDead == false)
            {
                PressedR = false;
                if (PressedS)
                {
                    CheckCollisionsWithEnemy();

                    if (level1.held.level2 == false)
                    {
                        mVideo.Blit(achtergrond);
                        level1.MoveLevel(level1.held);
                        level1.held.CheckCollisionsWithMetalBlocks(level1.MetalObjects, level1.EmptyBlocks);
                        AantalLevens.Draw(mVideo, level1.held);
                        level1.held.Die(level1.GameObjects);
                        level1.held.CheckCollisionsWithLifeItem(level1.LifeObjects);
                        level1.held.CheckCollisionsWithNextLevelDoor(level1.NextLevelObjects);
                        
                        foreach (GameObject g in level1.GameObjects)
                        {
                            g.Update();
                            g.Draw(mVideo);
                        }
                        foreach (MetalBlock m in level1.MetalObjects)
                        {
                            m.Update();
                        }
                        foreach (LifeItem l in level1.LifeObjects)
                        {
                            l.Update();
                        }
                        foreach (NextLevelDoor n in level1.NextLevelObjects)
                        {
                            n.Update();
                        }
                        foreach (Enemy v in level1.Vijanden)
                        {
                            v.Update();
                            v.EnemyMovement(level1.MetalObjects, level1.EmptyBlocks, level2.GrassObjects);
                        }

                        level1.Draw(mVideo);
                    }
                    else if (level1.held.level2)
                    {
                        level1.Vijanden.Clear();
                        level1.LifeObjects.Clear();
                        level1.NextLevelObjects.Clear();
                        level1.MetalObjects.Clear();
                        level1.EmptyBlocks.Clear();
                        level1.Draw(mVideo);

                        mVideo.Blit(achtergrond2); //achtergrond
                        level2.MoveLevel(level2.held);
                        AantalLevens.Draw(mVideo, level2.held);
                        level2.held.Die(level2.GameObjects);
                        level2.held.CheckCollisionsWithLifeItem(level2.LifeObjects);
                        level2.held.CheckCollisionsWithGrassBlocks(level2.GrassObjects,level2.EmptyBlocks);

                        foreach (GameObject g in level2.GameObjects)
                        {
                            g.Update();
                            g.Draw(mVideo);
                        }                        
                        foreach (LifeItem l in level2.LifeObjects)
                        {
                            l.Update();
                        }
                        foreach (NextLevelDoor n in level2.NextLevelObjects)
                        {
                            n.Update();
                        }
                        foreach (Enemy v in level2.Vijanden)
                        {
                            v.Update();
                            v.EnemyMovement(level2.MetalObjects, level2.EmptyBlocks, level2.GrassObjects);
                        }
                        foreach (Grass g in level2.GrassObjects)
                        {
                            g.Update();
                        }
                        

                        level2.Draw(mVideo);
                    }
                }


                else
                {
                    mVideo.Blit(start);
                    mVideo.Blit(fontSurfaceStart, new Point(900, 0));

                }
            }
            else
            {
                mVideo.Blit(gameOver);
                mVideo.Blit(fontSurfaceGameOver, new Point(500,500));
                if (PressedR)
                {
                    if (level1.held.level2)
                    {
                        level1.Vijanden.Clear();
                        level1.LifeObjects.Clear();
                        level1.NextLevelObjects.Clear();
                        level1.MetalObjects.Clear();
                        level1.EmptyBlocks.Clear();
                        level1.Createworld();
                        level1.Draw(mVideo);
                        level1.held.IamDead = false;
                        level1.held.NumberOflives = 3;
                    }
                    else
                    {
                        level2.Vijanden.Clear();
                        level2.LifeObjects.Clear();
                        level2.NextLevelObjects.Clear();
                        level2.MetalObjects.Clear();
                        level2.EmptyBlocks.Clear();
                        level2.Createworld();
                        level2.Draw(mVideo);
                        level2.held.IamDead = false;
                        level2.held.NumberOflives = 3;
                    }
                    
                    
                } 
            }
            mVideo.Update();
        }

        private void CheckCollisionsWithEnemy()
        {
            if (level1.held.level2 == false)
            {
                foreach (Enemy v in level1.Vijanden)
                {                
                        if (level1.held.Rightcollisionrectangle.IntersectsWith(v.Leftcollisionrectangle))
                        {
                            Console.WriteLine("Ik ben geraakt door de vijand. Ik verlies 1 leven");

                            level1.held.Position.X -= 20;

                            level1.held.NumberOflives -= 1;
                            v.MoveLeft = false;
                            v.MoveRight = true;
                        }
                        if (level1.held.Leftcollisionrectangle.IntersectsWith(v.Rightcollisionrectangle))
                        {
                            Console.WriteLine("Ik wordt weer geraakt");
                            level1.held.Position.X += 20;
                            level1.held.NumberOflives -= 1;
                            v.MoveLeft = true;
                            v.MoveRight = false;
                        }
                        if (level1.held.Lowercollisionrectangle.IntersectsWith(v.Uppercollisionrectangle))
                        {
                            Console.WriteLine("Ik heb de vijand gedood");
                            v.NumberOflives -= 1;
                            level1.held.Jump = true;
                        } 
                        if (v.NumberOflives == 0)
                        {
                            level1.Vijanden.Remove(v);
                            break;
                        }
                    }
                }
                else if(level1.held.level2)
                {
                    foreach (Enemy v in level2.Vijanden)
	                    {
                            if (level2.held.Rightcollisionrectangle.IntersectsWith(v.Leftcollisionrectangle))
                            {
                                Console.WriteLine("Ik ben geraakt door de vijand. Ik verlies 1 leven");

                                level2.held.Position.X -= 20;

                                level2.held.NumberOflives -= 1;
                                v.MoveLeft = false;
                                v.MoveRight = true;
                            }
                            if (level2.held.Leftcollisionrectangle.IntersectsWith(v.Rightcollisionrectangle))
                            {
                                Console.WriteLine("Ik wordt weer geraakt");
                                level2.held.Position.X += 20;
                                level2.held.NumberOflives -= 1;
                                v.MoveLeft = true;
                                v.MoveRight = false;
                            }
                            if (level2.held.Lowercollisionrectangle.IntersectsWith(v.Uppercollisionrectangle))
                            {
                                Console.WriteLine("Ik heb de vijand gedood");
                                v.NumberOflives -= 1;
                                level2.held.Jump = true;
                            }
                            if (v.NumberOflives == 0)
                            {
                                level2.Vijanden.Remove(v);
                                break;
                            }                  
                        }  

            }
        }       
    }
}
