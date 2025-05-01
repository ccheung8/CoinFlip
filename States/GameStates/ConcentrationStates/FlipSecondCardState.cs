using CoinFlip.Models.Concentration;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.ConcentrationStates {
    internal class FlipSecondCardState : GameState<Concentration> {
        public override void Update(GameTime gameTime, Concentration concentration) {
            Card card = concentration.GetClickedCard();

            if (card != null && card != concentration.firstCardChosen) {
                card.Flip();
                concentration.secondCardChosen = card;
                concentration.ChangeState(new ResolveTurnState());
            }
        }
    }
}
