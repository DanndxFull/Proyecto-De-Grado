using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Vehicle : MonoBehaviour
{
    [SerializeField] float exactWeight, currentlyWeight;

    [SerializeField] UnityEvent WinEvent;
    [SerializeField] Vector3 endPosition;
    [SerializeField] float timeToMove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            other.transform.parent = transform;
            currentlyWeight++;
            CheckWeigth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            other.transform.parent = null;
            currentlyWeight--;
        }        
    }


    public void CheckWeigth()
    {
        if (currentlyWeight >= exactWeight)
        {
            transform.DOMove(endPosition, timeToMove).OnComplete(()=>WinEvent.Invoke());

            Debug.Log("Me muevo");
        }
    }
}
