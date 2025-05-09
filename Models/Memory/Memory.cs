using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.MemoryStates;
using System.Diagnostics;

namespace CoinFlip.Models.Memory {
    internal class Memory : IMiniGames {
        public string P1Result {  get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }
        public int Round {  get; set; }

        public const int TEXTURE_SPACING = 20; // spacing of the textures
        public const int LIGHT_DURATION = 1;   // duration of light up in seconds

        public static MemoryTexture[] MemoryTextures;       // stores all texture for random selection
        public static List<MemoryTexture> GameOrder;        // stores list of order of textures
        public static Queue<MemoryTexture> GameOrderQueue;  // helper variable to check answers in answerstate

        public GameState<Memory> _gameState;

        public Memory(ContentManager content) {
            MemoryTextures = new MemoryTexture[4];
            GameOrder = new List<MemoryTexture>();
            GameOrderQueue = new Queue<MemoryTexture>();

            _gameState = new PlaybackState();

            Rectangle viewport = Game1._graphics.GraphicsDevice.Viewport.Bounds;
            int textureSize = viewport.Height / 4;
            // initializes 4 squares
            for (int i = 0; i < MemoryTextures.Length; i++) {
                // calculates position for each texture so that ID's goes from left to right
                // same x for even indexes
                int x = i % 2 == 0 ? (viewport.Width / 2) - textureSize - (TEXTURE_SPACING / 2) : (viewport.Width / 2) + (TEXTURE_SPACING / 2);
                // same y for indexes 0 and 1 and indexes 2 and 3
                int y = i <= 1 ? (viewport.Height / 2) - textureSize - (TEXTURE_SPACING / 2) : (viewport.Height / 2) + (TEXTURE_SPACING / 2);
                MemoryTextures[i] = 
                    new MemoryTexture(
                        i, 
                        new Texture2D(Game1._graphics.GraphicsDevice, 1, 1), 
                        new Vector2(x, y),
                        textureSize
                    );

            }

            Round = 1;
        }

        public void ChangeState(GameState<Memory> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime, this);
        }

        public void Draw(GameTime gameTime) {
            string message = "Memory";
            int center = StringAlignment.HorzCenter(message);
            int bottom = StringAlignment.Bottom(message);

            Game1._spriteBatch.DrawString(Game1._font, message, new Vector2(center, bottom - 8), Color.Black);

            _gameState.Draw(gameTime);

            // draws textures
            foreach (MemoryTexture texture in MemoryTextures) {
                texture.Draw();
            }
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;

            Round = 1;
            GameOrder.Clear();
            GameOrderQueue.Clear();
            _gameState = new PlaybackState();
        }
    }
}
