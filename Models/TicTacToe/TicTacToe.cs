using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoinFlip.Statics;
using CoinFlip.States.GameStates.TicTacToeStates;
using CoinFlip.States.GameStates;

namespace CoinFlip.Models.TicTacToe {
    internal class TicTacToe : IMiniGames {
        public const int BOARD_DIM = 3;
        private const int LINE_THICKNESS = 20;      // determines thickness of lines for board

        public string P1Result { get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public TicTacToePiece[,] Board;

        // instance variables for board drawing
        private Texture2D rectangle;    // rectangle texture to draw
        private readonly int boardDimension;     // dimension of horizontal width and vertical height for square shape
        private readonly Point rectAxis;         // determiens x and y position where board starts (centered on screen)
        private readonly int axisOffset;         // determines size of rectangles

        public readonly Texture2D X;
        public readonly Texture2D O;
        public Texture2D _activeTurn;

        private GameState<TicTacToe> _gameState;

        public TicTacToe(ContentManager content) {
            _gameState = new XPlayerState();
            Board = new TicTacToePiece[3, 3];

            rectangle = new Texture2D(Game1._graphics.GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.Black });

            // dimension of tic tac toe board takes up around 1/4 of window height
            boardDimension = (int)(Game1._graphics.GraphicsDevice.Viewport.Height / 1.25f);
            // determines placement of x and y axis for vertical stripes
            rectAxis = new Point((Game1._graphics.GraphicsDevice.Viewport.Width - boardDimension) / 2,
                (Game1._graphics.GraphicsDevice.Viewport.Height - boardDimension) / 2 - 16);

            axisOffset = (boardDimension - 2 * LINE_THICKNESS) / 3;

            X = content.Load<Texture2D>("TicTacToe/X");
            O = content.Load<Texture2D>("TicTacToe/O");

            // initializes tic tac toe pieces
            for (int i = 0; i < BOARD_DIM; i++) {
                // fills in hitboxes per row
                for (int j = 0; j < BOARD_DIM; j++) {
                    Board[i, j] = new TicTacToePiece(
                        new Vector2(
                            rectAxis.X + j * axisOffset + j * LINE_THICKNESS,
                            rectAxis.Y + i * axisOffset + i * LINE_THICKNESS
                        ),
                        axisOffset
                    );
                }
            }
        }

        public void ChangeState(GameState<TicTacToe> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime, this);
        }

        public void Draw(GameTime gameTime) {
            string message = "Tic Tac Toe";
            int center = StringAlignment.HorzCenter(message);
            int bottom = StringAlignment.Bottom(message);

            Game1._spriteBatch.DrawString(Game1._font, message, new Vector2(center, bottom - 8), Color.Black);

            foreach (TicTacToePiece ticTacToePiece in Board) {
                if (ticTacToePiece._activePiece != null) {
                    ticTacToePiece.Draw();
                }
            }

            DrawBoard();
        }

        public TicTacToePiece GetClickedPiece() {
            if (MinigameInputManager.OnMouseRelease) {
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

        private void DrawBoard() {
            // DRAWS BOARD
            for (int i = 1; i < BOARD_DIM; i++) {
                // draws vertical stripes
                Game1._spriteBatch.Draw(
                    rectangle,
                    new Rectangle(
                        rectAxis.X + i % BOARD_DIM * axisOffset + (i - 1) * LINE_THICKNESS,
                        rectAxis.Y,
                        LINE_THICKNESS,
                        boardDimension
                    ),
                    Color.Black
                );
                // draws horizontal stripes
                Game1._spriteBatch.Draw(
                    rectangle,
                    new Rectangle(
                        rectAxis.X,
                        rectAxis.Y + i % BOARD_DIM * axisOffset + (i - 1) * LINE_THICKNESS,
                        boardDimension,
                        LINE_THICKNESS
                    ),
                    Color.Black
                );
            }
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;
            _gameState = new XPlayerState();
            foreach(TicTacToePiece ticTacToePiece in Board) {
                ticTacToePiece.Reset();
            }
        }
    }
}
