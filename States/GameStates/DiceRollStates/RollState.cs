using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CoinFlip.Statics;
using CoinFlip.Models.DiceRoll;

namespace CoinFlip.States.GameStates.DiceRollStates {
    internal class RollState(DiceRoll diceRoll) : GameState<DiceRoll> {
        private readonly DiceRoll _diceRoll = diceRoll;

        public override void Update(GameTime gameTime) {
            // rolls dice when spacebar is clicked
            if (MinigameInputManager.OnKeyPress(Keys.Space)) {
                _diceRoll.P1Result = Convert.ToString(Game1._random.Next(6) + 1);

                _diceRoll.P2Result = Convert.ToString(Game1._random.Next(6) + 1);

                _diceRoll.ChangeState(new ResolveState(_diceRoll));
            }

        }
    }
}
