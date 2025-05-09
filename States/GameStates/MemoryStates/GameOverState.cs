using CoinFlip.Models.Memory;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class GameOverState : GameState<Memory> {
        public override void Update(GameTime gameTime, Memory memory) {
            // SET P1RESULT, P2RESULT, AND RESULT
            memory.P1Result = memory.Round.ToString();
            memory.P2Result = "0";
            memory.Result = "Game Over";
        }
    }
}
