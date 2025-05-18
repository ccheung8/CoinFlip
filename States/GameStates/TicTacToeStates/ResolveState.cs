using CoinFlip.Models.TicTacToe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinFlip.States.GameStates.TicTacToeStates {
    internal class ResolveState(TicTacToe ticTacToe) : GameState<TicTacToe> {
        private readonly TicTacToe _ticTacToe = ticTacToe;

        public override void Update(GameTime gameTime) {
            Texture2D winner = null;
            for (int i = 0; i < TicTacToe.BOARD_DIM; i++) {
                if (_ticTacToe.Board[i, 0].Id != 0 && _ticTacToe.Board[i, 1].Id != 0 && _ticTacToe.Board[i, 2].Id != 0 ||
                        _ticTacToe.Board[0, i].Id != 0 && _ticTacToe.Board[1, i].Id != 0 && _ticTacToe.Board[2, i].Id != 0) {
                    // wins by horizontal matching
                    if (_ticTacToe.Board[i, 0].Id == _ticTacToe.Board[i, 1].Id && _ticTacToe.Board[i, 1].Id == _ticTacToe.Board[i, 2].Id) {
                        winner = _ticTacToe.Board[i, 0]._activePiece;
                        break;
                    }
                    // wins by vertical matching;
                    else if (_ticTacToe.Board[0, i].Id == _ticTacToe.Board[1, i].Id && _ticTacToe.Board[1, i].Id == _ticTacToe.Board[2, i].Id) {
                        winner = _ticTacToe.Board[0, i]._activePiece;
                        break;
                    }
                }
            }

            // wins by back or forward slash
            if (_ticTacToe.Board[1, 1].Id != 0) {
                // forward slash
                if (_ticTacToe.Board[0, 0].Id == _ticTacToe.Board[1, 1].Id && _ticTacToe.Board[1, 1].Id == _ticTacToe.Board[2, 2].Id) {
                    winner = _ticTacToe.Board[1, 1]._activePiece;
                }
                // backwards slash
                if (_ticTacToe.Board[2, 0].Id == _ticTacToe.Board[1, 1].Id && _ticTacToe.Board[1, 1].Id == _ticTacToe.Board[0, 2].Id) {
                    winner = _ticTacToe.Board[1, 1]._activePiece;
                }
            }

            if (winner != null) {
                _ticTacToe.P1Result = winner == _ticTacToe.X ? "Player 1 (X) Wins!" : "Player 1 (X) Loses!";
                _ticTacToe.P2Result = winner == _ticTacToe.X ? "Player 2 (O) Loses!" : "Player 2 (O) Wins!";
                _ticTacToe.Result = winner == _ticTacToe.X ? "Player 1 Wins!" : "Player 2 Wins!";
                return;
            }

            // TODO CHECK FOR TIE
            int zeroCounter = 0;
            foreach (TicTacToePiece ticTacToePiece in _ticTacToe.Board) {
                if (ticTacToePiece.Id == 0) {
                    zeroCounter++;
                }
            }

            if (zeroCounter == 0) {
                _ticTacToe.P1Result = "Tie!";
                _ticTacToe.P2Result = "Tie!";
                _ticTacToe.Result = "Tie!";
                return;
            }

            if (_ticTacToe._activeTurn == _ticTacToe.X) _ticTacToe.ChangeState(new OPlayerState(_ticTacToe));
            else _ticTacToe.ChangeState(new XPlayerState(_ticTacToe));
        }
    }
}
