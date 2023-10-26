using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int turnCount;
    public List<CardView> gridStatus;
    public int winLevelCont;
    public int score;
    public SerializableDictionary<string, bool> cardsStatus;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        turnCount = 0;
        gridStatus = new List<CardView>();
        winLevelCont = 0;
        score = 0;
        cardsStatus = new SerializableDictionary<string, bool>();
    }
}
