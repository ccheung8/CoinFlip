using System.Diagnostics;
using System.Text;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip.Models.TypingTest {
    internal class TypingPrompt {
        public string Prompt { get; }
        public StringBuilder TypedText { get; set; }
        public string TypedString { get; private set; }

        private Vector2 drawLocation;
        private readonly float maxSize = Game1._font.MeasureString("W").X * 70;

        public TypingPrompt(string prompt) {
            Game1._gameWindow.TextInput += TextInput;

            // calls wrap text on prompt with a maxwidth of 70 characters or half of screen size (uses "W" as reference for char size)
            maxSize = maxSize > Game1._graphics.GraphicsDevice.Viewport.Width / 2 ? 500 : maxSize;
            Prompt = WrapText(Game1._font, prompt, maxSize > Game1._graphics.GraphicsDevice.Viewport.Width ? 500 : maxSize);
            TypedText = new StringBuilder();
            TypedString = "";

            drawLocation = new Vector2(StringAlignment.HorzCenter(Prompt), StringAlignment.VertCenter(Prompt));
        }

        public void Draw(GameTime gameTime) {
            // draws string in center of screen
            Game1._spriteBatch.DrawString(Game1._font, Prompt, drawLocation, Color.Gray);

            // draws typed prompt
            Game1._spriteBatch.DrawString(Game1._font, TypedString, drawLocation, Color.Black);
        }

        // helper function for wrapping text
        public string WrapText(SpriteFont font, string text, float maxLineWidth) {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = font.MeasureString(" ").X;

            foreach (string word in words) {
                Vector2 size = font.MeasureString(word);

                if (lineWidth + size.X < maxLineWidth) {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else {
                    Debug.WriteLine("new line");
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            return sb.ToString();
        }

        private void TextInput(object sender, TextInputEventArgs e) {
            // handles backspace
            if (e.Key == Keys.Back) {
                if (TypedText.Length > 0) {
                    TypedText.Remove(TypedText.Length - 1, 1);
                }
            }
            else {
                TypedText.Append(e.Character);
            }

            TypedString = WrapText(Game1._font, TypedText.ToString(), maxSize);
        }
    }
}
