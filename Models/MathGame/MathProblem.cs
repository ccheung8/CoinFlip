using System;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;

namespace CoinFlip.Models.MathGame {
    internal class MathProblem {
        public int FirstInt { get; set; }
        public int SecondInt { get; set; }
        public int AddOrSubtract { get; set; }  // 0 - add, 1 - subtract
        public int Answer { get; set; }
        public MathChoice[] Choices { get; } = new MathChoice[4];

        public MathProblem(int firstInt, int secondInt, int addOrSubtract) {
            FirstInt = firstInt;
            SecondInt = secondInt;
            AddOrSubtract = addOrSubtract;
            Answer = addOrSubtract == 0 ? firstInt + secondInt : firstInt - secondInt;

            // stores correct answer
            Choices[0] = new MathChoice(Answer, 0);

            // randomly assigns values
            int[] randomValues = new int[4];
            randomValues[0] = Answer;
            for (int i = 1; i < randomValues.Length; i++) {
                int randomValue;
                if (Game1._random.Next(2) == 0) {
                    randomValue = Answer + Game1._random.Next(1, 3);
                    while (Array.Exists(randomValues, value => value == randomValue)) {
                        randomValue += Game1._random.Next(1, 3);
                    }
                }
                else {
                    randomValue = Answer - Game1._random.Next(1, 3);
                    while (Array.Exists(randomValues, value => value == randomValue)) {
                        randomValue -= Game1._random.Next(1, 3);
                    }
                }
                randomValues[i] = randomValue;
            }

            // initializes all choices
            for (int i = 1; i < Choices.Length; i++) {
                Choices[i] = new MathChoice(randomValues[i], i);
            }

            Shuffle();
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

        // shuffle choices using fisher-yates
        public void Shuffle() {
            for (int i = Choices.Length - 1; i > 0; i--) {
                int j = Game1._random.Next(i + 1);
                (Choices[j].Position, Choices[i].Position) = (Choices[i].Position, Choices[j].Position);
            }
        }

    }
}
