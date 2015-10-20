using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame
{
    public abstract class GameObject
    {

        public Point Position;
        protected Surface Image;
        protected Rectangle ShowPartImage;
        public Rectangle Collisionrectangle;
        public Rectangle Rightcollisionrectangle;
        public Rectangle Leftcollisionrectangle;
        public Rectangle Uppercollisionrectangle;
        public Rectangle Lowercollisionrectangle;


        public abstract void Update();
    

        
        public virtual void Draw(Surface video)
        {
            video.Blit(Image, Position, ShowPartImage);
        }
    }
}
