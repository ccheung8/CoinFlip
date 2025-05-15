using CoinFlip.Models.MathGame;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class CheckAnswerState : GameState<MathGame> {
        private float timer = 0;

        public override void Update(GameTime gameTime, MathGame mathGame) {
            if (mathGame.MathProblems.Count <= 0) {
                mathGame.ChangeState(new FinishState());
                return;
            }
            if (mathGame.CurrentProblem.Answer != mathGame.ChosenAnswer.Value) {
                // lets user try again if they guess wrong
                //ADD SOME SORT OF PENALTY, MAYBE .5s?
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer >= 0.5f) mathGame.ChangeState(new AnswerState());
            }

            if (timer == 0) mathGame.ChangeState(new GetProblemState());
        }
    }
}
