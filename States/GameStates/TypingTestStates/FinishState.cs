using CoinFlip.Models.TypingTest;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.TypingTestStates {
    internal class FinishState(TypingTest typingTest) : GameState<TypingTest> {
        private readonly TypingTest _typingTest = typingTest;

        public override void Update(GameTime gameTime) {
            _typingTest.P1Result = "";
            _typingTest.P2Result = "";
            _typingTest.Result = "Finish";
        }
    }
}
