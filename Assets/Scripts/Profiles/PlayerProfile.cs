[System.Serializable]
public class PlayerProfile
{
    public string name;
    public int score;

    public PlayerProfile(string name, int score)
    {
        if (name != "")
        {
            this.name = name;
        }
        else
        {
            this.name = "Juan";
        }
        if (score != 0)
        {
            this.score = score;
        }
        else
        {
            this.score = 0;
        }
    }

    public PlayerProfile(PlayerProfile player)
    {
        this.name = player.name;
        this.score = player.score;
    }
}
