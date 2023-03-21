using System.Collections.Generic;

namespace PinBallRunner.Prototyping.Scripts.Data
{
    public interface IPlayerData
    {
        public uint MaxDistance { get; }
        public uint HighScore { get; }
        public uint GamesPlayed { get; }
        public uint SummaryDistanceRolling { get; }

        public IReadOnlyList<string> SkinsOpened { get; }
        public IReadOnlyList<string> ReachedAchiventsList { get; }
    }
}
