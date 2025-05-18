using CoinFlip.Models.MathGame;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class CheckAnswerState(MathGame mathGame) : GameState<MathGame> {
        private float timer = 0;
        private readonly MathGame _mathGame = mathGame;

        public override void Update(GameTime gameTime) {
            if (_mathGame.MathProblems.Count <= 0) {
                _mathGame.ChangeState(new FinishState(_mathGame));
                return;
            }
            if (_mathGame.CurrentProblem.Answer != _mathGame.ChosenAnswer.Value) {
                // lets user try again if they guess wrong
                //ADD SOME SORT OF PENALTY, MAYBE .5s?
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer >= 0.5f) _mathGame.ChangeState(new AnswerState(_mathGame));
            }

            if (timer == 0) _mathGame.ChangeState(new GetProblemState(_mathGame));
        }
    }
}
