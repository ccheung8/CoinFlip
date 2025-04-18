using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    internal class TicTacToe : IMiniGames {
        private static Random random;
        public string p1Result { get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        public TicTacToe() {
            random = new Random();
        }

        public void Update() {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont) {

        }
    }
}
