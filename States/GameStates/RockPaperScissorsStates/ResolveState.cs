using Microsoft.Xna.Framework;
using CoinFlip.Models.RockPaperScissors;

namespace CoinFlip.States.GameStates.RockPaperScissorsStates {
    internal class ResolveState(RockPaperScissors rockPaperScissors) : GameState<RockPaperScissors> {
        private readonly RockPaperScissors _rockPaperScissors = rockPaperScissors;

        public override void Update(GameTime gameTime) {
            _rockPaperScissors.P2Result = _rockPaperScissors.Choices[Game1._random.Next(3)];

            // game RPS logic
            if (_rockPaperScissors.P1Result == _rockPaperScissors.P2Result) {
                _rockPaperScissors.Result = "It's a Tie!";
            }
            else if (_rockPaperScissors.P1Result == "Rock" && _rockPaperScissors.P2Result == "Paper" ||
                _rockPaperScissors.P1Result == "Paper" && _rockPaperScissors.P2Result == "Scissors" ||
                _rockPaperScissors.P1Result == "Scissors" && _rockPaperScissors.P2Result == "Rock") {
                _rockPaperScissors.Result = "Player 2 Wins!";
            }
            else {
                _rockPaperScissors.Result = "Player 1 Wins!";
            }
        }
    }
}
