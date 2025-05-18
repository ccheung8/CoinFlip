using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.DiceRollStates;

namespace CoinFlip.Models.DiceRoll {
    internal class DiceRoll : IMiniGames {
        public string Message { get; }
        public string P1Result {  get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        private GameState<DiceRoll> _gameState;

        public DiceRoll(ContentManager content) {
            Message = "Press Space to Roll the Die";
            _gameState = new RollState(this);
        }

        public void ChangeState(GameState<DiceRoll> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime);
        }

        public void Draw(GameTime gameTime) {
            
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;
            _gameState = new RollState(this);
        }
    }
}
