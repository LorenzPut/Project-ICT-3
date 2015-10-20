using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;

namespace PlatformGame
{
    public abstract class GameObject
    {
        // Deze klasse is eigenlijk een soort template voor alle objecten die er van over erven.
        // Het bepaalt welke variabelen en/of methodes de overervende klassen moeten/kunnen bevatten.

        protected Surface Image;
        public Rectangle Leftcollisionrectangle;
        public Rectangle Lowercollisionrectangle;

        public Point Position;
        public Rectangle Rightcollisionrectangle;
        protected Rectangle ShowPartImage;
        public Rectangle Uppercollisionrectangle;
        public abstract void Update();

        //Worden gebruikt om de collision rechthoeken op het scherm te kunnen tekenen.
        protected Box Box0;
        protected Box Box1;
        protected Box Box2;
        protected Box Box3;

        //Een bepaald deel van de afbeelding wordt met een positie naar het scherm gestuurd.
        public virtual void Draw(Surface video)
        {
            video.Blit(Image, Position, ShowPartImage);
        }
    }
}