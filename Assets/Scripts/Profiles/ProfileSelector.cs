using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileSelector : MonoBehaviour
{
    [SerializeField] TMP_InputField nameProfile;
    [SerializeField] SimpleSceneCharger sceneCharger;

    public void SetCurrentProfile()
    {
        if (nameProfile.text == null || nameProfile.text == "")
            return;
        string name = nameProfile.text;
        Debug.Log(name);
        if (ProfilesManager.instance.currentProfiles.GetProfile(name) == null)
        {
            Debug.Log(ProfilesManager.instance.currentProfiles.GetProfile(name));
            nameProfile.text = "";
            return;
        }
        CurrentProfile.instanceProfile.SetCurrentProfile(ProfilesManager.instance.currentProfiles.GetProfile(name));
        sceneCharger.ChargeScene("Prototype1");
    }
}
