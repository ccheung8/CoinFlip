using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            IsFixedTimeStep = false;
            _random = new Random();

            this.Window.Title = "CoinFlip";  // sets window title
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
            DrawStringAligned(_font, "P2: " + _miniGame.p2Result, "Right", Color.Black);

            DrawStringAligned(_font, _miniGame.Result, "Center", Color.Black);

            Texture2D rectangle = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.Black });

            //Mouse.GetState().X;

            _spriteBatch.Draw(rectangle, new Rectangle(100, 100, 100, 100), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // draws an aligned string based on alignment value passed
        protected void DrawStringAligned(SpriteFont font, string text, string alignment, Color color) {
            Vector2 textSize = font.MeasureString(text);
            // values are casted to int from float to prevent text distortion from non int values
            if (alignment.Equals("Right")) {
                _spriteBatch.DrawString(font, text, new Vector2((int)(GraphicsDevice.Viewport.Width - textSize.X - 8), 8), color);
            } else if (alignment.Equals("Center")) {
                _spriteBatch.DrawString(font, text,
                    new Vector2((int)((GraphicsDevice.Viewport.Width / 2) - (textSize.X / 2)), (int)(GraphicsDevice.Viewport.Height / 2)),
                    color);
            }
        }
    }
}
