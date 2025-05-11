using System.Collections.Generic;
using CoinFlip.Models.Memory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class AddOneRoundState : GameState<Memory> {
        private readonly int _randomIdx = Game1._random.Next(Memory.MemoryTextures.Length);

        public override void Update(GameTime gameTime, Memory memory) {
            Memory.GameOrder.Add(Memory.MemoryTextures[_randomIdx]);
            Memory.GameOrderQueue = new Queue<MemoryTexture>(Memory.GameOrder); // sets helper queue before switching
            memory.ChangeState(new LightUpState(Memory.MemoryTextures[_randomIdx]));
        }
    }
}
