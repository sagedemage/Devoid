using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Wall
    {
        public Texture2D Texture;
        public Vector2 Position;

        public Wall(Vector2 wallPostion)
        {
            this.Position = wallPostion;
        }

        public void setTexture(Texture2D wallTexture)
        {
            this.Texture = wallTexture;
        }
    }
}
