using Microsoft.Xna.Framework.Input;

namespace CoinFlip.Statics {
    internal static class InputManager {
        private static MouseState _prevMouseState;
        private static KeyboardState _prevKeyboardState;

        public static bool OnMouseClick { get; private set; }
        public static bool OnMouseRelease { get; private set; }
        public static int MouseX { get; private set; }
        public static int MouseY { get; private set; }

        public static bool OnKeyRight {  get; private set; }
        public static bool OnKeySpace { get; private set; }
        public static bool OnKeyOne { get; private set; }
        public static bool OnKeyTwo { get; private set; }
        public static bool OnKeyThree { get; private set; }

        public static void Update() {
            /*----------- MOUSE UPDATES -----------*/
            OnMouseClick = (Mouse.GetState().LeftButton == ButtonState.Pressed &&
                _prevMouseState.LeftButton == ButtonState.Released);

            OnMouseRelease = (Mouse.GetState().LeftButton == ButtonState.Released &&
                _prevMouseState.LeftButton == ButtonState.Pressed);

            MouseX = Mouse.GetState().X;
            MouseY = Mouse.GetState().Y;

            /*----------- KEYBOARD UPDATES -----------*/
            OnKeyRight = Keyboard.GetState().IsKeyDown(Keys.Right) && _prevKeyboardState.IsKeyUp(Keys.Right);

            OnKeySpace = Keyboard.GetState().IsKeyDown(Keys.Space) && _prevKeyboardState.IsKeyUp(Keys.Space);

            OnKeyOne = Keyboard.GetState().IsKeyDown(Keys.D1) && _prevKeyboardState.IsKeyUp(Keys.D1);

            OnKeyTwo = Keyboard.GetState().IsKeyDown(Keys.D2) && _prevKeyboardState.IsKeyUp(Keys.D2);

            OnKeyThree = Keyboard.GetState().IsKeyDown(Keys.D3) && _prevKeyboardState.IsKeyUp(Keys.D3);

            _prevKeyboardState = Keyboard.GetState();
            _prevMouseState = Mouse.GetState();
        }
    }
}
