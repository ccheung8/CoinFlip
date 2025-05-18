using CoinFlip.Models.MathGame;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class GetProblemState(MathGame mathGame) : GameState<MathGame> {
        private readonly MathGame _mathGame = mathGame;

        public override void Update(GameTime gameTime) {
            _mathGame.CurrentProblem = _mathGame.MathProblems.Dequeue();
            _mathGame.ChangeState(new AnswerState(_mathGame));
        }
    }
}
