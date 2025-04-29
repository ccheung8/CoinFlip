using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoinFlip.States;
using CoinFlip.Models.Memory;
using CoinFlip.Models.TicTacToe;

namespace CoinFlip
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        public static KeyboardState prevKbd;
        public static SpriteBatch _spriteBatch;
        public static SpriteFont _font;

        private static Random _random;

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
                //new RockPaperScissors(this.Content),
                //new DiceRoll(this.Content),
                new TicTacToe(this.Content),
                //new Memory(this.Content)
            };

            IsMouseVisible = true;

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
                // resets minigame before switching
                if (_miniGame != null) _miniGame.Reset();

                _miniGame = _miniGames[0];    // randomly chooses minigame
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
                _miniGame.Draw();
                
                // only draws after player 1 and player 2 has gone
                if (_miniGame.p1Result != null && _miniGame.p2Result != null) {
                    _spriteBatch.DrawString(_font, "P1: " + _miniGame.p1Result, new Vector2(8), Color.Black);

                    // draws right aligned string for p2 result
                    int rightAlignedCoord = StringAlignment.Right(_font, "P2: " + _miniGame.p2Result);
                    _spriteBatch.DrawString(_font, "P2: " + _miniGame.p2Result, new Vector2(rightAlignedCoord - 8, 8), Color.Black);
                }

                if (_miniGame.Result != null) {
                    // draws center aligned string for result
                    int xCenterCoord = StringAlignment.HorzCenter(_font, _miniGame.Result);
                    int yCenterCoord = StringAlignment.VertCenter(_font, _miniGame.Result);
                    _spriteBatch.DrawString(_font, _miniGame.Result, new Vector2(xCenterCoord, yCenterCoord), Color.Black);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
