using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    // int x and int y used to check mouse location at time of click
    internal class CheckAnswerState(MemoryTexture texture, int x, int y) : GameState<Memory> {

        public override void Update(GameTime gameTime, Memory memory) {
            // if answer is incorrect
            if (!Memory.GameOrderQueue.Dequeue().sourceRectangle.Contains(x, y)) {
                memory.ChangeState(new GameOverState());
                return;
            }

            // if queue is empty then increments round
            if (Memory.GameOrderQueue.Count <= 0) {
                memory.Round++;
            }

            // highlight purple onclick
            memory.ChangeState(new LightUpState(texture));
        }
    }
}
