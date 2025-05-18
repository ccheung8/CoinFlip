using CoinFlip.Models.MathGame;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class FinishState(MathGame mathGame) : GameState<MathGame> {
        private readonly MathGame _mathGame = mathGame;

        public override void Update(GameTime gameTime) {
            _mathGame.CurrentProblem = null;

            _mathGame.P1Result = "";
            _mathGame.P2Result = "";
            _mathGame.Result = "Finish!";
        }
    }
}
