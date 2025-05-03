using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.RockPaperScissorsStates;

namespace CoinFlip.Models.RockPaperScissors {
    internal class RockPaperScissors : IMiniGames {
        public string P1Result { get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public readonly string[] Choices;

        public GameState<RockPaperScissors> _gameState;

        public RockPaperScissors(ContentManager content) {
            Choices = ["Rock", "Paper", "Scissors"];
            _gameState = new CountDownState();
        }

        public void ChangeState(GameState<RockPaperScissors> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime, this);
        }

        public void Draw(GameTime gameTime) {
            string message = "1: Rock, 2: Paper, 3: Scissors";
            int center = StringAlignment.HorzCenter(message);
            int bottom = StringAlignment.Bottom(message);

            Game1._spriteBatch.DrawString(Game1._font, message, new Vector2(center, bottom - 8), Color.Black);

            _gameState.Draw(gameTime);
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;
            _gameState = new CountDownState();
        }
    }
}
