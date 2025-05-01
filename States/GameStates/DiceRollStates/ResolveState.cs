using System;
using CoinFlip.Models.DiceRoll;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.DiceRollStates {
    internal class ResolveState : GameState<DiceRoll> {
        public override void Update(GameTime gameTime, DiceRoll diceRoll) {
            if (diceRoll.P1Result == diceRoll.P2Result) {
                diceRoll.Result = "It's a Tie!";
            }
            else if (Convert.ToInt32(diceRoll.P1Result) >= Convert.ToInt32(diceRoll.P2Result)) {
                diceRoll.Result = "Player 1 Wins!";
            }
            else {
                diceRoll.Result = "Player 2 Wins!";
            }
        }
    }
}
