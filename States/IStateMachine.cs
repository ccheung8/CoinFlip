using Microsoft.Xna.Framework;

namespace CoinFlip.States {
    internal interface IStateMachine<T> {
        void Update(GameTime gameTime, T game);
        void Draw(GameTime gameTime);
    }
}
