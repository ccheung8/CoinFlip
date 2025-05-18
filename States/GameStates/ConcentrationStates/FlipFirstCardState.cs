using CoinFlip.Models.Concentration;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.ConcentrationStates {
    internal class FlipFirstCardState(Concentration concentration) : GameState<Concentration> {
        private readonly Concentration _concentration = concentration;

        public override void Update(GameTime gameTime) {
            Card card = _concentration.GetClickedCard();

            if (card != null) {
                if (_concentration.firstCardChosen != null && _concentration.secondCardChosen != null
                        && !_concentration.firstCardChosen.Solved && !_concentration.firstCardChosen.Solved) {
                    _concentration.firstCardChosen.Flip();
                    _concentration.secondCardChosen.Flip();
                }
                card.Flip();
                _concentration.firstCardChosen = card;
                _concentration.ChangeState(new FlipSecondCardState(_concentration));
            }
        }
    }
}
