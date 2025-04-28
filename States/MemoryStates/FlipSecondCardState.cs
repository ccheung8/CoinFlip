using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlip.States.MemoryStates {
    internal class FlipSecondCardState : GameState<Memory> {
        public override void Update(Memory memory) {
            Card card = memory.GetClickedCard();

            if (card != null && card != memory.firstCardChosen) {
                card.Flip();
                memory.secondCardChosen = card;
                memory.ChangeState(new ResolveTurnState());
            }
        }
    }
}
