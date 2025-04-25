using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip {
    internal class Card {
        private readonly Texture2D _back;
        private readonly Texture2D _front;
        public Vector2 Position { get; set; }

        private bool _flipped;
        private Texture2D _activeTexture;

        public Card(Texture2D back, Texture2D front, Vector2 position) {
            _back = back;
            _front = front;
            Position = position;
            _activeTexture = _back;
            Flip();
        }

        // flips card
        public void Flip() {
            _flipped = !_flipped;
            _activeTexture = _flipped ? _front : _back;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_activeTexture, Position, Color.White);
        }
    }
}
