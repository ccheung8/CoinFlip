using Microsoft.Xna.Framework;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class PlaybackState : GameState<Memory> {
        private readonly Memory _memory;

        public PlaybackState(Memory memory) {
            MinigameInputManager.AllowInput = false;    // turns off input during playback
            _memory = memory;
        }

        public override void Update(GameTime gameTime) {
            if (Memory.GameOrderQueue.Count <= 0) {
                _memory.ChangeState(new AddOneRoundState(_memory));
                return;
            }

            // triggers light up state
            _memory.ChangeState(new LightUpState(_memory, Memory.GameOrderQueue.Peek()));
        }
    }
}
