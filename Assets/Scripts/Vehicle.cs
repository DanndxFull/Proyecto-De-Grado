using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vehicle : MonoBehaviour
{
    [SerializeField] float exactWeight, currentlyWeight;

    [SerializeField] UnityEvent WinEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            currentlyWeight++;
            CheckWeigth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            currentlyWeight--;
        }        
    }


    public void CheckWeigth()
    {
        if (currentlyWeight >= exactWeight)
        {
            WinEvent.Invoke();
            Debug.Log("Me muevo");
        }
    }
}
