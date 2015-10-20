using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using SdlDotNet.Audio;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Input;
using Font = SdlDotNet.Graphics.Font;
using Timer = System.Timers.Timer;

namespace PlatformGame
{
    internal class Manager : Program
    {
        private Level _level;
        private bool _pressedS, _pressedR;
        private int _teller = 1, _tijd = 60, _level1Score;
        private readonly HeroLives _aantalLevens;
        private readonly Surface _achtergrond; //achtergrond
        private readonly Surface _achtergrond2;
        private readonly Surface _endscreen;
        private readonly Font _font = new Font(@"Arial.ttf", 42);
        private readonly Surface _fontGameOver;
        private readonly Surface _fontStart;
        private readonly Surface _gameOver;
        private readonly Surface _mVideo;
        private readonly Surface _scoreimage;
        private readonly Surface _start;
        private Surface _fontScore;
        private Surface _fonttimer;
        private Surface _endfont, _endscore;
        private readonly Timer _timer;

        public Manager()
        {
            //De afbeeldingen worden ingeladen en de sdl app wordt gecreeërd
            try
            {
                _mVideo = Video.SetVideoMode(1300, 600);
                _achtergrond = new Surface("Background.jpg"); // achtergrond
                _achtergrond2 = new Surface("Background2.jpg"); // achtergrond
                _start = new Surface("Commander_Keen_StartScreen.jpg");
                _gameOver = new Surface("Commander_Keen_GameOverScreen.jpg");
                _scoreimage = new Surface("Item.png");
                _endscreen = new Surface("Commander_Keen_Endscreen.jpg");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            //De tekst voor het startscherm wordt gecreeërd
            _fontStart = _font.Render("Press s to start", Color.Red);
            _fontGameOver = _font.Render("Press r to restart\n Press esc to quit", Color.Red);

            //Polymorfisme wort toe gepast.
            //Hierdoor krijgt het level object alle eigenschappen van de level1 klasse.
            //Dit laat ons toe om gemakkelijk tussen de level te wisselen zonder dubbele code te schrijven.
            _level = new Level1();
            
            _aantalLevens = new HeroLives();

            //Een timer wordt aangemaakt.
            //Deze timer loopt om de seconde af.
            _timer = new Timer(1000);
            //Indien de timer afloopt wordt de callback functie aan geroepen.
            _timer.Elapsed += timer_Elapsed;

            Video.WindowCaption = "Commander Keen";
            Events.Tick += Events_Tick;
            Events.Quit += Events_Quit;
            Events.KeyboardUp += Events_KeyboardUp;

            //Dit is het hart van de applicatie. Indien dit niet gebruikt wordt, zal de applicatie niet starten.
            Events.Run();
        }

        void Events_Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //De tijd variabele die origineel op 60 stond, gaat elke keer dat de timer afloopt ééntje verminderen
            _tijd--;
        }

        private void Events_KeyboardUp(object sender, KeyboardEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                //De applicatie wordt afgesloten.
                Events.QuitApplication();
            }
            if (e.Key == Key.S)
            {
                _pressedS = true;
            }
            if (e.Key == Key.R)
            {
                _pressedR = true;
            }
            if (e.Key == Key.I)
            {
                _level.Held.Invincible = true;
            }
        }

        private void Events_Tick(object sender, TickEventArgs e)
        {
           //Indien de held niet dood, er op s geduwt is en de held de finish niet bereikt heeft zal het spel gestart worden.
            if (_level.Held.IamDead == false)
            {
                _pressedR = false;
                if (_pressedS)
                {
                    if (_level.Held.Finish)
                    {
                        //Indien de held de finish bereikt heeft, wordt de eindafbeelding en de score op het scherm geblit + nog wat extra informatie.
                        _endscore = _font.Render("Je totale score is : " + (_level1Score + _level.Held.Score), Color.Red);
                        _endfont = _font.Render("Press r to restart. Press i to become invincible. Press esc to close.",Color.Red);
                        _mVideo.Blit(_endscreen);
                        _mVideo.Blit(_endscore, new Point(500, 10));
                        _mVideo.Blit(_endfont, new Point(20, 540));
                    }
                    else
                    {
                        //Indien dit niet het geval is wordt het spel gestart.
                        //Er worden verschillende functie aangeroepen : 
                        /*   - CheckCollisionsWithEnemy : om te checken of de held niet geraakt wort door de vijand
                             - Die : om te checken of de held niet dood is.
                             - MoveLevel : om het level indien nodig te bewegen
                             - CheckCollisionsHeldWithBackground : om te checken of er zich geen "botsingen" voor doen tussen held en achtergrond
                             - UpdateBackGroundTiles : om de collision rechthoeken van de verschillende figuren te updaten
                             - TimeCheck : om te checken of de _tijd variabele niet op 0 staat*/

                        CheckCollisionsWithEnemy();                        
                        _level.Held.Die(_level.GameObjects);
                        _level.MoveLevel(_level.Held);
                        _level.CheckCollisionsHeldWithBackground();
                        UpdateBackGroundTiles();
                        TimeCheck();

                        if (_level.Held.Level2 == false)
                        {
                            //Verder wordt de juiste achtergrond getekend en wordt de variabele _level1Score gebruikt om de score van level1 in te bewaren
                            _mVideo.Blit(_achtergrond);
                            _level1Score = _level.Held.Score;
                        }
                        else if (_level.Held.Level2)
                        {
                            //Alle lijsten die uit level 1 komen worden gecleard
                            _level.Vijanden.Clear();
                            _level.LifeObjects.Clear();
                            _level.NextLevelObjects.Clear();
                            _level.MetalObjects.Clear();
                            _mVideo.Blit(_achtergrond2); //achtergrond van level 2
                            //De tijd wordt terug naar 60 gezet
                            _tijd = 60;
                            //Optimalisatie van de code. Anders zou er elke tick een nieuw level gecreeërd worden.
                            if (_teller == 1)
                            {
                                //Hier wordt weer polymorfisme toe gepast. Hierdoor krijgt het _level object nu alle specifities van de level2 klasse.
                                //Hierdoor kunnen we veel dubbele code vermijden.
                                _level = new Level2();
                                _teller++;
                            }
                        }
                        //Het level, aantal levens, score en de nog resterende tijd worden op het scherm geblit
                        _level.Draw(_mVideo);
                        _aantalLevens.Draw(_mVideo, _level.Held);
                        _fontScore = _font.Render("Score : " + _level.Held.Score, Color.Red);
                        _fonttimer = _font.Render("Time left :" + _tijd, Color.Red);
                        _mVideo.Blit(_fonttimer, new Point(600, 0));
                        _mVideo.Blit(_scoreimage, new Point(1050, 0));
                        _mVideo.Blit(_fontScore, new Point(1100, 0));
                    }
                }
                else
                {
                    //Indien er niet op s geduwt is, wordt het startscherm getoon.
                    _mVideo.Blit(_start);
                    _mVideo.Blit(_fontStart, new Point(900, 0));
                }
            }
            else if (_level.Held.IamDead)
            {
                //Als de held dood is, wordt het gameover scherm getoond.
                _mVideo.Blit(_gameOver);
                _mVideo.Blit(_fontGameOver, new Point(500, 500));

                if (_pressedR)
                {
                    //Indien er op r geduwt is, wordt de functie ReInitialize aan geroepen.
                    ReInitialize();
                }
            }
            //De hele sdl app wordt ge-updatet. Indien dit niet gebruikt wordt, zal de applicatie niet werken.
            _mVideo.Update();
        }

