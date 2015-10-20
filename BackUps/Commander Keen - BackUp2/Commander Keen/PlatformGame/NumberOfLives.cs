using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    class NumberOfLives 
    {
        Surface Image;
        Point Position;
        Rectangle ShowPartImage;
        public NumberOfLives()
        {
            Image = new Surface("NumberOfLives.png");
            Position = new Point(0,0);
            ShowPartImage = new Rectangle(0, 0, 171, 50);
        }
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

            video.Blit(Image,Position,ShowPartImage);
        }
    }
}
