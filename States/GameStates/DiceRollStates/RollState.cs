using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CoinFlip.Statics;
using CoinFlip.Models.DiceRoll;

namespace CoinFlip.States.GameStates.DiceRollStates {
    internal class RollState : GameState<DiceRoll> {
        public override void Update(GameTime gameTime, DiceRoll diceRoll) {
            // rolls dice when spacebar is clicked
            if (MinigameInputManager.OnKeyPress(Keys.Space)) {
                diceRoll.P1Result = Convert.ToString(Game1._random.Next(6) + 1);

                diceRoll.P2Result = Convert.ToString(Game1._random.Next(6) + 1);

                diceRoll.ChangeState(new ResolveState());
            }

        }
    }
}
