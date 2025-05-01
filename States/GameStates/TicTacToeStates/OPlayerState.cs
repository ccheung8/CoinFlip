using CoinFlip.Models.TicTacToe;
using Microsoft.Xna.Framework;

namespace CoinFlip.States.GameStates.TicTacToeStates {
    internal class OPlayerState : GameState<TicTacToe> {
        public override void Update(GameTime gameTime, TicTacToe ticTacToe) {
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
