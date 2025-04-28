namespace CoinFlip.States {
    public abstract class GameState<T> {
        public abstract void Update(T minigame);
    }
}
