using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForceManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI forceText;
    public static ForceManager instanceForce;
    public float force = 0;

    private void Awake()
    {
        if (instanceForce != null)
        {
            Destroy(this);
        }
        else
        {
            instanceForce = this;
            DontDestroyOnLoad(this);
        }
    }

    public void UpdateForceUI(float force)
    {
        this.force = force;
        forceText.SetText("Force: " + this.force);
    }
}
