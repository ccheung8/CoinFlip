using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CoinFlip.Statics;
using CoinFlip.Models.RockPaperScissors;

namespace CoinFlip.States.GameStates.RockPaperScissorsStates {
    internal class CountDownState : GameState<RockPaperScissors> {
        private float currentTime = 0f;
        private string option;
        private string centerText;

        public override void Update(GameTime gameTime, RockPaperScissors rockPaperScissors) {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            centerText = "Rock";
            if (currentTime >= 1f) {
                centerText = "Paper";
            }
            if (currentTime >= 2f) {
                centerText = "Scissors";
            }

            // process inputs
            // 1: Rock, 2: Paper, 3: Scissors
            if (InputManager.OnKeyOne) {
                option = rockPaperScissors.Choices[0];
            }
            else if (InputManager.OnKeyTwo) {
                option = rockPaperScissors.Choices[1];
            }
            else if (InputManager.OnKeyThree) {
                option = rockPaperScissors.Choices[2];
            }

            if (currentTime >= 3f) {
                rockPaperScissors.P1Result = option;
                rockPaperScissors.ChangeState(new ResolveState());
            };
        }

        public override void Draw(GameTime gameTime) {
            // Draws Rock, then Paper, then Scissors followed by result with 1 second intervals
            // can maybe do rock paper scissors shoot followed by fun animation
            Game1._spriteBatch.DrawString(Game1._font, centerText,
                new Vector2(StringAlignment.HorzCenter(centerText), StringAlignment.VertCenter(centerText)), Color.Black);
        }
    }
}
