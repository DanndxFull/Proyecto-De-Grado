using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilesManager : MonoBehaviour
{
    public PlayerProfiles currentProfiles;

    public static ProfilesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void CreateProfiles()
    {
        List<PlayerProfile> profiles = new List<PlayerProfile>();
        for(int i = 0; i < 5; i++)
        {
            PlayerProfile profile = new PlayerProfile("juan",0);
            profiles.Add(profile);
        }
        currentProfiles = new PlayerProfiles(profiles);
        SaveManager.SavePlayerProfile(currentProfiles);
    }

    public void CreateProfile(PlayerProfile profile)
    {
        currentProfiles.AddProfile(profile.name,profile.score);
        SaveManager.SavePlayerProfile(currentProfiles);
    }

    public void LoadProfiles()
    {
        currentProfiles = SaveManager.LoadPlayerProfile();
    }
}
