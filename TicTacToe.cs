using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip {
    internal class TicTacToe : IMiniGames {
        private const int BOARD_DIM = 3;
        private const int LINE_THICKNESS = 20;      // determines thickness of lines for board

        public string p1Result { get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        public List<TicTacToePiece> Board;
        int[,] BoardState;    // stores state of game. 1 = X, 2 = O
        private int boardVal;

        // instance variables for board drawing
        private Texture2D rectangle;    // rectangle texture to draw
        private readonly int boardDimension;      // dimension of horizontal width and vertical height for square shape
        private readonly int rectY;              // determines Y position where board starts (centered on screen)
        private readonly int rectX;              // determines X position where board starts (centered on screen)
        private readonly int axisOffset;         // determines size of rectangles

        private readonly Texture2D X;
        private readonly Texture2D O;
        private Texture2D _activeTurn;

        private MouseState lastMouseState;

        // instance variables for hover state
        private int hoverRow;
        private int hoverCol;

        public TicTacToe(ContentManager content) {
            BoardState = new int[3, 3];
            Board = new List<TicTacToePiece>();

            hoverRow = hoverCol = 0;

            rectangle = new Texture2D(Game1._graphics.GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.Black });

            // dimension of tic tac toe board takes up around 1/4 of window height
            boardDimension = (int)(Game1._graphics.GraphicsDevice.Viewport.Height / 1.25f);
            // determines placement of y axis for vertical stripes
            rectY = ((Game1._graphics.GraphicsDevice.Viewport.Height - boardDimension) / 2) - 16;
            // determiens placement of x axis for horizontal stripes
            rectX = ((Game1._graphics.GraphicsDevice.Viewport.Width - boardDimension) / 2);

            axisOffset = ((boardDimension - (2 * LINE_THICKNESS)) / 3);

            X = content.Load<Texture2D>("TicTacToe/X");
            O = content.Load<Texture2D>("TicTacToe/O");
            boardVal = 1;
            _activeTurn = X;
        }

        public void Update() {
            //// checks if mouse is hovering over a row
            //if (Mouse.GetState().Y >= rectY && Mouse.GetState().Y <= rectY + axisOffset) {
            //    hoverRow = 1;
            //}
            //else if (Mouse.GetState().Y >= rectY + axisOffset + LINE_THICKNESS
            //        && Mouse.GetState().Y <= rectY + (2 * axisOffset) + LINE_THICKNESS) {
            //    hoverRow = 2;
            //}
            //else if (Mouse.GetState().Y >= rectY + (2 * axisOffset) + (2 * LINE_THICKNESS)
            //        && Mouse.GetState().Y <= rectY + (3 * axisOffset) + (2 * LINE_THICKNESS)) {
            //    hoverRow = 3;
            //}
            //else {
            //    hoverRow = 0;
            //}

            //// checks if mouse is hovering over a col
            //if (Mouse.GetState().X >= rectX && Mouse.GetState().X <= rectX + axisOffset) {
            //    hoverCol = 1;
            //}
            //else if (Mouse.GetState().X >= rectX + axisOffset + LINE_THICKNESS
            //        && Mouse.GetState().X <= rectX + (2 * axisOffset) + LINE_THICKNESS) {
            //    hoverCol = 2;
            //}
            //else if (Mouse.GetState().X >= rectX + (2 * axisOffset) + (2 * LINE_THICKNESS)
            //            && Mouse.GetState().X <= rectX + (3 * axisOffset) + (2 * LINE_THICKNESS)) {
            //    hoverCol = 3;
            //}
            //else {
            //    hoverCol = 0;
            //}

            TicTacToePiece ticTacToePiece = GetClickedPiece();
            if (ticTacToePiece != null) {
                ticTacToePiece._activePiece = _activeTurn;
                ticTacToePiece.Id = _activeTurn == X ? 1 : 0;
            }

            // activate after pressing and releasing left click
            // updates board state then switches turns
            if (Mouse.GetState().LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed) {
                //if (hoverRow != 0 && hoverCol != 0) {
                //    BoardState[(hoverRow - 1), (hoverCol - 1)] = boardVal;
                //}

                boardVal = boardVal == 1 ? 2 : 1;
                _activeTurn = _activeTurn == X ? O : X;
            }

            // checks if someone has won the game
            for (int i = 0; i < BoardState.GetLength(0); i++) {
                // won by horizontal matching
                CheckWinner(BoardState[i, 0], BoardState[i, 1], BoardState[i, 2]);
                // won by vertical matching
                CheckWinner(BoardState[0, i], BoardState[1, i], BoardState[2, i]);
            }
            // won by backslash (\)
            CheckWinner(BoardState[0, 0], BoardState[1, 1], BoardState[2, 2]);
            // won by forwardslash (/)
            CheckWinner(BoardState[2, 0], BoardState[1, 1], BoardState[0, 2]);

            // checks to see if game is drawn
            if (Result == null) {
                CheckTie();
            }

            lastMouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font) {
            string message = "Tic Tac Toe";
            int center = StringAlignment.HorzCenter(font, message);
            int bottom = StringAlignment.Bottom(font, message);

            spriteBatch.DrawString(font, message, new Vector2(center, bottom - 8), Color.Black);

            foreach (TicTacToePiece ticTacToePiece in Board) {
                if (ticTacToePiece._activePiece != null) {
                    ticTacToePiece.Draw(spriteBatch);
                }
            }

            // places X's and O's based on board state
            //for (int i = 0; i < BoardState.GetLength(0); i++ ) {
            //    for (int j = 0; j < BoardState.GetLength(0); j++) {
            //        switch (BoardState[i, j]) {
            //            // place X if board value is 1
            //            case 1:
            //                spriteBatch.Draw(X, ConstructDestRect(i, j), Color.White);
            //                break;
            //            // place O if board value is 2
            //            case 2:
            //                spriteBatch.Draw(O, ConstructDestRect(i, j), Color.White);
            //                break;
            //        }
            //    }
            //}

            DrawBoard(spriteBatch);
        }

        public TicTacToePiece GetClickedPiece() {
            if (Mouse.GetState().LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed) {
                foreach (TicTacToePiece ticTacToePiece in Board) {
                    // if mouse is in rectangle and activepiece isn't assigned
                    if (ticTacToePiece.boundingRectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y) 
                            && ticTacToePiece._activePiece == null) {
                        return ticTacToePiece;
                    }
                }
            }

            return null;
        }

        private void CheckTie() {
            int zeroCounter = 0;
            for (int i = 0; i < BoardState.GetLength(0); i++) {
                for (int j = 0; j < BoardState.GetLength(0); j++) {
                    if (BoardState[i, j] == 0) {
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
            for (int i = 1; i < BOARD_DIM; i++) {
                // draws vertical stripes
                spriteBatch.Draw(
                    rectangle,
                    new Rectangle(
                        rectX + ((i % BOARD_DIM) * axisOffset) + ((i - 1) * LINE_THICKNESS),
                        rectY,
                        LINE_THICKNESS,
                        boardDimension
                    ),
                    Color.Black
                );
                // draws horizontal stripes
                spriteBatch.Draw(
                    rectangle,
                    new Rectangle(
                        rectX,
                        rectY + ((i % BOARD_DIM) * axisOffset) + ((i - 1) * LINE_THICKNESS),
                        boardDimension,
                        LINE_THICKNESS
                    ),
                    Color.Black
                );
            }

            // draws hitboxes
            for (int i = 0; i < BOARD_DIM; i++) {
                int iMod = i % BOARD_DIM;
                // fills in hitboxes per row
                for (int j = 0; j < BOARD_DIM; j++) {
                    int jMod = j % BOARD_DIM;
                    Board.Add(new TicTacToePiece(
                        new Vector2(
                            rectX + (jMod * axisOffset) + (jMod * LINE_THICKNESS),
                            rectY + (iMod * axisOffset) + (iMod * LINE_THICKNESS)),
                            axisOffset
                        )
                    );
                }
            }

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
        }

        public void Reset() {
            p1Result = null;
            p2Result = null;
            Result = null;
            BoardState = new int[3, 3];
            boardVal = 1;
        }
    }
}
