using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileSelector : MonoBehaviour
{
    [SerializeField] TMP_InputField nameProfile, nameStage;
    [SerializeField] SimpleSceneCharger sceneCharger;

    public void SetCurrentProfile()
    {
        if (nameProfile.text == null || nameProfile.text == "" || nameStage.text == null || nameStage.text == "")
            return;
        string name = nameProfile.text;
        Debug.Log(name);
        if (ProfilesManager.instance.currentProfiles.GetProfile(name) == null)
        {
            Debug.Log(ProfilesManager.instance.currentProfiles.GetProfile(name));
            return;
        }
        if (EscenarioManager.instance.LoadStage(nameStage.text) == null)
            return;

        CurrentProfile.instanceProfile.SetCurrentProfile(ProfilesManager.instance.currentProfiles.GetProfile(name));
        CurrentEscenario.instanceEscenario.SetCurrentEscenario(EscenarioManager.instance.LoadStage(nameStage.text));
        nameProfile.text = "";
        nameStage.text = "";
        sceneCharger.ChargeScene("Prototype1");
    }
}
