using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlip.States.MemoryStates {
    internal class ResolveTurnState : GameState<Memory> {
        public override void Update(Memory memory) {
            if (memory.firstCardChosen.Id == memory.secondCardChosen.Id) {
                // sets solved to true if there's a match
                memory.firstCardChosen.Solved = memory.secondCardChosen.Solved = true;
            }

            memory.ChangeState(new FlipFirstCardState());
        }
    }
}
