using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CoinFlip.Statics;
using CoinFlip.Models.RockPaperScissors;

namespace CoinFlip.States.GameStates.RockPaperScissorsStates {
    internal class CountDownState(RockPaperScissors rockPaperScissors) : GameState<RockPaperScissors> {
        private float currentTime = 0f;
        private string option = "Rock"; // defaults to rock
        private string centerText;
        private readonly RockPaperScissors _rockPaperScissors = rockPaperScissors;

        public override void Update(GameTime gameTime) {
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
            if (MinigameInputManager.OnKeyPress(Keys.D1)) {
                option = _rockPaperScissors.Choices[0];
            }
            else if (MinigameInputManager.OnKeyPress(Keys.D2)) {
                option = _rockPaperScissors.Choices[1];
            }
            else if (MinigameInputManager.OnKeyPress(Keys.D3)) {
                option = _rockPaperScissors.Choices[2];
            }

            if (currentTime >= 3f) {
                _rockPaperScissors.P1Result = option;
                _rockPaperScissors.ChangeState(new ResolveState(_rockPaperScissors));
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
