using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip {
    internal class TicTacToe : IMiniGames {
        private static Random random;
        public string p1Result { get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        int[,] Board;    // stores state of game. 1 = X, 2 = O
        private int boardVal;

        private const int LINE_THICKNESS = 20;      // determines thickness of lines for board

        // instance variables for board drawing
        private Texture2D rectangle;    // rectangle texture to draw
        private readonly int rectDimension;      // dimension of horizontal width and vertical height for square shape
        private readonly int rectY;              // determines Y position where board starts (centered on screen)
        private readonly int rectX;              // determines X position where board starts (centered on screen)
        private readonly int axisOffset;         // determines size of rectangles

        private readonly Texture2D X;
        private readonly Texture2D O;

        private MouseState lastMouseState;

        // instance variables for hover state
        private int hoverRow;
        private int hoverCol;

        public TicTacToe(ContentManager content) {
            random = new Random();
            Board = new int[3, 3];

            hoverRow = hoverCol = 0;

            rectangle = new Texture2D(Game1._graphics.GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.Black });

            // dimension of tic tac toe board takes up around 1/4 of window height
            rectDimension = (int)(Game1._graphics.GraphicsDevice.Viewport.Height / 1.25f);
            // determines placement of y axis for vertical stripes
            rectY = ((Game1._graphics.GraphicsDevice.Viewport.Height - rectDimension) / 2) - 16;
            // determiens placement of x axis for horizontal stripes
            rectX = ((Game1._graphics.GraphicsDevice.Viewport.Width - rectDimension) / 2);

            axisOffset = ((rectDimension - (2 * LINE_THICKNESS)) / 3);

            X = content.Load<Texture2D>("TicTacToe/X");
            O = content.Load<Texture2D>("TicTacToe/O");
            boardVal = 1;
        }

        public void Update() {
            // checks if mouse is hovering over a row
            if (Mouse.GetState().Y >= rectY && Mouse.GetState().Y <= rectY + axisOffset) {
                hoverRow = 1;
            }
            else if (Mouse.GetState().Y >= rectY + axisOffset + LINE_THICKNESS
                    && Mouse.GetState().Y <= rectY + (2 * axisOffset) + LINE_THICKNESS) {
                hoverRow = 2;
            }
            else if (Mouse.GetState().Y >= rectY + (2 * axisOffset) + (2 * LINE_THICKNESS)
                    && Mouse.GetState().Y <= rectY + (3 * axisOffset) + (2 * LINE_THICKNESS)) {
                hoverRow = 3;
            }
            else {
                hoverRow = 0;
            }

            // checks if mouse is hovering over a col
            if (Mouse.GetState().X >= rectX && Mouse.GetState().X <= rectX + axisOffset) {
                hoverCol = 1;
            }
            else if (Mouse.GetState().X >= rectX + axisOffset + LINE_THICKNESS
                    && Mouse.GetState().X <= rectX + (2 * axisOffset) + LINE_THICKNESS) {
                hoverCol = 2;
            }
            else if (Mouse.GetState().X >= rectX + (2 * axisOffset) + (2 * LINE_THICKNESS)
                        && Mouse.GetState().X <= rectX + (3 * axisOffset) + (2 * LINE_THICKNESS)) {
                hoverCol = 3;
            }
            else {
                hoverCol = 0;
            }

            // activate after pressing and releasing left click
            // updates board state then switches turns
            if (Mouse.GetState().LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed) {
                if (hoverRow != 0 && hoverCol != 0) {
                    Board[(hoverRow - 1), (hoverCol - 1)] = boardVal;
                }

                boardVal = boardVal == 1 ? 2 : 1;
            }

            // checks if someone has won the game
            for (int i = 0; i < Board.GetLength(0); i++) {
                // won by horizontal matching
                CheckWinner(Board[i, 0], Board[i, 1], Board[i, 2]);
                // won by vertical matching
                CheckWinner(Board[0, i], Board[1, i], Board[2, i]);
            }
            // won by backslash (\)
            CheckWinner(Board[0, 0], Board[1, 1], Board[2, 2]);
            // won by forwardslash (/)
            CheckWinner(Board[2, 0], Board[1, 1], Board[0, 2]);

            // checks to see if game is drawn
            CheckTie();
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font) {
            string message = "Tic Tac Toe";
            int center = StringAlignment.HorzCenter(font, message);
            int bottom = StringAlignment.Bottom(font, message);

            spriteBatch.DrawString(font, message, new Vector2(center, bottom - 8), Color.Black);

            // places X's and O's based on board state
            for (int i = 0; i < Board.GetLength(0); i++ ) {
                for (int j = 0; j < Board.GetLength(0); j++) {
                    switch (Board[i, j]) {
                        // place X if board value is 1
                        case 1:
                            spriteBatch.Draw(X, ConstructDestRect(i, j), Color.White);
                            break;
                        // place O if board value is 2
                        case 2:
                            spriteBatch.Draw(O, ConstructDestRect(i, j), Color.White);
                            break;
                    }
                }
            }

            lastMouseState = Mouse.GetState();

            DrawBoard(spriteBatch);
        }

        private void CheckTie() {
            int zeroCounter = 0;
            for (int i = 0; i < Board.GetLength(0); i++) {
                for (int j = 0; j < Board.GetLength(0); j++) {
                    if (Board[i, j] == 0) {
                        zeroCounter++;
                    }
                }
            }

            // if whole board is filled
            if (zeroCounter == 0) {
                p1Result = "Player 1 (X) Tied!";
                p2Result = "Player 2 (O) Tied!";
                Result = "Draw!";
            }
        }

        private void CheckWinner(int valOne, int valTwo, int valThree) {
            if (valOne != 0 && valTwo != 0 && valThree != 0) { 
                if (valOne == valTwo && valTwo == valThree) {
                    if (valOne == 1) {
                        p1Result = "Player 1 (X) Wins!";
                        p2Result = "Player 2 (O) Lost!";
                        Result = "Player 1 Wins!";
                    }
                    else {
                        p1Result = "Player 1 (X) Lost!";
                        p2Result = "Player 2 (O) Wins!";
                        Result = "Player 2 Wins!";
                    }
                }
            }
        }

        private Rectangle ConstructDestRect(int row, int col) {
            int x = 0;
            int y = 0;

            switch (row) {
                case 0:
                    y = rectY;
                    break;

                case 1:
                    y = rectY + axisOffset + LINE_THICKNESS;
                    break;

                case 2:
                    y = rectY + (2 * axisOffset) + (2 * LINE_THICKNESS);
                    break;
            }

            switch (col) {
                case 0:
                    x = rectX;
                    break;

                case 1:
                    x = rectX + axisOffset + LINE_THICKNESS;
                    break;

                case 2:
                    x = rectX + (2 * axisOffset) + (2 * LINE_THICKNESS);
                    break;
            }

            return new Rectangle(x, y, axisOffset, axisOffset);
        }

        private void DrawBoard(SpriteBatch spriteBatch) {
            // DRAWS BOARD
            // draws first vertical stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX + axisOffset,     // places first stripe at 1/3 of width
                    rectY,
                    LINE_THICKNESS,
                    rectDimension           // rectDimension for height ensures square shape
                ),
                Color.Black
            );
            // draws second vertical stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX + (2 * axisOffset) + LINE_THICKNESS,    // place second stripe at 2/3 of width accounting for width of first stripe
                    rectY,
                    LINE_THICKNESS,
                    rectDimension           // rectDimension for height ensures square shape
                ),
                Color.Black
            );
            // draws top horizontal stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX,
                    rectY + axisOffset,    // places first stripe at 1/3 of height
                    rectDimension,         // rectDimension for width ensures square shape
                    LINE_THICKNESS
                ),
                Color.Black
            );
            // draws second horizontal stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX,
                    rectY + (2 * axisOffset) + LINE_THICKNESS,      // place second stripe at 2/3 of width accounting for width of first stripe
                    rectDimension,         // rectDimension for width ensures square shape
                    LINE_THICKNESS
                ),
                Color.Black
            );
        }

        public void Reset() {
            p1Result = null;
            p2Result = null;
            Result = null;
            Board = new int[3, 3];
            boardVal = 1;
        }
    }
}
