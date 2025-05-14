using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinFlip.Models.MathGame;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.MathGameStates {
    internal class GetProblemState : GameState<MathGame> {
        public override void Update(GameTime gameTime, MathGame mathGame) {
            mathGame.CurrentProblem = mathGame.MathProblems.Dequeue();
            mathGame.ChangeState(new AnswerState());
        }
    }
}
