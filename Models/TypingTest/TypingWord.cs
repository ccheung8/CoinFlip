using Microsoft.Xna.Framework;

namespace CoinFlip.Models.TypingTest {
    internal class TypingWord(string[] wordStyle) {
        public string Word { get; set; } = wordStyle.Length > 1 ? wordStyle[1] : wordStyle[0];
        public bool IsCorrect { get; set; }
        public Color DrawColor { get; set; } = Color.Black;

        private Vector2 position;

        public void Draw(GameTime gameTime) {
            // FIND A WAY TO DRAW WORD IN BLACK IF NORMAL, RED IF CHAR IS INCORRECT, AND GREEN IF WORD ISCORRECT
            // CAN MAYBE ADD STYLES BY MAKING WORD A STRING ARRAY

            // I'M THINKING WE APPEND TO TYPEDWORD WHENEVER TEXTINPUT FIRES BUT KEEP DISPLAYING TYPEDSTRING
            // WE THEN CHECK ISCORRECT WHEN SPACEBAR IS CLICKED

            // OR
            // WE CAN MAYBE DISPLAY TYPEDWORD AND ONLY ALLOW USER TO INSERT SPACE IF ISCORRECT
            // THIS IS A MORE INTERESTING IDEA TO MY HIGH SELF
            // would need to sort out draw location which makes this idea less feasible
        }
    }
}
