using CoinFlip.Models.MathGame;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class AnswerState : GameState<MathGame> {
        public AnswerState() {
            MinigameInputManager.AllowInput = true;
        }

        public override void Update(GameTime gameTime, MathGame mathGame) {
            MathChoice choice = mathGame.GetClickedChoice();

            if (choice != null) {
                mathGame.ChosenAnswer = choice;
                mathGame.ChangeState(new CheckAnswerState());
            }
        }
    }
}
