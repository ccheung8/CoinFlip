using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    internal class DiceRoll : IMiniGames {
        private static Random random;
        public string p1Result {  get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        public DiceRoll() {
            random = new Random();
        }
        public void Update() {
            p1Result = Convert.ToString(random.Next(6) + 1);
            p2Result = Convert.ToString(random.Next(6) + 1);

            if (p1Result == p2Result) {
                Result = "It's a Tie!";
            } else if (Convert.ToInt32(p1Result) >= Convert.ToInt32(p2Result)) {
                Result = "Player 1 Wins!";
            } else {
                Result = "Player 2 Wins!";
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont) {

        }
    }
}
