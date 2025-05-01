using CoinFlip.Models.Concentration;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.ConcentrationStates {
    internal class ResolveTurnState : GameState<Concentration> {
        public override void Update(GameTime gameTime, Concentration concentration) {
            if (concentration.firstCardChosen.Id == concentration.secondCardChosen.Id) {
                // sets solved to true if there's a match
                concentration.firstCardChosen.Solved = concentration.secondCardChosen.Solved = true;
            }

            concentration.ChangeState(new FlipFirstCardState());
        }
    }
}