        //Er wordt door de lijst van vijanden gelopen en er wordt gekeken of er geen "bostingen" voorkomen.
        //Indien de held op de vijand springt, zal de vijand sterven en dus uit de lijst verwijdert worden.
        //Indien dit niet het geval is, zal de held een leven verliezen.
        private void CheckCollisionsWithEnemy()
        {
            foreach (var v in _level.Vijanden)
            {
                if (_level.Held.Rightcollisionrectangle.IntersectsWith(v.Leftcollisionrectangle))
                {

                    _level.Held.Position.X -= 20;

                    _level.Held.NumberOflives -= 1;
                    v.MoveLeft = false;
                    v.MoveRight = true;
                }
                if (_level.Held.Leftcollisionrectangle.IntersectsWith(v.Rightcollisionrectangle))
                {

                    _level.Held.Position.X += 20;
                    _level.Held.NumberOflives -= 1;
                    v.MoveLeft = true;
                    v.MoveRight = false;
                }
                if (_level.Held.Lowercollisionrectangle.IntersectsWith(v.Uppercollisionrectangle))
                {
                    v.NumberOflives -= 1;
                    _level.Held.Jump = true;
                }
                if (v.NumberOflives == 0)
                {
                    _level.Vijanden.Remove(v);
                    break;
                }
            }
        }
        //Er wordt door de verschillende lijsten van de achtergrond objecten gelopen en van elk object wordt de update methode aangeroepen.
        public void UpdateBackGroundTiles()
        {
            foreach (var s in _level.StoneObjects)
            {
                s.Update();
            }
            foreach (var m in _level.MetalObjects)
            {
                m.Update();
            }
            foreach (var g in _level.GameObjects)
            {
                g.Update();
                g.Draw(_mVideo);
            }

            foreach (var l in _level.LifeObjects)
            {
                l.Update();
            }
            foreach (var n in _level.NextLevelObjects)
            {
                n.Update();
            }
            foreach (var v in _level.Vijanden)
            {
                v.Update();
                //Hier word gecontroleerd of de vijand niet tegen de achtergrond blokjes loopt. Indien dit het geval is zal de vijand omkeren.
                v.EnemyMovement(_level.MetalObjects, _level.StoneObjects);
            }
            foreach (var i in _level.Items)
            {
                i.Update();
            }
            foreach (var k in _level.KlockObjects)
            {
                k.Update();
            }
            foreach (var f in _level.FinishDoors)
            {
                f.Update();
            }
        }
        //Alle lijsten worden gecleard en de variabelen worden terug op hun oorspronkelijke instellingen gezet
        public void ReInitialize()
        {
            _level.GameObjects.Clear();
            _level.Vijanden.Clear();
            _level.LifeObjects.Clear();
            _level.NextLevelObjects.Clear();
            _level.MetalObjects.Clear();
            _level.Held.NumberOflives = 1;
            _level.Held.IamDead = false;
            _level = new Level1();
            _tijd = 60;
            _teller = 1;
        }
        
        public void TimeCheck()
        {
            //De timer wordt elke keer opnieuw ge-enabled
            
            _timer.Enabled = true;
            //Indien de tijd 0 is, gaat de held dood
            if (_tijd <= 0)
            {
                _level.Held.IamDead = true;
            }
            //Indien de held een klokje heeft opgeraapt, komen er 10 seconden bij de tijd bij.
            if (_level.Held.Plustime)
            {
                _tijd += 10;
            }
            _level.Held.Plustime = false;
        }
    }
}