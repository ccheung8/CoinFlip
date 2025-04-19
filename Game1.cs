using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        public static KeyboardState prevKbd;

        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Random _random;

        private List<IMiniGames> _miniGames;
        private IMiniGames _miniGame;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            IsFixedTimeStep = false;
            _random = new Random();

            this.Window.Title = "Coin Flip";  // sets window title
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

            // updates when pressing Right arrow button
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && prevKbd.IsKeyUp(Keys.Right)) {
                if (_miniGame != null) _miniGame.Reset();

                _miniGame = _miniGames[_random.Next(2)];    // randomly chooses minigame
            }

            // calls minigame's update function if selected and result isn't determined
            if (_miniGame != null && _miniGame.Result == null) {
                _miniGame.Update();
            }

            prevKbd = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            // only draws after minigame has been chosen
            if (_miniGame != null) {
                _miniGame.Draw(_spriteBatch, _font);
                
                // only draws after player 1 and player 2 has gone
                if (_miniGame.p1Result != null && _miniGame.p2Result != null) {
                    _spriteBatch.DrawString(_font, "P1: " + _miniGame.p1Result, new Vector2(8), Color.Black);

                    // draws right aligned string for p2 result
                    int rightAlignedCoord = StringAlignment.Right(_font, "P2: " + _miniGame.p2Result);
                    _spriteBatch.DrawString(_font, "P2: " + _miniGame.p2Result, new Vector2(rightAlignedCoord - 8, 8), Color.Black);

                    // draws center aligned string for result
                    int xCenterCoord = StringAlignment.HorzCenter(_font, _miniGame.Result);
                    int yCenterCoord = StringAlignment.VertCenter(_font, _miniGame.Result);
                    _spriteBatch.DrawString(_font, _miniGame.Result, new Vector2(xCenterCoord, yCenterCoord), Color.Black);
                }
            }


            //Texture2D rectangle = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            //rectangle.SetData(new[] { Color.Black });

            //Mouse.GetState().X;

            //_spriteBatch.Draw(rectangle, new Rectangle(100, 100, 100, 100), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
