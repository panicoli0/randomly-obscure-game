using CardMatchingGame.Model.DataPersistance.SerializableDictionary;
using CardMatchingGame.UI.View;
using System.Collections.Generic;

namespace CardMatchingGame.Model.DataPersistance.Data
{
    [System.Serializable]
    public class GameData
    {
        public long lastUpdated;
        public int movesCount;
        public int movesRule;
        public List<CardView> gridStatus;
        public int winLevelCont;
        public int score;
        public SerializableDictionary<string, bool> cardsStatus;

        // the values defined in this constructor will be the default values
        // the game starts with when there's no data to load
        public GameData()
        {
            movesCount = 0;
            movesRule = 0;
            gridStatus = new List<CardView>();
            winLevelCont = 0;
            score = 0;
            cardsStatus = new SerializableDictionary<string, bool>();
        }
    }
}
