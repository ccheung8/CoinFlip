using CoinFlip.Models.TicTacToe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.States.GameStates.TicTacToeStates {
    internal class ResolveState : GameState<TicTacToe> {
        public override void Update(GameTime gameTime, TicTacToe ticTacToe) {
            Texture2D winner = null;
            for (int i = 0; i < TicTacToe.BOARD_DIM; i++) {
                if (ticTacToe.Board[i, 0].Id != 0 && ticTacToe.Board[i, 1].Id != 0 && ticTacToe.Board[i, 2].Id != 0 ||
                        ticTacToe.Board[0, i].Id != 0 && ticTacToe.Board[1, i].Id != 0 && ticTacToe.Board[2, i].Id != 0) {
                    // wins by horizontal matching
                    if (ticTacToe.Board[i, 0].Id == ticTacToe.Board[i, 1].Id && ticTacToe.Board[i, 1].Id == ticTacToe.Board[i, 2].Id) {
                        winner = ticTacToe.Board[i, 0]._activePiece;
                        break;
                    }
                    // wins by vertical matching;
                    else if (ticTacToe.Board[0, i].Id == ticTacToe.Board[1, i].Id && ticTacToe.Board[1, i].Id == ticTacToe.Board[2, i].Id) {
                        winner = ticTacToe.Board[0, i]._activePiece;
                        break;
                    }
                }
            }

            // wins by back or forward slash
            if (ticTacToe.Board[1, 1].Id != 0) {
                // forward slash
                if (ticTacToe.Board[0, 0].Id == ticTacToe.Board[1, 1].Id && ticTacToe.Board[1, 1].Id == ticTacToe.Board[2, 2].Id) {
                    winner = ticTacToe.Board[1, 1]._activePiece;
                }
                // backwards slash
                if (ticTacToe.Board[2, 0].Id == ticTacToe.Board[1, 1].Id && ticTacToe.Board[1, 1].Id == ticTacToe.Board[0, 2].Id) {
                    winner = ticTacToe.Board[1, 1]._activePiece;
                }
            }

            if (winner != null) {
                ticTacToe.P1Result = winner == ticTacToe.X ? "Player 1 (X) Wins!" : "Player 1 (X) Loses!";
                ticTacToe.P2Result = winner == ticTacToe.X ? "Player 2 (O) Loses!" : "Player 2 (O) Wins!";
                ticTacToe.Result = winner == ticTacToe.X ? "Player 1 Wins!" : "Player 2 Wins!";
                return;
            }

            // TODO CHECK FOR TIE
            int zeroCounter = 0;
            foreach (TicTacToePiece ticTacToePiece in ticTacToe.Board) {
                if (ticTacToePiece.Id == 0) {
                    zeroCounter++;
                }
            }

            if (zeroCounter == 0) {
                ticTacToe.P1Result = "Tie!";
                ticTacToe.P2Result = "Tie!";
                ticTacToe.Result = "Tie!";
                return;
            }

            if (ticTacToe._activeTurn == ticTacToe.X) ticTacToe.ChangeState(new OPlayerState());
            else ticTacToe.ChangeState(new XPlayerState());
        }
    }
}
