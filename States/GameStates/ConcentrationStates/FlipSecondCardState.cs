using CoinFlip.Models.Concentration;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.ConcentrationStates {
    internal class FlipSecondCardState(Concentration concentration) : GameState<Concentration> {
        private readonly Concentration _concentration = concentration;

        public override void Update(GameTime gameTime) {
            Card card = _concentration.GetClickedCard();

            if (card != null && card != _concentration.firstCardChosen) {
                card.Flip();
                _concentration.secondCardChosen = card;
                _concentration.ChangeState(new ResolveTurnState(_concentration));
            }
        }
    }
}
