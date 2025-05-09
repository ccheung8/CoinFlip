using CoinFlip.Models.Memory;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class LightUpState(MemoryTexture texture) : GameState<Memory> {
        private float time;

        public override void Update(GameTime gameTime, Memory memory) {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            texture._texture.SetData([time <= Memory.LIGHT_DURATION ? Color.Purple : Color.Black]);

            if (time > Memory.LIGHT_DURATION) memory.ChangeState(new PlaybackState());
        }
    }
}
