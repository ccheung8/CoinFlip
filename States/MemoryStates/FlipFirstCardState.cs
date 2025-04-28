using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlip.States.MemoryStates {
    internal class FlipFirstCardState : GameState<Memory> {
        public override void Update(Memory memory) {
            Card card = memory.GetClickedCard();

            if (card != null) {
                if (memory.firstCardChosen != null && memory.secondCardChosen != null
                        && !memory.firstCardChosen.Solved && !memory.firstCardChosen.Solved) {
                    memory.firstCardChosen.Flip();
                    memory.secondCardChosen.Flip();
                }
                card.Flip();
                memory.firstCardChosen = card;
                memory.ChangeState(new FlipSecondCardState());
            }
        }
    }
}
