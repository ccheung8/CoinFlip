using Microsoft.Xna.Framework;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class PlaybackState : GameState<Memory> {
        public PlaybackState() {
            MinigameInputManager.AllowInput = false;    // turns off input during playback
        }

        public override void Update(GameTime gameTime, Memory memory) {
            if (Memory.GameOrderQueue.Count <= 0) {
                memory.ChangeState(new AddOneRoundState());
                return;
            }

            // triggers light up state
            memory.ChangeState(new LightUpState(Memory.GameOrderQueue.Peek()));
        }
    }
}
