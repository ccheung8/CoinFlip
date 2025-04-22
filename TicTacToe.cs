using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinFlip {
    internal class TicTacToe : IMiniGames {
        private static Random random;
        public string p1Result { get; set; }
        public string p2Result { get; set; }
        public string Result { get; set; }

        int[] Board;    // stores state of game. 1 = X, 2 = O

        private Texture2D rectangle;    // rectangle texture to draw
        private int rectDimension;      // dimension of horizontal width and vertical height for square shape
        private int rectY;              // determines Y position where board starts (centered on screen)
        private int rectX;              // determines X position where board starts (centered on screen)
        private int lineThickness;      // determines thickness of lines for board

        public TicTacToe() {
            random = new Random();
            Board = new int[9];

            rectangle = new Texture2D(Game1._graphics.GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.Black });

            // dimension of tic tac toe board takes up around 1/4 of window height
            rectDimension = (int)(Game1._graphics.GraphicsDevice.Viewport.Height / 1.25f);
            // determines placement of y axis for vertical stripes
            rectY = (int)((Game1._graphics.GraphicsDevice.Viewport.Height - rectDimension) / 2) - 16;
            // determiens placement of x axis for horizontal stripes
            rectX = (int)((Game1._graphics.GraphicsDevice.Viewport.Width - rectDimension) / 2);
            lineThickness = 20;
        }

        public void Update() {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font) {
            string message = "Tic Tac Toe";
            int center = StringAlignment.HorzCenter(font, message);
            int bottom = StringAlignment.Bottom(font, message);

            spriteBatch.DrawString(font, message, new Vector2(center, bottom - 8), Color.Black);

            if ((Mouse.GetState().X >= rectX && Mouse.GetState().X <= rectX + rectDimension) &&
                        (Mouse.GetState().Y >= rectY && Mouse.GetState().Y <= rectY + rectDimension)) {
                spriteBatch.DrawString(font, "Hovering over board", new Vector2(24), Color.Black);
            }

            DrawBoard(spriteBatch);
        }

        private void DrawBoard(SpriteBatch spriteBatch) {
            // calculates offset to place stripes
            int axisOffset = (int)((rectDimension - (2 * lineThickness)) / 3);

            // DRAWS BOARD
            // draws first vertical stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX + axisOffset,     // places first stripe at 1/3 of width
                    rectY,
                    lineThickness,
                    rectDimension           // rectDimension for height ensures square shape
                ),
                Color.Black
            );
            // draws second vertical stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX + (2 * axisOffset) + lineThickness,    // place second stripe at 2/3 of width accounting for width of first stripe
                    rectY,
                    lineThickness,
                    rectDimension           // rectDimension for height ensures square shape
                ),
                Color.Black
            );
            // draws top horizontal stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX,
                    rectY + axisOffset,    // places first stripe at 1/3 of height
                    rectDimension,         // rectDimension for width ensures square shape
                    lineThickness
                ),
                Color.Black
            );
            // draws second horizontal stripe
            spriteBatch.Draw(
                rectangle,
                new Rectangle(
                    rectX,
                    rectY + (2 * axisOffset) + lineThickness,      // place second stripe at 2/3 of width accounting for width of first stripe
                    rectDimension,         // rectDimension for width ensures square shape
                    lineThickness
                ),
                Color.Black
            );
        }

        public void Reset() {
            p1Result = null;
            p2Result = null;
            Result = null;
            Board = new int[9];
        }
    }
}
