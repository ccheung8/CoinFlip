using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip.Statics {
    internal static class MinigameInputManager {
        private static MouseState _prevMouseState;
        private static KeyboardState _prevKeyboardState;

        public static bool AllowInput { get; set; } = true;

        public static bool OnMouseClick { get; private set; }
        public static bool OnMouseRelease { get; private set; }
        public static int MouseX { get; private set; }
        public static int MouseY { get; private set; }

        public static void Update() {
            /*----------- MOUSE UPDATES -----------*/
            OnMouseClick = AllowInput && Mouse.GetState().LeftButton == ButtonState.Pressed &&
                _prevMouseState.LeftButton == ButtonState.Released;

            OnMouseRelease = AllowInput && Mouse.GetState().LeftButton == ButtonState.Released &&
                _prevMouseState.LeftButton == ButtonState.Pressed;

            MouseX = Mouse.GetState().X;
            MouseY = Mouse.GetState().Y;

            _prevKeyboardState = Keyboard.GetState();
            _prevMouseState = Mouse.GetState();
        }
        
        // want to implement this later for a more elegant input checker
        public static bool OnKeyPress(Keys key) {
            return Keyboard.GetState().IsKeyDown(key) && _prevKeyboardState.IsKeyUp(key);
        }
    }
}
