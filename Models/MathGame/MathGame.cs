using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using CoinFlip.Statics;
using CoinFlip.States.GameStates;
using CoinFlip.States.GameStates.MathGameStates;
using System.Collections.Generic;

namespace CoinFlip.Models.MathGame {
    internal class MathGame : IMiniGames {
        public string Message { get; }
        public string P1Result { get; set; }
        public string P2Result { get; set; }
        public string Result { get; set; }

        public Queue<MathProblem> MathProblems { get; set; }
        public MathProblem CurrentProblem { get; set; }
        public MathChoice ChosenAnswer { get; set; }

        private GameState<MathGame> _gameState;

        public MathGame(ContentManager content) {
            Message = "Math";
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
            CurrentProblem.Draw(gameTime);
        }

        public void Reset() {
            P1Result = null;
            P2Result = null;
            Result = null;

            MathProblems.Clear();
            // generates 5 more problems
            for (int i = 0; i < 5; i++) {
                MathProblems.Enqueue(new(Game1._random.Next(10), Game1._random.Next(10), Game1._random.Next(2)));
            }

            _gameState = new GetProblemState();
        }

        public MathChoice GetClickedChoice() {
            if (MinigameInputManager.OnMouseRelease) {
                foreach (MathChoice choice in CurrentProblem.Choices) {
                    if (choice.HasBeenChosen) continue;
                    if (choice.SourceRectangle.Contains(MinigameInputManager.MouseX, MinigameInputManager.MouseY))
                        return choice;
                }
            }

            return null;
        }
    }
}
