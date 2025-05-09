using Microsoft.Xna.Framework;
using CoinFlip.Models.Memory;
using System.Diagnostics;
using System.Collections.Generic;

namespace CoinFlip.States.GameStates.MemoryStates {
    internal class PlaybackState : GameState<Memory> {
        private float _time = 0;
        private int _currentIdx = 0;    // current index of animation being played
        private int _randomIdx = Game1._random.Next(Memory.MemoryTextures.Length);
        private readonly Queue<MemoryTexture> playbackQueue = new Queue<MemoryTexture>(Memory.GameOrder);
        private MemoryTexture currTexture;

        public override void Update(GameTime gameTime, Memory memory) {
            _time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // randomly chooses new texture if playbackqueue is empty
            if (currTexture == null || playbackQueue.Count <= 0 && _time >= Memory.LIGHT_DURATION) {
                currTexture = Memory.MemoryTextures[_randomIdx];
            }

            // goes through playback queue 1 second at a time
            if (currTexture == null || playbackQueue.Count > 0 && _time >= Memory.LIGHT_DURATION) {
                currTexture = playbackQueue.Dequeue();
            }

            // lights up currTexture
            currTexture._texture.SetData([_time <= Memory.LIGHT_DURATION ? Color.Purple : Color.Black]);

            // adds to gameorder and increments currentidx
            if (_time >= Memory.LIGHT_DURATION) {
                Debug.WriteLine($"{_time} >= {Memory.LIGHT_DURATION} && {_currentIdx} < {memory.Round}");
                Memory.GameOrder.Add(Memory.MemoryTextures[_randomIdx]);
                // generates another random idx and resets timer if playbackqueue isn't empty
                if (playbackQueue.Count != 0) {
                    _randomIdx = Game1._random.Next(Memory.MemoryTextures.Length);
                    _time = 0;
                }
            }

            // goes to next state if greater than or equal to round number
            if (Memory.GameOrder.Count >= memory.Round && _time >= Memory.LIGHT_DURATION) {
                Debug.WriteLine("changing to answer state...");
                Memory.GameOrderQueue = new Queue<MemoryTexture>(Memory.GameOrder); // sets helper queue before switching
                memory.ChangeState(new AnswerState());
            }
        }
    }
}
