using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentProfile : MonoBehaviour
{
    public static CurrentProfile instanceProfile;

    public PlayerProfile playerProfile;
    public int index;

    private void Awake()
    {
        if (instanceProfile != null)
        {
            Destroy(this);
        }
        else
        {
            instanceProfile = this;
            DontDestroyOnLoad(this);
        }
    }


    public void SetCurrentProfile(PlayerProfile player)
    {
        this.playerProfile = player;
    }
}
