using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.Models.Memory {
    internal class MemoryTexture {
        public int Id { get; }
        public Vector2 Position { get; set; }

        private readonly int _size;
        public readonly Texture2D _texture;

        public Rectangle sourceRectangle => new Rectangle((int)Position.X, (int)Position.Y, _size, _size);

        public MemoryTexture(int id, Texture2D texture, Vector2 position, int size) {
            Id = id;
            _texture = texture;
            Position = position;
            _size = size;
            _texture.SetData([Color.Black]);
        }

        public void Draw() {
            Game1._spriteBatch.Draw(_texture, sourceRectangle, Color.White);
        }
    }
}
