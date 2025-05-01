using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.Statics {
    public static class StringAlignment {
        // returns x coordinate of Vector2 for right aligned text
        public static int Right(string text) {
            Vector2 textSize = Game1._font.MeasureString(text);
            return (int)(Game1._graphics.GraphicsDevice.Viewport.Width - textSize.X);
        }

        // returns x coordinate of Vector2 for center aligned text
        public static int HorzCenter(string text) {
            Vector2 textSize = Game1._font.MeasureString(text);
            return (int)(Game1._graphics.GraphicsDevice.Viewport.Width / 2 - textSize.X / 2);
        }

        // returns y coordinate of Vector2 for center aligned text
        public static int VertCenter(string text) {
            Vector2 textSize = Game1._font.MeasureString(text);
            return (int)(Game1._graphics.GraphicsDevice.Viewport.Height / 2 - textSize.Y / 2);
        }

        // returns y coordinate of Vector2 for bottom aligned text
        public static int Bottom(string text) {
            Vector2 textSize = Game1._font.MeasureString(text);
            return (int)(Game1._graphics.GraphicsDevice.Viewport.Height - textSize.Y);
        }
    }
}
