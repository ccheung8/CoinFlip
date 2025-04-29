using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.Models.TicTacToe {
    internal class TicTacToePiece {
        public Texture2D _activePiece;          // the texture that this piece draws (either X or O)
        public Vector2 Position {  get; set; }  // stores position of tictactoepiece

        public Rectangle boundingRectangle => new Rectangle((int)Position.X, (int)Position.Y, Size, Size);

        private int Size;
        public int Id { get; set; }

        public TicTacToePiece(Vector2 position, int size) {
            Position = position;
            Size = size;
        }

        public void Draw() {
            Game1._spriteBatch.Draw(_activePiece, boundingRectangle, Color.White);
        }

        public void Reset() {
            _activePiece = null;
            Id = 0;
        }
    }
}
