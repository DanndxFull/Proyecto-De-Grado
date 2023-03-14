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
        DontDestroyOnLoad(this);
        LoadProfiles();
    }

    public void CreateProfiles()
    {
        List<PlayerProfile> profiles = new List<PlayerProfile>();
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
        if (currentProfiles == null)
        {
            CreateProfiles();
        }
    }

    public void UpdateProfile(string name, int score)
    {
        currentProfiles.UpdateProfile(name, score);
        SaveManager.SavePlayerProfile(currentProfiles);
    }
}
