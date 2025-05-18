using CoinFlip.Models.MathGame;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class AnswerState : GameState<MathGame> {
        private readonly MathGame _mathGame;

        public AnswerState(MathGame mathGame) {
            MinigameInputManager.AllowInput = true;
            _mathGame = mathGame;
        }

        public override void Update(GameTime gameTime) {
            MathChoice choice = _mathGame.GetClickedChoice();

            if (choice != null) {
                _mathGame.ChosenAnswer = choice;
                choice.HasBeenChosen = true;
                _mathGame.ChangeState(new CheckAnswerState(_mathGame));
            }
        }
    }
}
