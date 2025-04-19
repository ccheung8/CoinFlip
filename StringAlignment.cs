using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    public static class StringAlignment {
        // returns x coordinate of Vector2 for right aligned text
        public static int Right(SpriteFont font, string text) {
            Vector2 textSize = font.MeasureString(text);
            return (int)(Game1._graphics.GraphicsDevice.Viewport.Width - textSize.X);
        }

        // returns x coordinate of Vector2 for center aligned text
        public static int horzCenter(SpriteFont font, string text) {
            Vector2 textSize = font.MeasureString(text);
            return (int)((Game1._graphics.GraphicsDevice.Viewport.Width / 2) - (textSize.X / 2));
        }

        // returns y coordinate of Vector2 for center aligned text
        public static int vertCenter(SpriteFont font, string text) {
            Vector2 textSize = font.MeasureString(text);
            return (int)((Game1._graphics.GraphicsDevice.Viewport.Height / 2) - (textSize.Y / 2));
        }

        // returns y coordinate of Vector2 for bottom aligned text
        public static int Bottom(SpriteFont font, string text) {
            Vector2 textSize = font.MeasureString(text);
            return (int)(Game1._graphics.GraphicsDevice.Viewport.Height - textSize.Y);
        }
    }
}
