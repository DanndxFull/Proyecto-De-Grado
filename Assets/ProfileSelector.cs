using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSelector : MonoBehaviour
{
    public void SetCurrentProfile(int i)
    {
        CurrentProfile.instanceProfile.SetCurrentProfile(i);
    }
}
