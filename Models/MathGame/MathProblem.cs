using System.Linq;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.Models.MathGame {
    internal class MathProblem {
        public int FirstInt { get; set; }
        public int SecondInt { get; set; }
        public int AddOrSubtract { get; set; }  // 0 - add, 1 - subtract
        public int Answer { get; set; }
        public MathChoice[] Choices { get; set; }

        public MathProblem(int firstInt, int secondInt, int addOrSubtract) {
            FirstInt = firstInt;
            SecondInt = secondInt;
            AddOrSubtract = addOrSubtract;
            Answer = addOrSubtract == 0 ? firstInt + secondInt : firstInt - secondInt;

            Choices = new MathChoice[4];
            // randomly assigns choices
            for (int i = 0; i < Choices.Length; i++) {
                Choices[i] = new MathChoice(Answer, i);
            }
            //Choices = Choices.OrderBy(choice => choice.Index).ToArray();
        }

        public void Draw(GameTime gameTime) {
            string problem = FirstInt + (AddOrSubtract == 0 ? " + " : " - ") + SecondInt;
            int centerX = StringAlignment.HorzCenter(problem);
            int centerY = StringAlignment.VertCenter(problem);

            Game1._spriteBatch.DrawString(Game1._font, problem, new Vector2(centerX, centerY), Color.Black);

            foreach (MathChoice choice in Choices) {
                choice.Draw(gameTime);
            }
        }
    }
}
