using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    internal interface IMiniGames {
        string p1Result { get; set; }
        string p2Result { get; set; }
        string Result { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, SpriteFont font);
    }
}
