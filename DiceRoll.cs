using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip {
    internal class DiceRoll : IMiniGames {
        private static Random random;
        public string p1Result {  get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        public DiceRoll(ContentManager content) {
            random = new Random();
        }

        public void Update() {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.prevKbd.IsKeyUp(Keys.Space)) {
                p1Result = Convert.ToString(random.Next(6) + 1);

                p2Result = Convert.ToString(random.Next(6) + 1);

                if (p1Result == p2Result) {
                    Result = "It's a Tie!";
                }
                else if (Convert.ToInt32(p1Result) >= Convert.ToInt32(p2Result)) {
                    Result = "Player 1 Wins!";
                }
                else {
                    Result = "Player 2 Wins!";
                }
            }
        }

        public void Draw() {
            string message = "Press Space to Roll the Die";
            int center = StringAlignment.HorzCenter(Game1._font, message);
            int bottom = StringAlignment.Bottom(Game1._font, message);

            Game1._spriteBatch.DrawString(Game1._font, message, new Vector2(center, bottom - 8), Color.Black);
        }

        public void Reset() {
            p1Result = null;
            p2Result = null;
            Result = null;
        }
    }
}
