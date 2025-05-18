using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class RoundTransitionState : GameState<Memory> {
        private readonly Memory _memory;
        private float time;
        private string message;

        public RoundTransitionState(Memory memory) {
            _memory = memory;
            MinigameInputManager.AllowInput = false;
            message = "";
        }

        public override void Update(GameTime gameTime) {
            message = $"Round {_memory.Round}";
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // resets queue for playback and changes state
            if (time > Memory.LIGHT_DURATION) {
                Memory.GameOrderQueue = new(Memory.GameOrder);
                _memory.ChangeState(new PlaybackState(_memory)); 
            }
        }

        public override void Draw(GameTime gameTime) {
            Game1._spriteBatch.DrawString(Game1._font, message,
                new Vector2(StringAlignment.HorzCenter(message), StringAlignment.VertCenter(message)), Color.Black);
        }
    }
}
