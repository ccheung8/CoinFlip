using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.MathGameStates;
using System.Collections.Generic;

namespace CoinFlip.Models.MathGame {
    internal class MathGame : IMiniGames {
        public string P1Result { get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public Queue<MathProblem> MathProblems { get; set; }
        public MathProblem CurrentProblem { get; set; }
        public MathChoice ChosenAnswer { get; set; }

        private GameState<MathGame> _gameState;

        public MathGame(ContentManager content) {
            _gameState = new GetProblemState();

            // initializes 5 problems
            MathProblems = new();
            for (int i = 0; i < 5; i++) {
                MathProblems.Enqueue(new(Game1._random.Next(10), Game1._random.Next(10), Game1._random.Next(2)));
            }
        }

        public void ChangeState(GameState<MathGame> gameState) {
            _gameState = gameState;
        }

        public void Update(GameTime gameTime) {
            _gameState.Update(gameTime, this);
        }

        public void Draw(GameTime gameTime) {
            string message = "Math";
            int center = StringAlignment.HorzCenter(message);
            int bottom = StringAlignment.Bottom(message);

            Game1._spriteBatch.DrawString(Game1._font, message, new Vector2(center, bottom - 8), Color.Black);

            CurrentProblem.Draw(gameTime);
        }

        public void Reset() {
            MathProblems.Clear();
            // generates 5 more problems
            for (int i = 0; i < 5; i++) {
                MathProblems.Enqueue(new(Game1._random.Next(10), Game1._random.Next(10), Game1._random.Next(2)));
            }
            _gameState = new GetProblemState();
            CurrentProblem = null;
        }

        public MathChoice GetClickedChoice() {
            if (MinigameInputManager.OnMouseRelease) {
                foreach (MathChoice choice in CurrentProblem.Choices) {
                    if (choice.SourceRectangle.Contains(MinigameInputManager.MouseX, MinigameInputManager.MouseY)) 
                        return choice;
                }
            }

            return null;
        }
    }
}
