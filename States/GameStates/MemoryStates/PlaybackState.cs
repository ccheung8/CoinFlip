using Microsoft.Xna.Framework;
using CoinFlip.Models.Memory;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class PlaybackState : GameState<Memory> {
        public override void Update(GameTime gameTime, Memory memory) {
            memory._memoryTextures[memory._randomIdx].IsLit = memory._time <= Memory.LIGHT_DURATION;

            if (memory._time <= Memory.LIGHT_DURATION) {
                memory._time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else {
                memory._randomIdx = Game1._random.Next(memory._memoryTextures.Length);
                memory._time = 0;
            }
        }

        public override void Draw(GameTime gameTime) {
        }
    }
}
