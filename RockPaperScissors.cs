using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            p1Result = Choices[random.Next(3)];
            p2Result = Choices[random.Next(3)];

            // game RPS logic
            if (p1Result == p2Result) {
                Result = "It's a Tie!";
            } else if (p1Result == "Rock" && p2Result == "Paper" ||
                p1Result == "Paper" && p2Result == "Scissors" ||
                p1Result == "Scissors" && p2Result == "Rock") {
                Result = "Player 2 Wins!";
            } else {
                Result = "Player 1 Wins!";
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font) {

        }
    }
}
