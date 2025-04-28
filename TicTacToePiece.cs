using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    internal class TicTacToePiece {
        public Texture2D _activePiece;
        public Vector2 Position {  get; set; }

        public Rectangle boundingRectangle => new Rectangle((int)Position.X, (int)Position.Y, Size, Size);

        private readonly int Size;
        public int Id { get; set; }

        public TicTacToePiece(Vector2 position, int size) {
            Position = position;
            Size = size;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_activePiece, boundingRectangle, Color.White);
        }
    }
}
