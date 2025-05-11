using System.Diagnostics;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class RoundTransitionState : GameState<Memory> {
        private float time;
        private string message;

        public RoundTransitionState() {
            InputManager.AllowInput = false;
            message = "";
        }

        public override void Update(GameTime gameTime, Memory memory) {
            message = $"Round {memory.Round}";
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // resets queue for playback and changes state
            if (time > Memory.LIGHT_DURATION) {
                Memory.GameOrderQueue = new(Memory.GameOrder);
                memory.ChangeState(new PlaybackState()); 
            }
        }

        public override void Draw(GameTime gameTime) {
            Game1._spriteBatch.DrawString(Game1._font, message,
                new Vector2(StringAlignment.HorzCenter(message), StringAlignment.VertCenter(message)), Color.Black);
        }
    }
}
