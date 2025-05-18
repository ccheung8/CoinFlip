using CoinFlip.Models.TicTacToe;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.TicTacToeStates {
    internal class OPlayerState(TicTacToe ticTacToe) : GameState<TicTacToe> {
        private readonly TicTacToe _ticTacToe = ticTacToe;

        public override void Update(GameTime gameTime) {
            _ticTacToe._activeTurn = _ticTacToe.O;
            TicTacToePiece ticTacToePiece = _ticTacToe.GetClickedPiece();

            if (ticTacToePiece != null) {
                // sets texture to O
                ticTacToePiece._activePiece = _ticTacToe.O;
                // sets Id
                ticTacToePiece.Id = 2;
                // TODO: switch to resolve state to check winner
                _ticTacToe.ChangeState(new ResolveState(_ticTacToe));
            }
        }
    }
}
