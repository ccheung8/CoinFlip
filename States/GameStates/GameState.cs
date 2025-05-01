using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates {
    public abstract class GameState<T> : IStateMachine<T> {
        public abstract void Update(GameTime gameTime, T minigame);

        public virtual void Draw(GameTime gameTime) {
            // pass if no draw
        }
    }
}
