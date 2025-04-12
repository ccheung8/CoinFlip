using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace CoinFlip
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;

        private IMiniGames _miniGames;
        private KeyboardState prevKbd;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _miniGames = new RockPaperScissors();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _font = Content.Load<SpriteFont>("Fonts/Score");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // updates when game is first run
            if (gameTime.TotalGameTime == TimeSpan.Zero) _miniGames.Update();

            // updates when pressing button
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && prevKbd.IsKeyUp(Keys.Right)) {
                _miniGames.Update();
            }

            prevKbd = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "P1: " + _miniGames.p1Result, new Vector2(8), Color.Black);
            _spriteBatch.DrawString(_font, "P2: " + _miniGames.p2Result, new Vector2(700, 8), Color.Black);

            _spriteBatch.DrawString(_font, _miniGames.Result, new Vector2(400, 240), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
