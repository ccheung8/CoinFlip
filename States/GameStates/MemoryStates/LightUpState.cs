using System;
using System.Diagnostics;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class LightUpState(Memory memory, MemoryTexture texture) : GameState<Memory> {
        private readonly Memory _memory = memory;
        private float time;

        public override void Update(GameTime gameTime) {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            texture._texture.SetData([time <= Memory.LIGHT_DURATION ? Color.Purple : Color.Black]);

            // fast forwards if lmb clicked while answering and queue is not empty
            MemoryTexture clickedTexture = _memory.GetClickedMemoryTexture();
            if (clickedTexture != null && Memory.GameOrderQueue.Count > 0) {
                texture._texture.SetData([Color.Black]);
                _memory.ChangeState(new CheckAnswerState(_memory, clickedTexture, MinigameInputManager.MouseX, MinigameInputManager.MouseY));
                return;
            }

            // switches to playbackstate or answerstate based on gameorder's count
            if (time > Memory.LIGHT_DURATION) {
                if (Memory.GameOrder.Count == _memory.Round) {
                    _memory.ChangeState(new AnswerState(_memory));
                    return;
                }

                // transitions to next round if queue is empty
                if (Memory.GameOrderQueue.Count <= 0) {
                    _memory.ChangeState(new RoundTransitionState(_memory));
                    return;
                }

                Memory.GameOrderQueue.Dequeue();
                _memory.ChangeState(new PlaybackState(_memory));
            }
        }
    }
}
