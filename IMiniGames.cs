using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    internal interface IMiniGames {
        string p1Result { get; set; }
        string p2Result { get; set; }
        string Result { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, SpriteFont font);
        void Reset();
    }
}
