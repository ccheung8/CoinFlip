using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.TypingTestStates;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace CoinFlip.Models.TypingTest {
    internal class TypingTest : IMiniGames {
        public string Message { get; }
        public string P1Result { get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public TypingPrompt Prompt { get; private set; }

        private GameState<TypingTest> _gameState;
        private readonly string[] _prompts;

        public TypingTest(ContentManager content) {
            Message = "Typing Test";

            _gameState = new TypingState();
            _prompts = ["The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog."];

            Prompt = new TypingPrompt(_prompts[0]);
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime, this);
        }

        public void Draw(GameTime gameTime) {
            Prompt.Draw(gameTime);
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;

            Prompt = new TypingPrompt(_prompts[0]);
        }
    }
}
