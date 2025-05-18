using System.Collections.Generic;
using CoinFlip.Models.Memory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class AddOneRoundState(Memory memory) : GameState<Memory> {
        private readonly int _randomIdx = Game1._random.Next(Memory.MemoryTextures.Length);
        private readonly Memory _memory = memory;

        public override void Update(GameTime gameTime) {
            Memory.GameOrder.Add(Memory.MemoryTextures[_randomIdx]);
            Memory.GameOrderQueue = new Queue<MemoryTexture>(Memory.GameOrder); // sets helper queue before switching
            _memory.ChangeState(new LightUpState(_memory, Memory.MemoryTextures[_randomIdx]));
        }
    }
}
