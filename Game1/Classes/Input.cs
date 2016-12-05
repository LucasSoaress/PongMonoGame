using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Game1.Classes
{
    public static class Input
    {
        public static List<GestureSample> Gestures;

        static Input()
        {
            Gestures = new List<GestureSample>();
        }

        public static Vector2 GetKeyboardInputDirection(PlayerIndex playerIndex)
        {
            Vector2 direction = Vector2.Zero;
            KeyboardState keyboardState = Keyboard.GetState(playerIndex);

            if (playerIndex == PlayerIndex.One)
            {
                if (keyboardState.IsKeyDown(Keys.W))
                    direction.Y += -1;
                if (keyboardState.IsKeyDown(Keys.S))
                    direction.Y += 1;
            }

            if (playerIndex == PlayerIndex.Two)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                    direction.Y += -1;
                if (keyboardState.IsKeyDown(Keys.Down))
                    direction.Y += 1;
            }
            return direction;
        }
    }
}
