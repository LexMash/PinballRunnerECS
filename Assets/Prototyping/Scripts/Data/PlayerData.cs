using PinBallRunner.Prototyping.Scripts.Data;
using System;
using System.Collections.Generic;

namespace PinBallRunner
{
    [Serializable]
    public class PlayerData : IPlayerData
    {
        uint IPlayerData.MaxDistance => MaxDistance;
        uint IPlayerData.HighScore => HighScore;
        uint IPlayerData.GamesPlayed => GamesPlayed;
        uint IPlayerData.SummaryDistanceRolling => SummaryDistanceRolling;
        IReadOnlyList<string> IPlayerData.SkinsOpened => SkinsOpened;
        IReadOnlyList<string> IPlayerData.ReachedAchiventsList => ReachedAchiventsList;

        public uint MaxDistance;
        public uint HighScore;
        public uint GamesPlayed;
        public uint SummaryDistanceRolling;

        public List<string> SkinsOpened;
        public List<string> ReachedAchiventsList;

        public PlayerData(uint maxDistance, uint highScore, uint gamesPlayed, uint summaryDistanceRolling, List<string> skinsOpened, List<string> reachedAchiventsList)
        {
            MaxDistance = maxDistance;
            HighScore = highScore;
            GamesPlayed = gamesPlayed;
            SummaryDistanceRolling = summaryDistanceRolling;
            SkinsOpened = skinsOpened;
            ReachedAchiventsList = reachedAchiventsList;
        }       
    }
}
