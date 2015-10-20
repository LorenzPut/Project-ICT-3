using System;
using System.Drawing;

namespace PlatformGame
{
    internal class Leeg : GameObject
    {
        //Deze code code komt grotendeels overeen met de andere GameObjecten (die niet held of vijand zijn). 
        //Het enige verschil zijn dat er HIER GEEN AFBEELDING WORDT INGELADEN.
        //Deze klasse wordt gebruikt in de held om te bepalen wanneer de held niet meer op een blokje staat en dus naar beneden moet vallen.
        
        public Leeg()
        {
        }

        public Leeg(int x, int y)
        {
            try
            {
                Position = new Point(x, y);
                Rect = new Rectangle(x, y, 50, 50);
            }
            catch (Exception error)
            {
                Console.WriteLine("Er is een fout opgetreden : " + error.Message);
            }
        }

        public Rectangle Rect { get; private set; }

        public override void Update()
        {
        }
    }
}