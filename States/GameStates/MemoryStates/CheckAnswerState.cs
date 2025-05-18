using CoinFlip.Models.Memory;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    // int x and int y used to check mouse location at time of click
    internal class CheckAnswerState(Memory memory, MemoryTexture texture, int x, int y) : GameState<Memory> {
        private readonly Memory _memory = memory;

        public override void Update(GameTime gameTime) {
            // if answer is incorrect
            if (!Memory.GameOrderQueue.Dequeue().sourceRectangle.Contains(x, y)) {
                _memory.ChangeState(new GameOverState(_memory));
                return;
            }

            // if queue is empty then increments round
            if (Memory.GameOrderQueue.Count <= 0) {
                _memory.Round++;
            }

            // highlight purple onclick
            _memory.ChangeState(new LightUpState(_memory, texture));
        }
    }
}
