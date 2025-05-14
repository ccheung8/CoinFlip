using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.Models.MathGame {
    internal class MathChoice {
        private const int CHOICE_MARGIN = 16;

        public int Value { get; set; }
        public int Index { get; set; }
        public Rectangle SourceRectangle => new Rectangle(position, choiceSize);

        private readonly Texture2D texture;
        private readonly Point position;
        private readonly Point choiceSize;

        private Vector2 TextSize => Game1._font.MeasureString(Value.ToString());

        public MathChoice(int value, int index) {
            Value = value;
            Index = index;
            texture = new Texture2D(Game1._graphics.GraphicsDevice, 1, 1);
            texture.SetData([Color.CornflowerBlue]);

            Rectangle window = Game1._graphics.GraphicsDevice.PresentationParameters.Bounds;
            // size of each choice hitbox
            choiceSize = new Point((window.Width / 3) - (CHOICE_MARGIN / 2), (int)(window.Height * 0.1f) - (CHOICE_MARGIN / 2));
            // x and y position of hitbox
            position = new Point((window.Width / 6) - (CHOICE_MARGIN / 2) + (Index % 2 == 0 ? 0 : choiceSize.X + CHOICE_MARGIN),
                (int)(window.Height * 0.75f) + (Index <= 1 ? 0 : choiceSize.Y + CHOICE_MARGIN) - 24);
        }

        public void Draw(GameTime gameTime) {
            Game1._spriteBatch.Draw(texture, SourceRectangle, Color.White);

            // draws value as string in middle of rectangle
            Game1._spriteBatch.DrawString(
                Game1._font,
                Value.ToString(),
                new Vector2(
                    SourceRectangle.X + (choiceSize.X / 2) - (TextSize.Y / 2),
                    SourceRectangle.Y + (choiceSize.Y / 2) - (TextSize.Y / 2)
                ),
                Color.Black
            );
        }
    }
}
