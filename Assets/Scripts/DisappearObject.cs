using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToDisappear;

    public void Disappear()
    {
        objectToDisappear.SetActive(false);
    }
}
