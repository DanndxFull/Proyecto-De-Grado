using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TouchEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent touchEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            touchEvent.Invoke();
        }        
    }
}
