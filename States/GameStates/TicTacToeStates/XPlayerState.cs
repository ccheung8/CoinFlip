using CoinFlip.Models.TicTacToe;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.TicTacToeStates {
    internal class XPlayerState(TicTacToe ticTacToe) : GameState<TicTacToe> {
        private readonly TicTacToe _ticTacToe = ticTacToe;

        public override void Update(GameTime gameTime) {
            _ticTacToe._activeTurn = _ticTacToe.X;
            TicTacToePiece ticTacToePiece = _ticTacToe.GetClickedPiece();

            if (ticTacToePiece != null) {
                // sets texture to draw for tictactoepiece
                ticTacToePiece._activePiece = _ticTacToe.X;
                // sets Id 
                ticTacToePiece.Id = 1;
                // changes state to O Player
                _ticTacToe.ChangeState(new ResolveState(_ticTacToe));
            }
        }
    }
}
