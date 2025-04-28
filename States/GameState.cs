using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlip.States {
    public abstract class GameState<T> {
        public abstract void Update(T minigame);
    }
}
