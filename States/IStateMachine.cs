using Microsoft.Xna.Framework;

namespace CoinFlip.States {
    internal interface IStateMachine<T> {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
