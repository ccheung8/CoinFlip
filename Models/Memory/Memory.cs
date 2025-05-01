using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;

namespace CoinFlip.Models.Memory {
    internal class Memory : IMiniGames {
        public string P1Result {  get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public Texture2D[] memoryTextures;

        public GameState<Memory> _gameState;

        public Memory(ContentManager content) {
            memoryTextures = new Texture2D[4];
            // initializes 4 squares
            for (int i = 0; i < memoryTextures.Length; i++) {
                memoryTextures[i] = new Texture2D(Game1._graphics.GraphicsDevice, 1, 1);
                memoryTextures[i].SetData([Color.AliceBlue]);
            }
        }

        public void ChangeState(GameState<Memory> gameState) {

        }

        public void Update(GameTime gameTime) {

        }

        public void Draw(GameTime gameTime) {
            string message = "Tic Tac Toe";
            int center = StringAlignment.HorzCenter(message);
            int bottom = StringAlignment.Bottom(message);

            Game1._spriteBatch.DrawString(Game1._font, message, new Vector2(center, bottom - 8), Color.Black);
        }

        public void Reset() {

        }
    }
}
