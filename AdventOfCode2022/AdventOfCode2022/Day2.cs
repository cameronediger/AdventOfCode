namespace AdventOfCode2022
{
    public class Day2 : BaseDay
    {
        private readonly int _gameMode;
        private int _myTotal = 0;
        public int MyTotalScore { get { return _myTotal; } }

        public Day2(int gameMode = 0)
        {
            _gameMode = gameMode;
        }

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"My Score (mode: {_gameMode}): {MyTotalScore}");
        }

        public override void ProcessData()
        {
            foreach (string round in _inputData)
            {
                var hands = round.Split(' ');
                if (_gameMode == 0)
                    _myTotal += ScoreRound(hands[0], hands[1]);
                else
                {
                    var myPlay = CalculateMyPlay(hands[0], hands[1]);
                    _myTotal += ScoreRound(hands[0], myPlay);
                }
            }
        }

        public int ScoreRound(string opponentPlay, string myPlay)
        {
            int roundScore = 0;

            roundScore += GetShapeScore(myPlay);

            var myResult = DidIWin(opponentPlay, myPlay);
            switch (myResult)
            {
                case RoundResult.Lost:
                    roundScore += 0;
                    break;
                case RoundResult.Draw:
                    roundScore += 3;
                    break;
                case RoundResult.Win:
                    roundScore += 6;
                    break;
            }

            return roundScore;
        }

        public string CalculateMyPlay(string opponentPlay, string expectedResult)
        {
            switch (expectedResult)
            {
                case ExpectedResult.Win:
                    {
                        switch (opponentPlay)
                        {
                            case OpponentPlay.Rock: return MyPlay.Paper;
                            case OpponentPlay.Paper: return MyPlay.Scissors;
                            case OpponentPlay.Scissors: return MyPlay.Rock;
                        };
                    }
                    break;

                case ExpectedResult.Draw:
                    {
                        switch (opponentPlay)
                        {
                            case OpponentPlay.Rock: return MyPlay.Rock;
                            case OpponentPlay.Paper: return MyPlay.Paper;
                            case OpponentPlay.Scissors: return MyPlay.Scissors;
                        };
                    }
                    break;
                case ExpectedResult.Lose:
                    {
                        switch (opponentPlay)
                        {
                            case OpponentPlay.Rock: return MyPlay.Scissors;
                            case OpponentPlay.Paper: return MyPlay.Rock;
                            case OpponentPlay.Scissors: return MyPlay.Paper;
                        };
                    }
                    break;
            }

            return string.Empty;
        }

        private int GetShapeScore(string shape)
        {
            switch (shape)
            {
                case MyPlay.Rock: return 1;
                case MyPlay.Paper: return 2;
                case MyPlay.Scissors: return 3;
            }

            return 0;
        }

        public RoundResult DidIWin(string opponentPlay, string myPlay)
        {
            switch (opponentPlay)
            {
                case OpponentPlay.Rock:
                    {
                        switch (myPlay)
                        {
                            case MyPlay.Rock: return RoundResult.Draw;
                            case MyPlay.Paper: return RoundResult.Win;
                            case MyPlay.Scissors: return RoundResult.Lost;
                        }
                    }
                    break;
                case OpponentPlay.Paper:
                    switch (myPlay)
                    {
                        case MyPlay.Rock: return RoundResult.Lost;
                        case MyPlay.Paper: return RoundResult.Draw;
                        case MyPlay.Scissors: return RoundResult.Win;
                    }
                    break;
                case OpponentPlay.Scissors:
                    switch (myPlay)
                    {
                        case MyPlay.Rock: return RoundResult.Win;
                        case MyPlay.Paper: return RoundResult.Lost;
                        case MyPlay.Scissors: return RoundResult.Draw;
                    }
                    break;
            }

            return RoundResult.Draw;
        }

        public enum RoundResult
        {
            Lost,
            Draw,
            Win
        }

        private static class OpponentPlay
        {
            public const string Rock = "A";
            public const string Paper = "B";
            public const string Scissors = "C";
        }

        private static class MyPlay
        {
            public const string Rock = "X";
            public const string Paper = "Y";
            public const string Scissors = "Z";
        }

        private static class ExpectedResult
        {
            public const string Lose = "X";
            public const string Draw = "Y";
            public const string Win = "Z";
        }
    }
}
