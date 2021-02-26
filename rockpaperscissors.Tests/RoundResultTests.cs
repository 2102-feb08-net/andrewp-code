using System;
using Xunit;

namespace rockpaperscissors.Tests
{
    public class RoundResultTests
    {
        // three reasons "this file can't talk to that file"
        // 1. access level
        // 2. project reference
        // 3. namespace (using directive)

        [Fact]
        public void IdenticalMovesShouldResultInADraw()
        {
            // arrange
            var paperDraw = new RoundResult(Move.Paper, Move.Paper);
            var rockDraw = new RoundResult(Move.Rock, Move.Rock);
            var scissorsDraw = new RoundResult(Move.Scissors, Move.Scissors);

            // act

            // assert
            Assert.True(Result.Draw == paperDraw.Result);
            Assert.True(Result.Draw == rockDraw.Result);
            Assert.True(Result.Draw == scissorsDraw.Result);
        }

        [Theory]
        [InlineData(Move.Paper, Move.Rock)]
        [InlineData(Move.Rock, Move.Scissors)]
        [InlineData(Move.Scissors, Move.Paper)]
        public void WinningMovesShouldResultInAWin(Move playerMove, Move compMove)
        {
            var round = new RoundResult(playerMove, compMove);

            Assert.True(Result.Win == round.Result);
        }

        [Theory]
        [InlineData(Move.Rock, Move.Paper)]
        [InlineData(Move.Scissors, Move.Rock)]
        [InlineData(Move.Paper, Move.Scissors)]
        public void LosingMovesShouldResultInALoss(Move playerMove, Move compMove)
        {
            var round = new RoundResult(playerMove, compMove);

            Assert.True(Result.Lose == round.Result);
        }
    }
}
