using System;
using System.Collections.Generic;
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
        private Random _random;

        private List<IMiniGames> _miniGames;
        private IMiniGames _miniGame;
        private KeyboardState prevKbd;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _random = new Random();
        }

        protected override void Initialize()
        {
            _miniGames = new List<IMiniGames>() {
                new RockPaperScissors(),
                new DiceRoll()
            };

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

            // updates when pressing button or when game is first run
            if ((Keyboard.GetState().IsKeyDown(Keys.Right) && prevKbd.IsKeyUp(Keys.Right))
                    || gameTime.TotalGameTime == TimeSpan.Zero) {
                _miniGame = _miniGames[_random.Next(2)];

                _miniGame.Update();
            }

            prevKbd = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "P1: " + _miniGame.p1Result, new Vector2(8), Color.Black);
            _spriteBatch.DrawString(_font, "P2: " + _miniGame.p2Result, new Vector2(700, 8), Color.Black);

            _spriteBatch.DrawString(_font, _miniGame.Result, new Vector2(400, 240), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
