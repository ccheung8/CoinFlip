using CoinFlip.Models.Concentration;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.ConcentrationStates {
    internal class FlipFirstCardState : GameState<Concentration> {
        public override void Update(GameTime gameTime, Concentration concentration) {
            Card card = concentration.GetClickedCard();

            if (card != null) {
                if (concentration.firstCardChosen != null && concentration.secondCardChosen != null
                        && !concentration.firstCardChosen.Solved && !concentration.firstCardChosen.Solved) {
                    concentration.firstCardChosen.Flip();
                    concentration.secondCardChosen.Flip();
                }
                card.Flip();
                concentration.firstCardChosen = card;
                concentration.ChangeState(new FlipSecondCardState());
            }
        }
    }
}
