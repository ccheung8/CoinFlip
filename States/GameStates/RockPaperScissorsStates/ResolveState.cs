using Microsoft.Xna.Framework;
using CoinFlip.Models.RockPaperScissors;

namespace CoinFlip.States.GameStates.RockPaperScissorsStates {
    internal class ResolveState : GameState<RockPaperScissors> {
        public override void Update(GameTime gameTime, RockPaperScissors rockPaperScissors) {
            rockPaperScissors.P2Result = rockPaperScissors.Choices[Game1._random.Next(3)];

            // game RPS logic
            if (rockPaperScissors.P1Result == rockPaperScissors.P2Result) {
                rockPaperScissors.Result = "It's a Tie!";
            }
            else if (rockPaperScissors.P1Result == "Rock" && rockPaperScissors.P2Result == "Paper" ||
                rockPaperScissors.P1Result == "Paper" && rockPaperScissors.P2Result == "Scissors" ||
                rockPaperScissors.P1Result == "Scissors" && rockPaperScissors.P2Result == "Rock") {
                rockPaperScissors.Result = "Player 2 Wins!";
            }
            else {
                rockPaperScissors.Result = "Player 1 Wins!";
            }
        }
    }
}
