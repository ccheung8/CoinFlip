using CoinFlip.Models.MathGame;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class FinishState : GameState<MathGame> {
        public override void Update(GameTime gameTime, MathGame mathGame) {
            mathGame.P1Result = "";
            mathGame.P2Result = "";
            mathGame.Result = "Finish!";
        }
    }
}
