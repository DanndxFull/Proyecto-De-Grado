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
            Weight weight = other.GetComponent<Weight>();
            currentlyWeight += weight.weight;
            CheckWeigth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            other.transform.parent = null;
            Weight weight = other.GetComponent<Weight>();
            currentlyWeight -= weight.weight;        
        }        
    }


    public void CheckWeigth()
    {
        if (currentlyWeight == exactWeight)
        {
            transform.DOMove(new Vector3(transform.position.x + -40, transform.position.y, transform.position.z), timeToMove).OnComplete(()=>WinEvent.Invoke());

            Debug.Log("Me muevo");
        }
    }
}
