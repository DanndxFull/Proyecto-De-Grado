using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIProfileController : MonoBehaviour
{
    [SerializeField] TMP_InputField newNameProfile;
    [SerializeField] TMP_Dropdown profileDropdown;

    public void ChangeNameProfile()
    {
        PlayerProfile player = SaveManager.LoadPlayerProfile(profileDropdown.value + 1);
        SaveManager.SavePlayerProfile(newNameProfile.text, player.score, profileDropdown.value + 1);
    }

    public void ResetScore(int index)
    {
        PlayerProfile player = SaveManager.LoadPlayerProfile(index);
        SaveManager.SavePlayerProfile(player.name, 0, index);
    }

}
