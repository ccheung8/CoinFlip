using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using CoinFlip.Models.TypingTest;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace CoinFlip.States.GameStates.TypingTestStates {
    internal class TypingState : GameState<TypingTest> {
        private readonly TypingTest _typingTest;

        public TypingState(TypingTest typingTest) {
            _typingTest = typingTest;

            Game1._gameWindow.TextInput += TextInput;
        }

        public override void Update(GameTime gameTime) {
            // do nothing since textinput handles everything
        }

        public void TextInput(object sender, TextInputEventArgs e) {
            // ignores all control characters except backspace
            if (char.IsControl(e.Character)) {
                if (e.Key != Keys.Back) {
                    return;
                }
            }

            // handles backspace
            if (e.Key == Keys.Back) {
                if (_typingTest.TypedWord.Length > 0) {
                    _typingTest.TypedWord.Remove(_typingTest.TypedWord.Length - 1, 1);
                    _typingTest.TypedLine.Remove(_typingTest.TypedLine.Length - 1, 1);
                }
            }
            else {
                _typingTest.TypedWord.Append(e.Character);
                _typingTest.TypedLine.Append(e.Character);
            }

            // switches to checkstate and unsubs textinput event
            Game1._gameWindow.TextInput -= TextInput;
            _typingTest.ChangeState(new CheckState(_typingTest));
        }
    }
}
