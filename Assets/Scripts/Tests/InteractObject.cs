using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
    [SerializeField] UnityEvent interactEvent;
    public void Interact()
    {
        Debug.Log("Interact");
        interactEvent.Invoke();
    }
}
