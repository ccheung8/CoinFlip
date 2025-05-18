using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.RockPaperScissorsStates;

namespace CoinFlip.Models.RockPaperScissors {
    internal class RockPaperScissors : IMiniGames {
        public string Message { get; }
        public string P1Result { get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public readonly string[] Choices;

        private GameState<RockPaperScissors> _gameState;

        public RockPaperScissors(ContentManager content) {
            Message = "1: Rock, 2: Paper, 3: Scissors";
            Choices = ["Rock", "Paper", "Scissors"];
            _gameState = new CountDownState(this);
        }

        public void ChangeState(GameState<RockPaperScissors> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime);
        }

        public void Draw(GameTime gameTime) {
            _gameState.Draw(gameTime);
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;
            _gameState = new CountDownState(this);
        }
    }
}
