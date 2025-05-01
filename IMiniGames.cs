using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    public interface IMiniGames {
        string P1Result { get; set; }
        string P2Result { get; set; }
        string Result { get; set; }
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Reset();
    }
}
