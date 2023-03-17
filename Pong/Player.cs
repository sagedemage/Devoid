using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Pong
{
    public class Player
    {
        private Texture2D Texture;
        public Vector2 Position;
        private float Speed;

        public Player(Vector2 playerPosition, float playerSpeed) 
        {
            this.Position = playerPosition;
            this.Speed = playerSpeed;
        }

        public void setTexture(Texture2D playerTexture)
        {
            this.Texture = playerTexture;
        }

        public Texture2D getTexture()
        {
            return this.Texture;
        }

        public float getSpeed()
        {
            return this.Speed;
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
