using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip {
    internal class RockPaperScissors : IMiniGames {
        private static Random random;
        private string[] Choices;
        public string p1Result { get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        public RockPaperScissors() {
            random = new Random();
            Choices = ["Rock", "Paper", "Scissors"];
        }

        public void Update() {
            // Keyboard input:
            // 1: Rock
            // 2: Paper
            // 3: Scissors
            if (Keyboard.GetState().IsKeyDown(Keys.D1) && Game1.prevKbd.IsKeyUp(Keys.D1)) {
                p1Result = Choices[0];
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2) && Game1.prevKbd.IsKeyUp(Keys.D2)) {
                p1Result = Choices[1];
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D3) && Game1.prevKbd.IsKeyUp(Keys.D3)) {
                p1Result = Choices[2];
            }

            if (p1Result != null) {
                p2Result = Choices[random.Next(3)];

                // game RPS logic
                if (p1Result == p2Result) {
                    Result = "It's a Tie!";
                }
                else if (p1Result == "Rock" && p2Result == "Paper" ||
                    p1Result == "Paper" && p2Result == "Scissors" ||
                    p1Result == "Scissors" && p2Result == "Rock") {
                    Result = "Player 2 Wins!";
                }
                else {
                    Result = "Player 1 Wins!";
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font) {
            string message = "1: Rock, 2: Paper, 3: Scissors";
            int center = StringAlignment.HorzCenter(font, message);
            int bottom = StringAlignment.Bottom(font, message);

            spriteBatch.DrawString(font, message, new Vector2(center, bottom - 8), Color.Black);
        }

        public void Reset() {
            p1Result = null;
            p2Result = null;
            Result = null;
        }
    }
}
