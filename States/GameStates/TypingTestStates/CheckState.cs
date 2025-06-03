using Microsoft.Xna.Framework;
using CoinFlip.Models.TypingTest;
using System.Text;

namespace CoinFlip.States.GameStates.TypingTestStates {
    internal class CheckState : GameState<TypingTest> {
        private readonly TypingTest _typingTest;

        public CheckState(TypingTest typingTest) {
            _typingTest = typingTest;
        }

        public override void Update(GameTime gameTime) {
            // finishes if no words left and last word is correct
            if (_typingTest.Words.Count <= 0 && _typingTest.TypedWord.ToString() == _typingTest.Word) {
                _typingTest.ChangeState(new FinishState(_typingTest));
                return;
            }

            // helper function to handle checking word
            _typingTest.CheckWord();

            // if word is too long then incorrect
            if (_typingTest.TypedWord.Length > _typingTest.Word.Length) {
                _typingTest.WordColor = Color.Red;
                _typingTest.ChangeState(new TypingState(_typingTest));
                return;
            }

            // if typedword is not equal to a substring of the word then set to red
            _typingTest.WordColor = 
                _typingTest.TypedWord.Equals(_typingTest.Word.Substring(0, _typingTest.TypedWord.Length))
                    ? Color.Black : Color.Red;

            _typingTest.ChangeState(new TypingState(_typingTest));
        }
    }
}
