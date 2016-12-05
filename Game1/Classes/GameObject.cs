using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Classes
{
    class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture;

        public void Draw(SpriteBatch spriteBach)
        {
            spriteBach.Draw(Texture, Position, Color.White);
        }

        public virtual void Move(Vector2 amount)
        {
            Position += amount;
        }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
        }

        public static bool CheckPaddleBallCollision(Player player, Ball ball)
        {
            if (player.Bounds.Intersects(ball.Bounds))
                return true;
            return false;
        }
    }
}
