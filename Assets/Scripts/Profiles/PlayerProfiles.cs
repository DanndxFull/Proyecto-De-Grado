using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfiles
{
    public List<PlayerProfile> profiles;


    public PlayerProfiles(List<PlayerProfile> profiles)
    {
        this.profiles = profiles;
    }

    public void AddProfile(string name, int score)
    {
        PlayerProfile profile = new PlayerProfile(name,score);
        profiles.Add(profile);
    }

    public PlayerProfile GetProfile(string name)
    {
        foreach (PlayerProfile p in profiles)
        {
            if(p.name == name)
            {
                return p;
            }
        }
        return null;
    }
    public List<PlayerProfile> GetProfiles()
    {
        return profiles;
    }

    public void UpdateProfile(string name, string newName, int score)
    {
        foreach (PlayerProfile p in profiles)
        {
            if (p.name == name)
            {
                p.name = newName;
                p.score = score;
            }
        }
    }
    
    public void UpdateProfile(string name, int score)
    {
        foreach (PlayerProfile p in profiles)
        {
            if (p.name == name)
            {
                p.score = score;                                
            }
        }
    }

    public PlayerProfiles DeleteProfile(string name)
    {
        foreach (PlayerProfile p in profiles)
        {
            if (p.name == name)
            {
                profiles.Remove(p);
                return this;
            }
        }
        return null;
    }
}
