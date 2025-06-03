using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CoinFlip.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.Models.TypingTest {
    internal class TypingPrompt {
        public StringBuilder TypedText { get; set; }
        public string TypedString { get; set; } = "";
        public StringBuilder TypedWord { get; set; }

        public Color WordColor { get; set; }
        public Vector2 DrawLocation { get; }
        public Vector2 WordDrawLocation { get; set; }

        public TypingPrompt(Vector2 drawLocation) {
            TypedText = new StringBuilder();
            TypedWord = new StringBuilder();
            WordColor = Color.Black;
        }
    }
}
