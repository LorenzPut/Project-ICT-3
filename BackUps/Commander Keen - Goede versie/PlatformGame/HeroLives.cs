using System;
using System.Drawing;
using SdlDotNet.Graphics;

namespace PlatformGame
{
    internal class HeroLives
    {

        private Rectangle ShowPartImage;
        private readonly Surface Image;
        private readonly Point Position;

        public HeroLives()
        {
            try
            {
                Image = new Surface("NumberOfLives.png");
                Position = new Point(0, 0);
                ShowPartImage = new Rectangle(0, 0, 171, 50);
            }
            catch (Exception error)
            {
                Console.WriteLine("Er is een fout opgetreden : " + error.Message);
            }
        }
        //Bepaalt hoe groot de rechthoek ShowPartImage is aan de hand van het aantal levens dat de held heeft.
        //De ShowPartImage rechthoek bepaalt dan weer hoeveel hartjes er op het scherm getekend zullen worden.
        public void Draw(Surface video, Hero held)
        {
            if (held.NumberOflives == 0)
            {
                ShowPartImage.Width = 0;
            }
            if (held.NumberOflives == 1)
            {
                ShowPartImage.Width = 57;
            }
            if (held.NumberOflives == 2)
            {
                ShowPartImage.Width = 114;
            }
            if (held.NumberOflives == 3)
            {
                ShowPartImage.Width = 171;
            }

            video.Blit(Image, Position, ShowPartImage);
        }
    }
}