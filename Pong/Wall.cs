using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Wall
    {
        private Texture2D Texture;
        public Vector2 Position;

        public Wall(Vector2 wallPostion)
        {
            this.Position = wallPostion;
        }

        public void setTexture(Texture2D wallTexture)
        {
            this.Texture = wallTexture;
        }

        public Texture2D getTexture()
        {
            return this.Texture;
        }

        public int getTextureWidth()
        {
            return this.Texture.Width;
        }

        public int getTextureHeight()
        {
            return this.Texture.Height;
        }

        public Vector2 getScale()
        {
            Vector2 Scale = new Vector2();

            if (this.Texture != null)
            {
                Scale = new Vector2(getTextureWidth() / 2, getTextureHeight() / 2);
            }
            return Scale;
        }
    }
}
