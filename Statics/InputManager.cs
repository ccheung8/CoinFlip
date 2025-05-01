using Microsoft.Xna.Framework.Input;

namespace CoinFlip.Statics {
    internal static class InputManager {
        private static MouseState _prevMouseState;
        private static KeyboardState _prevKeyboardState;

        public static bool OnMouseClick { get; private set; }
        public static bool OnMouseRelease { get; private set; }

        public static void Update() {
            OnMouseClick = (Mouse.GetState().LeftButton == ButtonState.Pressed &&
                _prevMouseState.LeftButton == ButtonState.Released);

            OnMouseRelease = (Mouse.GetState().LeftButton == ButtonState.Released &&
                _prevMouseState.LeftButton == ButtonState.Pressed);

            _prevKeyboardState = Keyboard.GetState();
            _prevMouseState = Mouse.GetState();
        }

        // fires once when the key is pressed
        public static bool OnKeyPress(Keys key) {
            if (Keyboard.GetState().IsKeyDown(key) && _prevKeyboardState.IsKeyDown(key)) {
                return true;
            }

            return false;
        }
    }
}
