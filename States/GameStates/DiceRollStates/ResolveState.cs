using System;
using CoinFlip.Models.DiceRoll;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.DiceRollStates {
    internal class ResolveState(DiceRoll diceRoll) : GameState<DiceRoll> {
        private readonly DiceRoll _diceRoll = diceRoll;

        public override void Update(GameTime gameTime) {
            if (_diceRoll.P1Result == _diceRoll.P2Result) {
                _diceRoll.Result = "It's a Tie!";
            }
            else if (Convert.ToInt32(_diceRoll.P1Result) >= Convert.ToInt32(_diceRoll.P2Result)) {
                _diceRoll.Result = "Player 1 Wins!";
            }
            else {
                _diceRoll.Result = "Player 2 Wins!";
            }
        }
    }
}
