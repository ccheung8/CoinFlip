using CoinFlip.Models.TypingTest;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip.States.GameStates.TypingTestStates {
    internal class TypingState : GameState<TypingTest> {
        private readonly TypingTest _typingTest;

        public TypingState(TypingTest typingTest) {
            _typingTest = typingTest;
            Game1._gameWindow.TextInput += TextInput;
        }

        public override void Update(GameTime gameTime) {
            _typingTest.Prompt.TypedString = "This is typed from typingstate";
        }

        // SHOULD MOVE TO TYPING STATE AND UNSUBSCRIBE TO LISTENER WHEN NECESSARY
        public void TextInput(object sender, TextInputEventArgs e) {
            TypingPrompt typingPrompt = _typingTest.Prompt;

            // ignores escape key
            if (e.Key == Keys.Escape) {
                return;
            }

            // handles backspace
            if (e.Key == Keys.Back) {
                if (typingPrompt.TypedText.Length > 0) {
                    typingPrompt.TypedText.Remove(typingPrompt.TypedText.Length - 1, 1);
                }
            }
            else {
                typingPrompt.TypedText.Append(e.Character);
            }

            typingPrompt.TypedString = typingPrompt.WrapText(Game1._font, typingPrompt.TypedText.ToString(), typingPrompt.MaxSize);
        }
    }
}
