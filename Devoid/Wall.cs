using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Devoid
{
    public class Wall
    {
        private Texture2D Texture;
        public Vector2 Position;

        public Wall(Vector2 wallPostion)
        {
            Position = wallPostion;
        }

        public void setTexture(Texture2D wallTexture)
        {
            Texture = wallTexture;
        }

        public Texture2D getTexture()
        {
            return Texture;
        }

        public int getTextureWidth()
        {
            return Texture.Width;
        }

        public int getTextureHeight()
        {
            return Texture.Height;
        }

        public Vector2 getScale()
        {
            Vector2 Scale = new Vector2();

            if (Texture != null)
            {
                Scale = new Vector2(Texture.Width / 2, Texture.Height / 2);
            }
            return Scale;
        }
    }
}
