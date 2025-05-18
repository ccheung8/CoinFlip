using Microsoft.Xna.Framework;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using System.Diagnostics;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class AnswerState : GameState<Memory> {
        private readonly Memory _memory;

        public AnswerState(Memory memory) {
            MinigameInputManager.AllowInput = true;
            _memory = memory;
        }

        public override void Update(GameTime gameTime) {
            MemoryTexture texture = _memory.GetClickedMemoryTexture();

            // when texture is set, 
            if (texture != null) _memory.ChangeState(new CheckAnswerState(_memory, texture, MinigameInputManager.MouseX, MinigameInputManager.MouseY));
        }
    }
}
