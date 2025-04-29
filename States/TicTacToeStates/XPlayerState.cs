using CoinFlip.Models.TicTacToe;

namespace CoinFlip.States.TicTacToeStates {
    internal class XPlayerState : GameState<TicTacToe> {
        public override void Update(TicTacToe ticTactoe) {
            ticTactoe._activeTurn = ticTactoe.X;
            TicTacToePiece ticTacToePiece = ticTactoe.GetClickedPiece();

            if (ticTacToePiece != null) {
                // sets texture to draw for tictactoepiece
                ticTacToePiece._activePiece = ticTactoe.X;
                // sets Id 
                ticTacToePiece.Id = 1;
                // changes state to O Player
                ticTactoe.ChangeState(new ResolveState());
            }
        }
    }
}
