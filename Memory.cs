using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip {
    internal class Memory : IMiniGames {
        private static Random random;
        public string p1Result {  get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }
        private readonly int scale;

        private const int CARDS_ROW = 2;    // number of rows in game
        private const int CARDS_COL = 5;    // number of cols in game
        private const int CARD_SPACING = 10;

        private MouseState lastMouseState;

        public List<Card> Cards { get; } = new List<Card>();

        private Card firstCardChosen;   // stores first card player flipped
        private Card secondCardChosen;  // stores second card player flipped

        public Memory(ContentManager content) {
            random = new Random();

            Texture2D back = content.Load<Texture2D>("Memory/Card_Back");
            scale = (Game1._graphics.GraphicsDevice.Viewport.Height / 4) / back.Height; // gets 1/4 height of screen then divies by height to get scale factor
            int cardDistanceX = (back.Width * scale) + CARD_SPACING;   // amount of space each card takes on X
            int cardDistanceY = (back.Height * scale) + CARD_SPACING;  // amount of space each card takes on Y
            int cardsCount = CARDS_ROW * CARDS_COL;          // number of cards
            int cardsCountHalf = cardsCount / 2;

            // initializes fronts of cards
            Texture2D[] fronts = new Texture2D[cardsCountHalf];
            for (int i = 0; i < cardsCountHalf; i++) {
                fronts[i] = content.Load<Texture2D>($"Memory/{i + 1}");
            }

            // initalizes cards and adds to Cards list
            for (int i = 0; i < cardsCount; i++) {
                // places cards horizontally in center of screen accounting for spacing of last card in row
                int x = (cardDistanceX * (i % CARDS_COL)) + 
                    (Game1._graphics.GraphicsDevice.Viewport.Width - ((5 * cardDistanceX) - CARD_SPACING)) / 2;
                // places cards vertically in center of screen accounting for spacing of last card in row
                int y = i <= 4 ? (Game1._graphics.GraphicsDevice.Viewport.Height / 2) - cardDistanceY - CARD_SPACING :
                    (Game1._graphics.GraphicsDevice.Viewport.Height / 2) - CARD_SPACING;

                Cards.Add(new Card(i / 2, back, fronts[i / 2], new Vector2(x, y), scale));           
            }

            Shuffle();
        }

        public void Update() {
            // flips card when lmb clicked and released
            if (Mouse.GetState().LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed) {
                // cycles through and finds which card is clicked, if any
                foreach (Card card in Cards) {
                    if (card.Visible) {
                        if (card.cardRectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y)) {
                            card.Flip();
                            // assigns cards based on first or second cards chosen
                            if (firstCardChosen == null) {
                                firstCardChosen = card;
                            }
                            else if (secondCardChosen == null) {
                                secondCardChosen = card;
                            }

                            if (firstCardChosen != null && secondCardChosen != null) {
                                CheckWinnerDelay(CheckWinner, 750);
                            }
                        }
                    }
                }
            }

            lastMouseState = Mouse.GetState();
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
            foreach (Card card in Cards) {
                card.Reset();
            }
        }

        public async Task CheckWinnerDelay(Action action, int mili) {
            await Task.Delay(mili);
            action();
        }

        public void CheckWinner() {
            if (firstCardChosen.Id == secondCardChosen.Id) {
                firstCardChosen.Visible = secondCardChosen.Visible = false;
            }
            else {
                firstCardChosen.Flip();
                secondCardChosen.Flip();
            }

            firstCardChosen = null;
            secondCardChosen = null;
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
