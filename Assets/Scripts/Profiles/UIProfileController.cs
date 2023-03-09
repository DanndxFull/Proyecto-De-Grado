using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIProfileController : MonoBehaviour
{
    [Header("Create")]
    [SerializeField] TMP_InputField newNameProfile;

    [Header("Update")]
    [SerializeField] TMP_InputField nameProfileToUpdate;
    [SerializeField] TMP_InputField newNameProfileToUpdate;

    [Header("Delete")]
    [SerializeField] TMP_InputField nameProfileToDelete;


    public void CreateProfile()
    {
        PlayerProfile profile = new PlayerProfile(newNameProfile.text,0);
        ProfilesManager.instance.CreateProfile(profile);
        newNameProfile.text = "";
    }

    public void UpdateProfile()
    {
        if (nameProfileToUpdate.text == null || nameProfileToUpdate.text == "" || newNameProfileToUpdate.text == null || newNameProfileToUpdate.text == "")
            return;

        Debug.Log("Nombre cambiado");
        PlayerProfiles profiles = ProfilesManager.instance.currentProfiles;
        foreach (PlayerProfile p in profiles.GetProfiles())
        {
            if(p.name == nameProfileToUpdate.text)
            {
                p.name = newNameProfileToUpdate.text;
            }
        }
        nameProfileToUpdate.text = "";
        newNameProfileToUpdate.text = "";
        SaveManager.SavePlayerProfile(profiles);
    }

    public void DeleteProfile()
    {
        if (nameProfileToDelete.text == null || nameProfileToDelete.text == "")
            return;

        PlayerProfiles profiles = ProfilesManager.instance.currentProfiles;
        foreach (PlayerProfile p in profiles.profiles)
        {
            if (p.name == nameProfileToDelete.text)
            {
                //profiles = profiles.DeleteProfile(p.name);
                //profiles.profiles.Remove(p);
                Debug.Log("Eliminaro");
                List<PlayerProfile> newProfiles = new List<PlayerProfile>();
                foreach (PlayerProfile pl in profiles.profiles)
                {
                    if (pl.name != p.name)
                    {
                        newProfiles.Add(pl);
                    }
                }
                profiles.profiles = newProfiles;
            }
        }
        nameProfileToDelete.text = "";
        SaveManager.SavePlayerProfile(profiles);
    }
}
