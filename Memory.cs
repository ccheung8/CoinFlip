using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    internal class Memory : IMiniGames {
        private static Random random;
        public string p1Result {  get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        private const int CARDS_ROW = 2;    // number of rows in game
        private const int CARDS_COL = 5;    // number of cols in game
        private const int CARD_SPACING = 10;
        private const int BOARD_SPACING = 50;

        public List<Card> Cards { get; } = new List<Card>();

        public Memory(ContentManager content) {
            random = new Random();

            Texture2D back = content.Load<Texture2D>("Memory/Card_Back");
            int cardDistanceX = back.Width + CARD_SPACING;
            int cardDistanceY = back.Height + CARD_SPACING;
            int cardsCount = CARDS_ROW * CARDS_COL;
            int cardsCountHalf = cardsCount / 2;

            // initializes fronts of cards
            Texture2D[] fronts = new Texture2D[cardsCountHalf];
            for (int i = 0; i < cardsCountHalf; i++) {
                fronts[i] = content.Load<Texture2D>($"Memory/{i + 1}");
            }

            // initalizes cards and adds to Cards list
            for (int i = 0; i < cardsCount; i++) {
                int x = (cardDistanceX * (i % CARDS_COL)) + BOARD_SPACING;
                int y = i <= 4 ? 0 : cardDistanceY;

                Cards.Add(new Card(back, fronts[i / 2], new Vector2(x, y)));
            }

            Shuffle();
        }

        public void Update() {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font) {
            string message = "Memory";
            int center = StringAlignment.HorzCenter(font, message);
            int bottom = StringAlignment.Bottom(font, message);

            spriteBatch.DrawString(font, message, new Vector2(center, bottom - 8), Color.Black);

            foreach (Card card in Cards) {
                card.Draw(spriteBatch);
            }
        }

        public void Reset() {
            p1Result = null;
            p2Result = null;
            Result = null;
            Shuffle();
        }

        // shuffles cards using Fisher-Yates algorithm
        public void Shuffle() {
            for (int i = Cards.Count - 1; i > 0; i--) {
                int j = random.Next(i + 1);
                // swaps positions of cards
                (Cards[j].Position, Cards[i].Position) = (Cards[i].Position, Cards[j].Position);
            }
        }
    }
}
