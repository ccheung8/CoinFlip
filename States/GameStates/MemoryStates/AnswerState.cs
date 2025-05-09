using Microsoft.Xna.Framework;
using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using System.Diagnostics;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class AnswerState : GameState<Memory> {
        private float timer = 0;
        private string message = "";

        public override void Update(GameTime gameTime, Memory memory) {
            // pops queue and checks when mouse clicked and released if there's elements
            if (InputManager.OnMouseRelease && Memory.GameOrderQueue.Count > 0) {
                Debug.WriteLine("In Answer state mouserelease");
                memory.ChangeState(new CheckAnswerState(Memory.GameOrderQueue.Dequeue(), InputManager.MouseX, InputManager.MouseY));
            }

            // waits a second before changing states when gameorder is dequeued
            if (timer <= 1f && Memory.GameOrderQueue.Count <= 0) {
                message = $"Round {memory.Round} complete";
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // changes round and state after a second
            if (timer >= 1f && Memory.GameOrderQueue.Count <= 0) {
                memory.Round++; // increments round
                memory.ChangeState(new PlaybackState());
            }
        }

        public override void Draw(GameTime gameTime) {
            if (timer <= 1f && Memory.GameOrderQueue.Count <= 0) {
                Game1._spriteBatch.DrawString(Game1._font, message,
                    new Vector2(StringAlignment.HorzCenter(message), StringAlignment.VertCenter(message)), Color.Black);
            }
        }
    }
}
