using CoinFlip.Models.TicTacToe;

namespace CoinFlip.States.TicTacToeStates {
    internal class OPlayerState : GameState<TicTacToe> {
        public override void Update(TicTacToe ticTacToe) {
            ticTacToe._activeTurn = ticTacToe.O;
            TicTacToePiece ticTacToePiece = ticTacToe.GetClickedPiece();

            if (ticTacToePiece != null) {
                // sets texture to O
                ticTacToePiece._activePiece = ticTacToe.O;
                // sets Id
                ticTacToePiece.Id = 2;
                // TODO: switch to resolve state to check winner
                ticTacToe.ChangeState(new ResolveState());
            }
        }
    }
}
