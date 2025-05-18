using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoinFlip.Statics;
using CoinFlip.States.GameStates.ConcentrationStates;
using CoinFlip.States.GameStates;

namespace CoinFlip.Models.Concentration {
    internal class Concentration : IMiniGames {
        public string Message { get; }
        public string P1Result {  get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        private const int CARDS_ROW = 2;    // number of rows in game
        private const int CARDS_COL = 5;    // number of cols in game
        private const int CARD_SPACING = 10;

        private readonly int scale;
        private GameState<Concentration> _gameState;

        public List<Card> Cards { get; } = new List<Card>();
        public Card firstCardChosen;   // stores first card player flipped
        public Card secondCardChosen;  // stores second card player flipped

        public Concentration(ContentManager content) {
            Message = "Concentration";
            _gameState = new FlipFirstCardState(this);

            Texture2D back = content.Load<Texture2D>("Concentration/Card_Back");
            Rectangle window = Game1._graphics.GraphicsDevice.PresentationParameters.Bounds;
            scale = Game1._graphics.GraphicsDevice.Viewport.Height / 4 / back.Height; // gets 1/4 height of screen then divies by height to get scale factor
            Point cardDistance = new Point(back.Width * scale + CARD_SPACING, back.Height * scale + CARD_SPACING);  // amount of space each card takes on X and Y
            Point boardSize = new Point(cardDistance.X * CARDS_COL - CARD_SPACING, cardDistance.Y * CARDS_ROW - CARD_SPACING);
            Point boardSpacing = new Point((window.Width - boardSize.X) / 2, (window.Height - boardSize.Y) / 2);

            int cardsCount = CARDS_ROW * CARDS_COL;          // number of cards
            int cardsCountHalf = cardsCount / 2;

            // initializes fronts of cards
            Texture2D[] fronts = new Texture2D[cardsCountHalf];
            for (int i = 0; i < cardsCountHalf; i++) {
                fronts[i] = content.Load<Texture2D>($"Concentration/{i + 1}");
            }

            // initalizes cards and adds to Cards list
            for (int i = 0; i < cardsCount; i++) {
                // places cards horizontally in center of screen accounting for spacing of last card in row
                int x = cardDistance.X * (i % CARDS_COL) + boardSpacing.X;
                // places cards vertically in center of screen accounting for spacing of last card in row
                int y = i <= 4 ? boardSpacing.Y :
                    boardSpacing.Y + cardDistance.Y;

                Cards.Add(new Card(i / 2, back, fronts[i / 2], new Vector2(x, y), scale));           
            }

            Shuffle();
        }

        public void ChangeState(GameState<Concentration> gameState) {
            if (gameState != null) _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime);
        }

        public void Draw(GameTime gameTime) {
            foreach (Card card in Cards) {
                card.Draw();
            }
        }

        public void Reset() {
            firstCardChosen = null;
            secondCardChosen = null;
            P1Result = null;
            P2Result = null;
            Result = null;
            Shuffle();
            foreach (Card card in Cards) {
                card.Reset();
            }
            _gameState = new FlipFirstCardState(this);
        }

        public Card GetClickedCard() {
            // flips card when lmb clicked and released
            if (MinigameInputManager.OnMouseRelease) {
                // cycles through and finds which card is clicked, if any
                foreach (Card card in Cards) {
                    if (card.Solved) continue;
                    if (card.cardRectangle.Contains(MinigameInputManager.MouseX, MinigameInputManager.MouseY)) {
                        return card;
                    }
                }
            }

            return null;
        }

        // shuffles cards using Fisher-Yates algorithm
        public void Shuffle() {
            for (int i = Cards.Count - 1; i > 0; i--) {
                int j = Game1._random.Next(i + 1);
                // swaps positions of cards
                (Cards[j].Position, Cards[i].Position) = (Cards[i].Position, Cards[j].Position);
            }
        }
    }
}
