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
        private readonly int _scale;
        
        public int Id { get; }
        public bool Visible { get; set; }

        // rectangle for bounds of card for click functionality
        public Rectangle cardRectangle => new Rectangle((int)Position.X, (int)Position.Y, _activeTexture.Width * _scale, _activeTexture.Height * _scale);

        public Card(int id, Texture2D back, Texture2D front, Vector2 position, int scale) {
            Id = id;
            _back = back;
            _front = front;
            Position = position;
            _activeTexture = _back;
            _scale = scale;
            Visible = true;
        }

        // flips card
        public void Flip() {
            _flipped = !_flipped;
            _activeTexture = _flipped ? _front : _back;
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (Visible) spriteBatch.Draw(_activeTexture, Position, null, Color.White, 0, new Vector2(0, 0), _scale, SpriteEffects.None, 0);
        }

        public void Reset() {
            _flipped = false;
            _activeTexture = _back;
            Visible = true;
        }
    }
}
