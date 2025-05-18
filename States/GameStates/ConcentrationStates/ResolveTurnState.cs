using CoinFlip.Models.Concentration;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.ConcentrationStates {
    internal class ResolveTurnState(Concentration concentration) : GameState<Concentration> {
        private readonly Concentration _concentration = concentration;

        public override void Update(GameTime gameTime) {
            if (_concentration.firstCardChosen.Id == _concentration.secondCardChosen.Id) {
                // sets solved to true if there's a match
                _concentration.firstCardChosen.Solved = _concentration.secondCardChosen.Solved = true;
            }

            _concentration.ChangeState(new FlipFirstCardState(_concentration));
        }
    }
}
