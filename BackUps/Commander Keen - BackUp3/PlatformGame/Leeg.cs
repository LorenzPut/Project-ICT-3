using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    class Leeg : GameObject
    {
        public Leeg()
        {

        }
        public Leeg(int x, int y)
        {
            Position = new Point(x, y);
            rect = new Rectangle(x, y, 50, 50);
        }
        private Rectangle rect;
        public Rectangle Rect
        {
            get { return rect; }
        }
        public override void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
