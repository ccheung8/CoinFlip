using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.TypingTestStates;
using System.Text;

namespace CoinFlip.Models.TypingTest {
    internal class TypingTest : IMiniGames {
        public string Message { get; }
        public string P1Result { get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public string Prompt { get; private set; }  // stores whole prompt
        public Queue<string> Words { get; set; }    // stores words in prompt
        public string Word { get; set; } = "";      // helper variable for current word

        public string TypedString { get; set; } = "";   // whole string user has typed
        public StringBuilder TypedWord { get; set; } = new StringBuilder(); // word user has typed
        public StringBuilder TypedLine { get; set; } = new StringBuilder(); // line user has typed

        public Color WordColor { get; set; } = Color.Black; // black = correct, red = incorrect
        public Vector2 DrawLocation { get; }    // base location to draw for prompt
        public Vector2 WordDrawLocation { get; set; }   // location to draw each word in accordance to typedline

        public float DrawWidth { get; } = Game1._font.MeasureString("W").X * 70;

        private GameState<TypingTest> _gameState;
        private readonly string[] _prompts; // stores possible prompts
        private int _line = 0;  // helper variable to keep track of lines

        public TypingTest(ContentManager content) {
            Message = "Typing Test";

            _prompts = ["The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog."];

            // calls wrap text on prompt with a maxwidth of 70 characters or half of screen size (uses "W" as reference for char size)
            DrawWidth = DrawWidth > Game1._graphics.GraphicsDevice.Viewport.Width / 2 ? 500 : DrawWidth;
            Prompt = StringAlignment.WrapText(Game1._font, _prompts[0], DrawWidth);
            Words = new Queue<string>(Prompt.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Word = Words.Dequeue();

            DrawLocation = WordDrawLocation = new Vector2(StringAlignment.HorzCenter(Prompt), StringAlignment.VertCenter(Prompt));

            _gameState = new TypingState(this);
        }

        public void ChangeState(GameState<TypingTest> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime);
        }

        public void Draw(GameTime gameTime) {
            // draws string in center of screen
            Game1._spriteBatch.DrawString(Game1._font, Prompt, DrawLocation, Color.Black * 0.4f);

            // draws typed prompt
            Game1._spriteBatch.DrawString(Game1._font, TypedString.ToString(), DrawLocation, Color.Black);

            // draws typed word
            Game1._spriteBatch.DrawString(Game1._font, TypedWord, WordDrawLocation, WordColor);
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;

            _gameState = new TypingState(this);
            Prompt = StringAlignment.WrapText(Game1._font, _prompts[0], DrawWidth);
            Words = new Queue<string>(Prompt.Split(" "));
            Word = Words.Dequeue();
        }

        public void CheckWord() {
            // returns if word is incorrect
            if (TypedWord.ToString() != Word + " ") {
                return;
            }

            // gets new word
            Word = Words.Dequeue();

            // appends word to typedstring
            TypedString += TypedWord.ToString();

            // updates y draw location and resets typed line for \n char
            if (Word[0] == '\n') {
                Word = Word.Replace("\n", "");  // removes newline char
                TypedString += '\n';            // adds newline char to string
                TypedLine = new StringBuilder();
                _line++;
            }

            float xDrawLocation = DrawLocation.X + Game1._font.MeasureString(TypedLine).X;
            // calculates draw location of Y using first character in prompt for line height reference
            float yDrawLocation = DrawLocation.Y + Game1._font.MeasureString(Prompt[0].ToString()).Y * _line;

            TypedWord = new StringBuilder();
            // updates draw location
            WordDrawLocation = new Vector2(xDrawLocation, yDrawLocation);
        }
    }
}
