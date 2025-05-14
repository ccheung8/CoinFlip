using System;
using System.Diagnostics;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class LightUpState(MemoryTexture texture) : GameState<Memory> {
        private float time;

        public override void Update(GameTime gameTime, Memory memory) {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            texture._texture.SetData([time <= Memory.LIGHT_DURATION ? Color.Purple : Color.Black]);

            // fast forwards if lmb clicked while answering and queue is not empty
            MemoryTexture clickedTexture = memory.GetClickedMemoryTexture();
            if (clickedTexture != null && Memory.GameOrderQueue.Count > 0) {
                texture._texture.SetData([Color.Black]);
                memory.ChangeState(new CheckAnswerState(clickedTexture, MinigameInputManager.MouseX, MinigameInputManager.MouseY));
                return;
            }

            // switches to playbackstate or answerstate based on gameorder's count
            if (time > Memory.LIGHT_DURATION) {
                if (Memory.GameOrder.Count == memory.Round) {
                    memory.ChangeState(new AnswerState());
                    return;
                }

                // transitions to next round if queue is empty
                if (Memory.GameOrderQueue.Count <= 0) {
                    memory.ChangeState(new RoundTransitionState());
                    return;
                }

                Memory.GameOrderQueue.Dequeue();
                memory.ChangeState(new PlaybackState());
            }
        }
    }
}
