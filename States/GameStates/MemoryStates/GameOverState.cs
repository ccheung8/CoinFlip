using CoinFlip.Models.Memory;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class GameOverState(Memory memory) : GameState<Memory> {
        private readonly Memory _memory = memory;

        public override void Update(GameTime gameTime) {
            // SET P1RESULT, P2RESULT, AND RESULT
            _memory.P1Result = _memory.Round.ToString();
            _memory.P2Result = "0";
            _memory.Result = "Game Over";
        }
    }
}
