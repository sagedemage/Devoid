using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Devoid
{
    public class Player
    {
        private Texture2D Texture;
        public Vector2 Position;
        private float Speed;

        public Player(Vector2 playerPosition, float playerSpeed)
        {
            Position = playerPosition;
            Speed = playerSpeed;
        }

        public void setTexture(Texture2D playerTexture)
        {
            Texture = playerTexture;
        }

        public Texture2D getTexture()
        {
            return Texture;
        }

        public float getSpeed()
        {
            return Speed;
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
                Scale = new Vector2(getTextureWidth() / 2, getTextureHeight() / 2);
            }
            return Scale;
        }

    }
}
