using Microsoft.Xna.Framework;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using System.Diagnostics;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class AnswerState : GameState<Memory> {
        public AnswerState() {
            MinigameInputManager.AllowInput = true;
        }

        public override void Update(GameTime gameTime, Memory memory) {
            MemoryTexture texture = memory.GetClickedMemoryTexture();

            // when texture is set, 
            if (texture != null) memory.ChangeState(new CheckAnswerState(texture, MinigameInputManager.MouseX, MinigameInputManager.MouseY));
        }
    }
}
