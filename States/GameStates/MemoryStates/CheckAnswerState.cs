using CoinFlip.Models.Memory;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MemoryStates {
    // int x and int y used to check mouse location at time of click
    internal class CheckAnswerState(MemoryTexture correctAnswer, int x, int y) : GameState<Memory> {
        private readonly MemoryTexture _correctAnswer = correctAnswer;    // correct texture used to check answer
        private float _time = 0f;

        public override void Update(GameTime gameTime, Memory memory) {
            // if answer is incorrect
            if (!_correctAnswer.sourceRectangle.Contains(x, y)) {
                memory.ChangeState(new GameOverState());
                return;
            }

            _time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // highlight purple onclick
            _correctAnswer._texture.SetData([_time <= Memory.LIGHT_DURATION ? Color.Purple : Color.Black]);
            if (_time >= 1f || InputManager.OnMouseRelease) {
                _correctAnswer._texture.SetData([Color.Black]);
                memory.ChangeState(new AnswerState());
            }
        }
    }
}
