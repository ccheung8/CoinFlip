using System;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.DiceRollStates;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.Models.DiceRoll {
    internal class DiceRoll : IMiniGames {
        public string P1Result {  get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        GameState<DiceRoll> _gameState;

        public DiceRoll(ContentManager content) {
            _gameState = new RollState();
        }

        public void ChangeState(GameState<DiceRoll> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime, this);
        }

        public void Draw(GameTime gameTime) {
            string message = "Press Space to Roll the Die";
            int center = StringAlignment.HorzCenter(message);
            int bottom = StringAlignment.Bottom(message);

            Game1._spriteBatch.DrawString(Game1._font, message, new Vector2(center, bottom - 8), Color.Black);
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;
            _gameState = new RollState();
        }
    }
}
