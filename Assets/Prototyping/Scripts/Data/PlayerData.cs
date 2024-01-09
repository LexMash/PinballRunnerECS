using System;
using System.Collections.Generic;

namespace PinBallRunner
{
    [Serializable]
    public class PlayerData
    {
        public uint MaxDistance;
        public uint HighScore;
        public uint GamesPlayed;
        public uint SummaryDistanceRolling;
        public string CurrentSkinID;
        public List<string> SkinsOpened;
        public List<string> ReachedAchiventsList;     
    }
}
