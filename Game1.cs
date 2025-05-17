using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoinFlip.States;
using CoinFlip.Statics;
using CoinFlip.Models.Concentration;
using CoinFlip.Models.DiceRoll;
using CoinFlip.Models.TicTacToe;
using CoinFlip.Models.RockPaperScissors;
using CoinFlip.Models.Memory;
using CoinFlip.Models.MathGame;
using CoinFlip.Models.TypingTest;

namespace CoinFlip
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        public static GameWindow _gameWindow;
        public static SpriteBatch _spriteBatch;
        public static SpriteFont _font;
        public static Random _random;

        private List<IMiniGames> _miniGames;
        private IMiniGames _miniGame;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            IsFixedTimeStep = false;
            _random = new Random();

            _gameWindow = this.Window;
            this.Window.Title = "Coin Flip";  // sets window title
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _font = Content.Load<SpriteFont>("Fonts/Score");

            _miniGames = new List<IMiniGames>() {
                //new RockPaperScissors(this.Content),
                //new DiceRoll(this.Content),
                //new TicTacToe(this.Content),
                //new Concentration(this.Content),
                //new Memory(this.Content),
                //new MathGame(this.Content)
                new TypingTest(this.Content)
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // updates when pressing Right arrow button
            if (MinigameInputManager.OnKeyPress(Keys.Right)) {
                // resets minigame before switching
                if (_miniGame != null) _miniGame.Reset();

                _miniGame = _miniGames[0];    // randomly chooses minigame
            }

            // calls minigame's update function if selected and result isn't determined
            if (_miniGame != null && _miniGame.Result == null) {
                _miniGame.Update(gameTime);
            }

            MinigameInputManager.Update();  // Updates InputManager
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            // only draws after minigame has been chosen
            if (_miniGame != null) {
                _miniGame.Draw(gameTime);
                
                // only draws after player 1 and player 2 has results
                if (_miniGame.P1Result != null && _miniGame.P2Result != null) {
                    _spriteBatch.DrawString(_font, "P1: " + _miniGame.P1Result, new Vector2(8), Color.Black);

                    // draws right aligned string for p2 result
                    _spriteBatch.DrawString(_font, "P2: " + _miniGame.P2Result,
                        new Vector2(StringAlignment.Right("P2: " + _miniGame.P2Result) - 8, 8),
                        Color.Black);
                }

                if (_miniGame.Result != null) {
                    // draws center aligned string for result
                    _spriteBatch.DrawString(_font, _miniGame.Result, 
                        new Vector2(StringAlignment.HorzCenter(_miniGame.Result), StringAlignment.VertCenter(_miniGame.Result)),
                        Color.Black);
                }

                // draws name of minigame on bottom center of screen
                _spriteBatch.DrawString(_font, _miniGame.Message, 
                    new Vector2(StringAlignment.HorzCenter(_miniGame.Message), StringAlignment.Bottom(_miniGame.Message) - 8),
                    Color.Black);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
